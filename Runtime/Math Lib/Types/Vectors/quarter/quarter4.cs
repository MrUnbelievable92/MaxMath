using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;

namespace MaxMath
{
#if DEBUG
    internal sealed class quarter4DebuggerProxy
    {
	    public quarter x;
	    public quarter y;
	    public quarter z;
	    public quarter w;
        
	    public quarter4DebuggerProxy(quarter4 v)
	    {
	    	x = v.x;
	    	y = v.y;
	    	z = v.z;
	    	w = v.w;
	    }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(quarter4DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct quarter4 : IEquatable<quarter4>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal uint __x0;
		
        public ref quarter x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(quarter4* ptr = &this) { return ref *((quarter*)ptr + 0); } } }
        public ref quarter y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(quarter4* ptr = &this) { return ref *((quarter*)ptr + 1); } } }
        public ref quarter z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(quarter4* ptr = &this) { return ref *((quarter*)ptr + 2); } } }
        public ref quarter w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(quarter4* ptr = &this) { return ref *((quarter*)ptr + 3); } } }


        public static quarter4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter x, quarter y, quarter z, quarter w)
        {
            this = asquarter(new byte4(x.value, y.value, z.value, w.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter xyzw)
        {
            this = asquarter(new byte4(xyzw.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter2 xy, quarter z, quarter w)
        {
            this = asquarter(new byte4(asbyte(xy), z.value, w.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter x, quarter2 yz, quarter w)
        {
            this = asquarter(new byte4(x.value, asbyte(yz), w.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter x, quarter y, quarter2 zw)
        {
            this = asquarter(new byte4(x.value, y.value, asbyte(zw)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter2 xy, quarter2 zw)
        {
            this = asquarter(new byte4(asbyte(xy), asbyte(zw)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter3 xyz, quarter w)
        {
            this = asquarter(new byte4(asbyte(xyz), w.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter x, quarter3 yzw)
        {
            this = asquarter(new byte4(x.value, asbyte(yzw)));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(bool v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(bool4 v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(mask8x4 v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(mask16x4 v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(mask32x4 v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(mask64x4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(byte v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(byte4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(sbyte v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(sbyte4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(ushort v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(ushort4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(short v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(short4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(uint v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(uint4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(int v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(int4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(ulong v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(ulong4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(long v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(long4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(UInt128 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(Int128 v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(half v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(half4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(float v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(float4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(double v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(double4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quadruple v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(Unity.Mathematics.bool4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(Unity.Mathematics.uint4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(Unity.Mathematics.int4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(Unity.Mathematics.half v)
        {
            this = (quarter4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(Unity.Mathematics.half4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(Unity.Mathematics.float4 v)
        {
            this = (quarter4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(Unity.Mathematics.double4 v)
        {
            this = (quarter4)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 xyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xyzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xyzw; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xywx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xywy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xywz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xywz; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzyw; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwyz; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xwyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzwy; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xwzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwzy; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxzw; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxwz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxwz; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yywx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yywy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yywz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxyw; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzwx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxyz; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).ywxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxwy; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).ywzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxzy; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzxw; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywxz; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zyxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zyxw; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zywx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyxz; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zywy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zywz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zwxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwxy; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zwyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzxy; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wxyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzwx; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wxzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywzx; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wyxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zywx; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wyzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyzx; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wywx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wywy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wywz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wzxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwyx; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wzyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzyx; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter4 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwww); }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xyz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xyw = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xzy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xzw = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xwy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xwz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xwz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yxz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yxw = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yzx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yzw = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).ywx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.ywx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).ywz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.ywz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zxy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zxw = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zyx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zyw = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zwx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zwx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zwy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zww); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wxy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wxz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wyx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wyz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wzx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wzy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzw); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).www); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xw = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yw = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zw = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter2 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ww); }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter4 input) => asbyte(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter4(v128 input) => asquarter((byte4)input);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(bool x) => (quarter4)(mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(bool4 x) => (quarter4)(mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(Unity.Mathematics.bool4 x) => (quarter4)(mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_pq((quarter)1f));
            }
            else
            {
                return (quarter4)(*(byte4*)&x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (quarter4)(mask8x4)x;
            }
            else
            {
                return (quarter4)(*(byte4*)&x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (quarter4)(mask8x4)x;
            }
            else
            {
                return (quarter4)(*(byte4*)&x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(mask64x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (quarter4)(mask8x4)x;
            }
            else
            {
                return *(quarter4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(quarter4 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(quarter4 x) => (bool4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(quarter4 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4(quarter4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4(quarter4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4(quarter4 x) => (mask8x4)x;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(byte x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(sbyte x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(ushort x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(short x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(uint x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(int x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(ulong x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(long x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(UInt128 x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(Int128 x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(quadruple x) => (quarter)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(Unity.Mathematics.half x) => (quarter4)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(Unity.Mathematics.half4 x) => (quarter4)(half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(Unity.Mathematics.float4 x) => (quarter4)(float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(Unity.Mathematics.double4 x) => (quarter4)(double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(Unity.Mathematics.uint4 x) => (quarter4)(uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(Unity.Mathematics.int4 x) => (quarter4)(int4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half4(quarter4 x) => (half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(quarter4 x) => (float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(quarter4 x) => (double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint4(quarter4 x) => (uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int4(quarter4 x) => (int4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter4(quarter input) => new quarter4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(double input) => (quarter)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(sbyte4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(input, MaxMath.quarter.PositiveInfinity, elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z,
                                    (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(byte4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(input, MaxMath.quarter.PositiveInfinity, elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z,
                                    (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(short4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pq(input, MaxMath.quarter.PositiveInfinity, elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z,
                                    (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(ushort4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_pq(input, MaxMath.quarter.PositiveInfinity, elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z,
                                    (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(int4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_pq(input, MaxMath.quarter.PositiveInfinity, elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z,
                                    (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(uint4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_pq(input, MaxMath.quarter.PositiveInfinity, elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z,
                                    (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_pq(input, MaxMath.quarter.PositiveInfinity, elements: 4);
            }
            else
            {
                return new quarter4((quarter2)input.xy,
                                    (quarter2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(ulong4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_pq(input, MaxMath.quarter.PositiveInfinity, elements: 4);
            }
            else
            {
                return new quarter4((quarter2)input.xy,
                                    (quarter2)input.zw);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(half4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_pq(input, elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(float4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_pq(input, elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(double4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpd_pq(input, elements: 4);
            }
            else
            {
                return new quarter4((quarter2)input.xy, (quarter2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(quarter4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(input, 4);
            }
            else
            {
                return new sbyte4((sbyte)input.x, (sbyte)input.y, (sbyte)input.z, (sbyte)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(quarter4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(input, 4);
            }
            else
            {
                return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(quarter4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi16(input, 4);
            }
            else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(quarter4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu16(input, 4);
            }
            else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(quarter4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi32(input, 4);
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(quarter4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu32(input, 4);
            }
            else
            {
                return new uint4((uint)input.x, (uint)input.y, (uint)input.z, (uint)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(quarter4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi64(input, 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 xy = Xse.cvttpq_epi64(input);
                v128 zw = Xse.cvttpq_epi64(Xse.bsrli_si128(input, 2 * sizeof(quarter)));

                return new long4(xy, zw);
            }
            else
            {
                return new long4((long)input.x, (long)input.y, (long)input.z, (long)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(quarter4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu64(input, 4);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 xy = Xse.cvttpq_epu64(input);
                v128 zw = Xse.cvttpq_epu64(Xse.bsrli_si128(input, 2 * sizeof(quarter)));

                return new ulong4(xy, zw);
            }
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(quarter4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ph(input, elements: 4);
            }
            else
            {
                return new half4((half)input.x, (half)input.y, (half)input.z, (half)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(quarter4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ps(input);
            }
            else
            {
                return new float4(input.x, input.y, input.z, input.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(quarter4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_pd(input, elements: 4);
            }
            else
            {
                return new double4((double2)input.xy, (double2)input.zw);
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
                byte4 cpy = asbyte(this);
                cpy[index] = asbyte(value);
                this = asquarter(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 operator - (quarter4 value)
        {
            return asquarter(asbyte(value) ^ new byte4(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, quarter4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_pq(left, right, elements: 4);
            }
            else
            {
                return new mask8x4(left.x == right.x, left.y == right.y, left.z == right.z, left.w == right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, quarter right) => left == (quarter4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter left, quarter4 right) => right == left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left == right;
            }
            else
            {
                return (half4)left == right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (half left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left == (float4)right;
            }
            else
            {
                return left == (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, half4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left == right;
            }
            else
            {
                return (half4)left == right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (half4 left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left == (float4)right;
            }
            else
            {
                return left == (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, Unity.Mathematics.half4 right) => left == (half4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.half4 left, quarter4 right) => (half4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, Unity.Mathematics.float4 right) => left == (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.float4 left, quarter4 right) => (float4)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, Unity.Mathematics.double4 right) => left == (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.double4 left, quarter4 right) => (double4)left == right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, quarter4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_pq(left, right, elements: 4);
            }
            else
            {
                return new mask8x4(left.x != right.x, left.y != right.y, left.z != right.z, left.w != right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, quarter right) => left != (quarter4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter left, quarter4 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left != right;
            }
            else
            {
                return (half4)left != right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (half left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left != (float4)right;
            }
            else
            {
                return left != (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, half4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left != right;
            }
            else
            {
                return (half4)left != right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (half4 left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left != (float4)right;
            }
            else
            {
                return left != (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, Unity.Mathematics.half4 right) => left != (half4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.half4 left, quarter4 right) => (half4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, Unity.Mathematics.float4 right) => left != (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.float4 left, quarter4 right) => (float4)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, Unity.Mathematics.double4 right) => left != (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.double4 left, quarter4 right) => (double4)left != right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, quarter4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_pq(left, right, elements: 4);
            }
            else
            {
                return new mask8x4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, quarter right) => left < (quarter4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter left, quarter4 right) => (quarter4)left < right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left < right;
            }
            else
            {
                return (half4)left < right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (half left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left < (float4)right;
            }
            else
            {
                return left < (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, half4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left < right;
            }
            else
            {
                return (half4)left < right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (half4 left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left < (float4)right;
            }
            else
            {
                return left < (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, Unity.Mathematics.half4 right) => left < (half4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.half4 left, quarter4 right) => (half4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, Unity.Mathematics.float4 right) => left < (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.float4 left, quarter4 right) => (float4)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, Unity.Mathematics.double4 right) => left < (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.double4 left, quarter4 right) => (double4)left < right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, quarter4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_pq(left, right, elements: 4);
            }
            else
            {
                return new mask8x4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, quarter right) => left > (quarter4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter left, quarter4 right) => (quarter4)left > right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left > right;
            }
            else
            {
                return (half4)left > right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (half left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left > (float4)right;
            }
            else
            {
                return left > (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, half4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left > right;
            }
            else
            {
                return (half4)left > right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (half4 left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left > (float4)right;
            }
            else
            {
                return left > (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, Unity.Mathematics.half4 right) => left > (half4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.half4 left, quarter4 right) => (half4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, Unity.Mathematics.float4 right) => left > (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.float4 left, quarter4 right) => (float4)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, Unity.Mathematics.double4 right) => left > (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.double4 left, quarter4 right) => (double4)left > right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, quarter4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_pq(left, right, elements: 4);
            }
            else
            {
                return new mask8x4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, quarter right) => left <= (quarter4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter left, quarter4 right) => (quarter4)left <= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left <= right;
            }
            else
            {
                return (half4)left <= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (half left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left <= (float4)right;
            }
            else
            {
                return left <= (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, half4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left <= right;
            }
            else
            {
                return (half4)left <= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (half4 left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left <= (float4)right;
            }
            else
            {
                return left <= (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, Unity.Mathematics.half4 right) => left <= (half4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.half4 left, quarter4 right) => (half4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, Unity.Mathematics.float4 right) => left <= (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.float4 left, quarter4 right) => (float4)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, Unity.Mathematics.double4 right) => left <= (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.double4 left, quarter4 right) => (double4)left <= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, quarter4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_pq(left, right, elements: 4);
            }
            else
            {
                return new mask8x4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, quarter right) => left >= (quarter4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter left, quarter4 right) => (quarter4)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left >= right;
            }
            else
            {
                return (half4)left >= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (half left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left >= (float4)right;
            }
            else
            {
                return left >= (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, half4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float4)left >= right;
            }
            else
            {
                return (half4)left >= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (half4 left, quarter4 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left >= (float4)right;
            }
            else
            {
                return left >= (half4)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, Unity.Mathematics.half4 right) => left >= (half4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.half4 left, quarter4 right) => (half4)left >= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, Unity.Mathematics.float4 right) => left >= (float4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.float4 left, quarter4 right) => (float4)left >= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, Unity.Mathematics.double4 right) => left >= (double4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.double4 left, quarter4 right) => (double4)left >= right;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left == (quarter)right;
                }
            }

            return (half4)left == right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left != (quarter)right;
                }
            }

            return (half4)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left < (quarter)right;
                }
            }

            return (half4)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left > (quarter)right;
                }
            }

            return (half4)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left <= (quarter)right;
                }
            }

            return (half4)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left >= (quarter)right;
                }
            }

            return (half4)left >= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.half left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left == right;
                }
            }

            return left == (half4)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.half left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left != right;
                }
            }

            return left != (half4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.half left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left < right;
                }
            }

            return left < (half4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.half left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left > right;
                }
            }

            return left > (half4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.half left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left <= right;
                }
            }

            return left <= (half4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.half left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left >= right;
                }
            }

            return left >= (half4)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left == (quarter)right;
                }
            }

            return (float4)left == right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left != (quarter)right;
                }
            }

            return (float4)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left < (quarter)right;
                }
            }

            return (float4)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left > (quarter)right;
                }
            }

            return (float4)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left <= (quarter)right;
                }
            }

            return (float4)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left >= (quarter)right;
                }
            }

            return (float4)left >= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (float left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left == right;
                }
            }

            return left == (float4)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (float left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left != right;
                }
            }

            return left != (float4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (float left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left < right;
                }
            }

            return left < (float4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (float left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left > right;
                }
            }

            return left > (float4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (float left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left <= right;
                }
            }

            return left <= (float4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (float left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left >= right;
                }
            }

            return left >= (float4)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (quarter4 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left == (quarter)right;
                }
            }

            return (double4)left == right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (quarter4 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left != (quarter)right;
                }
            }
            
            return (double4)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (quarter4 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left < (quarter)right;
                }
            }
            
            return (double4)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (quarter4 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left > (quarter)right;
                }
            }
            
            return (double4)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (quarter4 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left <= (quarter)right;
                }
            }
            
            return (double4)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (quarter4 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left >= (quarter)right;
                }
            }
            
            return (double4)left >= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (double left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left == right;
                }
            }
            
            return left == (double4)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (double left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left != right;
                }
            }
            
            return left != (double4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (double left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left < right;
                }
            }
            
            return left < (double4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (double left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left > right;
                }
            }
            
            return left > (double4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (double left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left <= right;
                }
            }
            
            return left <= (double4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (double left, quarter4 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left >= right;
                }
            }
            
            return left >= (double4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(quarter4 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vcmpeq_pq(this, other, elements: 4);
            }
            else
            {
                return this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w;
            }
        }

        public override bool Equals(object obj) => obj is quarter4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"quarter4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"quarter4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}