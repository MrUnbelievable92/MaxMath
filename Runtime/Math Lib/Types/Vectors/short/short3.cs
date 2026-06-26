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
    internal sealed class short3DebuggerProxy
    {
        public short x;
        public short y;
        public short z;
        
        public short3DebuggerProxy(short3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(short3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct short3 : IEquatable<short3>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal uint __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ushort __x2;
        
        public ref short x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short3* ptr = &this) { return ref *((short*)ptr +  0); } } }
        public ref short y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short3* ptr = &this) { return ref *((short*)ptr +  1); } } }
        public ref short z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(short3* ptr = &this) { return ref *((short*)ptr +  2); } } }


        public static short3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short x, short y, short z)
        {
            this = (short3)new ushort3((ushort)x, (ushort)y, (ushort)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short xyz)
        {
            this = (short3)new ushort3((ushort)xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short2 xy, short z)
        {
            this = (short3)new ushort3((ushort2)xy, (ushort)z);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short x, short2 yz)
        {
            this = (short3)new ushort3((ushort)x, (ushort2)yz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(bool v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(bool3 v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(mask8x3 v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(mask16x3 v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(mask32x3 v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(mask64x3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(byte v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(byte3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(sbyte v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(sbyte3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(ushort v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(ushort3 v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(uint v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(uint3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(int v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(int3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(ulong v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(ulong3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(long v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(long3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(UInt128 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(Int128 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(quarter v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(quarter3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(half v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(half3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(float v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(float3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(double v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(double3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(quadruple v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(Unity.Mathematics.bool3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(Unity.Mathematics.uint3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(Unity.Mathematics.int3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(Unity.Mathematics.half v)
        {
            this = (short3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(Unity.Mathematics.half3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(Unity.Mathematics.float3 v)
        {
            this = (short3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(Unity.Mathematics.double3 v)
        {
            this = (short3)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxxx => (short4)((ushort3)this).xxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxxy => (short4)((ushort3)this).xxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxxz => (short4)((ushort3)this).xxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxyx => (short4)((ushort3)this).xxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxyy => (short4)((ushort3)this).xxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxyz => (short4)((ushort3)this).xxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxzx => (short4)((ushort3)this).xxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxzy => (short4)((ushort3)this).xxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xxzz => (short4)((ushort3)this).xxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyxx => (short4)((ushort3)this).xyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyxy => (short4)((ushort3)this).xyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyxz => (short4)((ushort3)this).xyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyyx => (short4)((ushort3)this).xyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyyy => (short4)((ushort3)this).xyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyyz => (short4)((ushort3)this).xyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyzx => (short4)((ushort3)this).xyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyzy => (short4)((ushort3)this).xyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xyzz => (short4)((ushort3)this).xyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xzxx => (short4)((ushort3)this).xzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xzxy => (short4)((ushort3)this).xzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xzxz => (short4)((ushort3)this).xzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xzyx => (short4)((ushort3)this).xzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xzyy => (short4)((ushort3)this).xzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xzyz => (short4)((ushort3)this).xzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xzzx => (short4)((ushort3)this).xzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xzzy => (short4)((ushort3)this).xzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 xzzz => (short4)((ushort3)this).xzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxxx => (short4)((ushort3)this).yxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxxy => (short4)((ushort3)this).yxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxxz => (short4)((ushort3)this).yxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxyx => (short4)((ushort3)this).yxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxyy => (short4)((ushort3)this).yxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxyz => (short4)((ushort3)this).yxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxzx => (short4)((ushort3)this).yxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxzy => (short4)((ushort3)this).yxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yxzz => (short4)((ushort3)this).yxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyxx => (short4)((ushort3)this).yyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyxy => (short4)((ushort3)this).yyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyxz => (short4)((ushort3)this).yyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyyx => (short4)((ushort3)this).yyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyyy => (short4)((ushort3)this).yyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyyz => (short4)((ushort3)this).yyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyzx => (short4)((ushort3)this).yyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyzy => (short4)((ushort3)this).yyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yyzz => (short4)((ushort3)this).yyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yzxx => (short4)((ushort3)this).yzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yzxy => (short4)((ushort3)this).yzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yzxz => (short4)((ushort3)this).yzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yzyx => (short4)((ushort3)this).yzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yzyy => (short4)((ushort3)this).yzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yzyz => (short4)((ushort3)this).yzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yzzx => (short4)((ushort3)this).yzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yzzy => (short4)((ushort3)this).yzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 yzzz => (short4)((ushort3)this).yzzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zxxx => (short4)((ushort3)this).zxxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zxxy => (short4)((ushort3)this).zxxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zxxz => (short4)((ushort3)this).zxxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zxyx => (short4)((ushort3)this).zxyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zxyy => (short4)((ushort3)this).zxyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zxyz => (short4)((ushort3)this).zxyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zxzx => (short4)((ushort3)this).zxzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zxzy => (short4)((ushort3)this).zxzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zxzz => (short4)((ushort3)this).zxzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zyxx => (short4)((ushort3)this).zyxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zyxy => (short4)((ushort3)this).zyxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zyxz => (short4)((ushort3)this).zyxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zyyx => (short4)((ushort3)this).zyyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zyyy => (short4)((ushort3)this).zyyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zyyz => (short4)((ushort3)this).zyyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zyzx => (short4)((ushort3)this).zyzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zyzy => (short4)((ushort3)this).zyzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zyzz => (short4)((ushort3)this).zyzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zzxx => (short4)((ushort3)this).zzxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zzxy => (short4)((ushort3)this).zzxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zzxz => (short4)((ushort3)this).zzxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zzyx => (short4)((ushort3)this).zzyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zzyy => (short4)((ushort3)this).zzyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zzyz => (short4)((ushort3)this).zzyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zzzx => (short4)((ushort3)this).zzzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zzzy => (short4)((ushort3)this).zzzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short4 zzzz => (short4)((ushort3)this).zzzz;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xxx => (short3)((ushort3)this).xxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xxy => (short3)((ushort3)this).xxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xxz => (short3)((ushort3)this).xxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xyx => (short3)((ushort3)this).xyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xyy => (short3)((ushort3)this).xyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 xyz { readonly get => (short3)((ushort3)this).xyz;  set { ushort3 _this = (ushort3)this; _this.xyz = (ushort3)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xzx => (short3)((ushort3)this).xzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 xzy { readonly get => (short3)((ushort3)this).xzy;  set { ushort3 _this = (ushort3)this; _this.xzy = (ushort3)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 xzz => (short3)((ushort3)this).xzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yxx => (short3)((ushort3)this).yxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yxy => (short3)((ushort3)this).yxy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 yxz { readonly get => (short3)((ushort3)this).yxz;  set { ushort3 _this = (ushort3)this; _this.yxz = (ushort3)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yyx => (short3)((ushort3)this).yyx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yyy => (short3)((ushort3)this).yyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yyz => (short3)((ushort3)this).yyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 yzx { readonly get => (short3)((ushort3)this).yzx;  set { ushort3 _this = (ushort3)this; _this.yzx = (ushort3)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yzy => (short3)((ushort3)this).yzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 yzz => (short3)((ushort3)this).yzz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 zxx => (short3)((ushort3)this).zxx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 zxy { readonly get => (short3)((ushort3)this).zxy;  set { ushort3 _this = (ushort3)this; _this.zxy = (ushort3)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 zxz => (short3)((ushort3)this).zxz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short3 zyx { readonly get => (short3)((ushort3)this).zyx;  set { ushort3 _this = (ushort3)this; _this.zyx = (ushort3)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 zyy => (short3)((ushort3)this).zyy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 zyz => (short3)((ushort3)this).zyz;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 zzx => (short3)((ushort3)this).zzx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 zzy => (short3)((ushort3)this).zzy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short3 zzz => (short3)((ushort3)this).zzz;


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short2 xx => (short2)((ushort3)this).xx;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 xy { readonly get => (short2)((ushort3)this).xy;  set { ushort3 _this = (ushort3)this; _this.xy = (ushort2)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 xz { readonly get => (short2)((ushort3)this).xz;  set { ushort3 _this = (ushort3)this; _this.xz = (ushort2)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 yx { readonly get => (short2)((ushort3)this).yx;  set { ushort3 _this = (ushort3)this; _this.yx = (ushort2)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short2 yy => (short2)((ushort3)this).yy;

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 yz { readonly get => (short2)((ushort3)this).yz;  set { ushort3 _this = (ushort3)this; _this.yz = (ushort2)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 zx { readonly get => (short2)((ushort3)this).zx;  set { ushort3 _this = (ushort3)this; _this.zx = (ushort2)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public short2 zy { readonly get => (short2)((ushort3)this).zy;  set { ushort3 _this = (ushort3)this; _this.zy = (ushort2)value; this = (short3)_this; } }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public readonly short2 zz => (short2)((ushort3)this).zz;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short3 input) => (ushort3)input;
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(v128 input) => (short3)(ushort3)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(bool3 x) => (short3)(mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(Unity.Mathematics.bool3 x) => (short3)(mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (short3)(mask16x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (short3)(mask16x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(mask64x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (short3)(mask16x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(short3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(short3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(short3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(short3 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(short3 x) => (mask16x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(short3 x) => (mask16x3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short3(byte x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator short3(sbyte x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(ushort x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(uint x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(int x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(ulong x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(long x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(UInt128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(Int128 x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(quarter x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(half x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(float x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(double x) => (short)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(quadruple x) => (short)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(Unity.Mathematics.half x) => (short3)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(Unity.Mathematics.half3 x) => (short3)(half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(Unity.Mathematics.float3 x) => (short3)(float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(Unity.Mathematics.double3 x) => (short3)(double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(Unity.Mathematics.uint3 x) => (short3)(uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(Unity.Mathematics.int3 x) => (short3)(int3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half3(short3 x) => (half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(short3 x) => (float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(short3 x) => (double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint3(short3 x) => (uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int3(short3 x) => (int3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(short input) => new short3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(ushort3 input) => *(short3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(int3 input) => (short3)(ushort3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(uint3 input) => (short3)(ushort3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(long3 input) => (short3)(ushort3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(ulong3 input) => (short3)(ushort3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(float3 input) => (short3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(double3 input) => (short3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi32(input);
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi32(input);
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(short3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
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
        public static explicit operator ulong3(short3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
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
        public static implicit operator float3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_ps(input);
            }
            else
            {
                return (float3)(int3)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(short3 input) => (double3)(int3)input;


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (short)((ushort3)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ushort3 _this = (ushort3)this;
                _this[index] = (ushort)value;
                this = (short3)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (short3 left, short3 right) => (short3)((ushort3)left + (ushort3)right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (short left, short3 right) => (short3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (short3 left, short right) => left + (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 left, short3 right) => (short3)((ushort3)left - (ushort3)right);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short left, short3 right) => (short3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 left, short right) => left - (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, short3 right) => (short3)((ushort3)left * (ushort3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short left, short3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return new short3((short)(left.x * right), (short)(left.y * right), (short)(left.z * right));
                }
            }

            return left * (short3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi16(left, right, false, 3);
            }
            else
            {
                return new short3((short)(left.x / right.x), (short)(left.y / right.y), (short)(left.z / right.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short left, short3 right) => (short3)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, right, 3);
                }
            }

            return left / (short3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi16(left, right, 3);
            }
            else
            {
                return new short3((short)(left.x % right.x), (short)(left.y % right.y), (short)(left.z % right.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short left, short3 right) => (short3)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, right, 3);
                }
            }

            return left % (short3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (short3 left, byte3 right) => left + (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (byte3 left, short3 right) => (short3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 left, byte3 right) => left - (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (byte3 left, short3 right) => (short3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, byte3 right) => left * (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (byte3 left, short3 right) => (short3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, Xse.cvtepu8_epi16(right));
                }

                v128 left32 = Xse.cvtepi16_ps(left);
                v128 right32 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                return Xse.packs_epi32(toInt, toInt);
            }
            else
            {
                return new short3((short)(left.x / right.x), (short)(left.y / right.y), (short)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (byte3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(Xse.cvtepu8_epi16(left), right);
                }

                v128 left32 = Xse.cvtepu8_ps(left);
                v128 right32 = Xse.cvtepi16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                return Xse.packs_epi32(toInt, toInt);
            }
            else
            {
                return new short3((short)(left.x / right.x), (short)(left.y / right.y), (short)(left.z / right.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, Xse.cvtepu8_epi16(right));
                }

                v128 left32 = Xse.cvtepi16_ps(left);
                v128 right32 = Xse.cvtepu8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                v128 toInt16 = Xse.packs_epi32(toInt, toInt);

                return Xse.sub_epi16(left, Xse.mullo_epi16(toInt16, Xse.cvtepu8_epi16(right)));
            }
            else
            {
                return new short3((short)(left.x % right.x), (short)(left.y % right.y), (short)(left.z % right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (byte3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(Xse.cvtepu8_epi16(left), right);
                }

                v128 left32 = Xse.cvtepu8_ps(left);
                v128 right32 = Xse.cvtepi16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                v128 toInt16 = Xse.packs_epi32(toInt, toInt);

                return Xse.sub_epi16(Xse.cvtepu8_epi16(left), Xse.mullo_epi16(toInt16, right));
            }
            else
            {
                return new short3((short)(left.x % right.x), (short)(left.y % right.y), (short)(left.z % right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (short3 left, byte right) => left + (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (byte left, short3 right) => (short)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 left, byte right) => left - (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (byte left, short3 right) => (short)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, byte right) => left * (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (byte left, short3 right) => (short)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, byte right) => left / (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (byte left, short3 right) => (short)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, byte right) => left % (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (byte left, short3 right) => (short)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (short3 left, sbyte3 right) => left + (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (sbyte3 left, short3 right) => (short3)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 left, sbyte3 right) => left - (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (sbyte3 left, short3 right) => (short3)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, sbyte3 right) => left * (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (sbyte3 left, short3 right) => (short3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, sbyte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, Xse.cvtepi8_epi16(right));
                }

                v128 left32 = Xse.cvtepi16_ps(left);
                v128 right32 = Xse.cvtepi8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);
                
                v128 toInt = Xse.cvttps_epi32(quotient);

                if (constexpr.ALL_GT_EPI16(left, short.MinValue, 3) || constexpr.ALL_NEQ_EPI8(right, -1, 3))
                {
                    return Xse.packs_epi32(toInt, toInt);
                }
                else
                {
                    return Xse.cvtepi32_epi16(toInt);
                }
            }
            else
            {
                return new short3((short)(left.x / right.x), (short)(left.y / right.y), (short)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (sbyte3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(Xse.cvtepi8_epi16(left), right);
                }

                v128 left32 = Xse.cvtepi8_ps(left);
                v128 right32 = Xse.cvtepi16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                return Xse.packs_epi32(toInt, toInt);
            }
            else
            {
                return new short3((short)(left.x / right.x), (short)(left.y / right.y), (short)(left.z / right.z));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, sbyte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, Xse.cvtepi8_epi16(right));
                }

                v128 left32 = Xse.cvtepi16_ps(left);
                v128 right32 = Xse.cvtepi8_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                v128 quotient16;

                if (constexpr.ALL_GT_EPI16(left, short.MinValue, 3) || constexpr.ALL_NEQ_EPI8(right, -1, 3))
                {
                    quotient16 = Xse.packs_epi32(toInt, toInt);
                }
                else
                {
                    quotient16 = Xse.cvtepi32_epi16(toInt);
                }

                return Xse.sub_epi16(left, Xse.mullo_epi16(quotient16, Xse.cvtepi8_epi16(right)));
            }
            else
            {
                return new short3((short)(left.x % right.x), (short)(left.y % right.y), (short)(left.z % right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (sbyte3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(Xse.cvtepi8_epi16(left), right);
                }

                v128 left32 = Xse.cvtepi8_ps(left);
                v128 right32 = Xse.cvtepi16_ps(right);
                v128 quotient = Xse.DIV_FLOATV_SIGNED_USHORT_RANGE_RET_INT(left32, right32);
                
                v128 toInt = Xse.cvttps_epi32(quotient);
                v128 quotient16 = Xse.packs_epi32(toInt, toInt);

                return Xse.sub_epi16(Xse.cvtepi8_epi16(left), Xse.mullo_epi16(quotient16, right));
            }
            else
            {
                return new short3((short)(left.x % right.x), (short)(left.y % right.y), (short)(left.z % right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (short3 left, sbyte right) => left + (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (sbyte left, short3 right) => (short)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 left, sbyte right) => left - (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (sbyte left, short3 right) => (short)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, sbyte right) => left * (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (sbyte left, short3 right) => (short)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, sbyte right) => left / (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (sbyte left, short3 right) => (short)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, sbyte right) => left % (short)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (sbyte left, short3 right) => (short)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (short3 left, Unity.Mathematics.int3 right) => left + (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (Unity.Mathematics.int3 left, short3 right) => (int3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (short3 left, Unity.Mathematics.int3 right) => left - (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (Unity.Mathematics.int3 left, short3 right) => (int3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (short3 left, Unity.Mathematics.int3 right) => left * (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (Unity.Mathematics.int3 left, short3 right) => (int3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (short3 left, Unity.Mathematics.int3 right) => left / (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (Unity.Mathematics.int3 left, short3 right) => (int3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (short3 left, Unity.Mathematics.int3 right) => left % (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (Unity.Mathematics.int3 left, short3 right) => (int3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (short3 left, Unity.Mathematics.float3 right) => left + (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 left, short3 right) => (float3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (short3 left, Unity.Mathematics.float3 right) => left - (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 left, short3 right) => (float3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (short3 left, Unity.Mathematics.float3 right) => left * (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 left, short3 right) => (float3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (short3 left, Unity.Mathematics.float3 right) => left / (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 left, short3 right) => (float3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (short3 left, Unity.Mathematics.float3 right) => left % (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 left, short3 right) => (float3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (short3 left, Unity.Mathematics.double3 right) => left + (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 left, short3 right) => (double3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (short3 left, Unity.Mathematics.double3 right) => left - (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 left, short3 right) => (double3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (short3 left, Unity.Mathematics.double3 right) => left * (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 left, short3 right) => (double3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (short3 left, Unity.Mathematics.double3 right) => left / (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 left, short3 right) => (double3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (short3 left, Unity.Mathematics.double3 right) => left % (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 left, short3 right) => (double3)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (short3 left, short3 right) => (short3)((ushort3)left & (ushort3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (short3 left, short3 right) => (short3)((ushort3)left | (ushort3)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (short3 left, short3 right) => (short3)((ushort3)left ^ (ushort3)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (short left, short3 right) => (short3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (short3 left, short right) => left & (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (short left, short3 right) => (short3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (short3 left, short right) => left | (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (short left, short3 right) => (short3)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (short3 left, short right) => left ^ (short3)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (byte left, short3 right) => (short3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (short3 left, byte right) => left & (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (byte left, short3 right) => (short3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (short3 left, byte right) => left | (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (byte left, short3 right) => (short3)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (short3 left, byte right) => left ^ (short3)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (sbyte left, short3 right) => (short3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (short3 left, sbyte right) => left & (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (sbyte left, short3 right) => (short3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (short3 left, sbyte right) => left | (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (sbyte left, short3 right) => (short3)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (short3 left, sbyte right) => left ^ (short3)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (byte3 left, short3 right) => (short3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (short3 left, byte3 right) => left & (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (byte3 left, short3 right) => (short3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (short3 left, byte3 right) => left | (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (byte3 left, short3 right) => (short3)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (short3 left, byte3 right) => left ^ (short3)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (sbyte3 left, short3 right) => (short3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (short3 left, sbyte3 right) => left & (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (sbyte3 left, short3 right) => (short3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (short3 left, sbyte3 right) => left | (short3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (sbyte3 left, short3 right) => (short3)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (short3 left, sbyte3 right) => left ^ (short3)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (Unity.Mathematics.int3 left, short3 right) => (int3)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (short3 left, Unity.Mathematics.int3 right) => left & (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (Unity.Mathematics.int3 left, short3 right) => (int3)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (short3 left, Unity.Mathematics.int3 right) => left | (int3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (Unity.Mathematics.int3 left, short3 right) => (int3)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (short3 left, Unity.Mathematics.int3 right) => left ^ (int3)right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return new short3((short)-x.x, (short)-x.y, (short)-x.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ++ (short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi16(x);
			}
            else
            {
                return new short3((short)(x.x + 1), (short)(x.y + 1), (short)(x.z + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator -- (short3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi16(x);
			}
            else
            {
                return new short3((short)(x.x - 1), (short)(x.y - 1), (short)(x.z - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ~ (short3 x) => (short3)~(ushort3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator << (short3 x, int n) => (short3)((ushort3)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator >> (short3 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi16(x, n, inRange: true);
            }
            else
            {
                return new short3((short)(x.x >> n), (short)(x.y >> n), (short)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, short3 right) => (ushort3)left == (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmplt_epi16(left, right);
            }
            else
            {
                return new mask16x3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.cmpgt_epi16(left, right);
            }
            else
            {
                return new mask16x3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, short3 right) => (ushort3)left != (ushort3)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.not_si128(Xse.cmpgt_epi16(left, right));
            }
            else
            {
                return new mask16x3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, short3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				return Xse.not_si128(Xse.cmplt_epi16(left, right));
			}
            else
            {
                return new mask16x3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, byte right) => left == (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (byte left, short3 right) => (short)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, byte right) => left != (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (byte left, short3 right) => (short)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, byte right) => left < (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (byte left, short3 right) => (short)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, byte right) => left > (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (byte left, short3 right) => (short)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, byte right) => left <= (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (byte left, short3 right) => (short)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, byte right) => left >= (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (byte left, short3 right) => (short)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, sbyte right) => left == (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (sbyte left, short3 right) => (short)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, sbyte right) => left != (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (sbyte left, short3 right) => (short)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, sbyte right) => left < (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (sbyte left, short3 right) => (short)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, sbyte right) => left > (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (sbyte left, short3 right) => (short)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, sbyte right) => left <= (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (sbyte left, short3 right) => (short)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, sbyte right) => left >= (short)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (sbyte left, short3 right) => (short)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, short right) => left == (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short left, short3 right) => (short3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, short right) => left != (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short left, short3 right) => (short3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, short right) => left < (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short left, short3 right) => (short3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, short right) => left > (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short left, short3 right) => (short3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, short right) => left <= (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short left, short3 right) => (short3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, short right) => left >= (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short left, short3 right) => (short3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, byte3 right) => left == (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (byte3 left, short3 right) => (short3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, byte3 right) => left != (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (byte3 left, short3 right) => (short3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, byte3 right) => left < (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (byte3 left, short3 right) => (short3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, byte3 right) => left > (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (byte3 left, short3 right) => (short3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, byte3 right) => left <= (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (byte3 left, short3 right) => (short3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, byte3 right) => left >= (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (byte3 left, short3 right) => (short3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, sbyte3 right) => left == (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (sbyte3 left, short3 right) => (short3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, sbyte3 right) => left != (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (sbyte3 left, short3 right) => (short3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, sbyte3 right) => left < (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (sbyte3 left, short3 right) => (short3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, sbyte3 right) => left > (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (sbyte3 left, short3 right) => (short3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, sbyte3 right) => left <= (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (sbyte3 left, short3 right) => (short3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, sbyte3 right) => left >= (short3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (sbyte3 left, short3 right) => (short3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, Unity.Mathematics.int3 right) => left == (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.int3 left, short3 right) => (int3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, Unity.Mathematics.int3 right) => left != (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.int3 left, short3 right) => (int3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, Unity.Mathematics.int3 right) => left < (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.int3 left, short3 right) => (int3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, Unity.Mathematics.int3 right) => left > (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.int3 left, short3 right) => (int3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, Unity.Mathematics.int3 right) => left <= (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.int3 left, short3 right) => (int3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, Unity.Mathematics.int3 right) => left >= (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.int3 left, short3 right) => (int3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, Unity.Mathematics.half3 right) => left == (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.half3 left, short3 right) => (half3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, Unity.Mathematics.half3 right) => left != (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.half3 left, short3 right) => (half3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, Unity.Mathematics.half3 right) => left < (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.half3 left, short3 right) => (half3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, Unity.Mathematics.half3 right) => left > (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.half3 left, short3 right) => (half3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, Unity.Mathematics.half3 right) => left <= (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.half3 left, short3 right) => (half3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, Unity.Mathematics.half3 right) => left >= (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.half3 left, short3 right) => (half3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, Unity.Mathematics.float3 right) => left == (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.float3 left, short3 right) => (float3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, Unity.Mathematics.float3 right) => left != (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.float3 left, short3 right) => (float3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, Unity.Mathematics.float3 right) => left < (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.float3 left, short3 right) => (float3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, Unity.Mathematics.float3 right) => left > (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.float3 left, short3 right) => (float3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, Unity.Mathematics.float3 right) => left <= (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.float3 left, short3 right) => (float3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, Unity.Mathematics.float3 right) => left >= (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.float3 left, short3 right) => (float3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (short3 left, Unity.Mathematics.double3 right) => left == (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator == (Unity.Mathematics.double3 left, short3 right) => (double3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (short3 left, Unity.Mathematics.double3 right) => left != (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator != (Unity.Mathematics.double3 left, short3 right) => (double3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (short3 left, Unity.Mathematics.double3 right) => left < (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator < (Unity.Mathematics.double3 left, short3 right) => (double3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (short3 left, Unity.Mathematics.double3 right) => left > (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator > (Unity.Mathematics.double3 left, short3 right) => (double3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (short3 left, Unity.Mathematics.double3 right) => left <= (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator <= (Unity.Mathematics.double3 left, short3 right) => (double3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (short3 left, Unity.Mathematics.double3 right) => left >= (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask16x3 operator >= (Unity.Mathematics.double3 left, short3 right) => (double3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short3 other) => ((ushort3)this).Equals((ushort3)other);

        public override readonly bool Equals(object obj) => obj is short3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"short3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}