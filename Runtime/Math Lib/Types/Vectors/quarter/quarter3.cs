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
    internal sealed class quarter3DebuggerProxy
    {
        public quarter x;
        public quarter y;
        public quarter z;
        
        public quarter3DebuggerProxy(quarter3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(quarter3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct quarter3 : IEquatable<quarter3>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ushort __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal byte __x2;
        
        public ref quarter x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(quarter3* ptr = &this) { return ref *((quarter*)ptr +  0); } } }
        public ref quarter y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(quarter3* ptr = &this) { return ref *((quarter*)ptr +  1); } } }
        public ref quarter z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(quarter3* ptr = &this) { return ref *((quarter*)ptr +  2); } } }


        public static quarter3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter x, quarter y, quarter z)
        {
            this = asquarter(new byte3(x.value, y.value, z.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter xyz)
        {
            this = asquarter(new byte3(xyz.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter2 xy, quarter z)
        {
            this = asquarter(new byte3(asbyte(xy), z.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter x, quarter2 yz)
        {
            this = asquarter(new byte3(x.value, asbyte(yz)));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(bool v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(bool3 v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(mask8x3 v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(mask16x3 v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(mask32x3 v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(mask64x3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(byte v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(byte3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(sbyte v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(sbyte3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(ushort v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(ushort3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(short v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(short3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(uint v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(uint3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(int v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(int3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(ulong v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(ulong3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(long v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(long3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(UInt128 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(Int128 v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quarter3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(half v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(half3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(float v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(float3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(double v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(double3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(quadruple v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(Unity.Mathematics.bool3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(Unity.Mathematics.uint3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(Unity.Mathematics.int3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(Unity.Mathematics.half v)
        {
            this = (quarter3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(Unity.Mathematics.half3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(Unity.Mathematics.float3 v)
        {
            this = (quarter3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter3(Unity.Mathematics.double3 v)
        {
            this = (quarter3)v;
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
        public readonly quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xyz; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzy; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzz); }

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
        public quarter3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxz; }

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
        public quarter3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxy; }

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
        public readonly quarter3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzx; }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxz); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zyx; }

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
        public readonly quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xx); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.xy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.xz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.yx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yy); }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.yz = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.zx = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public quarter2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte3 temp = asbyte(this); temp.zy = asbyte(value); this = asquarter(temp); } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly quarter2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zz); }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter3 input) => asbyte(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter3(v128 input) => asquarter((byte3)input);

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(bool x) => (quarter3)(mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(bool3 x) => (quarter3)(mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(Unity.Mathematics.bool3 x) => (quarter3)(mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(x, Xse.set1_pq((quarter)1f));
            }
            else
            {
                return (quarter3)(*(byte3*)&x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (quarter3)(mask8x3)x;
            }
            else
            {
                return (quarter3)(*(byte3*)&x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (quarter3)(mask8x3)x;
            }
            else
            {
                return (quarter3)(*(byte3*)&x);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(mask64x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (quarter3)(mask8x3)x;
            }
            else
            {
                return *(quarter3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(quarter3 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(quarter3 x) => (bool3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(quarter3 x) => math.andnot(x != 0, math.isnan(x));
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(quarter3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(quarter3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(quarter3 x) => (mask8x3)x;
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(byte x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(sbyte x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(ushort x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(short x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(uint x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(int x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(ulong x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(long x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(UInt128 x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(Int128 x) => (quarter)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(quadruple x) => (quarter)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(Unity.Mathematics.half x) => (quarter3)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(Unity.Mathematics.half3 x) => (quarter3)(half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(Unity.Mathematics.float3 x) => (quarter3)(float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(Unity.Mathematics.double3 x) => (quarter3)(double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(Unity.Mathematics.uint3 x) => (quarter3)(uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(Unity.Mathematics.int3 x) => (quarter3)(int3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half3(quarter3 x) => (half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(quarter3 x) => (float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(quarter3 x) => (double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(quarter3 x) => (uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(quarter3 x) => (int3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter3(quarter input) => new quarter3(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(double input) => (quarter)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(sbyte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_pq(input, MaxMath.quarter.PositiveInfinity, elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(byte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_pq(input, MaxMath.quarter.PositiveInfinity, elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_pq(input, MaxMath.quarter.PositiveInfinity, elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu16_pq(input, MaxMath.quarter.PositiveInfinity, elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(int3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_pq(input, MaxMath.quarter.PositiveInfinity, elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(uint3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_pq(input, MaxMath.quarter.PositiveInfinity, elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x,
                                    (quarter)input.y,
                                    (quarter)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_pq(input, MaxMath.quarter.PositiveInfinity, elements: 3);
            }
            else
            {
                return new quarter3((quarter2)input.xy,
                                    (quarter)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu64_pq(input, MaxMath.quarter.PositiveInfinity, elements: 3);
            }
            else
            {
                return new quarter3((quarter2)input.xy,
                                    (quarter)input.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtph_pq(input, elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x, (quarter)input.y, (quarter)input.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(float3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtps_pq(input, elements: 3);
            }
            else
            {
                return new quarter3((quarter)input.x, (quarter)input.y, (quarter)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter3(double3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpd_pq(input, elements: 3);
            }
            else
            {
                return new quarter3((quarter2)input.xy, (quarter)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(quarter3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi8(input, 3);
            }
            else
            {
                return new sbyte3((sbyte)input.x, (sbyte)input.y, (sbyte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(quarter3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu8(input, 3);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(quarter3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi16(input, 3);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(quarter3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu16(input, 3);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(quarter3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epi32(input, 3);
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(quarter3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpq_epu32(input, 3);
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(quarter3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epi64(input, 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 xy = Xse.cvttpq_epi64(input);
                long z = (long)input.z;

                return new long3(xy, z);
            }
            else
            {
                return new long3((long)input.x, (long)input.y, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(quarter3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpq_epu64(input, 3);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 xy = Xse.cvttpq_epu64(input);
                ulong z = (ulong)input.z;

                return new ulong3(xy, z);
            }
            else
            {
                return new ulong3((ulong)input.x, (ulong)input.y, (ulong)input.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(quarter3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ph(input, elements: 3);
            }
            else
            {
                return new half3((half)input.x, (half)input.y, (half)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(quarter3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtpq_ps(input);
            }
            else
            {
                return new float3(input.x, input.y, input.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(quarter3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtpq_pd(input, elements: 3);
            }
            else
            {
                return new double3((double2)input.xy, (double)input.z);
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
                byte3 cpy = asbyte(this);
                cpy[index] = asbyte(value);
                this = asquarter(cpy);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter3 operator - (quarter3 value)
        {
            return asquarter(asbyte(value) ^ new byte3(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, quarter3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_pq(left, right, elements: 3);
            }
            else
            {
                return new mask8x3(left.x == right.x, left.y == right.y, left.z == right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, quarter right) => left == (quarter3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter left, quarter3 right) => right == left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left == right;
            }
            else
            {
                return (half3)left == right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (half left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left == (float3)right;
            }
            else
            {
                return left == (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, half3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left == right;
            }
            else
            {
                return (half3)left == right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (half3 left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left == (float3)right;
            }
            else
            {
                return left == (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, Unity.Mathematics.half3 right) => left == (half3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.half3 left, quarter3 right) => (half3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, Unity.Mathematics.float3 right) => left == (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.float3 left, quarter3 right) => (float3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, Unity.Mathematics.double3 right) => left == (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.double3 left, quarter3 right) => (double3)left == right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, quarter3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpneq_pq(left, right, elements: 3);
            }
            else
            {
                return new mask8x3(left.x != right.x, left.y != right.y, left.z != right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, quarter right) => left != (quarter3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter left, quarter3 right) => right != left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left != right;
            }
            else
            {
                return (half3)left != right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (half left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left != (float3)right;
            }
            else
            {
                return left != (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, half3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left != right;
            }
            else
            {
                return (half3)left != right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (half3 left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left != (float3)right;
            }
            else
            {
                return left != (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, Unity.Mathematics.half3 right) => left != (half3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.half3 left, quarter3 right) => (half3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, Unity.Mathematics.float3 right) => left != (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.float3 left, quarter3 right) => (float3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, Unity.Mathematics.double3 right) => left != (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.double3 left, quarter3 right) => (double3)left != right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, quarter3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_pq(left, right, elements: 3);
            }
            else
            {
                return new mask8x3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, quarter right) => left < (quarter3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter left, quarter3 right) => (quarter3)left < right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left < right;
            }
            else
            {
                return (half3)left < right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (half left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left < (float3)right;
            }
            else
            {
                return left < (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, half3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left < right;
            }
            else
            {
                return (half3)left < right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (half3 left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left < (float3)right;
            }
            else
            {
                return left < (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, Unity.Mathematics.half3 right) => left < (half3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.half3 left, quarter3 right) => (half3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, Unity.Mathematics.float3 right) => left < (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.float3 left, quarter3 right) => (float3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, Unity.Mathematics.double3 right) => left < (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.double3 left, quarter3 right) => (double3)left < right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, quarter3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_pq(left, right, elements: 3);
            }
            else
            {
                return new mask8x3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, quarter right) => left > (quarter3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter left, quarter3 right) => (quarter3)left > right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left > right;
            }
            else
            {
                return (half3)left > right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (half left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left > (float3)right;
            }
            else
            {
                return left > (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, half3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left > right;
            }
            else
            {
                return (half3)left > right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (half3 left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left > (float3)right;
            }
            else
            {
                return left > (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, Unity.Mathematics.half3 right) => left > (half3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.half3 left, quarter3 right) => (half3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, Unity.Mathematics.float3 right) => left > (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.float3 left, quarter3 right) => (float3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, Unity.Mathematics.double3 right) => left > (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.double3 left, quarter3 right) => (double3)left > right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, quarter3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_pq(left, right, elements: 3);
            }
            else
            {
                return new mask8x3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, quarter right) => left <= (quarter3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter left, quarter3 right) => (quarter3)left <= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left <= right;
            }
            else
            {
                return (half3)left <= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (half left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left <= (float3)right;
            }
            else
            {
                return left <= (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, half3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left <= right;
            }
            else
            {
                return (half3)left <= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (half3 left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left <= (float3)right;
            }
            else
            {
                return left <= (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, Unity.Mathematics.half3 right) => left <= (half3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.half3 left, quarter3 right) => (half3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, Unity.Mathematics.float3 right) => left <= (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.float3 left, quarter3 right) => (float3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, Unity.Mathematics.double3 right) => left <= (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.double3 left, quarter3 right) => (double3)left <= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, quarter3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_pq(left, right, elements: 3);
            }
            else
            {
                return new mask8x3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, quarter right) => left >= (quarter3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter left, quarter3 right) => (quarter3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, half right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left >= right;
            }
            else
            {
                return (half3)left >= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (half left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left >= (float3)right;
            }
            else
            {
                return left >= (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, half3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return (float3)left >= right;
            }
            else
            {
                return (half3)left >= right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (half3 left, quarter3 right)
        {
            if (BurstArchitecture.IsF16Supported)
            {
                return left >= (float3)right;
            }
            else
            {
                return left >= (half3)right;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, Unity.Mathematics.half3 right) => left >= (half3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.half3 left, quarter3 right) => (half3)left >= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, Unity.Mathematics.float3 right) => left >= (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.float3 left, quarter3 right) => (float3)left >= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, Unity.Mathematics.double3 right) => left >= (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.double3 left, quarter3 right) => (double3)left >= right;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left == (quarter)right;
                }
            }

            return (half3)left == right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left != (quarter)right;
                }
            }

            return (half3)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left < (quarter)right;
                }
            }

            return (half3)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left > (quarter)right;
                }
            }

            return (half3)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left <= (quarter)right;
                }
            }

            return (half3)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, Unity.Mathematics.half right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((half)(quarter)right == right)
                {
                    return left >= (quarter)right;
                }
            }

            return (half3)left >= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.half left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left == right;
                }
            }

            return left == (half3)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.half left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left != right;
                }
            }

            return left != (half3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.half left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left < right;
                }
            }

            return left < (half3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.half left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left > right;
                }
            }

            return left > (half3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.half left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left <= right;
                }
            }

            return left <= (half3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.half left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((half)(quarter)left == left)
                {
                    return (quarter)left >= right;
                }
            }

            return left >= (half3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left == (quarter)right;
                }
            }

            return (float3)left == right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left != (quarter)right;
                }
            }

            return (float3)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left < (quarter)right;
                }
            }

            return (float3)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left > (quarter)right;
                }
            }

            return (float3)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left <= (quarter)right;
                }
            }

            return (float3)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, float right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((float)(quarter)right == right)
                {
                    return left >= (quarter)right;
                }
            }

            return (float3)left >= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (float left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left == right;
                }
            }

            return left == (float3)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (float left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left != right;
                }
            }

            return left != (float3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (float left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left < right;
                }
            }

            return left < (float3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (float left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left > right;
                }
            }

            return left > (float3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (float left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left <= right;
                }
            }

            return left <= (float3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (float left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((float)(quarter)left == left)
                {
                    return (quarter)left >= right;
                }
            }

            return left >= (float3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (quarter3 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left == (quarter)right;
                }
            }

            return (double3)left == right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (quarter3 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left != (quarter)right;
                }
            }
            
            return (double3)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (quarter3 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left < (quarter)right;
                }
            }
            
            return (double3)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (quarter3 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left > (quarter)right;
                }
            }
            
            return (double3)left > right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (quarter3 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left <= (quarter)right;
                }
            }
            
            return (double3)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (quarter3 left, double right)
        {
            if (constexpr.IS_CONST(right))
            {
                if ((double)(quarter)right == right)
                {
                    return left >= (quarter)right;
                }
            }
            
            return (double3)left >= right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (double left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left == right;
                }
            }
            
            return left == (double3)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (double left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left != right;
                }
            }
            
            return left != (double3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (double left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left < right;
                }
            }
            
            return left < (double3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (double left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left > right;
                }
            }
            
            return left > (double3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (double left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left <= right;
                }
            }
            
            return left <= (double3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (double left, quarter3 right)
        {
            if (constexpr.IS_CONST(left))
            {
                if ((double)(quarter)left == left)
                {
                    return (quarter)left >= right;
                }
            }
            
            return left >= (double3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(quarter3 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.vcmpeq_pq(this, other, elements: 3);
            }
            else
            {
                return this.x == other.x && this.y == other.y && this.z == other.z;
            }
        }

        public override bool Equals(object obj) => obj is quarter3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"quarter3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"quarter3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}