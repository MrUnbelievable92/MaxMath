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
    internal sealed class sbyte4DebuggerProxy
    {
	    public sbyte x;
	    public sbyte y;
	    public sbyte z;
	    public sbyte w;
        
	    public sbyte4DebuggerProxy(sbyte4 v)
	    {
	    	x = v.x;
	    	y = v.y;
	    	z = v.z;
	    	w = v.w;
	    }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(sbyte4DebuggerProxy))]
#endif
    [Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct sbyte4 : IEquatable<sbyte4>, IFormattable
	{
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal uint __x0;
		
        public ref sbyte x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte4* ptr = &this) { return ref *((sbyte*)ptr + 0); } } }
        public ref sbyte y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte4* ptr = &this) { return ref *((sbyte*)ptr + 1); } } }
        public ref sbyte z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte4* ptr = &this) { return ref *((sbyte*)ptr + 2); } } }
        public ref sbyte w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte4* ptr = &this) { return ref *((sbyte*)ptr + 3); } } }


        public static sbyte4 zero => default;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte y, sbyte z, sbyte w)
        {
			this = (sbyte4)new byte4((byte)x, (byte)y, (byte)z, (byte)w);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte xyzw)
        {
			this = (sbyte4)new byte4((byte)xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte2 xy, sbyte z, sbyte w)
        {
			this = (sbyte4)new byte4((byte2)xy, (byte)z, (byte)w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte2 yz, sbyte w)
        {
			this = (sbyte4)new byte4((byte)x, (byte2)yz, (byte)w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte y, sbyte2 zw)
        {
			this = (sbyte4)new byte4((byte)x, (byte)y, (byte2)zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte2 xy, sbyte2 zw)
        {
			this = (sbyte4)new byte4((byte2)xy, (byte2)zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte3 xyz, sbyte w)
        {
			this = (sbyte4)new byte4((byte3)xyz, (byte)w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte3 yzw)
        {
			this = (sbyte4)new byte4((byte)x, (byte3)yzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(bool v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(bool4 v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(mask8x4 v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(mask16x4 v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(mask32x4 v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(mask64x4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(byte v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(byte4 v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(ushort v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(ushort4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(short v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(short4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(uint v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(uint4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(int v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(int4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(ulong v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(ulong4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(long v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(long4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(UInt128 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(Int128 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(quarter v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(quarter4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(half v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(half4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(float v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(float4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(double v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(double4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(quadruple v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(Unity.Mathematics.bool4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(Unity.Mathematics.uint4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(Unity.Mathematics.int4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(Unity.Mathematics.half v)
        {
            this = (sbyte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(Unity.Mathematics.half4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(Unity.Mathematics.float4 v)
        {
            this = (sbyte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(Unity.Mathematics.double4 v)
        {
            this = (sbyte4)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxxx => (sbyte4)((byte4)this).xxxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxxy => (sbyte4)((byte4)this).xxxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxxz => (sbyte4)((byte4)this).xxxz;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxxw => (sbyte4)((byte4)this).xxxw;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxyx => (sbyte4)((byte4)this).xxyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxyy => (sbyte4)((byte4)this).xxyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxyz => (sbyte4)((byte4)this).xxyz;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxyw => (sbyte4)((byte4)this).xxyw;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxzx => (sbyte4)((byte4)this).xxzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxzy => (sbyte4)((byte4)this).xxzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxzz => (sbyte4)((byte4)this).xxzz;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxzw => (sbyte4)((byte4)this).xxzw;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxwx => (sbyte4)((byte4)this).xxwx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxwy => (sbyte4)((byte4)this).xxwy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxwz => (sbyte4)((byte4)this).xxwz;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxww => (sbyte4)((byte4)this).xxww;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyxx => (sbyte4)((byte4)this).xyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyxy => (sbyte4)((byte4)this).xyxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyxz => (sbyte4)((byte4)this).xyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyxw => (sbyte4)((byte4)this).xyxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyyx => (sbyte4)((byte4)this).xyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyyy => (sbyte4)((byte4)this).xyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyyz => (sbyte4)((byte4)this).xyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyyw => (sbyte4)((byte4)this).xyyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyzx => (sbyte4)((byte4)this).xyzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyzy => (sbyte4)((byte4)this).xyzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyzz => (sbyte4)((byte4)this).xyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public		    sbyte4 xyzw { readonly get => (sbyte4)((byte4)this).xyzw;  set { byte4 _this = (byte4)this; _this.xyzw = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xywx => (sbyte4)((byte4)this).xywx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xywy => (sbyte4)((byte4)this).xywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public		    sbyte4 xywz { readonly get => (sbyte4)((byte4)this).xywz;  set { byte4 _this = (byte4)this; _this.xywz = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyww => (sbyte4)((byte4)this).xyww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzxx => (sbyte4)((byte4)this).xzxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzxy => (sbyte4)((byte4)this).xzxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzxz => (sbyte4)((byte4)this).xzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzxw => (sbyte4)((byte4)this).xzxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzyx => (sbyte4)((byte4)this).xzyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzyy => (sbyte4)((byte4)this).xzyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzyz => (sbyte4)((byte4)this).xzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 xzyw { readonly get => (sbyte4)((byte4)this).xzyw;  set { byte4 _this = (byte4)this; _this.xzyw = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzzx => (sbyte4)((byte4)this).xzzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzzy => (sbyte4)((byte4)this).xzzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzzz => (sbyte4)((byte4)this).xzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzzw => (sbyte4)((byte4)this).xzzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzwx => (sbyte4)((byte4)this).xzwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 xzwy { readonly get => (sbyte4)((byte4)this).xzwy;  set { byte4 _this = (byte4)this; _this.xzwy = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzwz => (sbyte4)((byte4)this).xzwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzww => (sbyte4)((byte4)this).xzww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwxx => (sbyte4)((byte4)this).xwxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwxy => (sbyte4)((byte4)this).xwxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwxz => (sbyte4)((byte4)this).xwxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwxw => (sbyte4)((byte4)this).xwxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwyx => (sbyte4)((byte4)this).xwyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwyy => (sbyte4)((byte4)this).xwyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 xwyz { readonly get => (sbyte4)((byte4)this).xwyz;  set { byte4 _this = (byte4)this; _this.xwyz = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwyw => (sbyte4)((byte4)this).xwyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwzx => (sbyte4)((byte4)this).xwzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 xwzy { readonly get => (sbyte4)((byte4)this).xwzy;  set { byte4 _this = (byte4)this; _this.xwzy = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwzz => (sbyte4)((byte4)this).xwzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwzw => (sbyte4)((byte4)this).xwzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwwx => (sbyte4)((byte4)this).xwwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwwy => (sbyte4)((byte4)this).xwwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwwz => (sbyte4)((byte4)this).xwwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xwww => (sbyte4)((byte4)this).xwww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxxx => (sbyte4)((byte4)this).yxxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxxy => (sbyte4)((byte4)this).yxxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxxz => (sbyte4)((byte4)this).yxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxxw => (sbyte4)((byte4)this).yxxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxyx => (sbyte4)((byte4)this).yxyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxyy => (sbyte4)((byte4)this).yxyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxyz => (sbyte4)((byte4)this).yxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxyw => (sbyte4)((byte4)this).yxyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxzx => (sbyte4)((byte4)this).yxzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxzy => (sbyte4)((byte4)this).yxzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxzz => (sbyte4)((byte4)this).yxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 yxzw { readonly get => (sbyte4)((byte4)this).yxzw;  set { byte4 _this = (byte4)this; _this.yxzw = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxwx => (sbyte4)((byte4)this).yxwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxwy => (sbyte4)((byte4)this).yxwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 yxwz { readonly get => (sbyte4)((byte4)this).yxwz;  set { byte4 _this = (byte4)this; _this.yxwz = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxww => (sbyte4)((byte4)this).yxww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyxx => (sbyte4)((byte4)this).yyxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyxy => (sbyte4)((byte4)this).yyxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyxz => (sbyte4)((byte4)this).yyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyxw => (sbyte4)((byte4)this).yyxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyyx => (sbyte4)((byte4)this).yyyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyyy => (sbyte4)((byte4)this).yyyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyyz => (sbyte4)((byte4)this).yyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyyw => (sbyte4)((byte4)this).yyyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyzx => (sbyte4)((byte4)this).yyzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyzy => (sbyte4)((byte4)this).yyzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyzz => (sbyte4)((byte4)this).yyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyzw => (sbyte4)((byte4)this).yyzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yywx => (sbyte4)((byte4)this).yywx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yywy => (sbyte4)((byte4)this).yywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yywz => (sbyte4)((byte4)this).yywz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyww => (sbyte4)((byte4)this).yyww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzxx => (sbyte4)((byte4)this).yzxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzxy => (sbyte4)((byte4)this).yzxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzxz => (sbyte4)((byte4)this).yzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 yzxw { readonly get => (sbyte4)((byte4)this).yzxw;  set { byte4 _this = (byte4)this; _this.yzxw = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzyx => (sbyte4)((byte4)this).yzyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzyy => (sbyte4)((byte4)this).yzyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzyz => (sbyte4)((byte4)this).yzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzyw => (sbyte4)((byte4)this).yzyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzzx => (sbyte4)((byte4)this).yzzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzzy => (sbyte4)((byte4)this).yzzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzzz => (sbyte4)((byte4)this).yzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzzw => (sbyte4)((byte4)this).yzzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 yzwx { readonly get => (sbyte4)((byte4)this).yzwx;  set { byte4 _this = (byte4)this; _this.yzwx = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzwy => (sbyte4)((byte4)this).yzwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzwz => (sbyte4)((byte4)this).yzwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzww => (sbyte4)((byte4)this).yzww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywxx => (sbyte4)((byte4)this).ywxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywxy => (sbyte4)((byte4)this).ywxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 ywxz { readonly get => (sbyte4)((byte4)this).ywxz;  set { byte4 _this = (byte4)this; _this.ywxz = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywxw => (sbyte4)((byte4)this).ywxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywyx => (sbyte4)((byte4)this).ywyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywyy => (sbyte4)((byte4)this).ywyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywyz => (sbyte4)((byte4)this).ywyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywyw => (sbyte4)((byte4)this).ywyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 ywzx { readonly get => (sbyte4)((byte4)this).ywzx;  set { byte4 _this = (byte4)this; _this.ywzx = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywzy => (sbyte4)((byte4)this).ywzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywzz => (sbyte4)((byte4)this).ywzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywzw => (sbyte4)((byte4)this).ywzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywwx => (sbyte4)((byte4)this).ywwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywwy => (sbyte4)((byte4)this).ywwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywwz => (sbyte4)((byte4)this).ywwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 ywww => (sbyte4)((byte4)this).ywww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxxx => (sbyte4)((byte4)this).zxxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxxy => (sbyte4)((byte4)this).zxxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxxz => (sbyte4)((byte4)this).zxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxxw => (sbyte4)((byte4)this).zxxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxyx => (sbyte4)((byte4)this).zxyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxyy => (sbyte4)((byte4)this).zxyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxyz => (sbyte4)((byte4)this).zxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 zxyw { readonly get => (sbyte4)((byte4)this).zxyw;  set { byte4 _this = (byte4)this; _this.zxyw = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxzx => (sbyte4)((byte4)this).zxzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxzy => (sbyte4)((byte4)this).zxzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxzz => (sbyte4)((byte4)this).zxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxzw => (sbyte4)((byte4)this).zxzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxwx => (sbyte4)((byte4)this).zxwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 zxwy { readonly get => (sbyte4)((byte4)this).zxwy;  set { byte4 _this = (byte4)this; _this.zxwy = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxwz => (sbyte4)((byte4)this).zxwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxww => (sbyte4)((byte4)this).zxww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyxx => (sbyte4)((byte4)this).zyxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyxy => (sbyte4)((byte4)this).zyxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyxz => (sbyte4)((byte4)this).zyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 zyxw { readonly get => (sbyte4)((byte4)this).zyxw;  set { byte4 _this = (byte4)this; _this.zyxw = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyyx => (sbyte4)((byte4)this).zyyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyyy => (sbyte4)((byte4)this).zyyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyyz => (sbyte4)((byte4)this).zyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyyw => (sbyte4)((byte4)this).zyyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyzx => (sbyte4)((byte4)this).zyzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyzy => (sbyte4)((byte4)this).zyzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyzz => (sbyte4)((byte4)this).zyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyzw => (sbyte4)((byte4)this).zyzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 zywx { readonly get => (sbyte4)((byte4)this).zywx;  set { byte4 _this = (byte4)this; _this.zywx = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zywy => (sbyte4)((byte4)this).zywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zywz => (sbyte4)((byte4)this).zywz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyww => (sbyte4)((byte4)this).zyww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzxx => (sbyte4)((byte4)this).zzxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzxy => (sbyte4)((byte4)this).zzxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzxz => (sbyte4)((byte4)this).zzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzxw => (sbyte4)((byte4)this).zzxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzyx => (sbyte4)((byte4)this).zzyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzyy => (sbyte4)((byte4)this).zzyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzyz => (sbyte4)((byte4)this).zzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzyw => (sbyte4)((byte4)this).zzyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzzx => (sbyte4)((byte4)this).zzzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzzy => (sbyte4)((byte4)this).zzzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzzz => (sbyte4)((byte4)this).zzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzzw => (sbyte4)((byte4)this).zzzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzwx => (sbyte4)((byte4)this).zzwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzwy => (sbyte4)((byte4)this).zzwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzwz => (sbyte4)((byte4)this).zzwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzww => (sbyte4)((byte4)this).zzww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwxx => (sbyte4)((byte4)this).zwxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 zwxy { readonly get => (sbyte4)((byte4)this).zwxy;  set { byte4 _this = (byte4)this; _this.zwxy = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwxz => (sbyte4)((byte4)this).zwxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwxw => (sbyte4)((byte4)this).zwxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 zwyx { readonly get => (sbyte4)((byte4)this).zwyx;  set { byte4 _this = (byte4)this; _this.zwyx = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwyy => (sbyte4)((byte4)this).zwyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwyz => (sbyte4)((byte4)this).zwyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwyw => (sbyte4)((byte4)this).zwyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwzx => (sbyte4)((byte4)this).zwzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwzy => (sbyte4)((byte4)this).zwzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwzz => (sbyte4)((byte4)this).zwzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwzw => (sbyte4)((byte4)this).zwzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwwx => (sbyte4)((byte4)this).zwwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwwy => (sbyte4)((byte4)this).zwwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwwz => (sbyte4)((byte4)this).zwwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zwww => (sbyte4)((byte4)this).zwww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxxx => (sbyte4)((byte4)this).wxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxxy => (sbyte4)((byte4)this).wxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxxz => (sbyte4)((byte4)this).wxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxxw => (sbyte4)((byte4)this).wxxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxyx => (sbyte4)((byte4)this).wxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxyy => (sbyte4)((byte4)this).wxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 wxyz { readonly get => (sbyte4)((byte4)this).wxyz;  set { byte4 _this = (byte4)this; _this.wxyz = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxyw => (sbyte4)((byte4)this).wxyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxzx => (sbyte4)((byte4)this).wxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 wxzy { readonly get => (sbyte4)((byte4)this).wxzy;  set { byte4 _this = (byte4)this; _this.wxzy = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxzz => (sbyte4)((byte4)this).wxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxzw => (sbyte4)((byte4)this).wxzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxwx => (sbyte4)((byte4)this).wxwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxwy => (sbyte4)((byte4)this).wxwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxwz => (sbyte4)((byte4)this).wxwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wxww => (sbyte4)((byte4)this).wxww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyxx => (sbyte4)((byte4)this).wyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyxy => (sbyte4)((byte4)this).wyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 wyxz { readonly get => (sbyte4)((byte4)this).wyxz;  set { byte4 _this = (byte4)this; _this.wyxz = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyxw => (sbyte4)((byte4)this).wyxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyyx => (sbyte4)((byte4)this).wyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyyy => (sbyte4)((byte4)this).wyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyyz => (sbyte4)((byte4)this).wyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyyw => (sbyte4)((byte4)this).wyyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 wyzx { readonly get => (sbyte4)((byte4)this).wyzx;  set { byte4 _this = (byte4)this; _this.wyzx = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyzy => (sbyte4)((byte4)this).wyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyzz => (sbyte4)((byte4)this).wyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyzw => (sbyte4)((byte4)this).wyzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wywx => (sbyte4)((byte4)this).wywx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wywy => (sbyte4)((byte4)this).wywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wywz => (sbyte4)((byte4)this).wywz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wyww => (sbyte4)((byte4)this).wyww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzxx => (sbyte4)((byte4)this).wzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 wzxy { readonly get => (sbyte4)((byte4)this).wzxy;  set { byte4 _this = (byte4)this; _this.wzxy = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzxz => (sbyte4)((byte4)this).wzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzxw => (sbyte4)((byte4)this).wzxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte4 wzyx { readonly get => (sbyte4)((byte4)this).wzyx;  set { byte4 _this = (byte4)this; _this.wzyx = (byte4)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzyy => (sbyte4)((byte4)this).wzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzyz => (sbyte4)((byte4)this).wzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzyw => (sbyte4)((byte4)this).wzyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzzx => (sbyte4)((byte4)this).wzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzzy => (sbyte4)((byte4)this).wzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzzz => (sbyte4)((byte4)this).wzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzzw => (sbyte4)((byte4)this).wzzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzwx => (sbyte4)((byte4)this).wzwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzwy => (sbyte4)((byte4)this).wzwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzwz => (sbyte4)((byte4)this).wzwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wzww => (sbyte4)((byte4)this).wzww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwxx => (sbyte4)((byte4)this).wwxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwxy => (sbyte4)((byte4)this).wwxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwxz => (sbyte4)((byte4)this).wwxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwxw => (sbyte4)((byte4)this).wwxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwyx => (sbyte4)((byte4)this).wwyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwyy => (sbyte4)((byte4)this).wwyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwyz => (sbyte4)((byte4)this).wwyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwyw => (sbyte4)((byte4)this).wwyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwzx => (sbyte4)((byte4)this).wwzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwzy => (sbyte4)((byte4)this).wwzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwzz => (sbyte4)((byte4)this).wwzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwzw => (sbyte4)((byte4)this).wwzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwwx => (sbyte4)((byte4)this).wwwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwwy => (sbyte4)((byte4)this).wwwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwwz => (sbyte4)((byte4)this).wwwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 wwww => (sbyte4)((byte4)this).wwww;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xxx => (sbyte3)((byte4)this).xxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xxy => (sbyte3)((byte4)this).xxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xxz => (sbyte3)((byte4)this).xxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xxw => (sbyte3)((byte4)this).xxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xyx => (sbyte3)((byte4)this).xyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xyy => (sbyte3)((byte4)this).xyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte3 xyz { readonly get => (sbyte3)((byte4)this).xyz;  set { byte4 _this = (byte4)this; _this.xyz = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte3 xyw { readonly get => (sbyte3)((byte4)this).xyw;  set { byte4 _this = (byte4)this; _this.xyw = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xzx => (sbyte3)((byte4)this).xzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 xzy { readonly get => (sbyte3)((byte4)this).xzy;  set { byte4 _this = (byte4)this; _this.xzy = (byte3)value; this = (sbyte4)_this; } }
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xzz => (sbyte3)((byte4)this).xzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte3 xzw { readonly get => (sbyte3)((byte4)this).xzw;  set { byte4 _this = (byte4)this; _this.xzw = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xwx => (sbyte3)((byte4)this).xwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte3 xwy { readonly get => (sbyte3)((byte4)this).xwy;  set { byte4 _this = (byte4)this; _this.xwy = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte3 xwz { readonly get => (sbyte3)((byte4)this).xwz;  set { byte4 _this = (byte4)this; _this.xwz = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xww => (sbyte3)((byte4)this).xww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yxx => (sbyte3)((byte4)this).yxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yxy => (sbyte3)((byte4)this).yxy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 yxz { readonly get => (sbyte3)((byte4)this).yxz;  set { byte4 _this = (byte4)this; _this.yxz = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte3 yxw { readonly get => (sbyte3)((byte4)this).yxw;  set { byte4 _this = (byte4)this; _this.yxw = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yyx => (sbyte3)((byte4)this).yyx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yyy => (sbyte3)((byte4)this).yyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yyz => (sbyte3)((byte4)this).yyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yyw => (sbyte3)((byte4)this).yyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 yzx { readonly get => (sbyte3)((byte4)this).yzx;  set { byte4 _this = (byte4)this; _this.yzx = (byte3)value; this = (sbyte4)_this; } }
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yzy => (sbyte3)((byte4)this).yzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yzz => (sbyte3)((byte4)this).yzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte3 yzw { readonly get => (sbyte3)((byte4)this).yzw;  set { byte4 _this = (byte4)this; _this.yzw = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte3 ywx { readonly get => (sbyte3)((byte4)this).ywx;  set { byte4 _this = (byte4)this; _this.ywx = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 ywy => (sbyte3)((byte4)this).ywy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public			sbyte3 ywz { readonly get => (sbyte3)((byte4)this).ywz;  set { byte4 _this = (byte4)this; _this.ywz = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yww => (sbyte3)((byte4)this).yww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zxx => (sbyte3)((byte4)this).zxx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 zxy { readonly get => (sbyte3)((byte4)this).zxy;  set { byte4 _this = (byte4)this; _this.zxy = (byte3)value; this = (sbyte4)_this; } }
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zxz => (sbyte3)((byte4)this).zxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 zxw { readonly get => (sbyte3)((byte4)this).zxw;  set { byte4 _this = (byte4)this; _this.zxw = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 zyx { readonly get => (sbyte3)((byte4)this).zyx;  set { byte4 _this = (byte4)this; _this.zyx = (byte3)value; this = (sbyte4)_this; } }
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zyy => (sbyte3)((byte4)this).zyy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zyz => (sbyte3)((byte4)this).zyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 zyw { readonly get => (sbyte3)((byte4)this).zyw;  set { byte4 _this = (byte4)this; _this.zyw = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zzx => (sbyte3)((byte4)this).zzx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zzy => (sbyte3)((byte4)this).zzy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zzz => (sbyte3)((byte4)this).zzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zzw => (sbyte3)((byte4)this).zzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 zwx { readonly get => (sbyte3)((byte4)this).zwx;  set { byte4 _this = (byte4)this; _this.zwx = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 zwy { readonly get => (sbyte3)((byte4)this).zwy;  set { byte4 _this = (byte4)this; _this.zwy = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zwz => (sbyte3)((byte4)this).zwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zww => (sbyte3)((byte4)this).zww;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 wxx => (sbyte3)((byte4)this).wxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 wxy { readonly get => (sbyte3)((byte4)this).wxy;  set { byte4 _this = (byte4)this; _this.wxy = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 wxz { readonly get => (sbyte3)((byte4)this).wxz;  set { byte4 _this = (byte4)this; _this.wxz = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 wxw => (sbyte3)((byte4)this).wxw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 wyx { readonly get => (sbyte3)((byte4)this).wyx;  set { byte4 _this = (byte4)this; _this.wyx = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 wyy => (sbyte3)((byte4)this).wyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 wyz { readonly get => (sbyte3)((byte4)this).wyz;  set { byte4 _this = (byte4)this; _this.wyz = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 wyw => (sbyte3)((byte4)this).wyw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 wzx { readonly get => (sbyte3)((byte4)this).wzx;  set { byte4 _this = (byte4)this; _this.wzx = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 wzy { readonly get => (sbyte3)((byte4)this).wzy;  set { byte4 _this = (byte4)this; _this.wzy = (byte3)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 wzz => (sbyte3)((byte4)this).wzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 wzw => (sbyte3)((byte4)this).wzw;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 wwx => (sbyte3)((byte4)this).wwx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 wwy => (sbyte3)((byte4)this).wwy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 wwz => (sbyte3)((byte4)this).wwz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 www => (sbyte3)((byte4)this).www;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte2 xx => (sbyte2)((byte4)this).xx;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 xy { readonly get => (sbyte2)((byte4)this).xy;  set { byte4 _this = (byte4)this; _this.xy = (byte2)value; this = (sbyte4)_this; } }
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 xz { readonly get => (sbyte2)((byte4)this).xz;  set { byte4 _this = (byte4)this; _this.xz = (byte2)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 xw { readonly get => (sbyte2)((byte4)this).xw;  set { byte4 _this = (byte4)this; _this.xw = (byte2)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 yx { readonly get => (sbyte2)((byte4)this).yx;  set { byte4 _this = (byte4)this; _this.yx = (byte2)value; this = (sbyte4)_this; } }
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte2 yy => (sbyte2)((byte4)this).yy;
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 yz { readonly get => (sbyte2)((byte4)this).yz;  set { byte4 _this = (byte4)this; _this.yz = (byte2)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 yw { readonly get => (sbyte2)((byte4)this).yw;  set { byte4 _this = (byte4)this; _this.yw = (byte2)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 zx { readonly get => (sbyte2)((byte4)this).zx;  set { byte4 _this = (byte4)this; _this.zx = (byte2)value; this = (sbyte4)_this; } }
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 zy { readonly get => (sbyte2)((byte4)this).zy;  set { byte4 _this = (byte4)this; _this.zy = (byte2)value; this = (sbyte4)_this; } }
 
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte2 zz => (sbyte2)((byte4)this).zz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 zw { readonly get => (sbyte2)((byte4)this).zw;  set { byte4 _this = (byte4)this; _this.zw = (byte2)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 wx { readonly get => (sbyte2)((byte4)this).wx;  set { byte4 _this = (byte4)this; _this.wx = (byte2)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 wy { readonly get => (sbyte2)((byte4)this).wy;  set { byte4 _this = (byte4)this; _this.wy = (byte2)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 wz { readonly get => (sbyte2)((byte4)this).wz;  set { byte4 _this = (byte4)this; _this.wz = (byte2)value; this = (sbyte4)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte2 ww => (sbyte2)((byte4)this).ww;
		#endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte4 input) => (byte4)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4(v128 input) => (sbyte4)(byte4)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(bool x) => math.tosbyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(bool4 x) => (sbyte4)(mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(Unity.Mathematics.bool4 x) => (sbyte4)(mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(sbyte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (sbyte4)(mask8x4)x;
            }
            else
            {
                return *(sbyte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (sbyte4)(mask8x4)x;
            }
            else
            {
                return *(sbyte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(mask64x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (sbyte4)(mask8x4)x;
            }
            else
            {
                return *(sbyte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(sbyte4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(sbyte4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(sbyte4 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4(sbyte4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4(sbyte4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4(sbyte4 x) => (mask8x4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(byte x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(ushort x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(short x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(uint x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(int x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(ulong x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(long x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(UInt128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(Int128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(quarter x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(half x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(float x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(double x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(quadruple x) => (sbyte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(Unity.Mathematics.half x) => (sbyte4)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(Unity.Mathematics.half4 x) => (sbyte4)(half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(Unity.Mathematics.float4 x) => (sbyte4)(float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(Unity.Mathematics.double4 x) => (sbyte4)(double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(Unity.Mathematics.uint4 x) => (sbyte4)(uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(Unity.Mathematics.int4 x) => (sbyte4)(int4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half4(sbyte4 x) => (half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(sbyte4 x) => (float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(sbyte4 x) => (double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint4(sbyte4 x) => (uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int4(sbyte4 x) => (int4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4(sbyte input) => new sbyte4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(byte4 input) => *(sbyte4*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(short4 input) => (sbyte4)(byte4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(ushort4 input) => (sbyte4)(byte4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(int4 input) => (sbyte4)(byte4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(uint4 input) => (sbyte4)(byte4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(long4 input) => (sbyte4)(byte4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(ulong4 input) => (sbyte4)(byte4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(float4 input) => (sbyte4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(double4 input) => (sbyte4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(sbyte4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cvtepi8_epi16(input);
			}
            else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(sbyte4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cvtepi8_epi16(input);
			}
            else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(sbyte4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cvtepi8_epi32(input);
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(sbyte4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cvtepi8_epi32(input);
            }
            else
            {
                return new uint4((uint)input.x, (uint)input.y, (uint)input.z, (uint)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(sbyte4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
			{
                return new long4((long2)input.xy, (long2)input.zw);
            }
            else
            {
                return new long4((long)input.x, (long)input.y, (long)input.z, (long)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(sbyte4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
			{
                return new ulong4((ulong2)input.xy, (ulong2)input.zw);
            }
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(sbyte4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_ps(input);
            }
            else
            {
                return (float4)(int4)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(sbyte4 input) => (double4)(int4)input;


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (sbyte)((byte4)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte4 _this = (byte4)this;
                _this[index] = (byte)value;
                this = (sbyte4)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator + (sbyte4 left, sbyte4 right) => (sbyte4)((byte4)left + (byte4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator - (sbyte4 left, sbyte4 right) => (sbyte4)((byte4)left - (byte4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator * (sbyte4 left, sbyte4 right) => (sbyte4)((byte4)left * (byte4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator / (sbyte4 left, sbyte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi8(left, right, false, 4);
            }
            else
            {
                return new sbyte4((sbyte)(left.x / right.x), (sbyte)(left.y / right.y), (sbyte)(left.z / right.z), (sbyte)(left.w / right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator % (sbyte4 left, sbyte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi8(left, right, 4);
            }
            else
            {
                return new sbyte4((sbyte)(left.x % right.x), (sbyte)(left.y % right.y), (sbyte)(left.z % right.z), (sbyte)(left.w % right.w));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator + (sbyte4 left, sbyte right) => left + (sbyte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator + (sbyte left, sbyte4 right) => (sbyte4)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator - (sbyte4 left, sbyte right) => left - (sbyte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator - (sbyte left, sbyte4 right) => (sbyte4)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator * (sbyte4 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constmullo_epi8(left, right, 4);
                }
            }

            return left * (sbyte4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator * (sbyte left, sbyte4 right) => right * left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator / (sbyte left, sbyte4 right) => (sbyte4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator / (sbyte4 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi8(left, right, 4);
                }
            }

            return left / (sbyte4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator % (sbyte left, sbyte4 right) => (sbyte4)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator % (sbyte4 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi8(left, right, 4);
                }
            }

            return left % (sbyte4)right;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator + (sbyte4 left, Unity.Mathematics.int4 right) => left + (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator + (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator - (sbyte4 left, Unity.Mathematics.int4 right) => left - (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator - (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator * (sbyte4 left, Unity.Mathematics.int4 right) => left * (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator * (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator / (sbyte4 left, Unity.Mathematics.int4 right) => left / (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator / (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator % (sbyte4 left, Unity.Mathematics.int4 right) => left % (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator % (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (sbyte4 left, Unity.Mathematics.float4 right) => left + (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (sbyte4 left, Unity.Mathematics.float4 right) => left - (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (sbyte4 left, Unity.Mathematics.float4 right) => left * (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (sbyte4 left, Unity.Mathematics.float4 right) => left / (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (sbyte4 left, Unity.Mathematics.float4 right) => left % (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (sbyte4 left, Unity.Mathematics.double4 right) => left + (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (sbyte4 left, Unity.Mathematics.double4 right) => left - (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (sbyte4 left, Unity.Mathematics.double4 right) => left * (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (sbyte4 left, Unity.Mathematics.double4 right) => left / (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (sbyte4 left, Unity.Mathematics.double4 right) => left % (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator & (sbyte4 left, sbyte4 right) => (sbyte4)((byte4)left & (byte4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator | (sbyte4 left, sbyte4 right) => (sbyte4)((byte4)left | (byte4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ^ (sbyte4 left, sbyte4 right) => (sbyte4)((byte4)left ^ (byte4)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator & (sbyte left, sbyte4 right) => (sbyte4)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator & (sbyte4 left, sbyte right) => left & (sbyte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator | (sbyte left, sbyte4 right) => (sbyte4)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator | (sbyte4 left, sbyte right) => left | (sbyte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ^ (sbyte left, sbyte4 right) => (sbyte4)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ^ (sbyte4 left, sbyte right) => left ^ (sbyte4)right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator & (sbyte4 left, Unity.Mathematics.int4 right) => left & (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator & (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator | (sbyte4 left, Unity.Mathematics.int4 right) => left | (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator | (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ^ (sbyte4 left, Unity.Mathematics.int4 right) => left ^ (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ^ (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator - (sbyte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return new sbyte4((sbyte)(-x.x), (sbyte)(-x.y), (sbyte)(-x.z), (sbyte)(-x.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ++ (sbyte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new sbyte4((sbyte)(x.x + 1), (sbyte)(x.y + 1), (sbyte)(x.z + 1), (sbyte)(x.w + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator -- (sbyte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new sbyte4((sbyte)(x.x - 1), (sbyte)(x.y - 1), (sbyte)(x.z - 1), (sbyte)(x.w - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ~ (sbyte4 x) => (sbyte4)~(byte4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator << (sbyte4 x, int n) => (sbyte4)((byte4)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator >> (sbyte4 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi8(x, n, inRange: true, elements: 4);
            }
            else
            {
                return new sbyte4((sbyte)(x.x >> n), (sbyte)(x.y >> n), (sbyte)(x.z >> n), (sbyte)(x.w >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (sbyte4 left, sbyte4 right) => (byte4)left == (byte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (sbyte4 left, sbyte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epi8(left, right);
            }
            else
            {
                return new mask8x4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (sbyte4 left, sbyte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epi8(left, right);
            }
            else
            {
                return new mask8x4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (sbyte4 left, sbyte4 right) => (byte4)left != (byte4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (sbyte4 left, sbyte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpgt_epi8(left, right));
            }
            else
            {
                return new mask8x4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (sbyte4 left, sbyte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new mask8x4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (sbyte4 left, sbyte right) => left == (sbyte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (sbyte left, sbyte4 right) => (sbyte4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (sbyte4 left, sbyte right) => left != (sbyte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (sbyte left, sbyte4 right) => (sbyte4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (sbyte4 left, sbyte right) => left < (sbyte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (sbyte left, sbyte4 right) => (sbyte4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (sbyte4 left, sbyte right) => left > (sbyte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (sbyte left, sbyte4 right) => (sbyte4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (sbyte4 left, sbyte right) => left <= (sbyte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (sbyte left, sbyte4 right) => (sbyte4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (sbyte4 left, sbyte right) => left >= (sbyte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (sbyte left, sbyte4 right) => (sbyte4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (sbyte4 left, Unity.Mathematics.int4 right) => left == (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (sbyte4 left, Unity.Mathematics.int4 right) => left != (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (sbyte4 left, Unity.Mathematics.int4 right) => left < (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (sbyte4 left, Unity.Mathematics.int4 right) => left > (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (sbyte4 left, Unity.Mathematics.int4 right) => left <= (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (sbyte4 left, Unity.Mathematics.int4 right) => left >= (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.int4 left, sbyte4 right) => (int4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (sbyte4 left, Unity.Mathematics.half4 right) => left == (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.half4 left, sbyte4 right) => (half4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (sbyte4 left, Unity.Mathematics.half4 right) => left != (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.half4 left, sbyte4 right) => (half4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (sbyte4 left, Unity.Mathematics.half4 right) => left < (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.half4 left, sbyte4 right) => (half4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (sbyte4 left, Unity.Mathematics.half4 right) => left > (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.half4 left, sbyte4 right) => (half4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (sbyte4 left, Unity.Mathematics.half4 right) => left <= (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.half4 left, sbyte4 right) => (half4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (sbyte4 left, Unity.Mathematics.half4 right) => left >= (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.half4 left, sbyte4 right) => (half4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (sbyte4 left, Unity.Mathematics.float4 right) => left == (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (sbyte4 left, Unity.Mathematics.float4 right) => left != (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (sbyte4 left, Unity.Mathematics.float4 right) => left < (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (sbyte4 left, Unity.Mathematics.float4 right) => left > (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (sbyte4 left, Unity.Mathematics.float4 right) => left <= (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (sbyte4 left, Unity.Mathematics.float4 right) => left >= (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.float4 left, sbyte4 right) => (float4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (sbyte4 left, Unity.Mathematics.double4 right) => left == (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (sbyte4 left, Unity.Mathematics.double4 right) => left != (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (sbyte4 left, Unity.Mathematics.double4 right) => left < (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (sbyte4 left, Unity.Mathematics.double4 right) => left > (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (sbyte4 left, Unity.Mathematics.double4 right) => left <= (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (sbyte4 left, Unity.Mathematics.double4 right) => left >= (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.double4 left, sbyte4 right) => (double4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte4 other) => ((byte4)this).Equals((byte4)other);

        public override readonly bool Equals(object obj) => obj is sbyte4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"sbyte4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}