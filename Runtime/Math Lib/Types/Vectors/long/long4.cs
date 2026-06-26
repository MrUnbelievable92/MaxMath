using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class long4DebuggerProxy
    {
	    public long x;
	    public long y;
	    public long z;
	    public long w;
        
	    public long4DebuggerProxy(long4 v)
	    {
	    	x = v.x;
	    	y = v.y;
	    	z = v.z;
	    	w = v.w;
	    }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(long4DebuggerProxy))]
#endif
    [Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct long4 : IEquatable<long4>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal long2 __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal long2 __x2;
		
        public ref long x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(long4* ptr = &this) { return ref *((long*)ptr + 0); } } }
        public ref long y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(long4* ptr = &this) { return ref *((long*)ptr + 1); } } }
        public ref long z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(long4* ptr = &this) { return ref *((long*)ptr + 2); } } }
        public ref long w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(long4* ptr = &this) { return ref *((long*)ptr + 3); } } }


        public static long4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long y, long z, long w)
        {
			this = (long4)new ulong4((ulong)x, (ulong)y, (ulong)z, (ulong)w);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long xyzw)
        {
			this = (long4)new ulong4((ulong)xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long2 xy, long z, long w)
        {
			this = (long4)new ulong4((ulong2)xy, (ulong)z, (ulong)w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long2 yz, long w)
        {
			this = (long4)new ulong4((ulong)x, (ulong2)yz, (ulong)w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long y, long2 zw)
        {
			this = (long4)new ulong4((ulong)x, (ulong)y, (ulong2)zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long2 xy, long2 zw)
        {
			this = (long4)new ulong4((ulong2)xy, (ulong2)zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long3 xyz, long w)
        {
			this = (long4)new ulong4((ulong3)xyz, (ulong)w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long3 yzw)
        {
			this = (long4)new ulong4((ulong)x, (ulong3)yzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(bool v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(bool4 v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(mask8x4 v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(mask16x4 v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(mask32x4 v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(mask64x4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(byte v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(byte4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(sbyte v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(sbyte4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(ushort v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(ushort4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(short v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(short4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(uint v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(uint4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(int v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(int4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(ulong v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(ulong4 v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(UInt128 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(Int128 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(quarter v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(quarter4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(half v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(half4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(float v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(float4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(double v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(double4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(quadruple v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(Unity.Mathematics.bool4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(Unity.Mathematics.uint4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(Unity.Mathematics.int4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(Unity.Mathematics.half v)
        {
            this = (long4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(Unity.Mathematics.half4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(Unity.Mathematics.float4 v)
        {
            this = (long4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(Unity.Mathematics.double4 v)
        {
            this = (long4)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxxx => (long4)((ulong4)this).xxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxxy => (long4)((ulong4)this).xxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxxz => (long4)((ulong4)this).xxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxxw => (long4)((ulong4)this).xxxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxyx => (long4)((ulong4)this).xxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxyy => (long4)((ulong4)this).xxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxyz => (long4)((ulong4)this).xxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxyw => (long4)((ulong4)this).xxyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxzx => (long4)((ulong4)this).xxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxzy => (long4)((ulong4)this).xxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxzz => (long4)((ulong4)this).xxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxzw => (long4)((ulong4)this).xxzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxwx => (long4)((ulong4)this).xxwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxwy => (long4)((ulong4)this).xxwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxwz => (long4)((ulong4)this).xxwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxww => (long4)((ulong4)this).xxww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyxx => (long4)((ulong4)this).xyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyxy => (long4)((ulong4)this).xyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyxz => (long4)((ulong4)this).xyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyxw => (long4)((ulong4)this).xyxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyyx => (long4)((ulong4)this).xyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyyy => (long4)((ulong4)this).xyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyyz => (long4)((ulong4)this).xyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyyw => (long4)((ulong4)this).xyyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyzx => (long4)((ulong4)this).xyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyzy => (long4)((ulong4)this).xyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyzz => (long4)((ulong4)this).xyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public		    long4 xyzw { readonly get => (long4)((ulong4)this).xyzw;  set { ulong4 _this = (ulong4)this; _this.xyzw = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xywx => (long4)((ulong4)this).xywx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xywy => (long4)((ulong4)this).xywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public		    long4 xywz { readonly get => (long4)((ulong4)this).xywz;  set { ulong4 _this = (ulong4)this; _this.xywz = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyww => (long4)((ulong4)this).xyww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzxx => (long4)((ulong4)this).xzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzxy => (long4)((ulong4)this).xzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzxz => (long4)((ulong4)this).xzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzxw => (long4)((ulong4)this).xzxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzyx => (long4)((ulong4)this).xzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzyy => (long4)((ulong4)this).xzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzyz => (long4)((ulong4)this).xzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 xzyw { readonly get => (long4)((ulong4)this).xzyw;  set { ulong4 _this = (ulong4)this; _this.xzyw = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzzx => (long4)((ulong4)this).xzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzzy => (long4)((ulong4)this).xzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzzz => (long4)((ulong4)this).xzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzzw => (long4)((ulong4)this).xzzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzwx => (long4)((ulong4)this).xzwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 xzwy { readonly get => (long4)((ulong4)this).xzwy;  set { ulong4 _this = (ulong4)this; _this.xzwy = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzwz => (long4)((ulong4)this).xzwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzww => (long4)((ulong4)this).xzww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwxx => (long4)((ulong4)this).xwxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwxy => (long4)((ulong4)this).xwxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwxz => (long4)((ulong4)this).xwxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwxw => (long4)((ulong4)this).xwxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwyx => (long4)((ulong4)this).xwyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwyy => (long4)((ulong4)this).xwyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 xwyz { readonly get => (long4)((ulong4)this).xwyz;  set { ulong4 _this = (ulong4)this; _this.xwyz = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwyw => (long4)((ulong4)this).xwyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwzx => (long4)((ulong4)this).xwzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 xwzy { readonly get => (long4)((ulong4)this).xwzy;  set { ulong4 _this = (ulong4)this; _this.xwzy = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwzz => (long4)((ulong4)this).xwzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwzw => (long4)((ulong4)this).xwzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwwx => (long4)((ulong4)this).xwwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwwy => (long4)((ulong4)this).xwwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwwz => (long4)((ulong4)this).xwwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xwww => (long4)((ulong4)this).xwww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxxx => (long4)((ulong4)this).yxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxxy => (long4)((ulong4)this).yxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxxz => (long4)((ulong4)this).yxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxxw => (long4)((ulong4)this).yxxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxyx => (long4)((ulong4)this).yxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxyy => (long4)((ulong4)this).yxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxyz => (long4)((ulong4)this).yxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxyw => (long4)((ulong4)this).yxyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxzx => (long4)((ulong4)this).yxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxzy => (long4)((ulong4)this).yxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxzz => (long4)((ulong4)this).yxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 yxzw { readonly get => (long4)((ulong4)this).yxzw;  set { ulong4 _this = (ulong4)this; _this.yxzw = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxwx => (long4)((ulong4)this).yxwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxwy => (long4)((ulong4)this).yxwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 yxwz { readonly get => (long4)((ulong4)this).yxwz;  set { ulong4 _this = (ulong4)this; _this.yxwz = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxww => (long4)((ulong4)this).yxww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyxx => (long4)((ulong4)this).yyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyxy => (long4)((ulong4)this).yyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyxz => (long4)((ulong4)this).yyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyxw => (long4)((ulong4)this).yyxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyyx => (long4)((ulong4)this).yyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyyy => (long4)((ulong4)this).yyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyyz => (long4)((ulong4)this).yyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyyw => (long4)((ulong4)this).yyyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyzx => (long4)((ulong4)this).yyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyzy => (long4)((ulong4)this).yyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyzz => (long4)((ulong4)this).yyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyzw => (long4)((ulong4)this).yyzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yywx => (long4)((ulong4)this).yywx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yywy => (long4)((ulong4)this).yywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yywz => (long4)((ulong4)this).yywz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyww => (long4)((ulong4)this).yyww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzxx => (long4)((ulong4)this).yzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzxy => (long4)((ulong4)this).yzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzxz => (long4)((ulong4)this).yzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 yzxw { readonly get => (long4)((ulong4)this).yzxw;  set { ulong4 _this = (ulong4)this; _this.yzxw = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzyx => (long4)((ulong4)this).yzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzyy => (long4)((ulong4)this).yzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzyz => (long4)((ulong4)this).yzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzyw => (long4)((ulong4)this).yzyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzzx => (long4)((ulong4)this).yzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzzy => (long4)((ulong4)this).yzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzzz => (long4)((ulong4)this).yzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzzw => (long4)((ulong4)this).yzzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 yzwx { readonly get => (long4)((ulong4)this).yzwx;  set { ulong4 _this = (ulong4)this; _this.yzwx = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzwy => (long4)((ulong4)this).yzwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzwz => (long4)((ulong4)this).yzwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzww => (long4)((ulong4)this).yzww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywxx => (long4)((ulong4)this).ywxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywxy => (long4)((ulong4)this).ywxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 ywxz { readonly get => (long4)((ulong4)this).ywxz;  set { ulong4 _this = (ulong4)this; _this.ywxz = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywxw => (long4)((ulong4)this).ywxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywyx => (long4)((ulong4)this).ywyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywyy => (long4)((ulong4)this).ywyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywyz => (long4)((ulong4)this).ywyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywyw => (long4)((ulong4)this).ywyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 ywzx { readonly get => (long4)((ulong4)this).ywzx;  set { ulong4 _this = (ulong4)this; _this.ywzx = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywzy => (long4)((ulong4)this).ywzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywzz => (long4)((ulong4)this).ywzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywzw => (long4)((ulong4)this).ywzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywwx => (long4)((ulong4)this).ywwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywwy => (long4)((ulong4)this).ywwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywwz => (long4)((ulong4)this).ywwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 ywww => (long4)((ulong4)this).ywww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxxx => (long4)((ulong4)this).zxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxxy => (long4)((ulong4)this).zxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxxz => (long4)((ulong4)this).zxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxxw => (long4)((ulong4)this).zxxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxyx => (long4)((ulong4)this).zxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxyy => (long4)((ulong4)this).zxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxyz => (long4)((ulong4)this).zxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 zxyw { readonly get => (long4)((ulong4)this).zxyw;  set { ulong4 _this = (ulong4)this; _this.zxyw = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxzx => (long4)((ulong4)this).zxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxzy => (long4)((ulong4)this).zxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxzz => (long4)((ulong4)this).zxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxzw => (long4)((ulong4)this).zxzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxwx => (long4)((ulong4)this).zxwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 zxwy { readonly get => (long4)((ulong4)this).zxwy;  set { ulong4 _this = (ulong4)this; _this.zxwy = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxwz => (long4)((ulong4)this).zxwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxww => (long4)((ulong4)this).zxww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyxx => (long4)((ulong4)this).zyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyxy => (long4)((ulong4)this).zyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyxz => (long4)((ulong4)this).zyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 zyxw { readonly get => (long4)((ulong4)this).zyxw;  set { ulong4 _this = (ulong4)this; _this.zyxw = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyyx => (long4)((ulong4)this).zyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyyy => (long4)((ulong4)this).zyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyyz => (long4)((ulong4)this).zyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyyw => (long4)((ulong4)this).zyyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyzx => (long4)((ulong4)this).zyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyzy => (long4)((ulong4)this).zyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyzz => (long4)((ulong4)this).zyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyzw => (long4)((ulong4)this).zyzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 zywx { readonly get => (long4)((ulong4)this).zywx;  set { ulong4 _this = (ulong4)this; _this.zywx = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zywy => (long4)((ulong4)this).zywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zywz => (long4)((ulong4)this).zywz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyww => (long4)((ulong4)this).zyww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzxx => (long4)((ulong4)this).zzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzxy => (long4)((ulong4)this).zzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzxz => (long4)((ulong4)this).zzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzxw => (long4)((ulong4)this).zzxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzyx => (long4)((ulong4)this).zzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzyy => (long4)((ulong4)this).zzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzyz => (long4)((ulong4)this).zzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzyw => (long4)((ulong4)this).zzyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzzx => (long4)((ulong4)this).zzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzzy => (long4)((ulong4)this).zzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzzz => (long4)((ulong4)this).zzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzzw => (long4)((ulong4)this).zzzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzwx => (long4)((ulong4)this).zzwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzwy => (long4)((ulong4)this).zzwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzwz => (long4)((ulong4)this).zzwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzww => (long4)((ulong4)this).zzww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwxx => (long4)((ulong4)this).zwxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 zwxy { readonly get => (long4)((ulong4)this).zwxy;  set { ulong4 _this = (ulong4)this; _this.zwxy = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwxz => (long4)((ulong4)this).zwxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwxw => (long4)((ulong4)this).zwxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 zwyx { readonly get => (long4)((ulong4)this).zwyx;  set { ulong4 _this = (ulong4)this; _this.zwyx = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwyy => (long4)((ulong4)this).zwyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwyz => (long4)((ulong4)this).zwyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwyw => (long4)((ulong4)this).zwyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwzx => (long4)((ulong4)this).zwzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwzy => (long4)((ulong4)this).zwzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwzz => (long4)((ulong4)this).zwzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwzw => (long4)((ulong4)this).zwzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwwx => (long4)((ulong4)this).zwwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwwy => (long4)((ulong4)this).zwwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwwz => (long4)((ulong4)this).zwwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zwww => (long4)((ulong4)this).zwww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxxx => (long4)((ulong4)this).wxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxxy => (long4)((ulong4)this).wxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxxz => (long4)((ulong4)this).wxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxxw => (long4)((ulong4)this).wxxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxyx => (long4)((ulong4)this).wxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxyy => (long4)((ulong4)this).wxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 wxyz { readonly get => (long4)((ulong4)this).wxyz;  set { ulong4 _this = (ulong4)this; _this.wxyz = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxyw => (long4)((ulong4)this).wxyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxzx => (long4)((ulong4)this).wxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 wxzy { readonly get => (long4)((ulong4)this).wxzy;  set { ulong4 _this = (ulong4)this; _this.wxzy = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxzz => (long4)((ulong4)this).wxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxzw => (long4)((ulong4)this).wxzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxwx => (long4)((ulong4)this).wxwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxwy => (long4)((ulong4)this).wxwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxwz => (long4)((ulong4)this).wxwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wxww => (long4)((ulong4)this).wxww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyxx => (long4)((ulong4)this).wyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyxy => (long4)((ulong4)this).wyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 wyxz { readonly get => (long4)((ulong4)this).wyxz;  set { ulong4 _this = (ulong4)this; _this.wyxz = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyxw => (long4)((ulong4)this).wyxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyyx => (long4)((ulong4)this).wyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyyy => (long4)((ulong4)this).wyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyyz => (long4)((ulong4)this).wyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyyw => (long4)((ulong4)this).wyyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 wyzx { readonly get => (long4)((ulong4)this).wyzx;  set { ulong4 _this = (ulong4)this; _this.wyzx = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyzy => (long4)((ulong4)this).wyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyzz => (long4)((ulong4)this).wyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyzw => (long4)((ulong4)this).wyzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wywx => (long4)((ulong4)this).wywx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wywy => (long4)((ulong4)this).wywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wywz => (long4)((ulong4)this).wywz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wyww => (long4)((ulong4)this).wyww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzxx => (long4)((ulong4)this).wzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 wzxy { readonly get => (long4)((ulong4)this).wzxy;  set { ulong4 _this = (ulong4)this; _this.wzxy = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzxz => (long4)((ulong4)this).wzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzxw => (long4)((ulong4)this).wzxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long4 wzyx { readonly get => (long4)((ulong4)this).wzyx;  set { ulong4 _this = (ulong4)this; _this.wzyx = (ulong4)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzyy => (long4)((ulong4)this).wzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzyz => (long4)((ulong4)this).wzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzyw => (long4)((ulong4)this).wzyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzzx => (long4)((ulong4)this).wzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzzy => (long4)((ulong4)this).wzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzzz => (long4)((ulong4)this).wzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzzw => (long4)((ulong4)this).wzzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzwx => (long4)((ulong4)this).wzwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzwy => (long4)((ulong4)this).wzwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzwz => (long4)((ulong4)this).wzwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wzww => (long4)((ulong4)this).wzww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwxx => (long4)((ulong4)this).wwxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwxy => (long4)((ulong4)this).wwxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwxz => (long4)((ulong4)this).wwxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwxw => (long4)((ulong4)this).wwxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwyx => (long4)((ulong4)this).wwyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwyy => (long4)((ulong4)this).wwyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwyz => (long4)((ulong4)this).wwyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwyw => (long4)((ulong4)this).wwyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwzx => (long4)((ulong4)this).wwzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwzy => (long4)((ulong4)this).wwzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwzz => (long4)((ulong4)this).wwzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwzw => (long4)((ulong4)this).wwzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwwx => (long4)((ulong4)this).wwwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwwy => (long4)((ulong4)this).wwwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwwz => (long4)((ulong4)this).wwwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 wwww => (long4)((ulong4)this).wwww;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xxx => (long3)((ulong4)this).xxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xxy => (long3)((ulong4)this).xxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xxz => (long3)((ulong4)this).xxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xxw => (long3)((ulong4)this).xxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xyx => (long3)((ulong4)this).xyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xyy => (long3)((ulong4)this).xyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long3 xyz { readonly get => (long3)((ulong4)this).xyz;  set { ulong4 _this = (ulong4)this; _this.xyz = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long3 xyw { readonly get => (long3)((ulong4)this).xyw;  set { ulong4 _this = (ulong4)this; _this.xyw = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xzx => (long3)((ulong4)this).xzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 xzy { readonly get => (long3)((ulong4)this).xzy;  set { ulong4 _this = (ulong4)this; _this.xzy = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xzz => (long3)((ulong4)this).xzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long3 xzw { readonly get => (long3)((ulong4)this).xzw;  set { ulong4 _this = (ulong4)this; _this.xzw = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xwx => (long3)((ulong4)this).xwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long3 xwy { readonly get => (long3)((ulong4)this).xwy;  set { ulong4 _this = (ulong4)this; _this.xwy = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long3 xwz { readonly get => (long3)((ulong4)this).xwz;  set { ulong4 _this = (ulong4)this; _this.xwz = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xww => (long3)((ulong4)this).xww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yxx => (long3)((ulong4)this).yxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yxy => (long3)((ulong4)this).yxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 yxz { readonly get => (long3)((ulong4)this).yxz;  set { ulong4 _this = (ulong4)this; _this.yxz = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long3 yxw { readonly get => (long3)((ulong4)this).yxw;  set { ulong4 _this = (ulong4)this; _this.yxw = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yyx => (long3)((ulong4)this).yyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yyy => (long3)((ulong4)this).yyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yyz => (long3)((ulong4)this).yyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yyw => (long3)((ulong4)this).yyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 yzx { readonly get => (long3)((ulong4)this).yzx;  set { ulong4 _this = (ulong4)this; _this.yzx = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yzy => (long3)((ulong4)this).yzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yzz => (long3)((ulong4)this).yzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long3 yzw { readonly get => (long3)((ulong4)this).yzw;  set { ulong4 _this = (ulong4)this; _this.yzw = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long3 ywx { readonly get => (long3)((ulong4)this).ywx;  set { ulong4 _this = (ulong4)this; _this.ywx = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 ywy => (long3)((ulong4)this).ywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			long3 ywz { readonly get => (long3)((ulong4)this).ywz;  set { ulong4 _this = (ulong4)this; _this.ywz = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yww => (long3)((ulong4)this).yww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zxx => (long3)((ulong4)this).zxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 zxy { readonly get => (long3)((ulong4)this).zxy;  set { ulong4 _this = (ulong4)this; _this.zxy = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zxz => (long3)((ulong4)this).zxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 zxw { readonly get => (long3)((ulong4)this).zxw;  set { ulong4 _this = (ulong4)this; _this.zxw = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 zyx { readonly get => (long3)((ulong4)this).zyx;  set { ulong4 _this = (ulong4)this; _this.zyx = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zyy => (long3)((ulong4)this).zyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zyz => (long3)((ulong4)this).zyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 zyw { readonly get => (long3)((ulong4)this).zyw;  set { ulong4 _this = (ulong4)this; _this.zyw = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zzx => (long3)((ulong4)this).zzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zzy => (long3)((ulong4)this).zzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zzz => (long3)((ulong4)this).zzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zzw => (long3)((ulong4)this).zzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 zwx { readonly get => (long3)((ulong4)this).zwx;  set { ulong4 _this = (ulong4)this; _this.zwx = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 zwy { readonly get => (long3)((ulong4)this).zwy;  set { ulong4 _this = (ulong4)this; _this.zwy = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zwz => (long3)((ulong4)this).zwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zww => (long3)((ulong4)this).zww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 wxx => (long3)((ulong4)this).wxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 wxy { readonly get => (long3)((ulong4)this).wxy;  set { ulong4 _this = (ulong4)this; _this.wxy = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 wxz { readonly get => (long3)((ulong4)this).wxz;  set { ulong4 _this = (ulong4)this; _this.wxz = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 wxw => (long3)((ulong4)this).wxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 wyx { readonly get => (long3)((ulong4)this).wyx;  set { ulong4 _this = (ulong4)this; _this.wyx = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 wyy => (long3)((ulong4)this).wyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 wyz { readonly get => (long3)((ulong4)this).wyz;  set { ulong4 _this = (ulong4)this; _this.wyz = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 wyw => (long3)((ulong4)this).wyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 wzx { readonly get => (long3)((ulong4)this).wzx;  set { ulong4 _this = (ulong4)this; _this.wzx = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 wzy { readonly get => (long3)((ulong4)this).wzy;  set { ulong4 _this = (ulong4)this; _this.wzy = (ulong3)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 wzz => (long3)((ulong4)this).wzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 wzw => (long3)((ulong4)this).wzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 wwx => (long3)((ulong4)this).wwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 wwy => (long3)((ulong4)this).wwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 wwz => (long3)((ulong4)this).wwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 www => (long3)((ulong4)this).www;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long2 xx => (long2)((ulong4)this).xx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 xy { readonly get => (long2)((ulong4)this).xy;  set { ulong4 _this = (ulong4)this; _this.xy = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 xz { readonly get => (long2)((ulong4)this).xz;  set { ulong4 _this = (ulong4)this; _this.xz = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 xw { readonly get => (long2)((ulong4)this).xw;  set { ulong4 _this = (ulong4)this; _this.xw = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 yx { readonly get => (long2)((ulong4)this).yx;  set { ulong4 _this = (ulong4)this; _this.yx = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long2 yy => (long2)((ulong4)this).yy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 yz { readonly get => (long2)((ulong4)this).yz;  set { ulong4 _this = (ulong4)this; _this.yz = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 yw { readonly get => (long2)((ulong4)this).yw;  set { ulong4 _this = (ulong4)this; _this.yw = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 zx { readonly get => (long2)((ulong4)this).zx;  set { ulong4 _this = (ulong4)this; _this.zx = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 zy { readonly get => (long2)((ulong4)this).zy;  set { ulong4 _this = (ulong4)this; _this.zy = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long2 zz => (long2)((ulong4)this).zz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 zw { readonly get => (long2)((ulong4)this).zw;  set { ulong4 _this = (ulong4)this; _this.zw = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 wx { readonly get => (long2)((ulong4)this).wx;  set { ulong4 _this = (ulong4)this; _this.wx = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 wy { readonly get => (long2)((ulong4)this).wy;  set { ulong4 _this = (ulong4)this; _this.wy = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 wz { readonly get => (long2)((ulong4)this).wz;  set { ulong4 _this = (ulong4)this; _this.wz = (ulong2)value; this = (long4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long2 ww => (long2)((ulong4)this).ww;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(long4 input) => (ulong4)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(v256 input) => (long4)(ulong4)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(bool4 x) => (long4)(mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(Unity.Mathematics.bool4 x) => (long4)(mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (long4)(mask64x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (long4)(mask64x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (long4)(mask64x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(mask64x4 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
            }
            else
            {
                return new long4((long2)x.xy, (long2)x.zw);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(long4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(long4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(long4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4(long4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4(long4 x) => (mask64x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4(long4 x) => x != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4(byte x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4(sbyte x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4(ushort x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4(short x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4(uint x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long4(int x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(ulong x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(UInt128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(Int128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(quarter x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(half x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(float x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(double x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(quadruple x) => (long)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(Unity.Mathematics.half x) => (long4)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(Unity.Mathematics.half4 x) => (long4)(half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(Unity.Mathematics.float4 x) => (long4)(float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(Unity.Mathematics.double4 x) => (long4)(double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(Unity.Mathematics.uint4 x) => (long4)(uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(Unity.Mathematics.int4 x) => (long4)(int4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half4(long4 x) => (half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(long4 x) => (float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(long4 x) => (double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(long4 x) => (uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(long4 x) => (int4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(long input) => new long4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(ulong4 input) => *(long4*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(uint4 input) => (long4)(ulong4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(int4 input) => (long4)(ulong4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(float4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epi64(input, 4);
            }
            else
            {
                return new long4((long2)input.xy, (long2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(double4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epi64(input, 4);
            }
            else
            {
                return new long4((long2)input.xy, (long2)input.zw);
            }
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4(long4 input) => (uint4)(ulong4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(long4 input) => (int4)(ulong4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_ps(input, 4);
            }
            else
            {
                return new float4((float2)input.__x0, (float2)input.__x2);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(long4 input)
		{
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_pd(input, 4);
            }
			else
			{
				return new double4((double2)input.__x0, (double2)input.__x2);
			}
		}


        public long this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (long)((ulong4)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ulong4 _this = (ulong4)this;
                _this[index] = (ulong)value;
                this = (long4)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, long4 right) => (long4)((ulong4)left + (ulong4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, long4 right) => (long4)((ulong4)left - (ulong4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, long4 right) => (long4)((ulong4)left * (ulong4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, right, elements: 4);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(left.xy, right.xy, useFPU: true), Xse.div_epi64(left.zw, right.zw, useFPU: false));
			}
			else
			{
				return new long4(left.__x0 / right.__x0, left.__x2 / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, right, elements: 4);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(left.xy, right.xy, useFPU: true), Xse.rem_epi64(left.zw, right.zw, useFPU: false));
			}
			else
			{
				return new long4(left.__x0 % right.__x0, left.__x2 % right.__x2);
			}
		}

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, byte right) => left + (byte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, ushort right) => left + (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, uint right) => left + (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, sbyte right) => left + (sbyte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, short right) => left + (short4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, int right) => left + (int4)right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 operator + (long4 left, long right) => left + (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, byte right) => left - (byte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, ushort right) => left - (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, uint right) => left - (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, sbyte right) => left - (sbyte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, short right) => left - (short4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, int right) => left - (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, long right) => left - (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, byte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, uint right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, sbyte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, short right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, int right) => right * left;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, long right)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(right))
				{
					return new long4(left.x * right, left.y * right, left.z * right, left.w * right);
				}
			}

            return new long4(left.xy * right, left.zw * right);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (byte4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (ushort4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (uint4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (sbyte4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (short4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, int right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (int4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, long right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constdiv_epi64(left, right, 4);
                }
            }

            return new long4(left.xy / right, left.zw / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (byte4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (ushort4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (uint4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (sbyte4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (short4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, int right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (int4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, long right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constrem_epi64(left, right, 4);
                }
            }

            return new long4(left.xy % right, left.zw % right);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (byte left, long4 right) => (byte4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (ushort left, long4 right) => (ushort4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (uint left, long4 right) => (uint4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (sbyte left, long4 right) => (sbyte4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (short left, long4 right) => (short4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (int left, long4 right) => (int4)left + right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 operator + (long left, long4 right) => (long4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (byte left, long4 right) => (byte4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (ushort left, long4 right) => (ushort4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (uint left, long4 right) => (uint4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (sbyte left, long4 right) => (sbyte4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (short left, long4 right) => (short4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (int left, long4 right) => (int4)left - right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 operator - (long left, long4 right) => (long4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (byte left, long4 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (ushort left, long4 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (uint left, long4 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (sbyte left, long4 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (short left, long4 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (int left, long4 right) => (long)left * right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 operator * (long left, long4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (byte left, long4 right) => (byte4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (ushort left, long4 right) => (ushort4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (uint left, long4 right) => (uint4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (sbyte left, long4 right) => (sbyte4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (short left, long4 right) => (short4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (int left, long4 right) => (int4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long left, long4 right) => (long4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (byte left, long4 right) => (byte4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (ushort left, long4 right) => (ushort4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (uint left, long4 right) => (uint4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (sbyte left, long4 right) => (sbyte4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (short left, long4 right) => (short4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (int left, long4 right) => (int4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long left, long4 right) => (long4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, byte4 right) => left + (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (byte4 left, long4 right) => (long4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, byte4 right) => left - (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (byte4 left, long4 right) => (long4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, byte4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long4)right, 4, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long4(left.xy * right.xy, left.zw * right.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (byte4 left, long4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (byte4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepu8_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(Xse.cvtepu8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), Xse.div_epi64(Xse.cvtepu8_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false, aNonNegative: true));
			}
			else
			{
				return new long4(left.xy / right.__x0, left.zw / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, byte4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu8_pd(right), elements: 4, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), Xse.div_epi64(left.zw, Xse.cvtepu8_epi64(right.zw), useFPU: false, bIsDbl: false, bNonNegative: true));
			}
			else
			{
				return new long4(left.__x0 / right.xy, left.__x2 / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (byte4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepu8_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(Xse.cvtepu8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), Xse.rem_epi64(Xse.cvtepu8_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false, aNonNegative: true));
			}
			else
			{
				return new long4(left.xy % right.__x0, left.zw % right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, byte4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu8_pd(right), elements: 4, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), Xse.rem_epi64(left.zw, Xse.cvtepu8_epi64(right.zw), useFPU: false, bIsDbl: false, bNonNegative: true));
			}
			else
			{
				return new long4(left.__x0 % right.xy, left.__x2 % right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, ushort4 right) => left + (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (ushort4 left, long4 right) => (long4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, ushort4 right) => left - (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (ushort4 left, long4 right) => (long4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, ushort4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long4)right, 4, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long4(left.xy * right.xy, left.zw * right.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (ushort4 left, long4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (ushort4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepu16_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(Xse.cvtepu16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), Xse.div_epi64(Xse.cvtepu16_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false, aNonNegative: true));
			}
			else
			{
				return new long4(left.xy / right.__x0, left.zw / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, ushort4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu16_pd(right), elements: 4, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), Xse.div_epi64(left.zw, Xse.cvtepu16_epi64(right.zw), useFPU: false, bIsDbl: false, bNonNegative: true));
			}
			else
			{
				return new long4(left.__x0 / right.xy, left.__x2 / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (ushort4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepu16_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(Xse.cvtepu16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), Xse.rem_epi64(Xse.cvtepu16_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false, aNonNegative: true));
			}
			else
			{
				return new long4(left.xy % right.__x0, left.zw % right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, ushort4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu16_pd(right), elements: 4, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), Xse.rem_epi64(left.zw, Xse.cvtepu16_epi64(right.zw), useFPU: false, bIsDbl: false, bNonNegative: true));
			}
			else
			{
				return new long4(left.__x0 % right.xy, left.__x2 % right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, uint4 right) => left + (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (uint4 left, long4 right) => (long4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, uint4 right) => left - (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (uint4 left, long4 right) => (long4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, uint4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long4)right, 4, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long4(left.xy * right.xy, left.zw * right.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (uint4 left, long4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (uint4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepu32_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(Xse.cvtepu32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), Xse.div_epi64(Xse.cvtepi32_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false, aNonNegative: true));
			}
			else
			{
				return new long4(left.xy / right.__x0, left.zw / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, uint4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu32_pd(right), elements: 4, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(left.xy, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), Xse.div_epi64(left.zw, Xse.cvtepi32_epi64(right.zw), useFPU: false, bIsDbl: false, bNonNegative: true));
			}
			else
			{
				return new long4(left.__x0 / right.xy, left.__x2 / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (uint4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepu32_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(Xse.cvtepu32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), Xse.rem_epi64(Xse.cvtepi32_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false, aNonNegative: true));
			}
			else
			{
				return new long4(left.xy % right.__x0, left.zw % right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, uint4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu32_pd(right), elements: 4, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(left.xy, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), Xse.rem_epi64(left.zw, Xse.cvtepi32_epi64(right.zw), useFPU: false, bIsDbl: false, bNonNegative: true));
			}
			else
			{
				return new long4(left.__x0 % right.xy, left.__x2 % right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, sbyte4 right) => left + (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (sbyte4 left, long4 right) => (long4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, sbyte4 right) => left - (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (sbyte4 left, long4 right) => (long4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, sbyte4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long4)right, 4, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long4(left.xy * right.xy, left.zw * right.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (sbyte4 left, long4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (sbyte4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepi8_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(Xse.cvtepi8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.div_epi64(Xse.cvtepi8_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new long4(left.xy / right.__x0, left.zw / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, sbyte4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepi8_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(left.xy, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.div_epi64(left.zw, Xse.cvtepi8_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new long4(left.__x0 / right.xy, left.__x2 / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (sbyte4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepi8_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(Xse.cvtepi8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.rem_epi64(Xse.cvtepi8_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new long4(left.xy % right.__x0, left.zw % right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, sbyte4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepi8_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(left.xy, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.rem_epi64(left.zw, Xse.cvtepi8_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new long4(left.__x0 % right.xy, left.__x2 % right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, short4 right) => left + (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (short4 left, long4 right) => (long4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, short4 right) => left - (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (short4 left, long4 right) => (long4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, short4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long4)right, 4, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long4(left.xy * right.xy, left.zw * right.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (short4 left, long4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (short4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepi16_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(Xse.cvtepi16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.div_epi64(Xse.cvtepi16_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new long4(left.xy / right.__x0, left.zw / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, short4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepi16_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(left.xy, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.div_epi64(left.zw, Xse.cvtepi16_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new long4(left.__x0 / right.xy, left.__x2 / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (short4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepi16_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(Xse.cvtepi16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.rem_epi64(Xse.cvtepi16_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new long4(left.xy % right.__x0, left.zw % right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, short4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepi16_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(left.xy, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.rem_epi64(left.zw, Xse.cvtepi16_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new long4(left.__x0 % right.xy, left.__x2 % right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, int4 right) => left + (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (int4 left, long4 right) => (long4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, int4 right) => left - (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (int4 left, long4 right) => (long4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, int4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long4)right, 4, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long4(left.xy * right.xy, left.zw * right.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (int4 left, long4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (int4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Avx.mm256_cvtepi32_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(Xse.cvtepi32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.div_epi64(Xse.cvtepi32_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new long4(left.xy / right.__x0, left.zw / right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, int4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Avx.mm256_cvtepi32_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(left.xy, Xse.cvtepi32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.div_epi64(left.zw, Xse.cvtepi32_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new long4(left.__x0 / right.xy, left.__x2 / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (int4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Avx.mm256_cvtepi32_pd(left), right, elements: 4, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(Xse.cvtepi32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), Xse.rem_epi64(Xse.cvtepi32_epi64(left.zw), right.zw, useFPU: false, aIsDbl: false));
			}
			else
			{
				return new long4(left.xy % right.__x0, left.zw % right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, int4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Avx.mm256_cvtepi32_pd(right), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(left.xy, Xse.cvtepi32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.rem_epi64(left.zw, Xse.cvtepi32_epi64(right.zw), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new long4(left.__x0 % right.xy, left.__x2 % right.zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, Unity.Mathematics.int4 right) => left + (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, Unity.Mathematics.int4 right) => left - (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, Unity.Mathematics.int4 right) => left * (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, Unity.Mathematics.int4 right) => left / (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, Unity.Mathematics.int4 right) => left % (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (Unity.Mathematics.int4 left, long4 right) => (int4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (Unity.Mathematics.int4 left, long4 right) => (int4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (Unity.Mathematics.int4 left, long4 right) => (int4)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (Unity.Mathematics.int4 left, long4 right) => (int4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (Unity.Mathematics.int4 left, long4 right) => (int4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 left, Unity.Mathematics.uint4 right) => left + (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 left, Unity.Mathematics.uint4 right) => left - (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, Unity.Mathematics.uint4 right) => left * (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, Unity.Mathematics.uint4 right) => left / (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, Unity.Mathematics.uint4 right) => left % (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (Unity.Mathematics.uint4 left, long4 right) => (uint4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (Unity.Mathematics.uint4 left, long4 right) => (uint4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (Unity.Mathematics.uint4 left, long4 right) => (uint4)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (Unity.Mathematics.uint4 left, long4 right) => (uint4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (Unity.Mathematics.uint4 left, long4 right) => (uint4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (long4 left, Unity.Mathematics.float4 right) => left + (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (long4 left, Unity.Mathematics.float4 right) => left - (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (long4 left, Unity.Mathematics.float4 right) => left * (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (long4 left, Unity.Mathematics.float4 right) => left / (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (long4 left, Unity.Mathematics.float4 right) => left % (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 left, long4 right) => (float4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 left, long4 right) => (float4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 left, long4 right) => (float4)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 left, long4 right) => (float4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 left, long4 right) => (float4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (long4 left, Unity.Mathematics.double4 right) => left + (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (long4 left, Unity.Mathematics.double4 right) => left - (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (long4 left, Unity.Mathematics.double4 right) => left * (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (long4 left, Unity.Mathematics.double4 right) => left / (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (long4 left, Unity.Mathematics.double4 right) => left % (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 left, long4 right) => (double4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 left, long4 right) => (double4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 left, long4 right) => (double4)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 left, long4 right) => (double4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 left, long4 right) => (double4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, long4 right) => (long4)((ulong4)left & (ulong4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, long4 right) => (long4)((ulong4)left | (ulong4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, long4 right) => (long4)((ulong4)left ^ (ulong4)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, byte4 right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, byte4 right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, byte4 right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (byte4 left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (byte4 left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (byte4 left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, ushort4 right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, ushort4 right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, ushort4 right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (ushort4 left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (ushort4 left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (ushort4 left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, uint4 right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, uint4 right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, uint4 right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (uint4 left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (uint4 left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (uint4 left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, Unity.Mathematics.uint4 right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, Unity.Mathematics.uint4 right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, Unity.Mathematics.uint4 right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (Unity.Mathematics.uint4 left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (Unity.Mathematics.uint4 left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (Unity.Mathematics.uint4 left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, sbyte4 right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, sbyte4 right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, sbyte4 right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (sbyte4 left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (sbyte4 left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (sbyte4 left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, short4 right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, short4 right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, short4 right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (short4 left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (short4 left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (short4 left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, int4 right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, int4 right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, int4 right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (int4 left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (int4 left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (int4 left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, Unity.Mathematics.int4 right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, Unity.Mathematics.int4 right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, Unity.Mathematics.int4 right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (Unity.Mathematics.int4 left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (Unity.Mathematics.int4 left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (Unity.Mathematics.int4 left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, byte right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, byte right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, byte right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (byte left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (byte left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (byte left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, ushort right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, ushort right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, ushort right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (ushort left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (ushort left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (ushort left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, uint right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, uint right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, uint right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (uint left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (uint left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (uint left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, sbyte right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, sbyte right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, sbyte right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (sbyte left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (sbyte left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (sbyte left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, short right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, short right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, short right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (short left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (short left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (short left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, int right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, int right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, int right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (int left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (int left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (int left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, long right) => left & (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, long right) => left | (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, long right) => left ^ (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long left, long4 right) => (long4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long left, long4 right) => (long4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long left, long4 right) => (long4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 x)
		{
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
			}
			else
            {
				return new long4(-x.__x0, -x.__x2);
            }
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ++ (long4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_inc_epi64(x);
			}
			else
			{
				return new long4(x.__x0 + 1, x.__x2 + 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator -- (long4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_dec_epi64(x);
			}
			else
			{
				return new long4(x.__x0 - 1, x.__x2 - 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ~ (long4 x) => (long4)~(ulong4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator << (long4 x, int n) => (long4)((ulong4)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator >> (long4 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_srai_epi64(x, n, 4);
			}
			else
			{
				return new long4(x.__x0 >> n, x.__x2 >> n);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, long4 right) => (ulong4)left == (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cmplt_epi64(left, right);
			}
			else
			{
				return new mask64x4(left.__x0 < right.__x0, left.__x2 < right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cmpgt_epi64(left, right);
			}
			else
			{
				return new mask64x4(left.__x0 > right.__x0, left.__x2 > right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, long4 right) => (ulong4)left != (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Avx2.mm256_cmpgt_epi64(left, right));
			}
			else
			{
				return new mask64x4(left.__x0 <= right.__x0, left.__x2 <= right.__x2);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Xse.mm256_cmplt_epi64(left, right));
			}
			else
			{
				return new mask64x4(left.__x0 >= right.__x0, left.__x2 >= right.__x2);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, byte right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (byte left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, byte right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (byte left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, byte right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (byte left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, byte right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (byte left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, byte right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (byte left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, byte right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (byte left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, ushort right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ushort left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, ushort right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ushort left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, ushort right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ushort left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, ushort right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ushort left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, ushort right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ushort left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, ushort right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ushort left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, uint right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (uint left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, uint right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (uint left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, uint right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (uint left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, uint right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (uint left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, uint right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (uint left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, uint right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (uint left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, sbyte right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (sbyte left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, sbyte right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (sbyte left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, sbyte right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (sbyte left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, sbyte right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (sbyte left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, sbyte right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (sbyte left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, sbyte right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (sbyte left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, short right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (short left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, short right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (short left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, short right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (short left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, short right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (short left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, short right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (short left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, short right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (short left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, int right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (int left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, int right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (int left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, int right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (int left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, int right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (int left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, int right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (int left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, int right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (int left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, long right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, long right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, long right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, long right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, long right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, long right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, byte4 right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (byte4 left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, byte4 right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (byte4 left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, byte4 right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (byte4 left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, byte4 right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (byte4 left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, byte4 right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (byte4 left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, byte4 right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (byte4 left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, ushort4 right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (ushort4 left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, ushort4 right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (ushort4 left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, ushort4 right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (ushort4 left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, ushort4 right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (ushort4 left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, ushort4 right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (ushort4 left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, ushort4 right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (ushort4 left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, uint4 right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (uint4 left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, uint4 right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (uint4 left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, uint4 right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (uint4 left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, uint4 right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (uint4 left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, uint4 right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (uint4 left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, uint4 right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (uint4 left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, Unity.Mathematics.uint4 right) => left == (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (Unity.Mathematics.uint4 left, long4 right) => (uint4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, Unity.Mathematics.uint4 right) => left != (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (Unity.Mathematics.uint4 left, long4 right) => (uint4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, Unity.Mathematics.uint4 right) => left < (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (Unity.Mathematics.uint4 left, long4 right) => (uint4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, Unity.Mathematics.uint4 right) => left > (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (Unity.Mathematics.uint4 left, long4 right) => (uint4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, Unity.Mathematics.uint4 right) => left <= (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (Unity.Mathematics.uint4 left, long4 right) => (uint4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, Unity.Mathematics.uint4 right) => left >= (uint4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (Unity.Mathematics.uint4 left, long4 right) => (uint4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, sbyte4 right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (sbyte4 left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, sbyte4 right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (sbyte4 left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, sbyte4 right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (sbyte4 left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, sbyte4 right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (sbyte4 left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, sbyte4 right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (sbyte4 left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, sbyte4 right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (sbyte4 left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, short4 right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (short4 left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, short4 right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (short4 left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, short4 right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (short4 left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, short4 right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (short4 left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, short4 right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (short4 left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, short4 right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (short4 left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, int4 right) => left == (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (int4 left, long4 right) => (long4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, int4 right) => left != (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (int4 left, long4 right) => (long4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, int4 right) => left < (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (int4 left, long4 right) => (long4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, int4 right) => left > (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (int4 left, long4 right) => (long4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, int4 right) => left <= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (int4 left, long4 right) => (long4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, int4 right) => left >= (long4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (int4 left, long4 right) => (long4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, Unity.Mathematics.int4 right) => left == (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (Unity.Mathematics.int4 left, long4 right) => (int4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, Unity.Mathematics.int4 right) => left != (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (Unity.Mathematics.int4 left, long4 right) => (int4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, Unity.Mathematics.int4 right) => left < (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (Unity.Mathematics.int4 left, long4 right) => (int4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, Unity.Mathematics.int4 right) => left > (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (Unity.Mathematics.int4 left, long4 right) => (int4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, Unity.Mathematics.int4 right) => left <= (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (Unity.Mathematics.int4 left, long4 right) => (int4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, Unity.Mathematics.int4 right) => left >= (int4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (Unity.Mathematics.int4 left, long4 right) => (int4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, Unity.Mathematics.float4 right) => left == (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (Unity.Mathematics.float4 left, long4 right) => (float4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, Unity.Mathematics.float4 right) => left != (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (Unity.Mathematics.float4 left, long4 right) => (float4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, Unity.Mathematics.float4 right) => left < (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (Unity.Mathematics.float4 left, long4 right) => (float4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, Unity.Mathematics.float4 right) => left > (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (Unity.Mathematics.float4 left, long4 right) => (float4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, Unity.Mathematics.float4 right) => left <= (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (Unity.Mathematics.float4 left, long4 right) => (float4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, Unity.Mathematics.float4 right) => left >= (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (Unity.Mathematics.float4 left, long4 right) => (float4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (long4 left, Unity.Mathematics.double4 right) => left == (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator == (Unity.Mathematics.double4 left, long4 right) => (double4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (long4 left, Unity.Mathematics.double4 right) => left != (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator != (Unity.Mathematics.double4 left, long4 right) => (double4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (long4 left, Unity.Mathematics.double4 right) => left < (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator < (Unity.Mathematics.double4 left, long4 right) => (double4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (long4 left, Unity.Mathematics.double4 right) => left > (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator > (Unity.Mathematics.double4 left, long4 right) => (double4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (long4 left, Unity.Mathematics.double4 right) => left <= (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator <= (Unity.Mathematics.double4 left, long4 right) => (double4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (long4 left, Unity.Mathematics.double4 right) => left >= (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x4 operator >= (Unity.Mathematics.double4 left, long4 right) => (double4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long4 other) => ((ulong4)this).Equals((ulong4)other);

        public override readonly bool Equals(object obj) => obj is long4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"long4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"long4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}