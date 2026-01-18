using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using MaxMath.Intrinsics;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
	[StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(short))]
	[DebuggerTypeProxy(typeof(short4.DebuggerProxy))]
    unsafe public struct short4 : IEquatable<short4>, IFormattable
	{
		internal sealed class DebuggerProxy
		{
			public short x;
			public short y;
			public short z;
			public short w;

			public DebuggerProxy(short4 v)
			{
				x = v.x;
				y = v.y;
				z = v.z;
				w = v.w;
			}
		}


        [FieldOffset(0)] public short x;
        [FieldOffset(2)] public short y;
        [FieldOffset(4)] public short z;
        [FieldOffset(6)] public short w;


        public static short4 zero => default;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short y, short z, short w)
        {
			this = (short4)new ushort4((ushort)x, (ushort)y, (ushort)z, (ushort)w);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short xyzw)
        {
			this = (short4)new ushort4((ushort)xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short2 xy, short z, short w)
        {
			this = (short4)new ushort4((ushort2)xy, (ushort)z, (ushort)w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short2 yz, short w)
        {
			this = (short4)new ushort4((ushort)x, (ushort2)yz, (ushort)w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short y, short2 zw)
        {
			this = (short4)new ushort4((ushort)x, (ushort)y, (ushort2)zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short2 xy, short2 zw)
        {
			this = (short4)new ushort4((ushort2)xy, (ushort2)zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short3 xyz, short w)
        {
			this = (short4)new ushort4((ushort3)xyz, (ushort)w);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short3 yzw)
        {
			this = (short4)new ushort4((ushort)x, (ushort3)yzw);
        }


        #region Shuffle
		public readonly short4 xxxx => (short4)((ushort4)this).xxxx;
        public readonly short4 xxxy => (short4)((ushort4)this).xxxy;
        public readonly short4 xxxz => (short4)((ushort4)this).xxxz;
        public readonly short4 xxxw => (short4)((ushort4)this).xxxw;
        public readonly short4 xxyx => (short4)((ushort4)this).xxyx;
        public readonly short4 xxyy => (short4)((ushort4)this).xxyy;
        public readonly short4 xxyz => (short4)((ushort4)this).xxyz;
        public readonly short4 xxyw => (short4)((ushort4)this).xxyw;
        public readonly short4 xxzx => (short4)((ushort4)this).xxzx;
        public readonly short4 xxzy => (short4)((ushort4)this).xxzy;
        public readonly short4 xxzz => (short4)((ushort4)this).xxzz;
        public readonly short4 xxzw => (short4)((ushort4)this).xxzw;
        public readonly short4 xxwx => (short4)((ushort4)this).xxwx;
        public readonly short4 xxwy => (short4)((ushort4)this).xxwy;
        public readonly short4 xxwz => (short4)((ushort4)this).xxwz;
        public readonly short4 xxww => (short4)((ushort4)this).xxww;
        public readonly short4 xyxx => (short4)((ushort4)this).xyxx;
		public readonly short4 xyxy => (short4)((ushort4)this).xyxy;
        public readonly short4 xyxz => (short4)((ushort4)this).xyxz;
		public readonly short4 xyxw => (short4)((ushort4)this).xyxw;
		public readonly short4 xyyx => (short4)((ushort4)this).xyyx;
		public readonly short4 xyyy => (short4)((ushort4)this).xyyy;
		public readonly short4 xyyz => (short4)((ushort4)this).xyyz;
		public readonly short4 xyyw => (short4)((ushort4)this).xyyw;
		public readonly short4 xyzx => (short4)((ushort4)this).xyzx;
        public readonly short4 xyzy => (short4)((ushort4)this).xyzy;
        public readonly short4 xyzz => (short4)((ushort4)this).xyzz;
		public readonly short4 xywx => (short4)((ushort4)this).xywx;
		public readonly short4 xywy => (short4)((ushort4)this).xywy;
		public		    short4 xywz { readonly get => (short4)((ushort4)this).xywz;  set { ushort4 _this = (ushort4)this; _this.xywz = (ushort4)value; this = (short4)_this; } }
		public readonly short4 xyww => (short4)((ushort4)this).xyww;
		public readonly short4 xzxx => (short4)((ushort4)this).xzxx;
        public readonly short4 xzxy => (short4)((ushort4)this).xzxy;
        public readonly short4 xzxz => (short4)((ushort4)this).xzxz;
		public readonly short4 xzxw => (short4)((ushort4)this).xzxw;
		public readonly short4 xzyx => (short4)((ushort4)this).xzyx;
        public readonly short4 xzyy => (short4)((ushort4)this).xzyy;
        public readonly short4 xzyz => (short4)((ushort4)this).xzyz;
		public			short4 xzyw { readonly get => (short4)((ushort4)this).xzyw;  set { ushort4 _this = (ushort4)this; _this.xzyw = (ushort4)value; this = (short4)_this; } }
		public readonly short4 xzzx => (short4)((ushort4)this).xzzx;
        public readonly short4 xzzy => (short4)((ushort4)this).xzzy;
        public readonly short4 xzzz => (short4)((ushort4)this).xzzz;
		public readonly short4 xzzw => (short4)((ushort4)this).xzzw;
		public readonly short4 xzwx => (short4)((ushort4)this).xzwx;
		public			short4 xzwy { readonly get => (short4)((ushort4)this).xzwy;  set { ushort4 _this = (ushort4)this; _this.xzwy = (ushort4)value; this = (short4)_this; } }
		public readonly short4 xzwz => (short4)((ushort4)this).xzwz;
		public readonly short4 xzww => (short4)((ushort4)this).xzww;
		public readonly short4 xwxx => (short4)((ushort4)this).xwxx;
		public readonly short4 xwxy => (short4)((ushort4)this).xwxy;
		public readonly short4 xwxz => (short4)((ushort4)this).xwxz;
		public readonly short4 xwxw => (short4)((ushort4)this).xwxw;
		public readonly short4 xwyx => (short4)((ushort4)this).xwyx;
		public readonly short4 xwyy => (short4)((ushort4)this).xwyy;
		public			short4 xwyz { readonly get => (short4)((ushort4)this).xwyz;  set { ushort4 _this = (ushort4)this; _this.xwyz = (ushort4)value; this = (short4)_this; } }
		public readonly short4 xwyw => (short4)((ushort4)this).xwyw;
		public readonly short4 xwzx => (short4)((ushort4)this).xwzx;
		public			short4 xwzy { readonly get => (short4)((ushort4)this).xwzy;  set { ushort4 _this = (ushort4)this; _this.xwzy = (ushort4)value; this = (short4)_this; } }
		public readonly short4 xwzz => (short4)((ushort4)this).xwzz;
		public readonly short4 xwzw => (short4)((ushort4)this).xwzw;
		public readonly short4 xwwx => (short4)((ushort4)this).xwwx;
		public readonly short4 xwwy => (short4)((ushort4)this).xwwy;
		public readonly short4 xwwz => (short4)((ushort4)this).xwwz;
		public readonly short4 xwww => (short4)((ushort4)this).xwww;
		public readonly short4 yxxx => (short4)((ushort4)this).yxxx;
        public readonly short4 yxxy => (short4)((ushort4)this).yxxy;
        public readonly short4 yxxz => (short4)((ushort4)this).yxxz;
		public readonly short4 yxxw => (short4)((ushort4)this).yxxw;
		public readonly short4 yxyx => (short4)((ushort4)this).yxyx;
        public readonly short4 yxyy => (short4)((ushort4)this).yxyy;
        public readonly short4 yxyz => (short4)((ushort4)this).yxyz;
		public readonly short4 yxyw => (short4)((ushort4)this).yxyw;
		public readonly short4 yxzx => (short4)((ushort4)this).yxzx;
        public readonly short4 yxzy => (short4)((ushort4)this).yxzy;
        public readonly short4 yxzz => (short4)((ushort4)this).yxzz;
		public			short4 yxzw { readonly get => (short4)((ushort4)this).yxzw;  set { ushort4 _this = (ushort4)this; _this.yxzw = (ushort4)value; this = (short4)_this; } }
		public readonly short4 yxwx => (short4)((ushort4)this).yxwx;
		public readonly short4 yxwy => (short4)((ushort4)this).yxwy;
		public			short4 yxwz { readonly get => (short4)((ushort4)this).yxwz;  set { ushort4 _this = (ushort4)this; _this.yxwz = (ushort4)value; this = (short4)_this; } }
		public readonly short4 yxww => (short4)((ushort4)this).yxww;
		public readonly short4 yyxx => (short4)((ushort4)this).yyxx;
        public readonly short4 yyxy => (short4)((ushort4)this).yyxy;
        public readonly short4 yyxz => (short4)((ushort4)this).yyxz;
		public readonly short4 yyxw => (short4)((ushort4)this).yyxw;
		public readonly short4 yyyx => (short4)((ushort4)this).yyyx;
        public readonly short4 yyyy => (short4)((ushort4)this).yyyy;
        public readonly short4 yyyz => (short4)((ushort4)this).yyyz;
		public readonly short4 yyyw => (short4)((ushort4)this).yyyw;
		public readonly short4 yyzx => (short4)((ushort4)this).yyzx;
        public readonly short4 yyzy => (short4)((ushort4)this).yyzy;
        public readonly short4 yyzz => (short4)((ushort4)this).yyzz;
		public readonly short4 yyzw => (short4)((ushort4)this).yyzw;
		public readonly short4 yywx => (short4)((ushort4)this).yywx;
		public readonly short4 yywy => (short4)((ushort4)this).yywy;
		public readonly short4 yywz => (short4)((ushort4)this).yywz;
		public readonly short4 yyww => (short4)((ushort4)this).yyww;
		public readonly short4 yzxx => (short4)((ushort4)this).yzxx;
        public readonly short4 yzxy => (short4)((ushort4)this).yzxy;
        public readonly short4 yzxz => (short4)((ushort4)this).yzxz;
		public			short4 yzxw { readonly get => (short4)((ushort4)this).yzxw;  set { ushort4 _this = (ushort4)this; _this.yzxw = (ushort4)value; this = (short4)_this; } }
		public readonly short4 yzyx => (short4)((ushort4)this).yzyx;
        public readonly short4 yzyy => (short4)((ushort4)this).yzyy;
        public readonly short4 yzyz => (short4)((ushort4)this).yzyz;
		public readonly short4 yzyw => (short4)((ushort4)this).yzyw;
		public readonly short4 yzzx => (short4)((ushort4)this).yzzx;
        public readonly short4 yzzy => (short4)((ushort4)this).yzzy;
        public readonly short4 yzzz => (short4)((ushort4)this).yzzz;
		public readonly short4 yzzw => (short4)((ushort4)this).yzzw;
		public			short4 yzwx { readonly get => (short4)((ushort4)this).yzwx;  set { ushort4 _this = (ushort4)this; _this.yzwx = (ushort4)value; this = (short4)_this; } }
		public readonly short4 yzwy => (short4)((ushort4)this).yzwy;
		public readonly short4 yzwz => (short4)((ushort4)this).yzwz;
		public readonly short4 yzww => (short4)((ushort4)this).yzww;
		public readonly short4 ywxx => (short4)((ushort4)this).ywxx;
		public readonly short4 ywxy => (short4)((ushort4)this).ywxy;
		public			short4 ywxz { readonly get => (short4)((ushort4)this).ywxz;  set { ushort4 _this = (ushort4)this; _this.ywxz = (ushort4)value; this = (short4)_this; } }
		public readonly short4 ywxw => (short4)((ushort4)this).ywxw;
		public readonly short4 ywyx => (short4)((ushort4)this).ywyx;
		public readonly short4 ywyy => (short4)((ushort4)this).ywyy;
		public readonly short4 ywyz => (short4)((ushort4)this).ywyz;
		public readonly short4 ywyw => (short4)((ushort4)this).ywyw;
		public			short4 ywzx { readonly get => (short4)((ushort4)this).ywzx;  set { ushort4 _this = (ushort4)this; _this.ywzx = (ushort4)value; this = (short4)_this; } }
		public readonly short4 ywzy => (short4)((ushort4)this).ywzy;
		public readonly short4 ywzz => (short4)((ushort4)this).ywzz;
		public readonly short4 ywzw => (short4)((ushort4)this).ywzw;
		public readonly short4 ywwx => (short4)((ushort4)this).ywwx;
		public readonly short4 ywwy => (short4)((ushort4)this).ywwy;
		public readonly short4 ywwz => (short4)((ushort4)this).ywwz;
		public readonly short4 ywww => (short4)((ushort4)this).ywww;
		public readonly short4 zxxx => (short4)((ushort4)this).zxxx;
        public readonly short4 zxxy => (short4)((ushort4)this).zxxy;
        public readonly short4 zxxz => (short4)((ushort4)this).zxxz;
		public readonly short4 zxxw => (short4)((ushort4)this).zxxw;
		public readonly short4 zxyx => (short4)((ushort4)this).zxyx;
        public readonly short4 zxyy => (short4)((ushort4)this).zxyy;
        public readonly short4 zxyz => (short4)((ushort4)this).zxyz;
		public			short4 zxyw { readonly get => (short4)((ushort4)this).zxyw;  set { ushort4 _this = (ushort4)this; _this.zxyw = (ushort4)value; this = (short4)_this; } }
		public readonly short4 zxzx => (short4)((ushort4)this).zxzx;
        public readonly short4 zxzy => (short4)((ushort4)this).zxzy;
        public readonly short4 zxzz => (short4)((ushort4)this).zxzz;
		public readonly short4 zxzw => (short4)((ushort4)this).zxzw;
		public readonly short4 zxwx => (short4)((ushort4)this).zxwx;
		public			short4 zxwy { readonly get => (short4)((ushort4)this).zxwy;  set { ushort4 _this = (ushort4)this; _this.zxwy = (ushort4)value; this = (short4)_this; } }
		public readonly short4 zxwz => (short4)((ushort4)this).zxwz;
		public readonly short4 zxww => (short4)((ushort4)this).zxww;
		public readonly short4 zyxx => (short4)((ushort4)this).zyxx;
        public readonly short4 zyxy => (short4)((ushort4)this).zyxy;
        public readonly short4 zyxz => (short4)((ushort4)this).zyxz;
		public			short4 zyxw { readonly get => (short4)((ushort4)this).zyxw;  set { ushort4 _this = (ushort4)this; _this.zyxw = (ushort4)value; this = (short4)_this; } }
		public readonly short4 zyyx => (short4)((ushort4)this).zyyx;
        public readonly short4 zyyy => (short4)((ushort4)this).zyyy;
        public readonly short4 zyyz => (short4)((ushort4)this).zyyz;
		public readonly short4 zyyw => (short4)((ushort4)this).zyyw;
		public readonly short4 zyzx => (short4)((ushort4)this).zyzx;
        public readonly short4 zyzy => (short4)((ushort4)this).zyzy;
        public readonly short4 zyzz => (short4)((ushort4)this).zyzz;
		public readonly short4 zyzw => (short4)((ushort4)this).zyzw;
		public			short4 zywx { readonly get => (short4)((ushort4)this).zywx;  set { ushort4 _this = (ushort4)this; _this.zywx = (ushort4)value; this = (short4)_this; } }
		public readonly short4 zywy => (short4)((ushort4)this).zywy;
		public readonly short4 zywz => (short4)((ushort4)this).zywz;
		public readonly short4 zyww => (short4)((ushort4)this).zyww;
		public readonly short4 zzxx => (short4)((ushort4)this).zzxx;
        public readonly short4 zzxy => (short4)((ushort4)this).zzxy;
        public readonly short4 zzxz => (short4)((ushort4)this).zzxz;
		public readonly short4 zzxw => (short4)((ushort4)this).zzxw;
		public readonly short4 zzyx => (short4)((ushort4)this).zzyx;
        public readonly short4 zzyy => (short4)((ushort4)this).zzyy;
        public readonly short4 zzyz => (short4)((ushort4)this).zzyz;
		public readonly short4 zzyw => (short4)((ushort4)this).zzyw;
		public readonly short4 zzzx => (short4)((ushort4)this).zzzx;
        public readonly short4 zzzy => (short4)((ushort4)this).zzzy;
        public readonly short4 zzzz => (short4)((ushort4)this).zzzz;
		public readonly short4 zzzw => (short4)((ushort4)this).zzzw;
		public readonly short4 zzwx => (short4)((ushort4)this).zzwx;
		public readonly short4 zzwy => (short4)((ushort4)this).zzwy;
		public readonly short4 zzwz => (short4)((ushort4)this).zzwz;
		public readonly short4 zzww => (short4)((ushort4)this).zzww;
		public readonly short4 zwxx => (short4)((ushort4)this).zwxx;
		public			short4 zwxy { readonly get => (short4)((ushort4)this).zwxy;  set { ushort4 _this = (ushort4)this; _this.zwxy = (ushort4)value; this = (short4)_this; } }
		public readonly short4 zwxz => (short4)((ushort4)this).zwxz;
		public readonly short4 zwxw => (short4)((ushort4)this).zwxw;
		public			short4 zwyx { readonly get => (short4)((ushort4)this).zwyx;  set { ushort4 _this = (ushort4)this; _this.zwyx = (ushort4)value; this = (short4)_this; } }
		public readonly short4 zwyy => (short4)((ushort4)this).zwyy;
		public readonly short4 zwyz => (short4)((ushort4)this).zwyz;
		public readonly short4 zwyw => (short4)((ushort4)this).zwyw;
		public readonly short4 zwzx => (short4)((ushort4)this).zwzx;
		public readonly short4 zwzy => (short4)((ushort4)this).zwzy;
		public readonly short4 zwzz => (short4)((ushort4)this).zwzz;
		public readonly short4 zwzw => (short4)((ushort4)this).zwzw;
		public readonly short4 zwwx => (short4)((ushort4)this).zwwx;
		public readonly short4 zwwy => (short4)((ushort4)this).zwwy;
		public readonly short4 zwwz => (short4)((ushort4)this).zwwz;
		public readonly short4 zwww => (short4)((ushort4)this).zwww;
		public readonly short4 wxxx => (short4)((ushort4)this).wxxx;
		public readonly short4 wxxy => (short4)((ushort4)this).wxxy;
		public readonly short4 wxxz => (short4)((ushort4)this).wxxz;
		public readonly short4 wxxw => (short4)((ushort4)this).wxxw;
		public readonly short4 wxyx => (short4)((ushort4)this).wxyx;
		public readonly short4 wxyy => (short4)((ushort4)this).wxyy;
		public			short4 wxyz { readonly get => (short4)((ushort4)this).wxyz;  set { ushort4 _this = (ushort4)this; _this.wxyz = (ushort4)value; this = (short4)_this; } }
		public readonly short4 wxyw => (short4)((ushort4)this).wxyw;
		public readonly short4 wxzx => (short4)((ushort4)this).wxzx;
		public			short4 wxzy { readonly get => (short4)((ushort4)this).wxzy;  set { ushort4 _this = (ushort4)this; _this.wxzy = (ushort4)value; this = (short4)_this; } }
		public readonly short4 wxzz => (short4)((ushort4)this).wxzz;
		public readonly short4 wxzw => (short4)((ushort4)this).wxzw;
		public readonly short4 wxwx => (short4)((ushort4)this).wxwx;
		public readonly short4 wxwy => (short4)((ushort4)this).wxwy;
		public readonly short4 wxwz => (short4)((ushort4)this).wxwz;
		public readonly short4 wxww => (short4)((ushort4)this).wxww;
		public readonly short4 wyxx => (short4)((ushort4)this).wyxx;
		public readonly short4 wyxy => (short4)((ushort4)this).wyxy;
		public			short4 wyxz { readonly get => (short4)((ushort4)this).wyxz;  set { ushort4 _this = (ushort4)this; _this.wyxz = (ushort4)value; this = (short4)_this; } }
		public readonly short4 wyxw => (short4)((ushort4)this).wyxw;
		public readonly short4 wyyx => (short4)((ushort4)this).wyyx;
		public readonly short4 wyyy => (short4)((ushort4)this).wyyy;
		public readonly short4 wyyz => (short4)((ushort4)this).wyyz;
		public readonly short4 wyyw => (short4)((ushort4)this).wyyw;
		public			short4 wyzx { readonly get => (short4)((ushort4)this).wyzx;  set { ushort4 _this = (ushort4)this; _this.wyzx = (ushort4)value; this = (short4)_this; } }
		public readonly short4 wyzy => (short4)((ushort4)this).wyzy;
		public readonly short4 wyzz => (short4)((ushort4)this).wyzz;
		public readonly short4 wyzw => (short4)((ushort4)this).wyzw;
		public readonly short4 wywx => (short4)((ushort4)this).wywx;
		public readonly short4 wywy => (short4)((ushort4)this).wywy;
		public readonly short4 wywz => (short4)((ushort4)this).wywz;
		public readonly short4 wyww => (short4)((ushort4)this).wyww;
		public readonly short4 wzxx => (short4)((ushort4)this).wzxx;
		public			short4 wzxy { readonly get => (short4)((ushort4)this).wzxy;  set { ushort4 _this = (ushort4)this; _this.wzxy = (ushort4)value; this = (short4)_this; } }
		public readonly short4 wzxz => (short4)((ushort4)this).wzxz;
		public readonly short4 wzxw => (short4)((ushort4)this).wzxw;
		public			short4 wzyx { readonly get => (short4)((ushort4)this).wzyx;  set { ushort4 _this = (ushort4)this; _this.wzyx = (ushort4)value; this = (short4)_this; } }
		public readonly short4 wzyy => (short4)((ushort4)this).wzyy;
		public readonly short4 wzyz => (short4)((ushort4)this).wzyz;
		public readonly short4 wzyw => (short4)((ushort4)this).wzyw;
		public readonly short4 wzzx => (short4)((ushort4)this).wzzx;
		public readonly short4 wzzy => (short4)((ushort4)this).wzzy;
		public readonly short4 wzzz => (short4)((ushort4)this).wzzz;
		public readonly short4 wzzw => (short4)((ushort4)this).wzzw;
		public readonly short4 wzwx => (short4)((ushort4)this).wzwx;
		public readonly short4 wzwy => (short4)((ushort4)this).wzwy;
		public readonly short4 wzwz => (short4)((ushort4)this).wzwz;
		public readonly short4 wzww => (short4)((ushort4)this).wzww;
		public readonly short4 wwxx => (short4)((ushort4)this).wwxx;
		public readonly short4 wwxy => (short4)((ushort4)this).wwxy;
		public readonly short4 wwxz => (short4)((ushort4)this).wwxz;
		public readonly short4 wwxw => (short4)((ushort4)this).wwxw;
		public readonly short4 wwyx => (short4)((ushort4)this).wwyx;
		public readonly short4 wwyy => (short4)((ushort4)this).wwyy;
		public readonly short4 wwyz => (short4)((ushort4)this).wwyz;
		public readonly short4 wwyw => (short4)((ushort4)this).wwyw;
		public readonly short4 wwzx => (short4)((ushort4)this).wwzx;
		public readonly short4 wwzy => (short4)((ushort4)this).wwzy;
		public readonly short4 wwzz => (short4)((ushort4)this).wwzz;
		public readonly short4 wwzw => (short4)((ushort4)this).wwzw;
		public readonly short4 wwwx => (short4)((ushort4)this).wwwx;
		public readonly short4 wwwy => (short4)((ushort4)this).wwwy;
		public readonly short4 wwwz => (short4)((ushort4)this).wwwz;
		public readonly short4 wwww => (short4)((ushort4)this).wwww;

		public readonly short3 xxx => (short3)((ushort4)this).xxx;
        public readonly short3 xxy => (short3)((ushort4)this).xxy;
        public readonly short3 xxz => (short3)((ushort4)this).xxz;
		public readonly short3 xxw => (short3)((ushort4)this).xxw;
		public readonly short3 xyx => (short3)((ushort4)this).xyx;
        public readonly short3 xyy => (short3)((ushort4)this).xyy;
		public			short3 xyz { readonly get => (short3)((ushort4)this).xyz;  set { ushort4 _this = (ushort4)this; _this.xyz = (ushort3)value; this = (short4)_this; } }
		public			short3 xyw { readonly get => (short3)((ushort4)this).xyw;  set { ushort4 _this = (ushort4)this; _this.xyw = (ushort3)value; this = (short4)_this; } }
		public readonly short3 xzx => (short3)((ushort4)this).xzx;
        public          short3 xzy { readonly get => (short3)((ushort4)this).xzy;  set { ushort4 _this = (ushort4)this; _this.xzy = (ushort3)value; this = (short4)_this; } }
        public readonly short3 xzz => (short3)((ushort4)this).xzz;
		public			short3 xzw { readonly get => (short3)((ushort4)this).xzw;  set { ushort4 _this = (ushort4)this; _this.xzw = (ushort3)value; this = (short4)_this; } }
		public readonly short3 xwx => (short3)((ushort4)this).xwx;
		public			short3 xwy { readonly get => (short3)((ushort4)this).xwy;  set { ushort4 _this = (ushort4)this; _this.xwy = (ushort3)value; this = (short4)_this; } }
		public			short3 xwz { readonly get => (short3)((ushort4)this).xwz;  set { ushort4 _this = (ushort4)this; _this.xwz = (ushort3)value; this = (short4)_this; } }
		public readonly short3 xww => (short3)((ushort4)this).xww;
		public readonly short3 yxx => (short3)((ushort4)this).yxx;
        public readonly short3 yxy => (short3)((ushort4)this).yxy;
        public          short3 yxz { readonly get => (short3)((ushort4)this).yxz;  set { ushort4 _this = (ushort4)this; _this.yxz = (ushort3)value; this = (short4)_this; } }
		public			short3 yxw { readonly get => (short3)((ushort4)this).yxw;  set { ushort4 _this = (ushort4)this; _this.yxw = (ushort3)value; this = (short4)_this; } }
		public readonly short3 yyx => (short3)((ushort4)this).yyx;
        public readonly short3 yyy => (short3)((ushort4)this).yyy;
        public readonly short3 yyz => (short3)((ushort4)this).yyz;
		public readonly short3 yyw => (short3)((ushort4)this).yyw;
		public          short3 yzx { readonly get => (short3)((ushort4)this).yzx;  set { ushort4 _this = (ushort4)this; _this.yzx = (ushort3)value; this = (short4)_this; } }
        public readonly short3 yzy => (short3)((ushort4)this).yzy;
        public readonly short3 yzz => (short3)((ushort4)this).yzz;
		public			short3 yzw { readonly get => (short3)((ushort4)this).yzw;  set { ushort4 _this = (ushort4)this; _this.yzw = (ushort3)value; this = (short4)_this; } }
		public			short3 ywx { readonly get => (short3)((ushort4)this).ywx;  set { ushort4 _this = (ushort4)this; _this.ywx = (ushort3)value; this = (short4)_this; } }
		public readonly short3 ywy => (short3)((ushort4)this).ywy;
		public			short3 ywz { readonly get => (short3)((ushort4)this).ywz;  set { ushort4 _this = (ushort4)this; _this.ywz = (ushort3)value; this = (short4)_this; } }
		public readonly short3 yww => (short3)((ushort4)this).yww;
		public readonly short3 zxx => (short3)((ushort4)this).zxx;
        public          short3 zxy { readonly get => (short3)((ushort4)this).zxy;  set { ushort4 _this = (ushort4)this; _this.zxy = (ushort3)value; this = (short4)_this; } }
        public readonly short3 zxz => (short3)((ushort4)this).zxz;
		public          short3 zxw { readonly get => (short3)((ushort4)this).zxw;  set { ushort4 _this = (ushort4)this; _this.zxw = (ushort3)value; this = (short4)_this; } }
		public          short3 zyx { readonly get => (short3)((ushort4)this).zyx;  set { ushort4 _this = (ushort4)this; _this.zyx = (ushort3)value; this = (short4)_this; } }
        public readonly short3 zyy => (short3)((ushort4)this).zyy;
        public readonly short3 zyz => (short3)((ushort4)this).zyz;
		public          short3 zyw { readonly get => (short3)((ushort4)this).zyw;  set { ushort4 _this = (ushort4)this; _this.zyw = (ushort3)value; this = (short4)_this; } }
		public readonly short3 zzx => (short3)((ushort4)this).zzx;
        public readonly short3 zzy => (short3)((ushort4)this).zzy;
        public readonly short3 zzz => (short3)((ushort4)this).zzz;
		public readonly short3 zzw => (short3)((ushort4)this).zzw;
		public          short3 zwx { readonly get => (short3)((ushort4)this).zwx;  set { ushort4 _this = (ushort4)this; _this.zwx = (ushort3)value; this = (short4)_this; } }
		public          short3 zwy { readonly get => (short3)((ushort4)this).zwy;  set { ushort4 _this = (ushort4)this; _this.zwy = (ushort3)value; this = (short4)_this; } }
		public readonly short3 zwz => (short3)((ushort4)this).zwz;
		public readonly short3 zww => (short3)((ushort4)this).zww;
		public readonly short3 wxx => (short3)((ushort4)this).wxx;
		public          short3 wxy { readonly get => (short3)((ushort4)this).wxy;  set { ushort4 _this = (ushort4)this; _this.wxy = (ushort3)value; this = (short4)_this; } }
		public          short3 wxz { readonly get => (short3)((ushort4)this).wxz;  set { ushort4 _this = (ushort4)this; _this.wxz = (ushort3)value; this = (short4)_this; } }
		public readonly short3 wxw => (short3)((ushort4)this).wxw;
		public          short3 wyx { readonly get => (short3)((ushort4)this).wyx;  set { ushort4 _this = (ushort4)this; _this.wyx = (ushort3)value; this = (short4)_this; } }
		public readonly short3 wyy => (short3)((ushort4)this).wyy;
		public          short3 wyz { readonly get => (short3)((ushort4)this).wyz;  set { ushort4 _this = (ushort4)this; _this.wyz = (ushort3)value; this = (short4)_this; } }
		public readonly short3 wyw => (short3)((ushort4)this).wyw;
		public          short3 wzx { readonly get => (short3)((ushort4)this).wzx;  set { ushort4 _this = (ushort4)this; _this.wzx = (ushort3)value; this = (short4)_this; } }
		public          short3 wzy { readonly get => (short3)((ushort4)this).wzy;  set { ushort4 _this = (ushort4)this; _this.wzy = (ushort3)value; this = (short4)_this; } }
		public readonly short3 wzz => (short3)((ushort4)this).wzz;
		public readonly short3 wzw => (short3)((ushort4)this).wzw;
		public readonly short3 wwx => (short3)((ushort4)this).wwx;
		public readonly short3 wwy => (short3)((ushort4)this).wwy;
		public readonly short3 wwz => (short3)((ushort4)this).wwz;
		public readonly short3 www => (short3)((ushort4)this).www;

		public readonly short2 xx => (short2)((ushort4)this).xx;
        public          short2 xy { readonly get => (short2)((ushort4)this).xy;  set { ushort4 _this = (ushort4)this; _this.xy = (ushort2)value; this = (short4)_this; } }
        public          short2 xz { readonly get => (short2)((ushort4)this).xz;  set { ushort4 _this = (ushort4)this; _this.xz = (ushort2)value; this = (short4)_this; } }
		public          short2 xw { readonly get => (short2)((ushort4)this).xw;  set { ushort4 _this = (ushort4)this; _this.xw = (ushort2)value; this = (short4)_this; } }
		public          short2 yx { readonly get => (short2)((ushort4)this).yx;  set { ushort4 _this = (ushort4)this; _this.yx = (ushort2)value; this = (short4)_this; } }
        public readonly short2 yy => (short2)((ushort4)this).yy;
        public          short2 yz { readonly get => (short2)((ushort4)this).yz;  set { ushort4 _this = (ushort4)this; _this.yz = (ushort2)value; this = (short4)_this; } }
		public          short2 yw { readonly get => (short2)((ushort4)this).yw;  set { ushort4 _this = (ushort4)this; _this.yw = (ushort2)value; this = (short4)_this; } }
		public          short2 zx { readonly get => (short2)((ushort4)this).zx;  set { ushort4 _this = (ushort4)this; _this.zx = (ushort2)value; this = (short4)_this; } }
        public          short2 zy { readonly get => (short2)((ushort4)this).zy;  set { ushort4 _this = (ushort4)this; _this.zy = (ushort2)value; this = (short4)_this; } }
        public readonly short2 zz => (short2)((ushort4)this).zz;
		public          short2 zw { readonly get => (short2)((ushort4)this).zw;  set { ushort4 _this = (ushort4)this; _this.zw = (ushort2)value; this = (short4)_this; } }
		public          short2 wx { readonly get => (short2)((ushort4)this).wx;  set { ushort4 _this = (ushort4)this; _this.wx = (ushort2)value; this = (short4)_this; } }
		public          short2 wy { readonly get => (short2)((ushort4)this).wy;  set { ushort4 _this = (ushort4)this; _this.wy = (ushort2)value; this = (short4)_this; } }
		public          short2 wz { readonly get => (short2)((ushort4)this).wz;  set { ushort4 _this = (ushort4)this; _this.wz = (ushort2)value; this = (short4)_this; } }
		public readonly short2 ww => (short2)((ushort4)this).ww;
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short4 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(v128 input) => RegisterConversion.ToAbstraction128<short4>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(short input) => new short4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(ushort4 input) => *(short4*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(int4 input) => (short4)(ushort4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(uint4 input) => (short4)(ushort4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(long4 input) => (short4)(ushort4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(ulong4 input) => (short4)(ushort4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(half4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epi16(RegisterConversion.ToV128(input), 4);
            }
            else
            {
                return new short4((short)maxmath.BASE_cvtf16i32(input.x, signed: true, trunc: true),
                                  (short)maxmath.BASE_cvtf16i32(input.y, signed: true, trunc: true),
                                  (short)maxmath.BASE_cvtf16i32(input.z, signed: true, trunc: true),
                                  (short)maxmath.BASE_cvtf16i32(input.w, signed: true, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(float4 input) => (short4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(double4 input) => (short4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(short4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				return RegisterConversion.ToInt4(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(short4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				return RegisterConversion.ToUInt4(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new uint4((uint)input.x, (uint)input.y, (uint)input.z, (uint)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(short4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
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
        public static explicit operator ulong4(short4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
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
        public static implicit operator half4(short4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf4(Xse.cvtepi16_ph(input, elements: 4));
            }
            else
            {
                return (half4)(float4)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(short4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat4(Xse.cvtepi16_ps(input));
            }
            else
            {
                return (float4)(int4)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(short4 input) => (double4)(int4)input;


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return (short)((ushort4)this)[index];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                ushort4 _this = (ushort4)this;
                _this[index] = (ushort)value;
                this = (short4)_this;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator + (short4 left, short4 right) => (short4)((ushort4)left + (ushort4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator - (short4 left, short4 right) => (short4)((ushort4)left - (ushort4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator * (short4 left, short4 right) => (short4)((ushort4)left * (ushort4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator / (short4 left, short4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epi16(left, right, false, 4);
            }
            else
            {
                return new short4((short)(left.x / right.x), (short)(left.y / right.y), (short)(left.z / right.z), (short)(left.w / right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator % (short4 left, short4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epi16(left, right, 4);
            }
            else
            {
                return new short4((short)(left.x % right.x), (short)(left.y % right.y), (short)(left.z % right.z), (short)(left.w % right.w));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator * (short left, short4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator * (short4 left, short right)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(right))
				{
					return (v128)((short8)((v128)left) * right);
				}
			}

			return left * (short4)right;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator / (short4 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epi16(left, right, 4);
                }
            }

            return left / (short4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator % (short4 left, short right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epi16(left, right, 4);
                }
            }

            return left % (short4)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator & (short4 left, short4 right) => (short4)((ushort4)left & (ushort4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator | (short4 left, short4 right) => (short4)((ushort4)left | (ushort4)right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator ^ (short4 left, short4 right) => (short4)((ushort4)left ^ (ushort4)right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator - (short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return new short4((short)-x.x, (short)-x.y, (short)-x.z, (short)-x.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator ++ (short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi16(x);
			}
            else
            {
                return new short4((short)(x.x + 1), (short)(x.y + 1), (short)(x.z + 1), (short)(x.w + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator -- (short4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi16(x);
			}
            else
            {
                return new short4((short)(x.x - 1), (short)(x.y - 1), (short)(x.z - 1), (short)(x.w - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator ~ (short4 x) => (short4)~(ushort4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator << (short4 x, int n) => (short4)((ushort4)x << n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator >> (short4 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srai_epi16(x, n, inRange: true);
            }
            else
            {
                return new short4((short)(x.x >> n), (short)(x.y >> n), (short)(x.z >> n), (short)(x.w >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (short4 left, short4 right) => (ushort4)left == (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (short4 left, short4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmplt_epi16(left, right));

				return *(bool4*)&results;
            }
            else
            {
                return new bool4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (short4 left, short4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmpgt_epi16(left, right));

				return *(bool4*)&results;
            }
            else
            {
                return new bool4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (short4 left, short4 right) => (ushort4)left != (ushort4)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (short4 left, short4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse16(Xse.cmpgt_epi16(left, right));

				return *(bool4*)&results;
            }
            else
            {
                return new bool4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (short4 left, short4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse16(Xse.cmplt_epi16(left, right));

				return *(bool4*)&results;
			}
            else
            {
                return new bool4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short4 other) => ((ushort4)this).Equals((ushort4)other);

        public override readonly bool Equals(object obj) => obj is short4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => ((ushort4)this).GetHashCode();


        public override readonly string ToString() => $"short4({x}, {y}, {z}, {w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}