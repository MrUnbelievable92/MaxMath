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
    internal sealed class long3DebuggerProxy
    {
        public long x;
        public long y;
        public long z;
        
        public long3DebuggerProxy(long3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(long3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct long3 : IEquatable<long3>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal long2 __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ulong __x2;
        
        public ref long x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(long3* ptr = &this) { return ref *((long*)ptr +  0); } } }
        public ref long y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(long3* ptr = &this) { return ref *((long*)ptr +  1); } } }
        public ref long z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(long3* ptr = &this) { return ref *((long*)ptr +  2); } } }


        public static long3 zero => default;



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long x, long y, long z)
        {
            this = (long3)new ulong3((ulong)x, (ulong)y, (ulong)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long xyz)
        {
            this = (long3)new ulong3((ulong)xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long2 xy, long z)
        {
            this = (long3)new ulong3((ulong2)xy, (ulong)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long x, long2 yz)
        {
            this = (long3)new ulong3((ulong)x, (ulong2)yz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(bool v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(bool3 v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(mask8x3 v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(mask16x3 v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(mask32x3 v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(mask64x3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(byte v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(byte3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(sbyte v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(sbyte3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(ushort v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(ushort3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(short v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(short3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(uint v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(uint3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(int v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(int3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(ulong v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(ulong3 v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(UInt128 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(Int128 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(quarter v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(quarter3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(half v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(half3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(float v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(float3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(double v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(double3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(quadruple v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(Unity.Mathematics.bool3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(Unity.Mathematics.uint3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(Unity.Mathematics.int3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(Unity.Mathematics.half v)
        {
            this = (long3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(Unity.Mathematics.half3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(Unity.Mathematics.float3 v)
        {
            this = (long3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(Unity.Mathematics.double3 v)
        {
            this = (long3)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxxx => (long4)((ulong3)this).xxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxxy => (long4)((ulong3)this).xxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxxz => (long4)((ulong3)this).xxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxyx => (long4)((ulong3)this).xxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxyy => (long4)((ulong3)this).xxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxyz => (long4)((ulong3)this).xxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxzx => (long4)((ulong3)this).xxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxzy => (long4)((ulong3)this).xxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xxzz => (long4)((ulong3)this).xxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyxx => (long4)((ulong3)this).xyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyxy => (long4)((ulong3)this).xyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyxz => (long4)((ulong3)this).xyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyyx => (long4)((ulong3)this).xyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyyy => (long4)((ulong3)this).xyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyyz => (long4)((ulong3)this).xyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyzx => (long4)((ulong3)this).xyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyzy => (long4)((ulong3)this).xyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xyzz => (long4)((ulong3)this).xyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzxx => (long4)((ulong3)this).xzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzxy => (long4)((ulong3)this).xzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzxz => (long4)((ulong3)this).xzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzyx => (long4)((ulong3)this).xzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzyy => (long4)((ulong3)this).xzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzyz => (long4)((ulong3)this).xzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzzx => (long4)((ulong3)this).xzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzzy => (long4)((ulong3)this).xzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 xzzz => (long4)((ulong3)this).xzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxxx => (long4)((ulong3)this).yxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxxy => (long4)((ulong3)this).yxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxxz => (long4)((ulong3)this).yxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxyx => (long4)((ulong3)this).yxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxyy => (long4)((ulong3)this).yxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxyz => (long4)((ulong3)this).yxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxzx => (long4)((ulong3)this).yxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxzy => (long4)((ulong3)this).yxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yxzz => (long4)((ulong3)this).yxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyxx => (long4)((ulong3)this).yyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyxy => (long4)((ulong3)this).yyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyxz => (long4)((ulong3)this).yyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyyx => (long4)((ulong3)this).yyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyyy => (long4)((ulong3)this).yyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyyz => (long4)((ulong3)this).yyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyzx => (long4)((ulong3)this).yyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyzy => (long4)((ulong3)this).yyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yyzz => (long4)((ulong3)this).yyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzxx => (long4)((ulong3)this).yzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzxy => (long4)((ulong3)this).yzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzxz => (long4)((ulong3)this).yzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzyx => (long4)((ulong3)this).yzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzyy => (long4)((ulong3)this).yzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzyz => (long4)((ulong3)this).yzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzzx => (long4)((ulong3)this).yzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzzy => (long4)((ulong3)this).yzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 yzzz => (long4)((ulong3)this).yzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxxx => (long4)((ulong3)this).zxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxxy => (long4)((ulong3)this).zxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxxz => (long4)((ulong3)this).zxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxyx => (long4)((ulong3)this).zxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxyy => (long4)((ulong3)this).zxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxyz => (long4)((ulong3)this).zxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxzx => (long4)((ulong3)this).zxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxzy => (long4)((ulong3)this).zxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zxzz => (long4)((ulong3)this).zxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyxx => (long4)((ulong3)this).zyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyxy => (long4)((ulong3)this).zyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyxz => (long4)((ulong3)this).zyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyyx => (long4)((ulong3)this).zyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyyy => (long4)((ulong3)this).zyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyyz => (long4)((ulong3)this).zyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyzx => (long4)((ulong3)this).zyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyzy => (long4)((ulong3)this).zyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zyzz => (long4)((ulong3)this).zyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzxx => (long4)((ulong3)this).zzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzxy => (long4)((ulong3)this).zzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzxz => (long4)((ulong3)this).zzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzyx => (long4)((ulong3)this).zzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzyy => (long4)((ulong3)this).zzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzyz => (long4)((ulong3)this).zzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzzx => (long4)((ulong3)this).zzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzzy => (long4)((ulong3)this).zzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long4 zzzz => (long4)((ulong3)this).zzzz;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xxx => (long3)((ulong3)this).xxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xxy => (long3)((ulong3)this).xxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xxz => (long3)((ulong3)this).xxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xyx => (long3)((ulong3)this).xyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xyy => (long3)((ulong3)this).xyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 xyz { readonly get => (long3)((ulong3)this).xyz;  set { ulong3 _this = (ulong3)this; _this.xyz = (ulong3)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xzx => (long3)((ulong3)this).xzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 xzy { readonly get => (long3)((ulong3)this).xzy;  set { ulong3 _this = (ulong3)this; _this.xzy = (ulong3)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 xzz => (long3)((ulong3)this).xzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yxx => (long3)((ulong3)this).yxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yxy => (long3)((ulong3)this).yxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 yxz { readonly get => (long3)((ulong3)this).yxz;  set { ulong3 _this = (ulong3)this; _this.yxz = (ulong3)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yyx => (long3)((ulong3)this).yyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yyy => (long3)((ulong3)this).yyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yyz => (long3)((ulong3)this).yyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 yzx { readonly get => (long3)((ulong3)this).yzx;  set { ulong3 _this = (ulong3)this; _this.yzx = (ulong3)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yzy => (long3)((ulong3)this).yzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 yzz => (long3)((ulong3)this).yzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zxx => (long3)((ulong3)this).zxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 zxy { readonly get => (long3)((ulong3)this).zxy;  set { ulong3 _this = (ulong3)this; _this.zxy = (ulong3)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zxz => (long3)((ulong3)this).zxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long3 zyx { readonly get => (long3)((ulong3)this).zyx;  set { ulong3 _this = (ulong3)this; _this.zyx = (ulong3)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zyy => (long3)((ulong3)this).zyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zyz => (long3)((ulong3)this).zyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zzx => (long3)((ulong3)this).zzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zzy => (long3)((ulong3)this).zzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long3 zzz => (long3)((ulong3)this).zzz;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long2 xx => (long2)((ulong3)this).xx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 xy { readonly get => (long2)((ulong3)this).xy;  set { ulong3 _this = (ulong3)this; _this.xy = (ulong2)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 xz { readonly get => (long2)((ulong3)this).xz;  set { ulong3 _this = (ulong3)this; _this.xz = (ulong2)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 yx { readonly get => (long2)((ulong3)this).yx;  set { ulong3 _this = (ulong3)this; _this.yx = (ulong2)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long2 yy => (long2)((ulong3)this).yy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 yz { readonly get => (long2)((ulong3)this).yz;  set { ulong3 _this = (ulong3)this; _this.yz = (ulong2)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 zx { readonly get => (long2)((ulong3)this).zx;  set { ulong3 _this = (ulong3)this; _this.zx = (ulong2)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public long2 zy { readonly get => (long2)((ulong3)this).zy;  set { ulong3 _this = (ulong3)this; _this.zy = (ulong2)value; this = (long3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly long2 zz => (long2)((ulong3)this).zz;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(long3 input) => (ulong3)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(v256 input) => (long3)(ulong3)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(bool3 x) => (long3)(mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(Unity.Mathematics.bool3 x) => (long3)(mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (long3)(mask64x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (long3)(mask64x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (long3)(mask64x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(mask64x3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
            }
            else
            {
                return new long3((long2)x.xy, math.tobyte(x.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(long3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(long3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(long3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(long3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(long3 x) => (mask64x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(long3 x) => x != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3(byte x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3(sbyte x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3(ushort x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3(short x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3(uint x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator long3(int x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(ulong x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(UInt128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(Int128 x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(quarter x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(half x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(float x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(double x) => (long)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(quadruple x) => (long)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(Unity.Mathematics.half x) => (long3)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(Unity.Mathematics.half3 x) => (long3)(half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(Unity.Mathematics.float3 x) => (long3)(float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(Unity.Mathematics.double3 x) => (long3)(double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(Unity.Mathematics.uint3 x) => (long3)(uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(Unity.Mathematics.int3 x) => (long3)(int3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half3(long3 x) => (half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(long3 x) => (float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(long3 x) => (double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(long3 x) => (uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int3(long3 x) => (int3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(long input) => new long3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(ulong3 input) => *(long3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(uint3 input) => (long3)(ulong3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(int3 input) => (long3)(ulong3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(float3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epi64(input, 3);
            }
            else
            {
                return new long3((long2)input.xy, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(double3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epi64(input, 3);
            }
            else
            {
                return new long3((long2)input.xy, (long)input.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(long3 input) => (uint3)(ulong3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(long3 input) => (int3)(ulong3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_ps(input, 3);
            }
            else
            {
                return new float3((float2)input.__x0, (float)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_pd(input, 3);
            }
            else
            {
                return new double3((double2)input.__x0, (double)input.z);
            }
        }


        public long this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (long)((ulong3)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ulong3 _this = (ulong3)this;
                _this[index] = (ulong)value;
                this = (long3)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, long3 right) => (long3)((ulong3)left + (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, long3 right) => (long3)((ulong3)left - (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, long3 right) => (long3)((ulong3)left * (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, right, elements: 3);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, right.xy, useFPU: true), left.z / right.z);
			}
			else
			{
				return new long3(left.__x0 / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, right, elements: 3);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, right.xy, useFPU: true), left.z % right.z);
			}
			else
			{
				return new long3(left.__x0 % right.__x0, left.z % right.z);
			}
		}

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, byte right) => left + (byte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, ushort right) => left + (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, uint right) => left + (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, sbyte right) => left + (sbyte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, short right) => left + (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, int right) => left + (int3)right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 operator + (long3 left, long right) => left + (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, byte right) => left - (byte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, ushort right) => left - (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, uint right) => left - (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, sbyte right) => left - (sbyte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, short right) => left - (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, int right) => left - (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, long right) => left - (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, byte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, uint right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, sbyte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, short right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, int right) => right * left;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, long right)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(right))
				{
					return new long3(left.x * right, left.y * right, left.z * right);
				}
			}

            return new long3(left.xy * right, left.z * right);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (byte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (uint3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (sbyte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (short3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, int right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (long)right;
                }
            }

            return left / (int3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, long right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constdiv_epi64(left, right, 3);
                }
            }

            return new long3(left.xy / right, left.z / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (byte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (uint3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (sbyte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (short3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, int right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (long)right;
                }
            }

            return left % (int3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, long right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constrem_epi64(left, right, 3);
                }
            }

            return new long3(left.xy % right, left.z % right);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (byte left, long3 right) => (byte3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (ushort left, long3 right) => (ushort3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (uint left, long3 right) => (uint3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (sbyte left, long3 right) => (sbyte3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (short left, long3 right) => (short3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (int left, long3 right) => (int3)left + right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 operator + (long left, long3 right) => (long3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (byte left, long3 right) => (byte3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (ushort left, long3 right) => (ushort3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (uint left, long3 right) => (uint3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (sbyte left, long3 right) => (sbyte3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (short left, long3 right) => (short3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (int left, long3 right) => (int3)left - right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 operator - (long left, long3 right) => (long3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (byte left, long3 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (ushort left, long3 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (uint left, long3 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (sbyte left, long3 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (short left, long3 right) => (long)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (int left, long3 right) => (long)left * right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long3 operator * (long left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (byte left, long3 right) => (byte3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (ushort left, long3 right) => (ushort3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (uint left, long3 right) => (uint3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (sbyte left, long3 right) => (sbyte3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (short left, long3 right) => (short3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (int left, long3 right) => (int3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long left, long3 right) => (long3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (byte left, long3 right) => (byte3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (ushort left, long3 right) => (ushort3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (uint left, long3 right) => (uint3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (sbyte left, long3 right) => (sbyte3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (short left, long3 right) => (short3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (int left, long3 right) => (int3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long left, long3 right) => (long3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, byte3 right) => left + (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (byte3 left, long3 right) => (long3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, byte3 right) => left - (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (byte3 left, long3 right) => (long3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, byte3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (byte3 left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (byte3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepu8_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(Xse.cvtepu8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), left.z / right.z);
			}
			else
			{
				return new long3(left.xy / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, byte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z / right.z);
			}
			else
			{
				return new long3(left.__x0 / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (byte3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepu8_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(Xse.cvtepu8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), left.z %right.z);
			}
			else
			{
				return new long3(left.xy % right.__x0, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, byte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z % right.z);
			}
			else
			{
				return new long3(left.__x0 % right.xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, ushort3 right) => left + (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (ushort3 left, long3 right) => (long3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, ushort3 right) => left - (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (ushort3 left, long3 right) => (long3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, ushort3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (ushort3 left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (ushort3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepu16_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(Xse.cvtepu16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), left.z / right.z);
			}
			else
			{
				return new long3(left.xy / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, ushort3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z / right.z);
			}
			else
			{
				return new long3(left.__x0 / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (ushort3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepu16_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(Xse.cvtepu16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), left.z % right.z);
			}
			else
			{
				return new long3(left.xy % right.__x0, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, ushort3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z % right.z);
			}
			else
			{
				return new long3(left.__x0 % right.xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, uint3 right) => left + (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (uint3 left, long3 right) => (long3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, uint3 right) => left - (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (uint3 left, long3 right) => (long3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, uint3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (uint3 left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (uint3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepu32_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(Xse.cvtepu32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), left.z / right.z);
			}
			else
			{
				return new long3(left.xy / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, uint3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu32_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z / right.z);
			}
			else
			{
				return new long3(left.__x0 / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (uint3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepu32_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true, aNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(Xse.cvtepu32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true, aNonNegative: true), left.z % right.z);
			}
			else
			{
				return new long3(left.xy % right.__x0, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, uint3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu32_pd(right), elements: 3, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), left.z % right.z);
			}
			else
			{
				return new long3(left.__x0 % right.xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, sbyte3 right) => left + (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (sbyte3 left, long3 right) => (long3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, sbyte3 right) => left - (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (sbyte3 left, long3 right) => (long3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, sbyte3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (sbyte3 left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (sbyte3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepi8_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(Xse.cvtepi8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z / right.z);
			}
			else
			{
				return new long3(left.xy / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, sbyte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepi8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z / right.z);
			}
			else
			{
				return new long3(left.__x0 / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (sbyte3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepi8_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(Xse.cvtepi8_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z % right.z);
			}
			else
			{
				return new long3(left.xy % right.__x0, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, sbyte3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepi8_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepi8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z % right.z);
			}
			else
			{
				return new long3(left.__x0 % right.xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, short3 right) => left + (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (short3 left, long3 right) => (long3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, short3 right) => left - (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (short3 left, long3 right) => (long3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, short3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (short3 left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (short3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Xse.mm256_cvtepi16_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(Xse.cvtepi16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z / right.z);
			}
			else
			{
				return new long3(left.xy / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, short3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepi16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z / right.z);
			}
			else
			{
				return new long3(left.__x0 / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (short3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Xse.mm256_cvtepi16_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(Xse.cvtepi16_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z % right.z);
			}
			else
			{
				return new long3(left.xy % right.__x0, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, short3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepi16_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepi16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z % right.z);
			}
			else
			{
				return new long3(left.__x0 % right.xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, int3 right) => left + (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (int3 left, long3 right) => (long3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, int3 right) => left - (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (int3 left, long3 right) => (long3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, int3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (long3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new long3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (int3 left, long3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (int3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(Avx.mm256_cvtepi32_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(Xse.cvtepi32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z / right.z);
			}
			else
			{
				return new long3(left.xy / right.__x0, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, int3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Avx.mm256_cvtepi32_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.div_epi64(left.xy, Xse.cvtepi32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z / right.z);
			}
			else
			{
				return new long3(left.__x0 / right.xy, left.z / right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (int3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(Avx.mm256_cvtepi32_pd(left), right, elements: 3, aIsDbl: true, aLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(Xse.cvtepi32_pd(left), right.xy, useFPU: true, aIsDbl: true, aLEu32max: true), left.z % right.z);
			}
			else
			{
				return new long3(left.xy % right.__x0, left.z % right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, int3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Avx.mm256_cvtepi32_pd(right), elements: 3, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long3(Xse.rem_epi64(left.xy, Xse.cvtepi32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true), left.z % right.z);
			}
			else
			{
				return new long3(left.__x0 % right.xy, left.z % right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, Unity.Mathematics.int3 right) => left + (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, Unity.Mathematics.int3 right) => left - (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, Unity.Mathematics.int3 right) => left * (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, Unity.Mathematics.int3 right) => left / (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, Unity.Mathematics.int3 right) => left % (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (Unity.Mathematics.int3 left, long3 right) => (int3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (Unity.Mathematics.int3 left, long3 right) => (int3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (Unity.Mathematics.int3 left, long3 right) => (int3)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (Unity.Mathematics.int3 left, long3 right) => (int3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (Unity.Mathematics.int3 left, long3 right) => (int3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 left, Unity.Mathematics.uint3 right) => left + (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 left, Unity.Mathematics.uint3 right) => left - (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 left, Unity.Mathematics.uint3 right) => left * (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 left, Unity.Mathematics.uint3 right) => left / (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 left, Unity.Mathematics.uint3 right) => left % (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (Unity.Mathematics.uint3 left, long3 right) => (uint3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (Unity.Mathematics.uint3 left, long3 right) => (uint3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (Unity.Mathematics.uint3 left, long3 right) => (uint3)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (Unity.Mathematics.uint3 left, long3 right) => (uint3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (Unity.Mathematics.uint3 left, long3 right) => (uint3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (long3 left, Unity.Mathematics.float3 right) => left + (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (long3 left, Unity.Mathematics.float3 right) => left - (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (long3 left, Unity.Mathematics.float3 right) => left * (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (long3 left, Unity.Mathematics.float3 right) => left / (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (long3 left, Unity.Mathematics.float3 right) => left % (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 left, long3 right) => (float3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 left, long3 right) => (float3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 left, long3 right) => (float3)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 left, long3 right) => (float3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 left, long3 right) => (float3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (long3 left, Unity.Mathematics.double3 right) => left + (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (long3 left, Unity.Mathematics.double3 right) => left - (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (long3 left, Unity.Mathematics.double3 right) => left * (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (long3 left, Unity.Mathematics.double3 right) => left / (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (long3 left, Unity.Mathematics.double3 right) => left % (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 left, long3 right) => (double3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 left, long3 right) => (double3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 left, long3 right) => (double3)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 left, long3 right) => (double3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 left, long3 right) => (double3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, long3 right) => (long3)((ulong3)left & (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, long3 right) => (long3)((ulong3)left | (ulong3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, long3 right) => (long3)((ulong3)left ^ (ulong3)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, byte3 right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, byte3 right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, byte3 right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (byte3 left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (byte3 left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (byte3 left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, ushort3 right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, ushort3 right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, ushort3 right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (ushort3 left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (ushort3 left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (ushort3 left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, uint3 right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, uint3 right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, uint3 right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (uint3 left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (uint3 left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (uint3 left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, Unity.Mathematics.uint3 right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, Unity.Mathematics.uint3 right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, Unity.Mathematics.uint3 right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (Unity.Mathematics.uint3 left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (Unity.Mathematics.uint3 left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (Unity.Mathematics.uint3 left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, sbyte3 right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, sbyte3 right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, sbyte3 right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (sbyte3 left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (sbyte3 left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (sbyte3 left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, short3 right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, short3 right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, short3 right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (short3 left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (short3 left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (short3 left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, int3 right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, int3 right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, int3 right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (int3 left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (int3 left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (int3 left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, Unity.Mathematics.int3 right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, Unity.Mathematics.int3 right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, Unity.Mathematics.int3 right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (Unity.Mathematics.int3 left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (Unity.Mathematics.int3 left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (Unity.Mathematics.int3 left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, byte right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, byte right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, byte right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (byte left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (byte left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (byte left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, ushort right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, ushort right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, ushort right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (ushort left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (ushort left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (ushort left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, uint right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, uint right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, uint right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (uint left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (uint left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (uint left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, sbyte right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, sbyte right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, sbyte right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (sbyte left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (sbyte left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (sbyte left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, short right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, short right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, short right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (short left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (short left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (short left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, int right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, int right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, int right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (int left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (int left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (int left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 left, long right) => left & (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 left, long right) => left | (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 left, long right) => left ^ (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long left, long3 right) => (long3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long left, long3 right) => (long3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long left, long3 right) => (long3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 x)
		{
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
			}
			else
            {
				return new long3(-x.__x0, -x.z);
            }
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ++ (long3 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_inc_epi64(x);
			}
			else
			{
				return new long3(x.__x0 + 1, x.z + 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator -- (long3 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_dec_epi64(x);
			}
			else
			{
				return new long3(x.__x0 - 1, x.z - 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ~ (long3 x) => (long3)~(ulong3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator << (long3 x, int n) => (long3)((ulong3)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator >> (long3 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_srai_epi64(x, n, 3);
			}
			else
			{
				return new long3(x.__x0 >> n, x.z >> n);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, long3 right) => (ulong3)left == (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_cmplt_epi64(left, right);
			}
			else
			{
				return new mask64x3(left.__x0 < right.__x0, left.z < right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_cmpgt_epi64(left, right);
			}
			else
			{
				return new mask64x3(left.__x0 > right.__x0, left.z > right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, long3 right) => (ulong3)left != (ulong3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Avx2.mm256_cmpgt_epi64(left, right));
			}
			else
			{
				return new mask64x3(left.__x0 <= right.__x0, left.z <= right.z);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, long3 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Xse.mm256_not_si256(Xse.mm256_cmplt_epi64(left, right));
			}
			else
			{
				return new mask64x3(left.__x0 >= right.__x0, left.z >= right.z);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, byte right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (byte left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, byte right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (byte left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, byte right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (byte left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, byte right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (byte left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, byte right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (byte left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, byte right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (byte left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, ushort right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ushort left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, ushort right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ushort left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, ushort right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ushort left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, ushort right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ushort left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, ushort right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ushort left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, ushort right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ushort left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, uint right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (uint left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, uint right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (uint left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, uint right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (uint left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, uint right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (uint left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, uint right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (uint left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, uint right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (uint left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, sbyte right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (sbyte left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, sbyte right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (sbyte left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, sbyte right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (sbyte left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, sbyte right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (sbyte left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, sbyte right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (sbyte left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, sbyte right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (sbyte left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, short right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (short left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, short right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (short left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, short right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (short left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, short right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (short left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, short right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (short left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, short right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (short left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, int right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (int left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, int right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (int left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, int right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (int left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, int right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (int left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, int right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (int left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, int right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (int left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, long right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, long right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, long right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, long right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, long right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, long right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, byte3 right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (byte3 left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, byte3 right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (byte3 left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, byte3 right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (byte3 left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, byte3 right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (byte3 left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, byte3 right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (byte3 left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, byte3 right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (byte3 left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, ushort3 right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (ushort3 left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, ushort3 right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (ushort3 left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, ushort3 right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (ushort3 left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, ushort3 right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (ushort3 left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, ushort3 right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (ushort3 left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, ushort3 right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (ushort3 left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, uint3 right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (uint3 left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, uint3 right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (uint3 left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, uint3 right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (uint3 left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, uint3 right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (uint3 left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, uint3 right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (uint3 left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, uint3 right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (uint3 left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, Unity.Mathematics.uint3 right) => left == (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.uint3 left, long3 right) => (uint3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, Unity.Mathematics.uint3 right) => left != (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.uint3 left, long3 right) => (uint3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, Unity.Mathematics.uint3 right) => left < (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.uint3 left, long3 right) => (uint3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, Unity.Mathematics.uint3 right) => left > (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.uint3 left, long3 right) => (uint3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, Unity.Mathematics.uint3 right) => left <= (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.uint3 left, long3 right) => (uint3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, Unity.Mathematics.uint3 right) => left >= (uint3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.uint3 left, long3 right) => (uint3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, sbyte3 right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (sbyte3 left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, sbyte3 right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (sbyte3 left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, sbyte3 right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (sbyte3 left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, sbyte3 right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (sbyte3 left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, sbyte3 right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (sbyte3 left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, sbyte3 right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (sbyte3 left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, short3 right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (short3 left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, short3 right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (short3 left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, short3 right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (short3 left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, short3 right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (short3 left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, short3 right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (short3 left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, short3 right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (short3 left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, int3 right) => left == (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (int3 left, long3 right) => (long3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, int3 right) => left != (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (int3 left, long3 right) => (long3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, int3 right) => left < (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (int3 left, long3 right) => (long3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, int3 right) => left > (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (int3 left, long3 right) => (long3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, int3 right) => left <= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (int3 left, long3 right) => (long3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, int3 right) => left >= (long3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (int3 left, long3 right) => (long3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, Unity.Mathematics.int3 right) => left == (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.int3 left, long3 right) => (int3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, Unity.Mathematics.int3 right) => left != (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.int3 left, long3 right) => (int3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, Unity.Mathematics.int3 right) => left < (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.int3 left, long3 right) => (int3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, Unity.Mathematics.int3 right) => left > (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.int3 left, long3 right) => (int3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, Unity.Mathematics.int3 right) => left <= (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.int3 left, long3 right) => (int3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, Unity.Mathematics.int3 right) => left >= (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.int3 left, long3 right) => (int3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, Unity.Mathematics.float3 right) => left == (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.float3 left, long3 right) => (float3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, Unity.Mathematics.float3 right) => left != (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.float3 left, long3 right) => (float3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, Unity.Mathematics.float3 right) => left < (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.float3 left, long3 right) => (float3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, Unity.Mathematics.float3 right) => left > (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.float3 left, long3 right) => (float3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, Unity.Mathematics.float3 right) => left <= (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.float3 left, long3 right) => (float3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, Unity.Mathematics.float3 right) => left >= (float3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.float3 left, long3 right) => (float3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (long3 left, Unity.Mathematics.double3 right) => left == (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator == (Unity.Mathematics.double3 left, long3 right) => (double3)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (long3 left, Unity.Mathematics.double3 right) => left != (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator != (Unity.Mathematics.double3 left, long3 right) => (double3)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (long3 left, Unity.Mathematics.double3 right) => left < (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator < (Unity.Mathematics.double3 left, long3 right) => (double3)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (long3 left, Unity.Mathematics.double3 right) => left > (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator > (Unity.Mathematics.double3 left, long3 right) => (double3)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (long3 left, Unity.Mathematics.double3 right) => left <= (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator <= (Unity.Mathematics.double3 left, long3 right) => (double3)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (long3 left, Unity.Mathematics.double3 right) => left >= (double3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x3 operator >= (Unity.Mathematics.double3 left, long3 right) => (double3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long3 other) => ((ulong3)this).Equals((ulong3)other);

        public override readonly bool Equals(object obj) => obj is long3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"long3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"long3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}