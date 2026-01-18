using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
	[StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(long))]
	[DebuggerTypeProxy(typeof(long4.DebuggerProxy))]
    unsafe public struct long4 : IEquatable<long4>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public long x;
            public long y;
            public long z;
            public long w;

            public DebuggerProxy(long4 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
                w = v.w;
            }
        }


        [FieldOffset(0)]  internal long2 _xy;
        [FieldOffset(16)] internal long2 _zw;

        [FieldOffset(0)]  public long x;
        [FieldOffset(8)]  public long y;
        [FieldOffset(16)] public long z;
        [FieldOffset(24)] public long w;


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


        #region Shuffle
		public readonly long4 xxxx => (long4)((ulong4)this).xxxx;
        public readonly long4 xxxy => (long4)((ulong4)this).xxxy;
        public readonly long4 xxxz => (long4)((ulong4)this).xxxz;
        public readonly long4 xxxw => (long4)((ulong4)this).xxxw;
        public readonly long4 xxyx => (long4)((ulong4)this).xxyx;
        public readonly long4 xxyy => (long4)((ulong4)this).xxyy;
        public readonly long4 xxyz => (long4)((ulong4)this).xxyz;
        public readonly long4 xxyw => (long4)((ulong4)this).xxyw;
        public readonly long4 xxzx => (long4)((ulong4)this).xxzx;
        public readonly long4 xxzy => (long4)((ulong4)this).xxzy;
        public readonly long4 xxzz => (long4)((ulong4)this).xxzz;
        public readonly long4 xxzw => (long4)((ulong4)this).xxzw;
        public readonly long4 xxwx => (long4)((ulong4)this).xxwx;
        public readonly long4 xxwy => (long4)((ulong4)this).xxwy;
        public readonly long4 xxwz => (long4)((ulong4)this).xxwz;
        public readonly long4 xxww => (long4)((ulong4)this).xxww;
        public readonly long4 xyxx => (long4)((ulong4)this).xyxx;
		public readonly long4 xyxy => (long4)((ulong4)this).xyxy;
        public readonly long4 xyxz => (long4)((ulong4)this).xyxz;
		public readonly long4 xyxw => (long4)((ulong4)this).xyxw;
		public readonly long4 xyyx => (long4)((ulong4)this).xyyx;
		public readonly long4 xyyy => (long4)((ulong4)this).xyyy;
		public readonly long4 xyyz => (long4)((ulong4)this).xyyz;
		public readonly long4 xyyw => (long4)((ulong4)this).xyyw;
		public readonly long4 xyzx => (long4)((ulong4)this).xyzx;
        public readonly long4 xyzy => (long4)((ulong4)this).xyzy;
        public readonly long4 xyzz => (long4)((ulong4)this).xyzz;
		public readonly long4 xywx => (long4)((ulong4)this).xywx;
		public readonly long4 xywy => (long4)((ulong4)this).xywy;
		public		    long4 xywz { readonly get => (long4)((ulong4)this).xywz;  set { ulong4 _this = (ulong4)this; _this.xywz = (ulong4)value; this = (long4)_this; } }
		public readonly long4 xyww => (long4)((ulong4)this).xyww;
		public readonly long4 xzxx => (long4)((ulong4)this).xzxx;
        public readonly long4 xzxy => (long4)((ulong4)this).xzxy;
        public readonly long4 xzxz => (long4)((ulong4)this).xzxz;
		public readonly long4 xzxw => (long4)((ulong4)this).xzxw;
		public readonly long4 xzyx => (long4)((ulong4)this).xzyx;
        public readonly long4 xzyy => (long4)((ulong4)this).xzyy;
        public readonly long4 xzyz => (long4)((ulong4)this).xzyz;
		public			long4 xzyw { readonly get => (long4)((ulong4)this).xzyw;  set { ulong4 _this = (ulong4)this; _this.xzyw = (ulong4)value; this = (long4)_this; } }
		public readonly long4 xzzx => (long4)((ulong4)this).xzzx;
        public readonly long4 xzzy => (long4)((ulong4)this).xzzy;
        public readonly long4 xzzz => (long4)((ulong4)this).xzzz;
		public readonly long4 xzzw => (long4)((ulong4)this).xzzw;
		public readonly long4 xzwx => (long4)((ulong4)this).xzwx;
		public			long4 xzwy { readonly get => (long4)((ulong4)this).xzwy;  set { ulong4 _this = (ulong4)this; _this.xzwy = (ulong4)value; this = (long4)_this; } }
		public readonly long4 xzwz => (long4)((ulong4)this).xzwz;
		public readonly long4 xzww => (long4)((ulong4)this).xzww;
		public readonly long4 xwxx => (long4)((ulong4)this).xwxx;
		public readonly long4 xwxy => (long4)((ulong4)this).xwxy;
		public readonly long4 xwxz => (long4)((ulong4)this).xwxz;
		public readonly long4 xwxw => (long4)((ulong4)this).xwxw;
		public readonly long4 xwyx => (long4)((ulong4)this).xwyx;
		public readonly long4 xwyy => (long4)((ulong4)this).xwyy;
		public			long4 xwyz { readonly get => (long4)((ulong4)this).xwyz;  set { ulong4 _this = (ulong4)this; _this.xwyz = (ulong4)value; this = (long4)_this; } }
		public readonly long4 xwyw => (long4)((ulong4)this).xwyw;
		public readonly long4 xwzx => (long4)((ulong4)this).xwzx;
		public			long4 xwzy { readonly get => (long4)((ulong4)this).xwzy;  set { ulong4 _this = (ulong4)this; _this.xwzy = (ulong4)value; this = (long4)_this; } }
		public readonly long4 xwzz => (long4)((ulong4)this).xwzz;
		public readonly long4 xwzw => (long4)((ulong4)this).xwzw;
		public readonly long4 xwwx => (long4)((ulong4)this).xwwx;
		public readonly long4 xwwy => (long4)((ulong4)this).xwwy;
		public readonly long4 xwwz => (long4)((ulong4)this).xwwz;
		public readonly long4 xwww => (long4)((ulong4)this).xwww;
		public readonly long4 yxxx => (long4)((ulong4)this).yxxx;
        public readonly long4 yxxy => (long4)((ulong4)this).yxxy;
        public readonly long4 yxxz => (long4)((ulong4)this).yxxz;
		public readonly long4 yxxw => (long4)((ulong4)this).yxxw;
		public readonly long4 yxyx => (long4)((ulong4)this).yxyx;
        public readonly long4 yxyy => (long4)((ulong4)this).yxyy;
        public readonly long4 yxyz => (long4)((ulong4)this).yxyz;
		public readonly long4 yxyw => (long4)((ulong4)this).yxyw;
		public readonly long4 yxzx => (long4)((ulong4)this).yxzx;
        public readonly long4 yxzy => (long4)((ulong4)this).yxzy;
        public readonly long4 yxzz => (long4)((ulong4)this).yxzz;
		public			long4 yxzw { readonly get => (long4)((ulong4)this).yxzw;  set { ulong4 _this = (ulong4)this; _this.yxzw = (ulong4)value; this = (long4)_this; } }
		public readonly long4 yxwx => (long4)((ulong4)this).yxwx;
		public readonly long4 yxwy => (long4)((ulong4)this).yxwy;
		public			long4 yxwz { readonly get => (long4)((ulong4)this).yxwz;  set { ulong4 _this = (ulong4)this; _this.yxwz = (ulong4)value; this = (long4)_this; } }
		public readonly long4 yxww => (long4)((ulong4)this).yxww;
		public readonly long4 yyxx => (long4)((ulong4)this).yyxx;
        public readonly long4 yyxy => (long4)((ulong4)this).yyxy;
        public readonly long4 yyxz => (long4)((ulong4)this).yyxz;
		public readonly long4 yyxw => (long4)((ulong4)this).yyxw;
		public readonly long4 yyyx => (long4)((ulong4)this).yyyx;
        public readonly long4 yyyy => (long4)((ulong4)this).yyyy;
        public readonly long4 yyyz => (long4)((ulong4)this).yyyz;
		public readonly long4 yyyw => (long4)((ulong4)this).yyyw;
		public readonly long4 yyzx => (long4)((ulong4)this).yyzx;
        public readonly long4 yyzy => (long4)((ulong4)this).yyzy;
        public readonly long4 yyzz => (long4)((ulong4)this).yyzz;
		public readonly long4 yyzw => (long4)((ulong4)this).yyzw;
		public readonly long4 yywx => (long4)((ulong4)this).yywx;
		public readonly long4 yywy => (long4)((ulong4)this).yywy;
		public readonly long4 yywz => (long4)((ulong4)this).yywz;
		public readonly long4 yyww => (long4)((ulong4)this).yyww;
		public readonly long4 yzxx => (long4)((ulong4)this).yzxx;
        public readonly long4 yzxy => (long4)((ulong4)this).yzxy;
        public readonly long4 yzxz => (long4)((ulong4)this).yzxz;
		public			long4 yzxw { readonly get => (long4)((ulong4)this).yzxw;  set { ulong4 _this = (ulong4)this; _this.yzxw = (ulong4)value; this = (long4)_this; } }
		public readonly long4 yzyx => (long4)((ulong4)this).yzyx;
        public readonly long4 yzyy => (long4)((ulong4)this).yzyy;
        public readonly long4 yzyz => (long4)((ulong4)this).yzyz;
		public readonly long4 yzyw => (long4)((ulong4)this).yzyw;
		public readonly long4 yzzx => (long4)((ulong4)this).yzzx;
        public readonly long4 yzzy => (long4)((ulong4)this).yzzy;
        public readonly long4 yzzz => (long4)((ulong4)this).yzzz;
		public readonly long4 yzzw => (long4)((ulong4)this).yzzw;
		public			long4 yzwx { readonly get => (long4)((ulong4)this).yzwx;  set { ulong4 _this = (ulong4)this; _this.yzwx = (ulong4)value; this = (long4)_this; } }
		public readonly long4 yzwy => (long4)((ulong4)this).yzwy;
		public readonly long4 yzwz => (long4)((ulong4)this).yzwz;
		public readonly long4 yzww => (long4)((ulong4)this).yzww;
		public readonly long4 ywxx => (long4)((ulong4)this).ywxx;
		public readonly long4 ywxy => (long4)((ulong4)this).ywxy;
		public			long4 ywxz { readonly get => (long4)((ulong4)this).ywxz;  set { ulong4 _this = (ulong4)this; _this.ywxz = (ulong4)value; this = (long4)_this; } }
		public readonly long4 ywxw => (long4)((ulong4)this).ywxw;
		public readonly long4 ywyx => (long4)((ulong4)this).ywyx;
		public readonly long4 ywyy => (long4)((ulong4)this).ywyy;
		public readonly long4 ywyz => (long4)((ulong4)this).ywyz;
		public readonly long4 ywyw => (long4)((ulong4)this).ywyw;
		public			long4 ywzx { readonly get => (long4)((ulong4)this).ywzx;  set { ulong4 _this = (ulong4)this; _this.ywzx = (ulong4)value; this = (long4)_this; } }
		public readonly long4 ywzy => (long4)((ulong4)this).ywzy;
		public readonly long4 ywzz => (long4)((ulong4)this).ywzz;
		public readonly long4 ywzw => (long4)((ulong4)this).ywzw;
		public readonly long4 ywwx => (long4)((ulong4)this).ywwx;
		public readonly long4 ywwy => (long4)((ulong4)this).ywwy;
		public readonly long4 ywwz => (long4)((ulong4)this).ywwz;
		public readonly long4 ywww => (long4)((ulong4)this).ywww;
		public readonly long4 zxxx => (long4)((ulong4)this).zxxx;
        public readonly long4 zxxy => (long4)((ulong4)this).zxxy;
        public readonly long4 zxxz => (long4)((ulong4)this).zxxz;
		public readonly long4 zxxw => (long4)((ulong4)this).zxxw;
		public readonly long4 zxyx => (long4)((ulong4)this).zxyx;
        public readonly long4 zxyy => (long4)((ulong4)this).zxyy;
        public readonly long4 zxyz => (long4)((ulong4)this).zxyz;
		public			long4 zxyw { readonly get => (long4)((ulong4)this).zxyw;  set { ulong4 _this = (ulong4)this; _this.zxyw = (ulong4)value; this = (long4)_this; } }
		public readonly long4 zxzx => (long4)((ulong4)this).zxzx;
        public readonly long4 zxzy => (long4)((ulong4)this).zxzy;
        public readonly long4 zxzz => (long4)((ulong4)this).zxzz;
		public readonly long4 zxzw => (long4)((ulong4)this).zxzw;
		public readonly long4 zxwx => (long4)((ulong4)this).zxwx;
		public			long4 zxwy { readonly get => (long4)((ulong4)this).zxwy;  set { ulong4 _this = (ulong4)this; _this.zxwy = (ulong4)value; this = (long4)_this; } }
		public readonly long4 zxwz => (long4)((ulong4)this).zxwz;
		public readonly long4 zxww => (long4)((ulong4)this).zxww;
		public readonly long4 zyxx => (long4)((ulong4)this).zyxx;
        public readonly long4 zyxy => (long4)((ulong4)this).zyxy;
        public readonly long4 zyxz => (long4)((ulong4)this).zyxz;
		public			long4 zyxw { readonly get => (long4)((ulong4)this).zyxw;  set { ulong4 _this = (ulong4)this; _this.zyxw = (ulong4)value; this = (long4)_this; } }
		public readonly long4 zyyx => (long4)((ulong4)this).zyyx;
        public readonly long4 zyyy => (long4)((ulong4)this).zyyy;
        public readonly long4 zyyz => (long4)((ulong4)this).zyyz;
		public readonly long4 zyyw => (long4)((ulong4)this).zyyw;
		public readonly long4 zyzx => (long4)((ulong4)this).zyzx;
        public readonly long4 zyzy => (long4)((ulong4)this).zyzy;
        public readonly long4 zyzz => (long4)((ulong4)this).zyzz;
		public readonly long4 zyzw => (long4)((ulong4)this).zyzw;
		public			long4 zywx { readonly get => (long4)((ulong4)this).zywx;  set { ulong4 _this = (ulong4)this; _this.zywx = (ulong4)value; this = (long4)_this; } }
		public readonly long4 zywy => (long4)((ulong4)this).zywy;
		public readonly long4 zywz => (long4)((ulong4)this).zywz;
		public readonly long4 zyww => (long4)((ulong4)this).zyww;
		public readonly long4 zzxx => (long4)((ulong4)this).zzxx;
        public readonly long4 zzxy => (long4)((ulong4)this).zzxy;
        public readonly long4 zzxz => (long4)((ulong4)this).zzxz;
		public readonly long4 zzxw => (long4)((ulong4)this).zzxw;
		public readonly long4 zzyx => (long4)((ulong4)this).zzyx;
        public readonly long4 zzyy => (long4)((ulong4)this).zzyy;
        public readonly long4 zzyz => (long4)((ulong4)this).zzyz;
		public readonly long4 zzyw => (long4)((ulong4)this).zzyw;
		public readonly long4 zzzx => (long4)((ulong4)this).zzzx;
        public readonly long4 zzzy => (long4)((ulong4)this).zzzy;
        public readonly long4 zzzz => (long4)((ulong4)this).zzzz;
		public readonly long4 zzzw => (long4)((ulong4)this).zzzw;
		public readonly long4 zzwx => (long4)((ulong4)this).zzwx;
		public readonly long4 zzwy => (long4)((ulong4)this).zzwy;
		public readonly long4 zzwz => (long4)((ulong4)this).zzwz;
		public readonly long4 zzww => (long4)((ulong4)this).zzww;
		public readonly long4 zwxx => (long4)((ulong4)this).zwxx;
		public			long4 zwxy { readonly get => (long4)((ulong4)this).zwxy;  set { ulong4 _this = (ulong4)this; _this.zwxy = (ulong4)value; this = (long4)_this; } }
		public readonly long4 zwxz => (long4)((ulong4)this).zwxz;
		public readonly long4 zwxw => (long4)((ulong4)this).zwxw;
		public			long4 zwyx { readonly get => (long4)((ulong4)this).zwyx;  set { ulong4 _this = (ulong4)this; _this.zwyx = (ulong4)value; this = (long4)_this; } }
		public readonly long4 zwyy => (long4)((ulong4)this).zwyy;
		public readonly long4 zwyz => (long4)((ulong4)this).zwyz;
		public readonly long4 zwyw => (long4)((ulong4)this).zwyw;
		public readonly long4 zwzx => (long4)((ulong4)this).zwzx;
		public readonly long4 zwzy => (long4)((ulong4)this).zwzy;
		public readonly long4 zwzz => (long4)((ulong4)this).zwzz;
		public readonly long4 zwzw => (long4)((ulong4)this).zwzw;
		public readonly long4 zwwx => (long4)((ulong4)this).zwwx;
		public readonly long4 zwwy => (long4)((ulong4)this).zwwy;
		public readonly long4 zwwz => (long4)((ulong4)this).zwwz;
		public readonly long4 zwww => (long4)((ulong4)this).zwww;
		public readonly long4 wxxx => (long4)((ulong4)this).wxxx;
		public readonly long4 wxxy => (long4)((ulong4)this).wxxy;
		public readonly long4 wxxz => (long4)((ulong4)this).wxxz;
		public readonly long4 wxxw => (long4)((ulong4)this).wxxw;
		public readonly long4 wxyx => (long4)((ulong4)this).wxyx;
		public readonly long4 wxyy => (long4)((ulong4)this).wxyy;
		public			long4 wxyz { readonly get => (long4)((ulong4)this).wxyz;  set { ulong4 _this = (ulong4)this; _this.wxyz = (ulong4)value; this = (long4)_this; } }
		public readonly long4 wxyw => (long4)((ulong4)this).wxyw;
		public readonly long4 wxzx => (long4)((ulong4)this).wxzx;
		public			long4 wxzy { readonly get => (long4)((ulong4)this).wxzy;  set { ulong4 _this = (ulong4)this; _this.wxzy = (ulong4)value; this = (long4)_this; } }
		public readonly long4 wxzz => (long4)((ulong4)this).wxzz;
		public readonly long4 wxzw => (long4)((ulong4)this).wxzw;
		public readonly long4 wxwx => (long4)((ulong4)this).wxwx;
		public readonly long4 wxwy => (long4)((ulong4)this).wxwy;
		public readonly long4 wxwz => (long4)((ulong4)this).wxwz;
		public readonly long4 wxww => (long4)((ulong4)this).wxww;
		public readonly long4 wyxx => (long4)((ulong4)this).wyxx;
		public readonly long4 wyxy => (long4)((ulong4)this).wyxy;
		public			long4 wyxz { readonly get => (long4)((ulong4)this).wyxz;  set { ulong4 _this = (ulong4)this; _this.wyxz = (ulong4)value; this = (long4)_this; } }
		public readonly long4 wyxw => (long4)((ulong4)this).wyxw;
		public readonly long4 wyyx => (long4)((ulong4)this).wyyx;
		public readonly long4 wyyy => (long4)((ulong4)this).wyyy;
		public readonly long4 wyyz => (long4)((ulong4)this).wyyz;
		public readonly long4 wyyw => (long4)((ulong4)this).wyyw;
		public			long4 wyzx { readonly get => (long4)((ulong4)this).wyzx;  set { ulong4 _this = (ulong4)this; _this.wyzx = (ulong4)value; this = (long4)_this; } }
		public readonly long4 wyzy => (long4)((ulong4)this).wyzy;
		public readonly long4 wyzz => (long4)((ulong4)this).wyzz;
		public readonly long4 wyzw => (long4)((ulong4)this).wyzw;
		public readonly long4 wywx => (long4)((ulong4)this).wywx;
		public readonly long4 wywy => (long4)((ulong4)this).wywy;
		public readonly long4 wywz => (long4)((ulong4)this).wywz;
		public readonly long4 wyww => (long4)((ulong4)this).wyww;
		public readonly long4 wzxx => (long4)((ulong4)this).wzxx;
		public			long4 wzxy { readonly get => (long4)((ulong4)this).wzxy;  set { ulong4 _this = (ulong4)this; _this.wzxy = (ulong4)value; this = (long4)_this; } }
		public readonly long4 wzxz => (long4)((ulong4)this).wzxz;
		public readonly long4 wzxw => (long4)((ulong4)this).wzxw;
		public			long4 wzyx { readonly get => (long4)((ulong4)this).wzyx;  set { ulong4 _this = (ulong4)this; _this.wzyx = (ulong4)value; this = (long4)_this; } }
		public readonly long4 wzyy => (long4)((ulong4)this).wzyy;
		public readonly long4 wzyz => (long4)((ulong4)this).wzyz;
		public readonly long4 wzyw => (long4)((ulong4)this).wzyw;
		public readonly long4 wzzx => (long4)((ulong4)this).wzzx;
		public readonly long4 wzzy => (long4)((ulong4)this).wzzy;
		public readonly long4 wzzz => (long4)((ulong4)this).wzzz;
		public readonly long4 wzzw => (long4)((ulong4)this).wzzw;
		public readonly long4 wzwx => (long4)((ulong4)this).wzwx;
		public readonly long4 wzwy => (long4)((ulong4)this).wzwy;
		public readonly long4 wzwz => (long4)((ulong4)this).wzwz;
		public readonly long4 wzww => (long4)((ulong4)this).wzww;
		public readonly long4 wwxx => (long4)((ulong4)this).wwxx;
		public readonly long4 wwxy => (long4)((ulong4)this).wwxy;
		public readonly long4 wwxz => (long4)((ulong4)this).wwxz;
		public readonly long4 wwxw => (long4)((ulong4)this).wwxw;
		public readonly long4 wwyx => (long4)((ulong4)this).wwyx;
		public readonly long4 wwyy => (long4)((ulong4)this).wwyy;
		public readonly long4 wwyz => (long4)((ulong4)this).wwyz;
		public readonly long4 wwyw => (long4)((ulong4)this).wwyw;
		public readonly long4 wwzx => (long4)((ulong4)this).wwzx;
		public readonly long4 wwzy => (long4)((ulong4)this).wwzy;
		public readonly long4 wwzz => (long4)((ulong4)this).wwzz;
		public readonly long4 wwzw => (long4)((ulong4)this).wwzw;
		public readonly long4 wwwx => (long4)((ulong4)this).wwwx;
		public readonly long4 wwwy => (long4)((ulong4)this).wwwy;
		public readonly long4 wwwz => (long4)((ulong4)this).wwwz;
		public readonly long4 wwww => (long4)((ulong4)this).wwww;

		public readonly long3 xxx => (long3)((ulong4)this).xxx;
        public readonly long3 xxy => (long3)((ulong4)this).xxy;
        public readonly long3 xxz => (long3)((ulong4)this).xxz;
		public readonly long3 xxw => (long3)((ulong4)this).xxw;
		public readonly long3 xyx => (long3)((ulong4)this).xyx;
        public readonly long3 xyy => (long3)((ulong4)this).xyy;
		public			long3 xyz { readonly get => (long3)((ulong4)this).xyz;  set { ulong4 _this = (ulong4)this; _this.xyz = (ulong3)value; this = (long4)_this; } }
		public			long3 xyw { readonly get => (long3)((ulong4)this).xyw;  set { ulong4 _this = (ulong4)this; _this.xyw = (ulong3)value; this = (long4)_this; } }
		public readonly long3 xzx => (long3)((ulong4)this).xzx;
        public          long3 xzy { readonly get => (long3)((ulong4)this).xzy;  set { ulong4 _this = (ulong4)this; _this.xzy = (ulong3)value; this = (long4)_this; } }
        public readonly long3 xzz => (long3)((ulong4)this).xzz;
		public			long3 xzw { readonly get => (long3)((ulong4)this).xzw;  set { ulong4 _this = (ulong4)this; _this.xzw = (ulong3)value; this = (long4)_this; } }
		public readonly long3 xwx => (long3)((ulong4)this).xwx;
		public			long3 xwy { readonly get => (long3)((ulong4)this).xwy;  set { ulong4 _this = (ulong4)this; _this.xwy = (ulong3)value; this = (long4)_this; } }
		public			long3 xwz { readonly get => (long3)((ulong4)this).xwz;  set { ulong4 _this = (ulong4)this; _this.xwz = (ulong3)value; this = (long4)_this; } }
		public readonly long3 xww => (long3)((ulong4)this).xww;
		public readonly long3 yxx => (long3)((ulong4)this).yxx;
        public readonly long3 yxy => (long3)((ulong4)this).yxy;
        public          long3 yxz { readonly get => (long3)((ulong4)this).yxz;  set { ulong4 _this = (ulong4)this; _this.yxz = (ulong3)value; this = (long4)_this; } }
		public			long3 yxw { readonly get => (long3)((ulong4)this).yxw;  set { ulong4 _this = (ulong4)this; _this.yxw = (ulong3)value; this = (long4)_this; } }
		public readonly long3 yyx => (long3)((ulong4)this).yyx;
        public readonly long3 yyy => (long3)((ulong4)this).yyy;
        public readonly long3 yyz => (long3)((ulong4)this).yyz;
		public readonly long3 yyw => (long3)((ulong4)this).yyw;
		public          long3 yzx { readonly get => (long3)((ulong4)this).yzx;  set { ulong4 _this = (ulong4)this; _this.yzx = (ulong3)value; this = (long4)_this; } }
        public readonly long3 yzy => (long3)((ulong4)this).yzy;
        public readonly long3 yzz => (long3)((ulong4)this).yzz;
		public			long3 yzw { readonly get => (long3)((ulong4)this).yzw;  set { ulong4 _this = (ulong4)this; _this.yzw = (ulong3)value; this = (long4)_this; } }
		public			long3 ywx { readonly get => (long3)((ulong4)this).ywx;  set { ulong4 _this = (ulong4)this; _this.ywx = (ulong3)value; this = (long4)_this; } }
		public readonly long3 ywy => (long3)((ulong4)this).ywy;
		public			long3 ywz { readonly get => (long3)((ulong4)this).ywz;  set { ulong4 _this = (ulong4)this; _this.ywz = (ulong3)value; this = (long4)_this; } }
		public readonly long3 yww => (long3)((ulong4)this).yww;
		public readonly long3 zxx => (long3)((ulong4)this).zxx;
        public          long3 zxy { readonly get => (long3)((ulong4)this).zxy;  set { ulong4 _this = (ulong4)this; _this.zxy = (ulong3)value; this = (long4)_this; } }
        public readonly long3 zxz => (long3)((ulong4)this).zxz;
		public          long3 zxw { readonly get => (long3)((ulong4)this).zxw;  set { ulong4 _this = (ulong4)this; _this.zxw = (ulong3)value; this = (long4)_this; } }
		public          long3 zyx { readonly get => (long3)((ulong4)this).zyx;  set { ulong4 _this = (ulong4)this; _this.zyx = (ulong3)value; this = (long4)_this; } }
        public readonly long3 zyy => (long3)((ulong4)this).zyy;
        public readonly long3 zyz => (long3)((ulong4)this).zyz;
		public          long3 zyw { readonly get => (long3)((ulong4)this).zyw;  set { ulong4 _this = (ulong4)this; _this.zyw = (ulong3)value; this = (long4)_this; } }
		public readonly long3 zzx => (long3)((ulong4)this).zzx;
        public readonly long3 zzy => (long3)((ulong4)this).zzy;
        public readonly long3 zzz => (long3)((ulong4)this).zzz;
		public readonly long3 zzw => (long3)((ulong4)this).zzw;
		public          long3 zwx { readonly get => (long3)((ulong4)this).zwx;  set { ulong4 _this = (ulong4)this; _this.zwx = (ulong3)value; this = (long4)_this; } }
		public          long3 zwy { readonly get => (long3)((ulong4)this).zwy;  set { ulong4 _this = (ulong4)this; _this.zwy = (ulong3)value; this = (long4)_this; } }
		public readonly long3 zwz => (long3)((ulong4)this).zwz;
		public readonly long3 zww => (long3)((ulong4)this).zww;
		public readonly long3 wxx => (long3)((ulong4)this).wxx;
		public          long3 wxy { readonly get => (long3)((ulong4)this).wxy;  set { ulong4 _this = (ulong4)this; _this.wxy = (ulong3)value; this = (long4)_this; } }
		public          long3 wxz { readonly get => (long3)((ulong4)this).wxz;  set { ulong4 _this = (ulong4)this; _this.wxz = (ulong3)value; this = (long4)_this; } }
		public readonly long3 wxw => (long3)((ulong4)this).wxw;
		public          long3 wyx { readonly get => (long3)((ulong4)this).wyx;  set { ulong4 _this = (ulong4)this; _this.wyx = (ulong3)value; this = (long4)_this; } }
		public readonly long3 wyy => (long3)((ulong4)this).wyy;
		public          long3 wyz { readonly get => (long3)((ulong4)this).wyz;  set { ulong4 _this = (ulong4)this; _this.wyz = (ulong3)value; this = (long4)_this; } }
		public readonly long3 wyw => (long3)((ulong4)this).wyw;
		public          long3 wzx { readonly get => (long3)((ulong4)this).wzx;  set { ulong4 _this = (ulong4)this; _this.wzx = (ulong3)value; this = (long4)_this; } }
		public          long3 wzy { readonly get => (long3)((ulong4)this).wzy;  set { ulong4 _this = (ulong4)this; _this.wzy = (ulong3)value; this = (long4)_this; } }
		public readonly long3 wzz => (long3)((ulong4)this).wzz;
		public readonly long3 wzw => (long3)((ulong4)this).wzw;
		public readonly long3 wwx => (long3)((ulong4)this).wwx;
		public readonly long3 wwy => (long3)((ulong4)this).wwy;
		public readonly long3 wwz => (long3)((ulong4)this).wwz;
		public readonly long3 www => (long3)((ulong4)this).www;

		public readonly long2 xx => (long2)((ulong4)this).xx;
        public          long2 xy { readonly get => (long2)((ulong4)this).xy;  set { ulong4 _this = (ulong4)this; _this.xy = (ulong2)value; this = (long4)_this; } }
        public          long2 xz { readonly get => (long2)((ulong4)this).xz;  set { ulong4 _this = (ulong4)this; _this.xz = (ulong2)value; this = (long4)_this; } }
		public          long2 xw { readonly get => (long2)((ulong4)this).xw;  set { ulong4 _this = (ulong4)this; _this.xw = (ulong2)value; this = (long4)_this; } }
		public          long2 yx { readonly get => (long2)((ulong4)this).yx;  set { ulong4 _this = (ulong4)this; _this.yx = (ulong2)value; this = (long4)_this; } }
        public readonly long2 yy => (long2)((ulong4)this).yy;
        public          long2 yz { readonly get => (long2)((ulong4)this).yz;  set { ulong4 _this = (ulong4)this; _this.yz = (ulong2)value; this = (long4)_this; } }
		public          long2 yw { readonly get => (long2)((ulong4)this).yw;  set { ulong4 _this = (ulong4)this; _this.yw = (ulong2)value; this = (long4)_this; } }
		public          long2 zx { readonly get => (long2)((ulong4)this).zx;  set { ulong4 _this = (ulong4)this; _this.zx = (ulong2)value; this = (long4)_this; } }
        public          long2 zy { readonly get => (long2)((ulong4)this).zy;  set { ulong4 _this = (ulong4)this; _this.zy = (ulong2)value; this = (long4)_this; } }
        public readonly long2 zz => (long2)((ulong4)this).zz;
		public          long2 zw { readonly get => (long2)((ulong4)this).zw;  set { ulong4 _this = (ulong4)this; _this.zw = (ulong2)value; this = (long4)_this; } }
		public          long2 wx { readonly get => (long2)((ulong4)this).wx;  set { ulong4 _this = (ulong4)this; _this.wx = (ulong2)value; this = (long4)_this; } }
		public          long2 wy { readonly get => (long2)((ulong4)this).wy;  set { ulong4 _this = (ulong4)this; _this.wy = (ulong2)value; this = (long4)_this; } }
		public          long2 wz { readonly get => (long2)((ulong4)this).wz;  set { ulong4 _this = (ulong4)this; _this.wz = (ulong2)value; this = (long4)_this; } }
		public readonly long2 ww => (long2)((ulong4)this).ww;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(long4 input) => RegisterConversion.ToRegister256(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(v256 input) => RegisterConversion.ToAbstraction256<long4>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(long input) => new long4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(ulong4 input) => *(long4*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(uint4 input) => (long4)(ulong4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(int4 input) => (long4)(ulong4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(half4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epi64(RegisterConversion.ToV128(input), 4);
            }
            else
            {
                return new long4((long2)input.xy, (long2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(float4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epi64(RegisterConversion.ToV128(input), 4);
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
                return Xse.mm256_cvttpd_epi64(RegisterConversion.ToV256(input), 4);
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
        public static explicit operator half4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToHalf4(Xse.mm256_cvtepi64_ph(input, (half)float.PositiveInfinity, elements: 4));
            }
            else
            {
                return new half4((half2)input.xy, (half2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToFloat4(Xse.mm256_cvtepi64_ps(input, 4));
            }
            else
            {
                return new float4((float2)input._xy, (float2)input._zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(long4 input)
		{
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(Xse.mm256_cvtepi64_pd(input, 4));
            }
			else
			{
				return new double4((double2)input._xy, (double2)input._zw);
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
				return new long4(left._xy / right.xy, left._zw / right.zw);
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
				return new long4(left._xy / right.xy, left._zw / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, uint4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Xse.mm256_cvtepu32_pd(RegisterConversion.ToV128(right)), elements: 4, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(left.xy, Xse.cvtepu32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), Xse.div_epi64(left.zw, Xse.cvtepi32_epi64(RegisterConversion.ToV128(right.zw)), useFPU: false, bIsDbl: false, bNonNegative: true));
			}
			else
			{
				return new long4(left._xy / right.xy, left._zw / right.zw);
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
				return new long4(left._xy / right.xy, left._zw / right.zw);
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
				return new long4(left._xy / right.xy, left._zw / right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 left, int4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_div_epi64(left, Avx.mm256_cvtepi32_pd(RegisterConversion.ToV128(right)), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.div_epi64(left.xy, Xse.cvtepi32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.div_epi64(left.zw, Xse.cvtepi32_epi64(RegisterConversion.ToV128(right.zw)), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new long4(left._xy / right.xy, left._zw / right.zw);
			}
		}

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
				return new long4(left._xy / right._xy, left._zw / right._zw);
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
				return new long4(left._xy % right.xy, left._zw % right.zw);
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
				return new long4(left._xy % right.xy, left._zw % right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, uint4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Xse.mm256_cvtepu32_pd(RegisterConversion.ToV128(right)), elements: 4, bIsDbl: true, bLEu32max: true, bNonNegative: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(left.xy, Xse.cvtepu32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true, bNonNegative: true), Xse.rem_epi64(left.zw, Xse.cvtepi32_epi64(RegisterConversion.ToV128(right.zw)), useFPU: false, bIsDbl: false, bNonNegative: true));
			}
			else
			{
				return new long4(left._xy % right.xy, left._zw % right.zw);
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
				return new long4(left._xy % right.xy, left._zw % right.zw);
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
				return new long4(left._xy % right.xy, left._zw % right.zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 left, int4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
                return Xse.mm256_rem_epi64(left, Avx.mm256_cvtepi32_pd(RegisterConversion.ToV128(right)), elements: 4, bIsDbl: true, bLEu32max: true);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				return new long4(Xse.rem_epi64(left.xy, Xse.cvtepi32_pd(RegisterConversion.ToV128(right)), useFPU: true, bIsDbl: true, bLEu32max: true), Xse.rem_epi64(left.zw, Xse.cvtepi32_epi64(RegisterConversion.ToV128(right.zw)), useFPU: false, bIsDbl: false));
			}
			else
			{
				return new long4(left._xy % right.xy, left._zw % right.zw);
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
				return new long4(left._xy % right._xy, left._zw % right._zw);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long4 operator * (long left, long4 right) => right * left;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 left, long right)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (constexpr.IS_CONST(right))
				{
					return new long4(left.x * right, left.y * right, left.z * right, left.w * right);
				}
				else
				{
					return left * (long4)right;
				}
			}
			else
			{
				return new long4(left._xy * right, left._zw * right);
			}
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_constdiv_epi64(left, right, 4);
                    }
                    else
                    {
                        return new long4(Xse.constdiv_epi64(left.xy, right), Xse.constdiv_epi64(left.zw, right));
                    }
                }
            }

            return left / (long4)right;
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_constrem_epi64(left, right, 4);
                    }
                    else
                    {
                        return new long4(Xse.constrem_epi64(left.xy, right), Xse.constrem_epi64(left.zw, right));
                    }
                }
            }

            return left % (long4)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 left, long4 right) => (long4)((ulong4)left & (ulong4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 left, long4 right) => (long4)((ulong4)left | (ulong4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 left, long4 right) => (long4)((ulong4)left ^ (ulong4)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 x)
		{
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi64(x);
			}
			else
            {
				return new long4(-x._xy, -x._zw);
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
				return new long4(x._xy + 1, x._zw + 1);
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
				return new long4(x._xy - 1, x._zw - 1);
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
				return new long4(x._xy >> n, x._zw >> n);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (long4 left, long4 right) => (ulong4)left == (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_cmplt_epi64(left, right)));
			}
			else
			{
				return new bool4(left._xy < right._xy, left._zw < right._zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return RegisterConversion.ToBool4(RegisterConversion.IsTrue64(Xse.mm256_cmpgt_epi64(left, right)));
			}
			else
			{
				return new bool4(left._xy > right._xy, left._zw > right._zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (long4 left, long4 right) => (ulong4)left != (ulong4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return RegisterConversion.ToBool4(RegisterConversion.IsFalse64(Xse.mm256_cmpgt_epi64(left, right)));
			}
			else
			{
				return new bool4(left._xy <= right._xy, left._zw <= right._zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (long4 left, long4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return RegisterConversion.ToBool4(RegisterConversion.IsFalse64(Xse.mm256_cmplt_epi64(left, right)));
			}
			else
			{
				return new bool4(left._xy >= right._xy, left._zw >= right._zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(long4 other) => ((ulong4)this).Equals((ulong4)other);

        public override readonly bool Equals(object obj) => obj is long4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((ulong4)this).GetHashCode();


        public override readonly string ToString() => $"long4({x}, {y}, {z}, {w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"long4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}