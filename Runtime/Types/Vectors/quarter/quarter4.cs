using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(byte))]  [DebuggerTypeProxy(typeof(quarter4.DebuggerProxy))]
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


        [FieldOffset(0)] private fixed byte asArray[4];

        [FieldOffset(0)] public quarter x;
        [FieldOffset(1)] public quarter y;
        [FieldOffset(2)] public quarter z;
        [FieldOffset(3)] public quarter w;


        public static quarter4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter x, quarter y, quarter z, quarter w)
        {
            this = maxmath.asquarter(new byte4(x.value, y.value, z.value, w.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter xyzw)
        {
            this = maxmath.asquarter(new byte4(xyzw.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter2 xy, quarter z, quarter w)
        {
            this = maxmath.asquarter(new byte4(maxmath.asbyte(xy), z.value, w.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter x, quarter2 yz, quarter w)
        {
            this = maxmath.asquarter(new byte4(x.value, maxmath.asbyte(yz), w.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter x, quarter y, quarter2 zw)
        {
            this = maxmath.asquarter(new byte4(x.value, y.value, maxmath.asbyte(zw)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter2 xy, quarter2 zw)
        {
            this = maxmath.asquarter(new byte4(maxmath.asbyte(xy), maxmath.asbyte(zw)));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter3 xyz, quarter w)
        {
            this = maxmath.asquarter(new byte4(maxmath.asbyte(xyz), w.value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public quarter4(quarter x, quarter3 yzw)
        {
            this = maxmath.asquarter(new byte4(x.value, maxmath.asbyte(yzw)));
        }


        #region Shuffle
        public readonly quarter4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxx); }
        public readonly quarter4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxy); }
        public readonly quarter4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxz); }
        public readonly quarter4 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxxw); }
        public readonly quarter4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxyx); }
        public readonly quarter4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxyy); }
        public readonly quarter4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxyz); }
        public readonly quarter4 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxyw); }
        public readonly quarter4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxzx); }
        public readonly quarter4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxzy); }
        public readonly quarter4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxzz); }
        public readonly quarter4 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxzw); }
        public readonly quarter4 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxwx); }
        public readonly quarter4 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxwy); }
        public readonly quarter4 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxwz); }
        public readonly quarter4 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxww); }
        public readonly quarter4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyxx); }
        public readonly quarter4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyxy); }
        public readonly quarter4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyxz); }
        public readonly quarter4 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyxw); }
        public readonly quarter4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyyx); }
        public readonly quarter4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyyy); }
        public readonly quarter4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyyz); }
        public readonly quarter4 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyyw); }
        public readonly quarter4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyzx); }
        public readonly quarter4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyzy); }
        public readonly quarter4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyzz); }
        public readonly quarter4 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xywx); }
        public readonly quarter4 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xywy); }
        public          quarter4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xywz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xywz; }
        public readonly quarter4 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyww); }
        public readonly quarter4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzxx); }
        public readonly quarter4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzxy); }
        public readonly quarter4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzxz); }
        public readonly quarter4 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzxw); }
        public readonly quarter4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzyx); }
        public readonly quarter4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzyy); }
        public readonly quarter4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzyz); }
        public          quarter4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xzyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzyw; }
        public readonly quarter4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzzx); }
        public readonly quarter4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzzy); }
        public readonly quarter4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzzz); }
        public readonly quarter4 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzzw); }
        public readonly quarter4 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzwx); }
        public          quarter4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xzwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwyz; }
        public readonly quarter4 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzwz); }
        public readonly quarter4 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzww); }
        public readonly quarter4 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwxx); }
        public readonly quarter4 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwxy); }
        public readonly quarter4 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwxz); }
        public readonly quarter4 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwxw); }
        public readonly quarter4 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwyx); }
        public readonly quarter4 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwyy); }
        public          quarter4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xwyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzwy; }
        public readonly quarter4 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwyw); }
        public readonly quarter4 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwzx); }
        public          quarter4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xwzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwzy; }
        public readonly quarter4 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwzz); }
        public readonly quarter4 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwzw); }
        public readonly quarter4 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwwx); }
        public readonly quarter4 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwwy); }
        public readonly quarter4 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwwz); }
        public readonly quarter4 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwww); }
        public readonly quarter4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxxx); }
        public readonly quarter4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxxy); }
        public readonly quarter4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxxz); }
        public readonly quarter4 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxxw); }
        public readonly quarter4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxyx); }
        public readonly quarter4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxyy); }
        public readonly quarter4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxyz); }
        public readonly quarter4 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxyw); }
        public readonly quarter4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxzx); }
        public readonly quarter4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxzy); }
        public readonly quarter4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxzz); }
        public          quarter4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yxzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxzw; }
        public readonly quarter4 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxwx); }
        public readonly quarter4 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxwy); }
        public          quarter4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yxwz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxwz; }
        public readonly quarter4 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxww); }
        public readonly quarter4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyxx); }
        public readonly quarter4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyxy); }
        public readonly quarter4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyxz); }
        public readonly quarter4 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyxw); }
        public readonly quarter4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyx); }
        public readonly quarter4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyy); }
        public readonly quarter4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyz); }
        public readonly quarter4 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyyw); }
        public readonly quarter4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyzx); }
        public readonly quarter4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyzy); }
        public readonly quarter4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyzz); }
        public readonly quarter4 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyzw); }
        public readonly quarter4 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yywx); }
        public readonly quarter4 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yywy); }
        public readonly quarter4 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yywz); }
        public readonly quarter4 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyww); }
        public readonly quarter4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzxx); }
        public readonly quarter4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzxy); }
        public readonly quarter4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzxz); }
        public          quarter4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yzxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxyw; }
        public readonly quarter4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzyx); }
        public readonly quarter4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzyy); }
        public readonly quarter4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzyz); }
        public readonly quarter4 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzyw); }
        public readonly quarter4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzzx); }
        public readonly quarter4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzzy); }
        public readonly quarter4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzzz); }
        public readonly quarter4 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzzw); }
        public          quarter4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yzwx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxyz; }
        public readonly quarter4 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzwy); }
        public readonly quarter4 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzwz); }
        public readonly quarter4 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzww); }
        public readonly quarter4 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywxx); }
        public readonly quarter4 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywxy); }
        public          quarter4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).ywxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxwy; }
        public readonly quarter4 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywxw); }
        public readonly quarter4 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywyx); }
        public readonly quarter4 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywyy); }
        public readonly quarter4 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywyz); }
        public readonly quarter4 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywyw); }
        public          quarter4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).ywzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxzy; }
        public readonly quarter4 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywzy); }
        public readonly quarter4 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywzz); }
        public readonly quarter4 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywzw); }
        public readonly quarter4 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywwx); }
        public readonly quarter4 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywwy); }
        public readonly quarter4 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywwz); }
        public readonly quarter4 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywww); }
        public readonly quarter4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxxx); }
        public readonly quarter4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxxy); }
        public readonly quarter4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxxz); }
        public readonly quarter4 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxxw); }
        public readonly quarter4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxyx); }
        public readonly quarter4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxyy); }
        public readonly quarter4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxyz); }
        public          quarter4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zxyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzxw; }
        public readonly quarter4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxzx); }
        public readonly quarter4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxzy); }
        public readonly quarter4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxzz); }
        public readonly quarter4 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxzw); }
        public readonly quarter4 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxwx); }
        public          quarter4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zxwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywxz; }
        public readonly quarter4 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxwz); }
        public readonly quarter4 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxww); }
        public readonly quarter4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyxx); }
        public readonly quarter4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyxy); }
        public readonly quarter4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyxz); }
        public          quarter4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zyxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zyxw; }
        public readonly quarter4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyyx); }
        public readonly quarter4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyyy); }
        public readonly quarter4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyyz); }
        public readonly quarter4 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyyw); }
        public readonly quarter4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyzx); }
        public readonly quarter4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyzy); }
        public readonly quarter4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyzz); }
        public readonly quarter4 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyzw); }
        public          quarter4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zywx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyxz; }
        public readonly quarter4 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zywy); }
        public readonly quarter4 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zywz); }
        public readonly quarter4 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyww); }
        public readonly quarter4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzxx); }
        public readonly quarter4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzxy); }
        public readonly quarter4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzxz); }
        public readonly quarter4 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzxw); }
        public readonly quarter4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzyx); }
        public readonly quarter4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzyy); }
        public readonly quarter4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzyz); }
        public readonly quarter4 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzyw); }
        public readonly quarter4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzzx); }
        public readonly quarter4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzzy); }
        public readonly quarter4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzzz); }
        public readonly quarter4 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzzw); }
        public readonly quarter4 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzwx); }
        public readonly quarter4 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzwy); }
        public readonly quarter4 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzwz); }
        public readonly quarter4 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzww); }
        public readonly quarter4 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwxx); }
        public          quarter4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zwxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwxy; }
        public readonly quarter4 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwxz); }
        public readonly quarter4 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwxw); }
        public          quarter4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zwyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzxy; }
        public readonly quarter4 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwyy); }
        public readonly quarter4 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwyz); }
        public readonly quarter4 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwyw); }
        public readonly quarter4 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwzx); }
        public readonly quarter4 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwzy); }
        public readonly quarter4 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwzz); }
        public readonly quarter4 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwzw); }
        public readonly quarter4 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwwx); }
        public readonly quarter4 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwwy); }
        public readonly quarter4 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwwz); }
        public readonly quarter4 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwww); }
        public readonly quarter4 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxxx); }
        public readonly quarter4 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxxy); }
        public readonly quarter4 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxxz); }
        public readonly quarter4 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxxw); }
        public readonly quarter4 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxyx); }
        public readonly quarter4 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxyy); }
        public          quarter4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wxyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzwx; }
        public readonly quarter4 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxyw); }
        public readonly quarter4 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxzx); }
        public          quarter4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wxzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywzx; }
        public readonly quarter4 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxzz); }
        public readonly quarter4 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxzw); }
        public readonly quarter4 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxwx); }
        public readonly quarter4 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxwy); }
        public readonly quarter4 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxwz); }
        public readonly quarter4 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxww); }
        public readonly quarter4 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyxx); }
        public readonly quarter4 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyxy); }
        public          quarter4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wyxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zywx; }
        public readonly quarter4 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyxw); }
        public readonly quarter4 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyyx); }
        public readonly quarter4 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyyy); }
        public readonly quarter4 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyyz); }
        public readonly quarter4 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyyw); }
        public          quarter4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wyzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyzx; }
        public readonly quarter4 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyzy); }
        public readonly quarter4 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyzz); }
        public readonly quarter4 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyzw); }
        public readonly quarter4 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wywx); }
        public readonly quarter4 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wywy); }
        public readonly quarter4 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wywz); }
        public readonly quarter4 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyww); }
        public readonly quarter4 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzxx); }
        public          quarter4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wzxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwyx; }
        public readonly quarter4 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzxz); }
        public readonly quarter4 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzxw); }
        public          quarter4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wzyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzyx; }
        public readonly quarter4 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzyy); }
        public readonly quarter4 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzyz); }
        public readonly quarter4 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzyw); }
        public readonly quarter4 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzzx); }
        public readonly quarter4 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzzy); }
        public readonly quarter4 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzzz); }
        public readonly quarter4 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzzw); }
        public readonly quarter4 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzwx); }
        public readonly quarter4 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzwy); }
        public readonly quarter4 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzwz); }
        public readonly quarter4 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzww); }
        public readonly quarter4 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwxx); }
        public readonly quarter4 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwxy); }
        public readonly quarter4 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwxz); }
        public readonly quarter4 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwxw); }
        public readonly quarter4 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwyx); }
        public readonly quarter4 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwyy); }
        public readonly quarter4 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwyz); }
        public readonly quarter4 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwyw); }
        public readonly quarter4 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwzx); }
        public readonly quarter4 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwzy); }
        public readonly quarter4 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwzz); }
        public readonly quarter4 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwzw); }
        public readonly quarter4 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwwx); }
        public readonly quarter4 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwwy); }
        public readonly quarter4 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwwz); }
        public readonly quarter4 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwww); }

        public readonly quarter3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxx); }
        public readonly quarter3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxy); }
        public readonly quarter3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxz); }
        public readonly quarter3 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xxw); }
        public readonly quarter3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyx); }
        public readonly quarter3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xyy); }
        public          quarter3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.xyz = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.xyw = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzx); }                                                          
        public          quarter3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.xzy = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xzz); }                                                           
        public          quarter3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.xzw = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xwx); }                                                    
        public          quarter3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.xwy = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xwz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.xwz = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xww); }                                                              
        public readonly quarter3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxx); }                                                              
        public readonly quarter3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yxy); }                                                              
        public          quarter3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.yxz = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.yxw = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyx); }                                                             
        public readonly quarter3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyy); }                                                             
        public readonly quarter3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyz); }                                                             
        public readonly quarter3 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yyw); }                                                             
        public          quarter3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.yzx = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzy); }                                                             
        public          quarter3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yzz); }                                                             
        public          quarter3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yzw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.yzw = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).ywx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.ywx = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ywy); }                                                              
        public          quarter3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).ywz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.ywz = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yww); }                                                               
        public readonly quarter3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxx); }                                                               
        public          quarter3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.zxy = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zxz); }                                                            
        public          quarter3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zxw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.zxw = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.zyx = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyy); }                                                              
        public readonly quarter3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zyz); }                                                              
        public          quarter3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zyw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.zyw = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzx); }                                                               
        public readonly quarter3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzy); }                                                               
        public readonly quarter3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzz); }                                                               
        public readonly quarter3 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zzw); }                                                               
        public          quarter3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zwx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.zwx = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zwy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.zwy = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zwz); }                                                             
        public readonly quarter3 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zww); }                                                             
        public readonly quarter3 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxx); }                                                             
        public          quarter3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wxy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.wxy = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wxz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.wxz = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wxw); }                                                          
        public          quarter3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wyx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.wyx = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyy); }                                                       
        public          quarter3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wyz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.wyz = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wyw); }                                                  
        public          quarter3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wzx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.wzx = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wzy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.wzy = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter3 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzz); }
        public readonly quarter3 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wzw); }
        public readonly quarter3 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwx); }
        public readonly quarter3 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwy); }
        public readonly quarter3 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).wwz); }
        public readonly quarter3 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).www); }
        public readonly quarter2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).xx); }
        public          quarter2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.xy = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.xz = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).xw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.xw = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.yx = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).yy); }                                                                                                
        public          quarter2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.yz = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).yw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.yw = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.zx = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.zy = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).zz); }                                                                                              
        public          quarter2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).zw); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.zw = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wx); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.wx = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wy); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.wy = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public          quarter2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] readonly get => maxmath.asquarter(maxmath.asbyte(this).wz); [MethodImpl(MethodImplOptions.AggressiveInlining)] set { byte4 temp = maxmath.asbyte(this); temp.wz = maxmath.asbyte(value); this = maxmath.asquarter(temp); } }
        public readonly quarter2 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => maxmath.asquarter(maxmath.asbyte(this).ww); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(quarter4 input) => maxmath.asbyte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter4(v128 input) => maxmath.asquarter((byte4)input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator quarter4(quarter input) => new quarter4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(sbyte4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                sbyte4 sign = input & (sbyte)-0b1000_0000;
                sbyte4 abs = maxmath.abs(input);
                v128 overflowMask = Sse2.cmpgt_epi8(abs, new sbyte4(15));


                float4 f = abs;

                int4 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi8(abs, default(v128));

                sbyte4 infinity = (sbyte)quarter.PositiveInfinity.value;
                sbyte4 regular = Sse2.andnot_si128(notZeroMask, Cast.Int4ToByte4(*(v128*)&f32));

                return (v128)(sign | Mask.BlendV(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(byte4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 overflowMask = Sse2.cmpgt_epi8(input, new byte4(15));


                float4 f = input;

                int4 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi8(input, default(v128));

                byte4 infinity = quarter.PositiveInfinity.value;
                byte4 regular = Sse2.andnot_si128(notZeroMask, Cast.Int4ToByte4(*(v128*)&f32));

                return Mask.BlendV(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(short4 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                sbyte4 sign = (sbyte4)((ushort4)input >> 15) << 7;
                short4 abs = maxmath.abs(input);
                v128 overflowMask = (sbyte4)(short4)Sse2.cmpgt_epi16(abs, new short4(15));


                float4 f = abs;

                int4 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(Cast.ShortToInt(abs), default(v128));

                sbyte4 infinity = (sbyte)quarter.PositiveInfinity.value;
                sbyte4 regular = Cast.Int4ToByte4(Sse2.andnot_si128(notZeroMask, *(v128*)&f32));

                return (v128)(sign | Sse4_1.blendv_epi8(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(ushort4 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 overflowMask = (sbyte4)(ushort4)Sse2.cmpgt_epi16(input, new ushort4(15));


                float4 f = input;

                int4 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(Cast.ShortToInt(input), default(v128));

                byte4 infinity = quarter.PositiveInfinity.value;
                byte4 regular = Cast.Int4ToByte4(Sse2.andnot_si128(notZeroMask, *(v128*)&f32));

                return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(int4 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                sbyte4 sign = (sbyte4)((uint4)input >> 31) << 7;
                int4 abs = math.abs(input);
                v128 overflowMask = Cast.Int4ToByte4(Sse2.cmpgt_epi32(*(v128*)&abs, new v128(15)));


                float4 f = abs;

                int4 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(*(v128*)&abs, default(v128));

                sbyte4 infinity = (sbyte)quarter.PositiveInfinity.value;
                sbyte4 regular = Cast.Int4ToByte4(Sse2.andnot_si128(notZeroMask, *(v128*)&f32));

                return (v128)(sign | Sse4_1.blendv_epi8(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(uint4 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 overflowMask = Cast.Int4ToByte4(Sse2.cmpgt_epi32(*(v128*)&input, new v128(15)));


                float4 f = input;

                int4 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(*(v128*)&input, default(v128));

                byte4 infinity = quarter.PositiveInfinity.value;
                byte4 regular = Cast.Int4ToByte4(Sse2.andnot_si128(notZeroMask, *(v128*)&f32));

                return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                sbyte4 sign = (sbyte4)((ulong4)input >> 63) << 7;
                long4 abs = maxmath.abs(input);
                v128 overflowMask = (sbyte4)(long4)Avx2.mm256_cmpgt_epi64(abs, new long4(15));


                v128 castToInt = Cast.Long4ToInt4(abs);
                float4 f = *(int4*)&castToInt;

                int4 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(castToInt, default(v128));

                sbyte4 infinity = (sbyte)quarter.PositiveInfinity.value;
                sbyte4 regular = Cast.Int4ToByte4(Sse2.andnot_si128(notZeroMask, *(v128*)&f32));

                return (v128)(sign | Sse4_1.blendv_epi8(regular, infinity, overflowMask));
            }
            else
            {
                return new quarter4((quarter2)input.xy, (quarter2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(ulong4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                v128 overflowMask = (sbyte4)(ulong4)Avx2.mm256_cmpgt_epi64(input, new ulong4(15));


                v128 castToInt = Cast.Long4ToInt4(input);
                float4 f = *(int4*)&castToInt;

                int4 f32 = math.asint(f) - ((127 + quarter.EXPONENT_BIAS) << 23);
                f32 >>= 19;

                v128 notZeroMask = Sse2.cmpeq_epi32(castToInt, default(v128));

                byte4 infinity = quarter.PositiveInfinity.value;
                byte4 regular = Cast.Int4ToByte4(Sse2.andnot_si128(notZeroMask, *(v128*)&f32));

                return Sse4_1.blendv_epi8(regular, infinity, overflowMask);
            }
            else
            {
                return new quarter4((quarter2)input.xy, (quarter2)input.zw);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(half4 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                byte4 f8_sign = (byte4)((maxmath.asushort(input) >> 15) << 7);
                uint4 f16_exponent = (maxmath.asushort(input) << 1) >> 11;


                uint4 f16_mantissa = (maxmath.asushort(input) << 6) >> 6;

                int4 cmp = 13 - (int4)f16_exponent;
                v128 cmpIsZeroOrNegativeMask = Sse2.cmpgt_epi32(new v128(1), *(v128*)&cmp);

                int4 denormalShift = maxmath.shrl((int4)0b0001_0000, cmp);
                v128 denormalExponent = Sse2.andnot_si128(cmpIsZeroOrNegativeMask, *(v128*)&denormalShift);
                denormalExponent = Sse2.add_epi32(denormalExponent,
                                                  Sse2.and_si128(new v128(1),
                                                                 Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f16_exponent, new v128(9)),
                                                                                Sse2.andnot_si128(Sse2.cmpgt_epi32(new v128(0x0200),
                                                                                                                   *(v128*)&f16_mantissa),
                                                                                                  new v128(-1)))));

                v128 mantissaIfSmallerEpsilon = Sse2.and_si128(new v128(1),
                                                               Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f16_exponent, new v128(8)),
                                                                              Sse2.andnot_si128(Sse2.cmpeq_epi32(*(v128*)&f16_mantissa, default(v128)), new v128(-1))));

                int4 normalExponent = (*(int4*)&cmpIsZeroOrNegativeMask & ((int4)f16_exponent - (15 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

                int4 mantissaShift = 6 + maxmath.andnot(cmp, *(int4*)&cmpIsZeroOrNegativeMask);
                uint4 shifted = maxmath.shrl(f16_mantissa, mantissaShift);


                v128 exponentMantissa = Sse2.or_si128(Sse2.or_si128(*(v128*)&normalExponent, denormalExponent),
                                                      Sse2.or_si128(mantissaIfSmallerEpsilon, *(v128*)&shifted));

                v128 infNanexponentMantissa = Sse2.or_si128(new v128((int)quarter.PositiveInfinity.value),
                                                            Sse2.and_si128(new v128(1),
                                                                           Sse2.cmpgt_epi32(Sse2.and_si128(Sse4_1.cvtepu16_epi32(maxmath.asushort(input)), new v128(maxmath.bitmask32(15))),
                                                                                            new v128(0x7C00))));

                v128 underflowMask = Sse2.cmpgt_epi32(new v128(8), *(v128*)&f16_exponent);
                v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&f16_exponent, new v128(18));

                exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, default(v128), underflowMask);
                exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, *(v128*)&infNanexponentMantissa, overflowMask);

                return maxmath.asquarter(f8_sign | Cast.Int4ToByte4(exponentMantissa));
            }
            else
            {
                return new quarter4((quarter)input.x, (quarter)input.y, (quarter)input.z, (quarter)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator quarter4(float4 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                byte4 f8_sign = (byte4)((math.asuint(input) >> 31) << 7);
                uint4 f32_exponent = (math.asuint(input) << 1) >> 24;


                uint4 f32_mantissa = (math.asuint(input) << 9) >> 9;

                int4 cmp = 125 - (int4)f32_exponent;
                v128 cmpIsZeroOrNegativeMask = Sse2.cmpgt_epi32(new v128(1), *(v128*)&cmp);

                int4 denormalShift = maxmath.shrl((int4)0b0001_0000, cmp);
                v128 denormalExponent = Sse2.andnot_si128(cmpIsZeroOrNegativeMask, *(v128*)&denormalShift);
                denormalExponent = Sse2.add_epi32(denormalExponent,
                                                  Sse2.and_si128(new v128(1),
                                                                 Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f32_exponent, new v128(121)),
                                                                                Sse2.andnot_si128(Sse2.cmpgt_epi32(new v128(0x0040_0000),
                                                                                                                   *(v128*)&f32_mantissa),
                                                                                                  new v128(-1)))));

                v128 mantissaIfSmallerEpsilon = Sse2.and_si128(new v128(1),
                                                               Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f32_exponent, new v128(120)),
                                                                              Sse2.andnot_si128(Sse2.cmpeq_epi32(*(v128*)&f32_mantissa, default(v128)), new v128(-1))));

                int4 normalExponent = (*(int4*)&cmpIsZeroOrNegativeMask & ((int4)f32_exponent - (127 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

                int4 mantissaShift = 19 + maxmath.andnot(cmp, *(int4*)&cmpIsZeroOrNegativeMask);
                uint4 shifted = maxmath.shrl(f32_mantissa, mantissaShift);


                v128 exponentMantissa = Sse2.or_si128(Sse2.or_si128(*(v128*)&normalExponent, denormalExponent),
                                                      Sse2.or_si128(mantissaIfSmallerEpsilon, *(v128*)&shifted));

                v128 infNanexponentMantissa = Sse2.or_si128(new v128((int)quarter.PositiveInfinity.value),
                                                            Sse2.and_si128(new v128(1),
                                                                           Sse2.cmpgt_epi32(Sse.and_ps(*(v128*)&input, new v128(maxmath.bitmask32(31))),
                                                                                            new v128(0x7F80_0000))));

                v128 underflowMask = Sse2.cmpgt_epi32(new v128(120), *(v128*)&f32_exponent);
                v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&f32_exponent, new v128(130));

                exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, default(v128), underflowMask);
                exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, *(v128*)&infNanexponentMantissa, overflowMask);

                return maxmath.asquarter(f8_sign | Cast.Int4ToByte4(exponentMantissa));
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
                byte4 f8_sign = (byte4)((maxmath.asulong(input) >> 63) << 7);
                uint4 f64_exponent = (uint4)((maxmath.asulong(input) << 1) >> 53);


                ulong4 f64_mantissa = (maxmath.asulong(input) << 12) >> 12;

                int4 cmp = 1021 - (int4)f64_exponent;
                v128 cmpIsZeroOrNegativeMask = Sse2.cmpgt_epi32(new v128(1), *(v128*)&cmp);

                int4 denormalShift = maxmath.shrl((int4)0b0001_0000, cmp);
                v128 denormalExponent = Sse2.andnot_si128(cmpIsZeroOrNegativeMask, *(v128*)&denormalShift);
                denormalExponent = Sse2.add_epi32(denormalExponent,
                                                  Sse2.and_si128(new v128(1),
                                                                 Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f64_exponent, new v128(1017)),
                                                                                Cast.Long4ToInt4(Avx2.mm256_andnot_si256(Avx2.mm256_cmpgt_epi64(new v256(0x0008_0000_0000_0000ul),
                                                                                                                                                f64_mantissa),
                                                                                                                             new v256(-1))))));

                v128 mantissaIfSmallerEpsilon = Sse2.and_si128(new v128(1),
                                                               Sse2.and_si128(Sse2.cmpeq_epi32(*(v128*)&f64_exponent, new v128(1016)),
                                                                               Cast.Long4ToInt4(Avx2.mm256_andnot_si256(Avx2.mm256_cmpeq_epi32(f64_mantissa, default(v256)), new v256(-1)))));

                int4 normalExponent = (*(int4*)&cmpIsZeroOrNegativeMask & ((int4)f64_exponent - (1023 + quarter.EXPONENT_BIAS))) << quarter.MANTISSA_BITS;

                int4 mantissaShift = 48 + maxmath.andnot(cmp, *(int4*)&cmpIsZeroOrNegativeMask);


                v128 exponentMantissa = Sse2.or_si128(Sse2.or_si128(*(v128*)&normalExponent, denormalExponent),
                                                      Sse2.or_si128(mantissaIfSmallerEpsilon, Cast.Long4ToInt4(Avx2.mm256_srlv_epi64(f64_mantissa, (ulong4)mantissaShift))));

                v128 infNanexponentMantissa = Sse2.or_si128(new v128((int)quarter.PositiveInfinity.value),
                                                            Sse2.and_si128(new v128(1),
                                                                           Cast.Long4ToInt4(Avx2.mm256_cmpgt_epi64(Avx.mm256_and_pd(*(v256*)&input, new v256(maxmath.bitmask64(63L))),
                                                                                                                   new v256(0x7FF0_0000_0000_0000L)))));

                v128 underflowMask = Sse2.cmpgt_epi32(new v128(1016), *(v128*)&f64_exponent);
                v128 overflowMask = Sse2.cmpgt_epi32(*(v128*)&f64_exponent, new v128(1026));

                exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, default(v128), underflowMask);
                exponentMantissa = Sse4_1.blendv_epi8(exponentMantissa, *(v128*)&infNanexponentMantissa, overflowMask);

                return maxmath.asquarter(f8_sign | Cast.Int4ToByte4(exponentMantissa));
            }
            else
            {
                return new quarter4((quarter2)input.xy, (quarter2)input.zw);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4(quarter4 input) => (sbyte4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(quarter4 input) => (byte4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(quarter4 input) => (short4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(quarter4 input) => (ushort4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(quarter4 input) => (int4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(quarter4 input) => (uint4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(quarter4 input) => (int4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(quarter4 input) => (uint4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(quarter4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(quarter4 input)
        {
            uint4 widen = maxmath.asbyte(input);

            uint4 sign = (widen >> 7) << 31;
            uint4 fusedExponentMantissa = (widen << (32 - (quarter.MANTISSA_BITS + quarter.EXPONENT_BITS))) >> 6;

            bool4 isNanOrInfinity = (widen & 0b0111_0000) == 0b0111_0000;
            uint4 nanInfinityOrZeroExponent = math.select(0u, 255u << 23, isNanOrInfinity);
            float4 magic = math.select(math.asfloat((255 - 1 + quarter.EXPONENT_BIAS) << 23), 1f, isNanOrInfinity);

            return magic * math.asfloat(sign | nanInfinityOrZeroExponent | fusedExponentMantissa);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(quarter4 input)
        {
            ulong4 widen = maxmath.asbyte(input);
             
            ulong4 sign = (widen >> 7) << 63;
            ulong4 fusedExponentMantissa = (widen << (64 - (quarter.MANTISSA_BITS + quarter.EXPONENT_BITS))) >> 9;

            bool4 isNanOrInfinity = (widen & 0b0111_0000) == 0b0111_0000;
            ulong4 nanInfinityOrZeroExponent = maxmath.select(0ul, 2047ul << 52, isNanOrInfinity);
            double4 magic = math.select(math.asdouble((2047L - 1L + quarter.EXPONENT_BIAS) << 52), 1d, isNanOrInfinity);

            return magic * maxmath.asdouble(sign | nanInfinityOrZeroExponent | fusedExponentMantissa);
        }


        public quarter this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 4);

                return maxmath.asquarter(asArray[index]);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                asArray[index] = maxmath.asbyte(value);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (quarter4 left, quarter4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 maskedLeft = Sse2.and_si128(left, new byte4(0b0111_1111));
                v128 maskedRight = Sse2.and_si128(right, new byte4(0b0111_1111));


                v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft, new byte4(0b0111_0000)), new v128(-1)),
                                          Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte4(0b0111_0000)), new v128(-1)));

                v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                           Sse2.cmpeq_epi8(default(v128), maskedRight));

                v128 value = Sse2.cmpeq_epi8(left, right);


                v128 result = Sse2.sub_epi8(default(v128), Sse2.and_si128(nan, Sse2.or_si128(zero, value)));

                return *(bool4*)&result;
            }
            else
            {
                return new bool4(left.x == right.x, left.y == right.y, left.z == right.z, left.w == right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (quarter4 left, quarter4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 maskedLeft = Sse2.and_si128(left, new byte4(0b0111_1111));
                v128 maskedRight = Sse2.and_si128(right, new byte4(0b0111_1111));


                v128 nan = Sse2.or_si128(Sse2.cmpgt_epi8(maskedLeft, new byte4(0b0111_0000)),
                                         Sse2.cmpgt_epi8(maskedRight, new byte4(0b0111_0000)));

                v128 zero = Sse2.or_si128(Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft), new v128(-1)),
                                          Sse2.andnot_si128(Sse2.cmpeq_epi8(default(v128), maskedRight), new v128(-1)));

                v128 value = Sse2.andnot_si128(Sse2.cmpeq_epi8(left, right), new v128(-1));


                v128 result = Sse2.sub_epi8(default(v128), Sse2.or_si128(nan, Sse2.and_si128(zero, value)));

                return *(bool4*)&result;
            }
            else
            {
                return new bool4(left.x != right.x, left.y != right.y, left.z != right.z, left.w != right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(quarter4 other)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 maskedLeft = Sse2.and_si128(this, new byte4(0b0111_1111));
                v128 maskedRight = Sse2.and_si128(other, new byte4(0b0111_1111));


                v128 nan = Sse2.and_si128(Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedLeft, new byte4(0b0111_0000)), new v128(-1)),
                                          Sse2.andnot_si128(Sse2.cmpgt_epi8(maskedRight, new byte4(0b0111_0000)), new v128(-1)));

                v128 zero = Sse2.and_si128(Sse2.cmpeq_epi8(default(v128), maskedLeft),
                                           Sse2.cmpeq_epi8(default(v128), maskedRight));

                v128 value = Sse2.cmpeq_epi8(this, other);


                v128 result = Sse2.and_si128(nan, Sse2.or_si128(zero, value));

                return result.UInt0 == uint.MaxValue;
            }
            else
            {
                return this.x == other.x && this.y == other.y && this.z == other.z && this.w == other.w;
            }
        }

        public override readonly bool Equals(object obj) => Equals((quarter4)obj);


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