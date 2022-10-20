using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(byte))] 
    [DebuggerTypeProxy(typeof(quarter4.DebuggerProxy))]
    unsafe public struct quarter4 : IEquatable<quarter4>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public quarter x;
            public quarter y;
            public quarter z;
            public quarter w;

            public DebuggerProxy(quarter4 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
                w = v.w;
            }
        }


        [FieldOffset(0)] public quarter x;
        [FieldOffset(1)] public quarter y;
        [FieldOffset(2)] public quarter z;
        [FieldOffset(3)] public quarter w;


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


        #region Shuffle
        public readonly quarter4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxx); }
        public readonly quarter4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxy); }
        public readonly quarter4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxz); }
        public readonly quarter4 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxxw); }
        public readonly quarter4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyx); }
        public readonly quarter4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyy); }
        public readonly quarter4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyz); }
        public readonly quarter4 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxyw); }
        public readonly quarter4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzx); }
        public readonly quarter4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzy); }
        public readonly quarter4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzz); }
        public readonly quarter4 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxzw); }
        public readonly quarter4 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxwx); }
        public readonly quarter4 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxwy); }
        public readonly quarter4 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxwz); }
        public readonly quarter4 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxww); }
        public readonly quarter4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxx); }
        public readonly quarter4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxy); }
        public readonly quarter4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxz); }
        public readonly quarter4 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyxw); }
        public readonly quarter4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyx); }
        public readonly quarter4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyy); }
        public readonly quarter4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyz); }
        public readonly quarter4 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyyw); }
        public readonly quarter4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyzx); }
        public readonly quarter4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyzy); }
        public readonly quarter4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyzz); }
        public readonly quarter4 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xywx); }
        public readonly quarter4 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xywy); }
        public          quarter4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xywz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xywz; }
        public readonly quarter4 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyww); }
        public readonly quarter4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxx); }
        public readonly quarter4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxy); }
        public readonly quarter4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxz); }
        public readonly quarter4 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzxw); }
        public readonly quarter4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzyx); }
        public readonly quarter4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzyy); }
        public readonly quarter4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzyz); }
        public          quarter4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzyw; }
        public readonly quarter4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzx); }
        public readonly quarter4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzy); }
        public readonly quarter4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzz); }
        public readonly quarter4 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzzw); }
        public readonly quarter4 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzwx); }
        public          quarter4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwyz; }
        public readonly quarter4 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzwz); }
        public readonly quarter4 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzww); }
        public readonly quarter4 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwxx); }
        public readonly quarter4 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwxy); }
        public readonly quarter4 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwxz); }
        public readonly quarter4 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwxw); }
        public readonly quarter4 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwyx); }
        public readonly quarter4 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwyy); }
        public          quarter4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xwyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzwy; }
        public readonly quarter4 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwyw); }
        public readonly quarter4 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwzx); }
        public          quarter4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xwzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwzy; }
        public readonly quarter4 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwzz); }
        public readonly quarter4 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwzw); }
        public readonly quarter4 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwwx); }
        public readonly quarter4 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwwy); }
        public readonly quarter4 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwwz); }
        public readonly quarter4 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwww); }
        public readonly quarter4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxx); }
        public readonly quarter4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxy); }
        public readonly quarter4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxz); }
        public readonly quarter4 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxxw); }
        public readonly quarter4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyx); }
        public readonly quarter4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyy); }
        public readonly quarter4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyz); }
        public readonly quarter4 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxyw); }
        public readonly quarter4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxzx); }
        public readonly quarter4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxzy); }
        public readonly quarter4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxzz); }
        public          quarter4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxzw; }
        public readonly quarter4 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxwx); }
        public readonly quarter4 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxwy); }
        public          quarter4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxwz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxwz; }
        public readonly quarter4 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxww); }
        public readonly quarter4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxx); }
        public readonly quarter4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxy); }
        public readonly quarter4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxz); }
        public readonly quarter4 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyxw); }
        public readonly quarter4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyx); }
        public readonly quarter4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyy); }
        public readonly quarter4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyz); }
        public readonly quarter4 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyyw); }
        public readonly quarter4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzx); }
        public readonly quarter4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzy); }
        public readonly quarter4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzz); }
        public readonly quarter4 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyzw); }
        public readonly quarter4 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yywx); }
        public readonly quarter4 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yywy); }
        public readonly quarter4 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yywz); }
        public readonly quarter4 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyww); }
        public readonly quarter4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzxx); }
        public readonly quarter4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzxy); }
        public readonly quarter4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzxz); }
        public          quarter4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxyw; }
        public readonly quarter4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyx); }
        public readonly quarter4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyy); }
        public readonly quarter4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyz); }
        public readonly quarter4 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzyw); }
        public readonly quarter4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzx); }
        public readonly quarter4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzy); }
        public readonly quarter4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzz); }
        public readonly quarter4 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzzw); }
        public          quarter4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzwx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxyz; }
        public readonly quarter4 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzwy); }
        public readonly quarter4 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzwz); }
        public readonly quarter4 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzww); }
        public readonly quarter4 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywxx); }
        public readonly quarter4 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywxy); }
        public          quarter4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).ywxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxwy; }
        public readonly quarter4 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywxw); }
        public readonly quarter4 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywyx); }
        public readonly quarter4 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywyy); }
        public readonly quarter4 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywyz); }
        public readonly quarter4 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywyw); }
        public          quarter4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).ywzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxzy; }
        public readonly quarter4 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywzy); }
        public readonly quarter4 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywzz); }
        public readonly quarter4 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywzw); }
        public readonly quarter4 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywwx); }
        public readonly quarter4 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywwy); }
        public readonly quarter4 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywwz); }
        public readonly quarter4 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywww); }
        public readonly quarter4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxx); }
        public readonly quarter4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxy); }
        public readonly quarter4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxz); }
        public readonly quarter4 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxxw); }
        public readonly quarter4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxyx); }
        public readonly quarter4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxyy); }
        public readonly quarter4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxyz); }
        public          quarter4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzxw; }
        public readonly quarter4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzx); }
        public readonly quarter4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzy); }
        public readonly quarter4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzz); }
        public readonly quarter4 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxzw); }
        public readonly quarter4 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxwx); }
        public          quarter4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywxz; }
        public readonly quarter4 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxwz); }
        public readonly quarter4 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxww); }
        public readonly quarter4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyxx); }
        public readonly quarter4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyxy); }
        public readonly quarter4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyxz); }
        public          quarter4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zyxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zyxw; }
        public readonly quarter4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyx); }
        public readonly quarter4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyy); }
        public readonly quarter4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyz); }
        public readonly quarter4 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyyw); }
        public readonly quarter4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzx); }
        public readonly quarter4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzy); }
        public readonly quarter4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzz); }
        public readonly quarter4 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyzw); }
        public          quarter4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zywx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyxz; }
        public readonly quarter4 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zywy); }
        public readonly quarter4 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zywz); }
        public readonly quarter4 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyww); }
        public readonly quarter4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxx); }
        public readonly quarter4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxy); }
        public readonly quarter4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxz); }
        public readonly quarter4 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzxw); }
        public readonly quarter4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyx); }
        public readonly quarter4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyy); }
        public readonly quarter4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyz); }
        public readonly quarter4 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzyw); }
        public readonly quarter4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzx); }
        public readonly quarter4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzy); }
        public readonly quarter4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzz); }
        public readonly quarter4 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzzw); }
        public readonly quarter4 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzwx); }
        public readonly quarter4 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzwy); }
        public readonly quarter4 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzwz); }
        public readonly quarter4 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzww); }
        public readonly quarter4 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwxx); }
        public          quarter4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zwxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwxy; }
        public readonly quarter4 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwxz); }
        public readonly quarter4 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwxw); }
        public          quarter4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zwyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzxy; }
        public readonly quarter4 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwyy); }
        public readonly quarter4 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwyz); }
        public readonly quarter4 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwyw); }
        public readonly quarter4 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwzx); }
        public readonly quarter4 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwzy); }
        public readonly quarter4 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwzz); }
        public readonly quarter4 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwzw); }
        public readonly quarter4 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwwx); }
        public readonly quarter4 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwwy); }
        public readonly quarter4 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwwz); }
        public readonly quarter4 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwww); }
        public readonly quarter4 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxxx); }
        public readonly quarter4 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxxy); }
        public readonly quarter4 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxxz); }
        public readonly quarter4 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxxw); }
        public readonly quarter4 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxyx); }
        public readonly quarter4 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxyy); }
        public          quarter4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wxyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzwx; }
        public readonly quarter4 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxyw); }
        public readonly quarter4 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxzx); }
        public          quarter4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wxzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywzx; }
        public readonly quarter4 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxzz); }
        public readonly quarter4 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxzw); }
        public readonly quarter4 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxwx); }
        public readonly quarter4 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxwy); }
        public readonly quarter4 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxwz); }
        public readonly quarter4 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxww); }
        public readonly quarter4 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyxx); }
        public readonly quarter4 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyxy); }
        public          quarter4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wyxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zywx; }
        public readonly quarter4 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyxw); }
        public readonly quarter4 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyyx); }
        public readonly quarter4 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyyy); }
        public readonly quarter4 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyyz); }
        public readonly quarter4 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyyw); }
        public          quarter4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wyzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyzx; }
        public readonly quarter4 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyzy); }
        public readonly quarter4 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyzz); }
        public readonly quarter4 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyzw); }
        public readonly quarter4 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wywx); }
        public readonly quarter4 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wywy); }
        public readonly quarter4 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wywz); }
        public readonly quarter4 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyww); }
        public readonly quarter4 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzxx); }
        public          quarter4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wzxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwyx; }
        public readonly quarter4 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzxz); }
        public readonly quarter4 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzxw); }
        public          quarter4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wzyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzyx; }
        public readonly quarter4 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzyy); }
        public readonly quarter4 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzyz); }
        public readonly quarter4 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzyw); }
        public readonly quarter4 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzzx); }
        public readonly quarter4 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzzy); }
        public readonly quarter4 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzzz); }
        public readonly quarter4 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzzw); }
        public readonly quarter4 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzwx); }
        public readonly quarter4 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzwy); }
        public readonly quarter4 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzwz); }
        public readonly quarter4 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzww); }
        public readonly quarter4 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwxx); }
        public readonly quarter4 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwxy); }
        public readonly quarter4 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwxz); }
        public readonly quarter4 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwxw); }
        public readonly quarter4 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwyx); }
        public readonly quarter4 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwyy); }
        public readonly quarter4 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwyz); }
        public readonly quarter4 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwyw); }
        public readonly quarter4 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwzx); }
        public readonly quarter4 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwzy); }
        public readonly quarter4 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwzz); }
        public readonly quarter4 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwzw); }
        public readonly quarter4 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwwx); }
        public readonly quarter4 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwwy); }
        public readonly quarter4 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwwz); }
        public readonly quarter4 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwww); }

        public readonly quarter3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxx); }
        public readonly quarter3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxy); }
        public readonly quarter3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxz); }
        public readonly quarter3 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xxw); }
        public readonly quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyx); }
        public readonly quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xyy); }
        public          quarter3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xyz = asbyte(value); this = asquarter(temp); } }
        public          quarter3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xyw = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzx); }                                                          
        public          quarter3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xzy = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xzz); }                                                           
        public          quarter3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xzw = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xwx); }                                                    
        public          quarter3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xwy = asbyte(value); this = asquarter(temp); } }
        public          quarter3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xwz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xwz = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xww); }                                                              
        public readonly quarter3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxx); }                                                              
        public readonly quarter3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yxy); }                                                              
        public          quarter3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yxz = asbyte(value); this = asquarter(temp); } }
        public          quarter3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yxw = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyx); }                                                             
        public readonly quarter3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyy); }                                                             
        public readonly quarter3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyz); }                                                             
        public readonly quarter3 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yyw); }                                                             
        public          quarter3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yzx = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzy); }                                                             
        public          quarter3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yzz); }                                                             
        public          quarter3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yzw = asbyte(value); this = asquarter(temp); } }
        public          quarter3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).ywx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.ywx = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ywy); }                                                              
        public          quarter3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).ywz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.ywz = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yww); }                                                               
        public readonly quarter3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxx); }                                                               
        public          quarter3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zxy = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zxz); }                                                            
        public          quarter3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zxw = asbyte(value); this = asquarter(temp); } }
        public          quarter3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zyx = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyy); }                                                              
        public readonly quarter3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zyz); }                                                              
        public          quarter3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zyw = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzx); }                                                               
        public readonly quarter3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzy); }                                                               
        public readonly quarter3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzz); }                                                               
        public readonly quarter3 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zzw); }                                                               
        public          quarter3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zwx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zwx = asbyte(value); this = asquarter(temp); } }
        public          quarter3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zwy = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zwz); }                                                             
        public readonly quarter3 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zww); }                                                             
        public readonly quarter3 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxx); }                                                             
        public          quarter3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wxy = asbyte(value); this = asquarter(temp); } }
        public          quarter3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wxz = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wxw); }                                                          
        public          quarter3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wyx = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyy); }                                                       
        public          quarter3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wyz = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wyw); }                                                  
        public          quarter3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wzx = asbyte(value); this = asquarter(temp); } }
        public          quarter3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wzy = asbyte(value); this = asquarter(temp); } }
        public readonly quarter3 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzz); }
        public readonly quarter3 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wzw); }
        public readonly quarter3 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwx); }
        public readonly quarter3 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwy); }
        public readonly quarter3 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).wwz); }
        public readonly quarter3 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).www); }
        public readonly quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).xx); }
        public          quarter2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xy = asbyte(value); this = asquarter(temp); } }
        public          quarter2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xz = asbyte(value); this = asquarter(temp); } }
        public          quarter2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).xw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.xw = asbyte(value); this = asquarter(temp); } }
        public          quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yx = asbyte(value); this = asquarter(temp); } }
        public readonly quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).yy); }                                                                                                
        public          quarter2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yz = asbyte(value); this = asquarter(temp); } }
        public          quarter2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).yw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.yw = asbyte(value); this = asquarter(temp); } }
        public          quarter2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zx = asbyte(value); this = asquarter(temp); } }
        public          quarter2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zy = asbyte(value); this = asquarter(temp); } }
        public readonly quarter2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).zz); }                                                                                              
        public          quarter2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).zw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.zw = asbyte(value); this = asquarter(temp); } }
        public          quarter2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wx = asbyte(value); this = asquarter(temp); } }
        public          quarter2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wy = asbyte(value); this = asquarter(temp); } }
        public          quarter2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => asquarter(asbyte(this).wz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = asbyte(this); temp.wz = asbyte(value); this = asquarter(temp); } }
        public readonly quarter2 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => asquarter(asbyte(this).ww); }
        #endregion

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter4 input)
        {
            v128 result;

            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                v128* dummyPtr = &result;
            }

            result.Byte0 = input.x.value;
            result.Byte1 = input.y.value;
            result.Byte2 = input.z.value;
            result.Byte3 = input.w.value;
            
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter4(v128 input) => new quarter4 { x = maxmath.asquarter(input.Byte0), y = maxmath.asquarter(input.Byte1), z = maxmath.asquarter(input.Byte2), w = maxmath.asquarter(input.Byte3) };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter4(quarter input) => new quarter4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(half input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(float input) => (quarter)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(double input) => (quarter)input;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 SByte4ToQuarter4(sbyte4 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi8_pq(input, overflowValue, elements: 4);
            }
            else
            {
                return new quarter4(quarter.SByteToQuarter(input.x, overflowValue), 
                                    quarter.SByteToQuarter(input.y, overflowValue), 
                                    quarter.SByteToQuarter(input.z, overflowValue), 
                                    quarter.SByteToQuarter(input.w, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(sbyte4 input)
        {
            return SByte4ToQuarter4(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 Byte4ToQuarter4(byte4 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu8_pq(input, overflowValue, elements: 4);
            }
            else
            {
                return new quarter4(quarter.ByteToQuarter(input.x, overflowValue), 
                                    quarter.ByteToQuarter(input.y, overflowValue), 
                                    quarter.ByteToQuarter(input.z, overflowValue), 
                                    quarter.ByteToQuarter(input.w, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(byte4 input)
        {
            return Byte4ToQuarter4(input, quarter.PositiveInfinity);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 Short4ToQuarter4(short4 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi16_pq(input, overflowValue, elements: 4);
            }
            else
            {
                return new quarter4(quarter.ShortToQuarter(input.x, overflowValue), 
                                    quarter.ShortToQuarter(input.y, overflowValue), 
                                    quarter.ShortToQuarter(input.z, overflowValue), 
                                    quarter.ShortToQuarter(input.w, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(short4 input)
        {
            return Short4ToQuarter4(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 UShort4ToQuarter4(ushort4 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu16_pq(input, overflowValue, elements: 4);
            }
            else
            {
                return new quarter4(quarter.UShortToQuarter(input.x, overflowValue), 
                                    quarter.UShortToQuarter(input.y, overflowValue), 
                                    quarter.UShortToQuarter(input.z, overflowValue), 
                                    quarter.UShortToQuarter(input.w, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(ushort4 input)
        {
            return UShort4ToQuarter4(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 Int4ToQuarter4(int4 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepi32_pq(RegisterConversion.ToV128(input), overflowValue, elements: 4);
            }
            else
            {
                return new quarter4(quarter.IntToQuarter(input.x, overflowValue), 
                                    quarter.IntToQuarter(input.y, overflowValue), 
                                    quarter.IntToQuarter(input.z, overflowValue), 
                                    quarter.IntToQuarter(input.w, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(int4 input)
        {
            return Int4ToQuarter4(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 UInt4ToQuarter4(uint4 input, quarter overflowValue)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtepu32_pq(RegisterConversion.ToV128(input), overflowValue, elements: 4);
            }
            else
            {
                return new quarter4(quarter.UIntToQuarter(input.x, overflowValue), 
                                    quarter.UIntToQuarter(input.y, overflowValue), 
                                    quarter.UIntToQuarter(input.z, overflowValue), 
                                    quarter.UIntToQuarter(input.w, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(uint4 input)
        {
            return UInt4ToQuarter4(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 Long4ToQuarter4(long4 input, quarter overflowValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtepi64_pq(input, overflowValue, elements: 4);
            }
            else
            {
                return new quarter4(quarter2.Long2ToQuarter2(input.xy, overflowValue), 
                                    quarter2.Long2ToQuarter2(input.zw, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(long4 input)
        {
            return Long4ToQuarter4(input, quarter.PositiveInfinity);
        }
        
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 ULong4ToQuarter4(ulong4 input, quarter overflowValue)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtepu64_pq(input, overflowValue, elements: 4);
            }
            else
            {
                return new quarter4(quarter2.ULong2ToQuarter2(input.xy, overflowValue), 
                                    quarter2.ULong2ToQuarter2(input.zw, overflowValue));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(ulong4 input)
        {
            return ULong4ToQuarter4(input, quarter.PositiveInfinity);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(half4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtph_pq(RegisterConversion.ToV128(input), elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(float4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtps_pq(RegisterConversion.ToV128(input), elements: 4);
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 FloatToQuarterInRange(float4 f)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtps_pq(RegisterConversion.ToV128(f), promiseInRange: true, elements: 4);
            }
            else
            {
                return new quarter4(quarter.FloatToQuarterInRange(f.x), quarter.FloatToQuarterInRange(f.y), quarter.FloatToQuarterInRange(f.z), quarter.FloatToQuarterInRange(f.w));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 FloatToQuarterInRangeAbs(float4 f)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.cvtps_pq(RegisterConversion.ToV128(f), promiseAbsoluteAndInRange: true, elements: 4);
            }
            else
            {
                return new quarter4(quarter.FloatToQuarterInRangeAbs(f.x), quarter.FloatToQuarterInRangeAbs(f.y), quarter.FloatToQuarterInRangeAbs(f.z), quarter.FloatToQuarterInRangeAbs(f.w));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(double4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtpd_pq(RegisterConversion.ToV256(input), elements: 4);
            }
            else
            {
                return new quarter4((quarter2)input.xy, (quarter2)input.zw);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 DoubleToQuarterInRange(double4 d)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtpd_pq(RegisterConversion.ToV256(d), promiseInRange: true, elements: 4);
            }
            else
            {
                return new quarter4(quarter2.DoubleToQuarterInRange(d.xy), quarter2.DoubleToQuarterInRange(d.zw));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static quarter4 DoubleToQuarterInRangeAbs(double4 d)
        {
            if (Avx2.IsAvx2Supported)
            {
                return quarter.Vectorized.mm256_cvtpd_pq(RegisterConversion.ToV256(d), promiseAbsoluteAndInRange: true, elements: 4);
            }
            else
            {
                return new quarter4(quarter2.DoubleToQuarterInRangeAbs(d.xy), quarter2.DoubleToQuarterInRangeAbs(d.zw));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(quarter4 input) => (sbyte4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(quarter4 input) => (byte4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(quarter4 input) => (short4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(quarter4 input) => (ushort4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(quarter4 input) => (int4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(quarter4 input) => (uint4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(quarter4 input) => (int4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(quarter4 input) => (ulong4)(int4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(quarter4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(quarter4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat4(quarter.Vectorized.cvtpq_ps(input, elements: 4));
            }
            else
            {
                return new float4(input.x, input.y, input.z, input.w);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float4 QuarterToFloatInRange(quarter4 q)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat4(quarter.Vectorized.cvtpq_ps(q, promiseInRange: true, elements: 4));
            }
            else
            {
                return new float4(quarter.QuarterToFloatInRange(q.x), quarter.QuarterToFloatInRange(q.y), quarter.QuarterToFloatInRange(q.z), quarter.QuarterToFloatInRange(q.w));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static float4 QuarterToFloatInRangeAbs(quarter4 q)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat4(quarter.Vectorized.cvtpq_ps(q, promiseAbsoluteAndInRange: true, elements: 4));
            }
            else
            {
                return new float4(quarter.QuarterToFloatInRangeAbs(q.x), quarter.QuarterToFloatInRangeAbs(q.y), quarter.QuarterToFloatInRangeAbs(q.z), quarter.QuarterToFloatInRangeAbs(q.w));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(quarter4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(quarter.Vectorized.mm256_cvtpq_pd(input, elements: 4));
            }
            else
            {
                return new double4((double2)input.xy, (double2)input.zw);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double4 QuarterToDoubleInRange(quarter4 q)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(quarter.Vectorized.mm256_cvtpq_pd(q, promiseInRange: true, elements: 4));
            }
            else
            {
                return new double4(quarter2.QuarterToDoubleInRange(q.xy), quarter2.QuarterToDoubleInRange(q.zw));
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static double4 QuarterToDoubleInRangeAbs(quarter4 q)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble4(quarter.Vectorized.mm256_cvtpq_pd(q, promiseAbsoluteAndInRange: true, elements: 4));
            }
            else
            {
                return new double4(quarter2.QuarterToDoubleInRangeAbs(q.xy), quarter2.QuarterToDoubleInRangeAbs(q.zw));
            }
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 4);

                if (Sse2.IsSse2Supported)
                {
                    return asquarter(Xse.extract_epi8(this, (byte)index));
                }
                else
                {
                    quarter4 onStack = this;

                    return *((quarter*)&onStack + index);
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi8(this, asbyte(value), (byte)index);
                }
                else
                {
                    quarter4 onStack = this;
                    *((quarter*)&onStack + index) = value;
                    this = onStack;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static quarter4 operator - (quarter4 value)
        {
            return asquarter(asbyte(value) ^ new byte4(0b1000_0000));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter4 left, quarter4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue8(quarter.Vectorized.cmpeq_pq(left, right, elements: 4));

                return *(bool4*)&results;
            }
            else
            {
                return new bool4(left.x == right.x, left.y == right.y, left.z == right.z, left.w == right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter4 left, quarter right)
        {
            return left == (quarter4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter left, quarter4 right)
        {
            return (quarter4)left == right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter4 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter4);
            }
            else
            {
                return (float4)left == (float4)right;
            } 
        }

        public static bool4 operator == (half left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter4);
            }
            else
            {
                return (float4)left == (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter4 left, half4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)right == 0f)))
            {
                return left == default(quarter4);
            }
            else
            {
                return (float4)left == (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (half4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)left == 0f)))
            {
                return right == default(quarter4);
            }
            else
            {
                return (float4)left == (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter4 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter4);
            }
            else
            {
                return (float4)left == (float4)right;
            } 
        }

        public static bool4 operator == (float left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter4);
            }
            else
            {
                return (float4)left == (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter4 left, float4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left == default(quarter4);
            }
            else
            {
                return (float4)left == (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (float4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right == default(quarter4);
            }
            else
            {
                return (float4)left == (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter4 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left == default(quarter4);
            }
            else
            {
                return (double4)left == (double4)right;
            } 
        }

        public static bool4 operator == (double left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right == default(quarter4);
            }
            else
            {
                return (double4)left == (double4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter4 left, double4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left == default(quarter4);
            }
            else
            {
                return (double4)left == (double4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (double4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right == default(quarter4);
            }
            else
            {
                return (double4)left == (double4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter4 left, quarter4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue8(quarter.Vectorized.cmpneq_pq(left, right, elements: 4));

                return *(bool4*)&results;
            }
            else
            {
                return new bool4(left.x != right.x, left.y != right.y, left.z != right.z, left.w != right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter4 left, quarter right)
        {
            return left != (quarter4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter left, quarter4 right)
        {
            return (quarter4)left != right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter4 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter4);
            }
            else
            {
                return (float4)left != (float4)right;
            } 
        }

        public static bool4 operator != (half left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter4);
            }
            else
            {
                return (float4)left != (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter4 left, half4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)right == 0f)))
            {
                return left != default(quarter4);
            }
            else
            {
                return (float4)left != (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (half4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)left == 0f)))
            {
                return right != default(quarter4);
            }
            else
            {
                return (float4)left != (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter4 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter4);
            }
            else
            {
                return (float4)left != (float4)right;
            } 
        }

        public static bool4 operator != (float left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter4);
            }
            else
            {
                return (float4)left != (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter4 left, float4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left != default(quarter4);
            }
            else
            {
                return (float4)left != (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (float4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right != default(quarter4);
            }
            else
            {
                return (float4)left != (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter4 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left != default(quarter4);
            }
            else
            {
                return (double4)left != (double4)right;
            } 
        }

        public static bool4 operator != (double left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right != default(quarter4);
            }
            else
            {
                return (double4)left != (double4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter4 left, double4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left != default(quarter4);
            }
            else
            {
                return (double4)left != (double4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (double4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right != default(quarter4);
            }
            else
            {
                return (double4)left != (double4)right;
            } 
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (quarter4 left, quarter4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(quarter.Vectorized.cmplt_pq(left, right, elements: 4)));
            }
            else
            {
                return new bool4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (quarter4 left, quarter right)
        {
            return left < (quarter4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (quarter left, quarter4 right)
        {
            return (quarter4)left < right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (quarter4 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter4);
            }
            else
            {
                return (float4)left < (float4)right;
            } 
        }

        public static bool4 operator < (half left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter4);
            }
            else
            {
                return (float4)left < (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (quarter4 left, half4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)right == 0f)))
            {
                return left < default(quarter4);
            }
            else
            {
                return (float4)left < (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (half4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)left == 0f)))
            {
                return right > default(quarter4);
            }
            else
            {
                return (float4)left < (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (quarter4 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter4);
            }
            else
            {
                return (float4)left < (float4)right;
            } 
        }

        public static bool4 operator < (float left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter4);
            }
            else
            {
                return (float4)left < (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (quarter4 left, float4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left < default(quarter4);
            }
            else
            {
                return (float4)left < (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (float4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right > default(quarter4);
            }
            else
            {
                return (float4)left < (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (quarter4 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left < default(quarter4);
            }
            else
            {
                return (double4)left < (double4)right;
            } 
        }

        public static bool4 operator < (double left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right > default(quarter4);
            }
            else
            {
                return (double4)left < (double4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (quarter4 left, double4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left < default(quarter4);
            }
            else
            {
                return (double4)left < (double4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (double4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right > default(quarter4);
            }
            else
            {
                return (double4)left < (double4)right;
            } 
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (quarter4 left, quarter4 right) => right < left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (quarter4 left, quarter right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (quarter left, quarter4 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (quarter4 left, half right) => right < left;

        public static bool4 operator > (half left, quarter4 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (quarter4 left, half4 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (half4 left, quarter4 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (quarter4 left, float right) => right < left;

        public static bool4 operator > (float left, quarter4 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (quarter4 left, float4 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (float4 left, quarter4 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (quarter4 left, double right) => right < left;

        public static bool4 operator > (double left, quarter4 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (quarter4 left, double4 right) => right < left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (double4 left, quarter4 right) => right < left;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (quarter4 left, quarter4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToBool4(RegisterConversion.IsTrue8(quarter.Vectorized.cmple_pq(left, right, elements: 4)));
            }
            else
            {
                return new bool4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (quarter4 left, quarter right)
        {
            return left <= (quarter4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (quarter left, quarter4 right)
        {
            return (quarter4)left <= right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (quarter4 left, half right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter4);
            }
            else
            {
                return (float4)left <= (float4)right;
            } 
        }

        public static bool4 operator <= (half left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter4);
            }
            else
            {
                return (float4)left <= (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (quarter4 left, half4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)right == 0f)))
            {
                return left <= default(quarter4);
            }
            else
            {
                return (float4)left <= (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (half4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all((float4)left == 0f)))
            {
                return right >= default(quarter4);
            }
            else
            {
                return (float4)left <= (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (quarter4 left, float right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter4);
            }
            else
            {
                return (float4)left <= (float4)right;
            } 
        }

        public static bool4 operator <= (float left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter4);
            }
            else
            {
                return (float4)left <= (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (quarter4 left, float4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left <= default(quarter4);
            }
            else
            {
                return (float4)left <= (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (float4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right >= default(quarter4);
            }
            else
            {
                return (float4)left <= (float4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (quarter4 left, double right)
        {
            if (Xse.constexpr.IS_TRUE(right == 0f))
            {
                return left <= default(quarter4);
            }
            else
            {
                return (double4)left <= (double4)right;
            } 
        }

        public static bool4 operator <= (double left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(left == 0f))
            {
                return right >= default(quarter4);
            }
            else
            {
                return (double4)left <= (double4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (quarter4 left, double4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(right == 0f)))
            {
                return left <= default(quarter4);
            }
            else
            {
                return (double4)left <= (double4)right;
            } 
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (double4 left, quarter4 right)
        {
            if (Xse.constexpr.IS_TRUE(math.all(left == 0f)))
            {
                return right >= default(quarter4);
            }
            else
            {
                return (double4)left <= (double4)right;
            } 
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (quarter4 left, quarter4 right) => right <= left;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (quarter4 left, quarter right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (quarter left, quarter4 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (quarter4 left, half right) => right <= left;

        public static bool4 operator >= (half left, quarter4 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (quarter4 left, half4 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (half4 left, quarter4 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (quarter4 left, float right) => right <= left;

        public static bool4 operator >= (float left, quarter4 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (quarter4 left, float4 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (float4 left, quarter4 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (quarter4 left, double right) => right <= left;

        public static bool4 operator >= (double left, quarter4 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (quarter4 left, double4 right) => right <= left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (double4 left, quarter4 right) => right <= left;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter4 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return quarter.Vectorized.vcmpeq_pq(this, other, elements: 4);
            }
            else
            {
                return this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w;
            }
        }

        public override readonly bool Equals(object obj) => obj is quarter4 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse.IsSseSupported)
            {
                return ((v128)this).SInt0;
            }
            else
            {
                quarter4 temp = this;
                return *(int*)&temp;
            }
        } 


        public override readonly string ToString() => $"quarter4({x}, {y}, {z}, {w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"quarter4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}