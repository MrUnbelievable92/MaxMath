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
    internal sealed class sbyte3DebuggerProxy
    {
        public sbyte x;
        public sbyte y;
        public sbyte z;
        
        public sbyte3DebuggerProxy(sbyte3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(sbyte3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct sbyte3 : IEquatable<sbyte3>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ushort __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal byte __x2;
        
        public ref sbyte x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte3* ptr = &this) { return ref *((sbyte*)ptr +  0); } } }
        public ref sbyte y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte3* ptr = &this) { return ref *((sbyte*)ptr +  1); } } }
        public ref sbyte z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(sbyte3* ptr = &this) { return ref *((sbyte*)ptr +  2); } } }


        public static sbyte3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte x, sbyte y, sbyte z)
        {
            this = (sbyte3)new byte3((byte)x, (byte)y, (byte)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte xyz)
        {
            this = (sbyte3)new byte3((byte)xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte2 xy, sbyte z)
        {
            this = (sbyte3)new byte3((byte2)xy, (byte)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte x, sbyte2 yz)
        {
            this = (sbyte3)new byte3((byte)x, (byte2)yz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(bool v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(bool3 v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(mask8x3 v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(mask16x3 v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(mask32x3 v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(mask64x3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(byte v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(byte3 v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(ushort v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(ushort3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(short v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(short3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(uint v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(uint3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(int v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(int3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(ulong v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(ulong3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(long v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(long3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(UInt128 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(Int128 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(quarter v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(quarter3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(half v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(half3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(float v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(float3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(double v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(double3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(quadruple v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(Unity.Mathematics.bool3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(Unity.Mathematics.uint3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(Unity.Mathematics.int3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(Unity.Mathematics.half v)
        {
            this = (sbyte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(Unity.Mathematics.half3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(Unity.Mathematics.float3 v)
        {
            this = (sbyte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(Unity.Mathematics.double3 v)
        {
            this = (sbyte3)v;
        }

        #region Shuffle

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxxx => (sbyte4)((byte3)this).xxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxxy => (sbyte4)((byte3)this).xxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxxz => (sbyte4)((byte3)this).xxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxyx => (sbyte4)((byte3)this).xxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxyy => (sbyte4)((byte3)this).xxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxyz => (sbyte4)((byte3)this).xxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxzx => (sbyte4)((byte3)this).xxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxzy => (sbyte4)((byte3)this).xxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xxzz => (sbyte4)((byte3)this).xxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyxx => (sbyte4)((byte3)this).xyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyxy => (sbyte4)((byte3)this).xyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyxz => (sbyte4)((byte3)this).xyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyyx => (sbyte4)((byte3)this).xyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyyy => (sbyte4)((byte3)this).xyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyyz => (sbyte4)((byte3)this).xyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyzx => (sbyte4)((byte3)this).xyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyzy => (sbyte4)((byte3)this).xyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xyzz => (sbyte4)((byte3)this).xyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzxx => (sbyte4)((byte3)this).xzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzxy => (sbyte4)((byte3)this).xzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzxz => (sbyte4)((byte3)this).xzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzyx => (sbyte4)((byte3)this).xzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzyy => (sbyte4)((byte3)this).xzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzyz => (sbyte4)((byte3)this).xzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzzx => (sbyte4)((byte3)this).xzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzzy => (sbyte4)((byte3)this).xzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 xzzz => (sbyte4)((byte3)this).xzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxxx => (sbyte4)((byte3)this).yxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxxy => (sbyte4)((byte3)this).yxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxxz => (sbyte4)((byte3)this).yxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxyx => (sbyte4)((byte3)this).yxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxyy => (sbyte4)((byte3)this).yxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxyz => (sbyte4)((byte3)this).yxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxzx => (sbyte4)((byte3)this).yxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxzy => (sbyte4)((byte3)this).yxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yxzz => (sbyte4)((byte3)this).yxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyxx => (sbyte4)((byte3)this).yyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyxy => (sbyte4)((byte3)this).yyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyxz => (sbyte4)((byte3)this).yyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyyx => (sbyte4)((byte3)this).yyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyyy => (sbyte4)((byte3)this).yyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyyz => (sbyte4)((byte3)this).yyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyzx => (sbyte4)((byte3)this).yyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyzy => (sbyte4)((byte3)this).yyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yyzz => (sbyte4)((byte3)this).yyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzxx => (sbyte4)((byte3)this).yzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzxy => (sbyte4)((byte3)this).yzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzxz => (sbyte4)((byte3)this).yzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzyx => (sbyte4)((byte3)this).yzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzyy => (sbyte4)((byte3)this).yzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzyz => (sbyte4)((byte3)this).yzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzzx => (sbyte4)((byte3)this).yzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzzy => (sbyte4)((byte3)this).yzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 yzzz => (sbyte4)((byte3)this).yzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxxx => (sbyte4)((byte3)this).zxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxxy => (sbyte4)((byte3)this).zxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxxz => (sbyte4)((byte3)this).zxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxyx => (sbyte4)((byte3)this).zxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxyy => (sbyte4)((byte3)this).zxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxyz => (sbyte4)((byte3)this).zxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxzx => (sbyte4)((byte3)this).zxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxzy => (sbyte4)((byte3)this).zxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zxzz => (sbyte4)((byte3)this).zxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyxx => (sbyte4)((byte3)this).zyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyxy => (sbyte4)((byte3)this).zyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyxz => (sbyte4)((byte3)this).zyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyyx => (sbyte4)((byte3)this).zyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyyy => (sbyte4)((byte3)this).zyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyyz => (sbyte4)((byte3)this).zyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyzx => (sbyte4)((byte3)this).zyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyzy => (sbyte4)((byte3)this).zyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zyzz => (sbyte4)((byte3)this).zyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzxx => (sbyte4)((byte3)this).zzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzxy => (sbyte4)((byte3)this).zzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzxz => (sbyte4)((byte3)this).zzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzyx => (sbyte4)((byte3)this).zzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzyy => (sbyte4)((byte3)this).zzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzyz => (sbyte4)((byte3)this).zzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzzx => (sbyte4)((byte3)this).zzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzzy => (sbyte4)((byte3)this).zzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte4 zzzz => (sbyte4)((byte3)this).zzzz;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xxx => (sbyte3)((byte3)this).xxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xxy => (sbyte3)((byte3)this).xxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xxz => (sbyte3)((byte3)this).xxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xyx => (sbyte3)((byte3)this).xyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xyy => (sbyte3)((byte3)this).xyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 xyz { readonly get => (sbyte3)((byte3)this).xyz;  set { byte3 _this = (byte3)this; _this.xyz = (byte3)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xzx => (sbyte3)((byte3)this).xzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 xzy { readonly get => (sbyte3)((byte3)this).xzy;  set { byte3 _this = (byte3)this; _this.xzy = (byte3)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 xzz => (sbyte3)((byte3)this).xzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yxx => (sbyte3)((byte3)this).yxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yxy => (sbyte3)((byte3)this).yxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 yxz { readonly get => (sbyte3)((byte3)this).yxz;  set { byte3 _this = (byte3)this; _this.yxz = (byte3)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yyx => (sbyte3)((byte3)this).yyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yyy => (sbyte3)((byte3)this).yyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yyz => (sbyte3)((byte3)this).yyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 yzx { readonly get => (sbyte3)((byte3)this).yzx;  set { byte3 _this = (byte3)this; _this.yzx = (byte3)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yzy => (sbyte3)((byte3)this).yzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 yzz => (sbyte3)((byte3)this).yzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zxx => (sbyte3)((byte3)this).zxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 zxy { readonly get => (sbyte3)((byte3)this).zxy;  set { byte3 _this = (byte3)this; _this.zxy = (byte3)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zxz => (sbyte3)((byte3)this).zxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte3 zyx { readonly get => (sbyte3)((byte3)this).zyx;  set { byte3 _this = (byte3)this; _this.zyx = (byte3)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zyy => (sbyte3)((byte3)this).zyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zyz => (sbyte3)((byte3)this).zyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zzx => (sbyte3)((byte3)this).zzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zzy => (sbyte3)((byte3)this).zzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte3 zzz => (sbyte3)((byte3)this).zzz;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte2 xx => (sbyte2)((byte3)this).xx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 xy { readonly get => (sbyte2)((byte3)this).xy;  set { byte3 _this = (byte3)this; _this.xy = (byte2)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 xz { readonly get => (sbyte2)((byte3)this).xz;  set { byte3 _this = (byte3)this; _this.xz = (byte2)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 yx { readonly get => (sbyte2)((byte3)this).yx;  set { byte3 _this = (byte3)this; _this.yx = (byte2)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte2 yy => (sbyte2)((byte3)this).yy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 yz { readonly get => (sbyte2)((byte3)this).yz;  set { byte3 _this = (byte3)this; _this.yz = (byte2)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 zx { readonly get => (sbyte2)((byte3)this).zx;  set { byte3 _this = (byte3)this; _this.zx = (byte2)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public sbyte2 zy { readonly get => (sbyte2)((byte3)this).zy;  set { byte3 _this = (byte3)this; _this.zy = (byte2)value; this = (sbyte3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly sbyte2 zz => (sbyte2)((byte3)this).zz;
		#endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte3 input) => (byte3)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte3(v128 input) => (sbyte3)(byte3)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(bool x) => math.tosbyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(bool3 x) => (sbyte3)(mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(Unity.Mathematics.bool3 x) => (sbyte3)(mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(sbyte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (sbyte3)(mask8x3)x;
            }
            else
            {
                return *(sbyte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (sbyte3)(mask8x3)x;
            }
            else
            {
                return *(sbyte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(mask64x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (sbyte3)(mask8x3)x;
            }
            else
            {
                return *(sbyte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(sbyte3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(sbyte3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(sbyte3 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(sbyte3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(sbyte3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(sbyte3 x) => (mask8x3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(byte x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(ushort x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(short x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(uint x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(int x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(ulong x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(long x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(UInt128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(Int128 x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(quarter x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(half x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(float x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(double x) => (sbyte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(quadruple x) => (sbyte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(Unity.Mathematics.half x) => (sbyte3)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(Unity.Mathematics.half3 x) => (sbyte3)(half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(Unity.Mathematics.float3 x) => (sbyte3)(float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(Unity.Mathematics.double3 x) => (sbyte3)(double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(Unity.Mathematics.uint3 x) => (sbyte3)(uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(Unity.Mathematics.int3 x) => (sbyte3)(int3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half3(sbyte3 x) => (half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(sbyte3 x) => (float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(sbyte3 x) => (double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint3(sbyte3 x) => (uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int3(sbyte3 x) => (int3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte3(sbyte input) => new sbyte3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(byte3 input) => *(sbyte3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(short3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(ushort3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(int3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(uint3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(long3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(ulong3 input) => (sbyte3)(byte3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(float3 input) => (sbyte3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(double3 input) => (sbyte3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(sbyte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi16(input);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(sbyte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi16(input);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(sbyte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi32(input);
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(sbyte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_epi32(input);
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(sbyte3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long3((long2)input.xy, (long)input.z);
            }
            else
            {
                return new long3((long)input.x, (long)input.y, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(sbyte3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
            else
            {
                return new ulong3((ulong)input.x, (ulong)input.y, (ulong)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(sbyte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi8_ps(input);
            }
            else
            {
                return (float3)(int3)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(sbyte3 input) => (double3)(int3)input;


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (sbyte)((byte3)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                byte3 _this = (byte3)this;
                _this[index] = (byte)value;
                this = (sbyte3)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator + (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left + (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator - (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left - (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator * (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left * (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator / (sbyte3 left, sbyte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi8(left, right, false, 3);
            }
            else
            {
                return new sbyte3((sbyte)(left.x / right.x), (sbyte)(left.y / right.y), (sbyte)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator % (sbyte3 left, sbyte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi8(left, right, 3);
            }
            else
            {
                return new sbyte3((sbyte)(left.x % right.x), (sbyte)(left.y % right.y), (sbyte)(left.z % right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator + (sbyte3 left, sbyte right) => left + (sbyte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator + (sbyte left, sbyte3 right) => (sbyte3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator - (sbyte3 left, sbyte right) => left - (sbyte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator - (sbyte left, sbyte3 right) => (sbyte3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator * (sbyte3 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constmullo_epi8(left, right, 3);
                }
            }

            return left * (sbyte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator * (sbyte left, sbyte3 right) => right * left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator / (sbyte left, sbyte3 right) => (sbyte3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator / (sbyte3 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi8(left, right, 3);
                }
            }

            return left / (sbyte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator % (sbyte left, sbyte3 right) => (sbyte3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator % (sbyte3 left, sbyte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi8(left, right, 3);
                }
            }

            return left % (sbyte3)right;
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (sbyte3 left, Unity.Mathematics.int3 right) => left + (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (sbyte3 left, Unity.Mathematics.int3 right) => left - (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (sbyte3 left, Unity.Mathematics.int3 right) => left * (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (sbyte3 left, Unity.Mathematics.int3 right) => left / (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (sbyte3 left, Unity.Mathematics.int3 right) => left % (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (sbyte3 left, Unity.Mathematics.float3 right) => left + (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (sbyte3 left, Unity.Mathematics.float3 right) => left - (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (sbyte3 left, Unity.Mathematics.float3 right) => left * (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (sbyte3 left, Unity.Mathematics.float3 right) => left / (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (sbyte3 left, Unity.Mathematics.float3 right) => left % (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (sbyte3 left, Unity.Mathematics.double3 right) => left + (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (sbyte3 left, Unity.Mathematics.double3 right) => left - (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (sbyte3 left, Unity.Mathematics.double3 right) => left * (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (sbyte3 left, Unity.Mathematics.double3 right) => left / (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (sbyte3 left, Unity.Mathematics.double3 right) => left % (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator & (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left & (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator | (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left | (byte3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ^ (sbyte3 left, sbyte3 right) => (sbyte3)((byte3)left ^ (byte3)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator & (sbyte left, sbyte3 right) => (sbyte3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator & (sbyte3 left, sbyte right) => left & (sbyte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator | (sbyte left, sbyte3 right) => (sbyte3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator | (sbyte3 left, sbyte right) => left | (sbyte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ^ (sbyte left, sbyte3 right) => (sbyte3)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ^ (sbyte3 left, sbyte right) => left ^ (sbyte3)right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (sbyte3 left, Unity.Mathematics.int3 right) => left & (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (sbyte3 left, Unity.Mathematics.int3 right) => left | (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (sbyte3 left, Unity.Mathematics.int3 right) => left ^ (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator - (sbyte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return new sbyte3((sbyte)(-x.x), (sbyte)(-x.y), (sbyte)(-x.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ++ (sbyte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new sbyte3((sbyte)(x.x + 1), (sbyte)(x.y + 1), (sbyte)(x.z + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator -- (sbyte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new sbyte3((sbyte)(x.x - 1), (sbyte)(x.y - 1), (sbyte)(x.z - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ~ (sbyte3 x) => (sbyte3)~(byte3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator << (sbyte3 x, int n) => (sbyte3)((byte3)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator >> (sbyte3 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi8(x, n, inRange: true, elements: 3);
            }
            else
            {
                return new sbyte3((sbyte)(x.x >> n), (sbyte)(x.y >> n), (sbyte)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (sbyte3 left, sbyte3 right) => (byte3)left == (byte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (sbyte3 left, sbyte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epi8(left, right);
            }
            else
            {
                return new mask8x3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (sbyte3 left, sbyte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epi8(left, right);
            }
            else
            {
                return new mask8x3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (sbyte3 left, sbyte3 right) => (byte3)left != (byte3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (sbyte3 left, sbyte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpgt_epi8(left, right));
            }
            else
            {
                return new mask8x3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (sbyte3 left, sbyte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmplt_epi8(left, right));
            }
            else
            {
                return new mask8x3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (sbyte3 left, sbyte right) => left == (sbyte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (sbyte left, sbyte3 right) => (sbyte3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (sbyte3 left, sbyte right) => left != (sbyte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (sbyte left, sbyte3 right) => (sbyte3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (sbyte3 left, sbyte right) => left < (sbyte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (sbyte left, sbyte3 right) => (sbyte3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (sbyte3 left, sbyte right) => left > (sbyte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (sbyte left, sbyte3 right) => (sbyte3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (sbyte3 left, sbyte right) => left <= (sbyte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (sbyte left, sbyte3 right) => (sbyte3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (sbyte3 left, sbyte right) => left >= (sbyte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (sbyte left, sbyte3 right) => (sbyte3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (sbyte3 left, Unity.Mathematics.int3 right) => left == (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (sbyte3 left, Unity.Mathematics.int3 right) => left != (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (sbyte3 left, Unity.Mathematics.int3 right) => left < (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (sbyte3 left, Unity.Mathematics.int3 right) => left > (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (sbyte3 left, Unity.Mathematics.int3 right) => left <= (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (sbyte3 left, Unity.Mathematics.int3 right) => left >= (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.int3 left, sbyte3 right) => (int3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (sbyte3 left, Unity.Mathematics.half3 right) => left == (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.half3 left, sbyte3 right) => (half3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (sbyte3 left, Unity.Mathematics.half3 right) => left != (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.half3 left, sbyte3 right) => (half3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (sbyte3 left, Unity.Mathematics.half3 right) => left < (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.half3 left, sbyte3 right) => (half3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (sbyte3 left, Unity.Mathematics.half3 right) => left > (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.half3 left, sbyte3 right) => (half3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (sbyte3 left, Unity.Mathematics.half3 right) => left <= (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.half3 left, sbyte3 right) => (half3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (sbyte3 left, Unity.Mathematics.half3 right) => left >= (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.half3 left, sbyte3 right) => (half3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (sbyte3 left, Unity.Mathematics.float3 right) => left == (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (sbyte3 left, Unity.Mathematics.float3 right) => left != (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (sbyte3 left, Unity.Mathematics.float3 right) => left < (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (sbyte3 left, Unity.Mathematics.float3 right) => left > (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (sbyte3 left, Unity.Mathematics.float3 right) => left <= (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (sbyte3 left, Unity.Mathematics.float3 right) => left >= (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.float3 left, sbyte3 right) => (float3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (sbyte3 left, Unity.Mathematics.double3 right) => left == (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (sbyte3 left, Unity.Mathematics.double3 right) => left != (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (sbyte3 left, Unity.Mathematics.double3 right) => left < (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (sbyte3 left, Unity.Mathematics.double3 right) => left > (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (sbyte3 left, Unity.Mathematics.double3 right) => left <= (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (sbyte3 left, Unity.Mathematics.double3 right) => left >= (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.double3 left, sbyte3 right) => (double3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(sbyte3 other) => ((byte3)this).Equals((byte3)other);

        public override readonly bool Equals(object obj) => obj is sbyte3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);

        public override string ToString() => $"sbyte3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}