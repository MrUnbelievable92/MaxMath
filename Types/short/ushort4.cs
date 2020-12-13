using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 8)]
    unsafe public struct ushort4 : IEquatable<ushort4>
    {
        [FieldOffset(0)] internal long cast_long;

        [FieldOffset(0)] public ushort x;
        [FieldOffset(2)] public ushort y;
        [FieldOffset(4)] public ushort z;
        [FieldOffset(6)] public ushort w;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort x, ushort y, ushort z, ushort w)
        {
            this = Sse2.set_epi16(0, 0, 0, 0, (short)w, (short)z, (short)y, (short)x);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort xyzw)
        {
            this = Sse2.set1_epi16((short)xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort2 xy, ushort z, ushort w)
        {
            this = Sse2.insert_epi16(Sse2.insert_epi16(xy, z, 2), w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort x, ushort2 yz, ushort w)
        {
            this = Sse2.insert_epi16(Sse2.insert_epi16(Sse2.bslli_si128(yz, sizeof(ushort)), x, 0), w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort x, ushort y, ushort2 zw)
        {
            this = Sse2.insert_epi16(Sse2.insert_epi16(Sse2.bslli_si128(zw, 2 * sizeof(ushort)), x, 0), y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort2 xy, ushort2 zw)
        {
            this = Sse2.unpacklo_epi32(xy, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort3 xyz, ushort w)
        {
            this = Sse2.insert_epi16(xyz, w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort4(ushort x, ushort3 yzw)
        {
            this = Sse2.insert_epi16(Sse2.bslli_si128(yzw, sizeof(ushort)), x, 0);
        }


        #region Shuffle
        public ushort4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0)); }
        public ushort4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 0)); }
        public ushort4 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 0)); }
        public ushort4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0)); }
        public ushort4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0)); }
        public ushort4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 0)); }
        public ushort4 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public ushort4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 0)); }
        public ushort4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 0)); }
        public ushort4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 0)); }
        public ushort4 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0)); }
        public ushort4 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 0)); }
        public ushort4 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 0)); }
        public ushort4 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 0)); }
        public ushort4 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 0)); }
        public ushort4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0)); }
        public ushort4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }
        public ushort4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 0)); }
        public ushort4 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 0)); }
        public ushort4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0)); }
        public ushort4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0)); }
        public ushort4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 0)); }
        public ushort4 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public ushort4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 0)); }
        public ushort4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 0)); }
        public ushort4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 0)); }
        public ushort4 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 0)); }
        public ushort4 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 0)); }
        public ushort4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 0)); }
        public ushort4 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 0)); }
        public ushort4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 0)); }
        public ushort4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 0)); }
        public ushort4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 0)); }
        public ushort4 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public ushort4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 0)); }
        public ushort4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 0)); }
        public ushort4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 0)); }
        public ushort4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0)); }
        public ushort4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 0)); }
        public ushort4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 0)); }
        public ushort4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 0)); }
        public ushort4 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public ushort4 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 0)); }
        public ushort4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 0)); }
        public ushort4 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 0)); }
        public ushort4 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0)); }
        public ushort4 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 0)); }
        public ushort4 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 0)); }
        public ushort4 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 0)); }
        public ushort4 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 0)); }
        public ushort4 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 0)); }
        public ushort4 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 0)); }
        public ushort4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 0)); }
        public ushort4 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 0)); }
        public ushort4 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 0)); }
        public ushort4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 0)); }
        public ushort4 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 0)); }
        public ushort4 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 0)); }
        public ushort4 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 0)); }
        public ushort4 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 0)); }
        public ushort4 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 0)); }
        public ushort4 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0)); }
        public ushort4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1)); }
        public ushort4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1)); }
        public ushort4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 1)); }
        public ushort4 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public ushort4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1)); }
        public ushort4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1)); }
        public ushort4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 1)); }
        public ushort4 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public ushort4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 1)); }
        public ushort4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 1)); }
        public ushort4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 1)); }
        public ushort4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1)); }
        public ushort4 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 1)); }
        public ushort4 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 1)); }
        public ushort4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 1)); }
        public ushort4 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public ushort4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1)); }
        public ushort4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1)); }
        public ushort4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 1)); }
        public ushort4 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public ushort4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1)); }
        public ushort4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1)); }
        public ushort4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 1)); }
        public ushort4 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public ushort4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 1)); }
        public ushort4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 1)); }
        public ushort4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 1)); }
        public ushort4 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public ushort4 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 1)); }
        public ushort4 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 1)); }
        public ushort4 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 1)); }
        public ushort4 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        public ushort4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public ushort4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 1)); }
        public ushort4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 1)); }
        public ushort4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1)); }
        public ushort4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 1)); }
        public ushort4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 1)); }
        public ushort4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 1)); }
        public ushort4 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public ushort4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 1)); }
        public ushort4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 1)); }
        public ushort4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 1)); }
        public ushort4 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public ushort4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 1)); }
        public ushort4 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 1)); }
        public ushort4 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 1)); }
        public ushort4 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1)); }
        public ushort4 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 1)); }
        public ushort4 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 1)); }
        public ushort4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 1)); }
        public ushort4 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 1)); }
        public ushort4 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 1)); }
        public ushort4 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 1)); }
        public ushort4 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 1)); }
        public ushort4 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 1)); }
        public ushort4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 1)); }
        public ushort4 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 1)); }
        public ushort4 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 1)); }
        public ushort4 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 1)); }
        public ushort4 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 1)); }
        public ushort4 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 1)); }
        public ushort4 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 1)); }
        public ushort4 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1)); }
        public ushort4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 2)); }
        public ushort4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 2)); }
        public ushort4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 2)); }
        public ushort4 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public ushort4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 2)); }
        public ushort4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 2)); }
        public ushort4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 2)); }
        public ushort4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2)); }
        public ushort4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 2)); }
        public ushort4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 2)); }
        public ushort4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 2)); }
        public ushort4 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public ushort4 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 2)); }
        public ushort4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 2)); }
        public ushort4 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 2)); }
        public ushort4 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2)); }
        public ushort4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 2)); }
        public ushort4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 2)); }
        public ushort4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 2)); }
        public ushort4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2)); }
        public ushort4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 2)); }
        public ushort4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 2)); }
        public ushort4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 2)); }
        public ushort4 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public ushort4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 2)); }
        public ushort4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 2)); }
        public ushort4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 2)); }
        public ushort4 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public ushort4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 2)); }
        public ushort4 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 2)); }
        public ushort4 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 2)); }
        public ushort4 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2)); }
        public ushort4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 2)); }
        public ushort4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 2)); }
        public ushort4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 2)); }
        public ushort4 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public ushort4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 2)); }
        public ushort4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 2)); }
        public ushort4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 2)); }
        public ushort4 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public ushort4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 2)); }
        public ushort4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 2)); }
        public ushort4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 2)); }
        public ushort4 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2)); }
        public ushort4 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 2)); }
        public ushort4 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 2)); }
        public ushort4 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 2)); }
        public ushort4 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        public ushort4 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public ushort4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 2)); }
        public ushort4 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 2)); }
        public ushort4 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 2)); }
        public ushort4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 2)); }
        public ushort4 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 2)); }
        public ushort4 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 2)); }
        public ushort4 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 2)); }
        public ushort4 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 2)); }
        public ushort4 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 2)); }
        public ushort4 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 2)); }
        public ushort4 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public ushort4 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 2)); }
        public ushort4 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 2)); }
        public ushort4 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 2)); }
        public ushort4 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2)); }
        public ushort4 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 3)); }
        public ushort4 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 3)); }
        public ushort4 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 3)); }
        public ushort4 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 3)); }
        public ushort4 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 3)); }
        public ushort4 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 3)); }
        public ushort4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 3)); }
        public ushort4 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 3)); }
        public ushort4 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 3)); }
        public ushort4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 3)); }
        public ushort4 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 3)); }
        public ushort4 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 3)); }
        public ushort4 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 3)); }
        public ushort4 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 3)); }
        public ushort4 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 3)); }
        public ushort4 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3)); }
        public ushort4 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 3)); }
        public ushort4 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 3)); }
        public ushort4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 3)); }
        public ushort4 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 3)); }
        public ushort4 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 3)); }
        public ushort4 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 3)); }
        public ushort4 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 3)); }
        public ushort4 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 3)); }
        public ushort4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 3)); }
        public ushort4 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 3)); }
        public ushort4 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 3)); }
        public ushort4 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 3)); }
        public ushort4 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 3)); }
        public ushort4 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 3)); }
        public ushort4 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 3)); }
        public ushort4 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3)); }
        public ushort4 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 3)); }
        public ushort4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 3)); }
        public ushort4 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 3)); }
        public ushort4 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 3)); }
        public ushort4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 3)); }
        public ushort4 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 3)); }
        public ushort4 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 3)); }
        public ushort4 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 3)); }
        public ushort4 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 3)); }
        public ushort4 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 3)); }
        public ushort4 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 3)); }
        public ushort4 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 3)); }
        public ushort4 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 3)); }
        public ushort4 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 3)); }
        public ushort4 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 3)); }
        public ushort4 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3)); }
        public ushort4 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 3)); }
        public ushort4 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 3)); }
        public ushort4 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 3)); }
        public ushort4 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 3)); }
        public ushort4 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 3)); }
        public ushort4 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 3)); }
        public ushort4 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 3)); }
        public ushort4 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 3)); }
        public ushort4 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 3)); }
        public ushort4 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 3)); }
        public ushort4 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 3)); }
        public ushort4 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 3)); }
        public ushort4 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 3)); }
        public ushort4 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 3)); }
        public ushort4 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 3)); }
        public ushort4 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3)); }

        public ushort3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public ushort3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0)); }
        public ushort3 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 0)); }
        public ushort3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }
        public ushort3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public ushort3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }                
        public ushort3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 0)); }
        public ushort3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public ushort3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0)); }
        public ushort3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public ushort3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0)); }
        public ushort3 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 0)); }
        public ushort3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 0)); }
        public ushort3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 0)); }
        public ushort3 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0)); }
        public ushort3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public ushort3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public ushort3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1)); }
        public ushort3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public ushort3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public ushort3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public ushort3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public ushort3 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        public ushort3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1)); }
        public ushort3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public ushort3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public ushort3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1)); }       
        public ushort3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 1)); }
        public ushort3 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 1)); }
        public ushort3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 1)); }
        public ushort3 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1)); }
        public ushort3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public ushort3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2)); }
        public ushort3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public ushort3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2)); }
        public ushort3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2)); }
        public ushort3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public ushort3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public ushort3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2)); }
        public ushort3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public ushort3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public ushort3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2)); }
        public ushort3 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        public ushort3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 2)); }
        public ushort3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 2)); }
        public ushort3 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public ushort3 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2)); }
        public ushort3 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 3)); }
        public ushort3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 3)); }
        public ushort3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 3)); }
        public ushort3 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3)); }
        public ushort3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 3)); }
        public ushort3 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 3)); }
        public ushort3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 3)); }
        public ushort3 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3)); }
        public ushort3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 3)); }
        public ushort3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 3)); }
        public ushort3 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 3)); }
        public ushort3 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3)); }
        public ushort3 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 3)); }
        public ushort3 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 3)); }
        public ushort3 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 3)); }
        public ushort3 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3)); }

        public ushort2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public ushort2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0)); }
        public ushort2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0)); }
        public ushort2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public ushort2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        public ushort2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1)); }          
        public ushort2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1)); }
        public ushort2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2)); }
        public ushort2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2)); }
        public ushort2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        public ushort2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2)); }
        public ushort2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3)); }
        public ushort2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3)); }
        public ushort2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3)); }
        public ushort2 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ushort4 input) => Sse2.set1_epi64x(input.cast_long);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static implicit operator ushort4(v128 input) => new ushort4 { cast_long = Sse4_1.extract_epi64(input, 0) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4(ushort input) => new ushort4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(short4 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(int4 input) => Cast.Int4ToShort4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(uint4 input) => Cast.Int4ToShort4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(long4 input) => Cast.Long4ToShort4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(ulong4 input) => Cast.Long4ToShort4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(half4 input) => (ushort4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(float4 input) => (ushort4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(double4 input) => (ushort4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(ushort4 input) { v128 temp = Sse4_1.cvtepu16_epi32(input); return *(int4*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4(ushort4 input) { v128 temp = Sse4_1.cvtepu16_epi32(input); return *(uint4*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(ushort4 input) => Avx2.mm256_cvtepu16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(ushort4 input) => Avx2.mm256_cvtepu16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(ushort4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(ushort4 input) { v128 t = Cast.UShortToFloat(input); return *(float4*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(ushort4 input) => (double4)(int4)input;


        public ushort this[[AssumeRange(0, 3)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    return ((ushort*)ptr)[index];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    ((ushort*)ptr)[index] = value;
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator + (ushort4 lhs, ushort4 rhs) => Sse2.add_epi16(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator - (ushort4 lhs, ushort4 rhs) => Sse2.sub_epi16(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator * (ushort4 lhs, ushort4 rhs) => Sse2.mullo_epi16(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort4 lhs, ushort4 rhs) => new ushort4((ushort)(lhs.x / rhs.x), (ushort)(lhs.y / rhs.y), (ushort)(lhs.z / rhs.z), (ushort)(lhs.w / rhs.w));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort4 lhs, ushort4 rhs) => new ushort4((ushort)(lhs.x % rhs.x), (ushort)(lhs.y % rhs.y), (ushort)(lhs.z % rhs.z), (ushort)(lhs.w % rhs.w));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator / (ushort4 lhs, ushort rhs) => Operator.div(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator % (ushort4 lhs, ushort rhs) => Operator.rem(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator & (ushort4 lhs, ushort4 rhs) => Sse2.and_si128(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator | (ushort4 lhs, ushort4 rhs) => Sse2.or_si128(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ^ (ushort4 lhs, ushort4 rhs) => Sse2.xor_si128(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ++ (ushort4 x) => Sse2.add_epi16(x, new v128((ushort)1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator -- (ushort4 x) => Sse2.sub_epi16(x, new v128((ushort)1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator ~ (ushort4 x) => Sse2.andnot_si128(x, new v128((short)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator << (ushort4 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 operator >> (ushort4 x, int n) => Operator.shrl_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (ushort4 lhs, ushort4 rhs) => TestIsTrue(Sse2.cmpeq_epi16(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (ushort4 lhs, ushort4 rhs) => TestIsTrue(Operator.greater_mask_ushort(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (ushort4 lhs, ushort4 rhs) => TestIsTrue(Operator.greater_mask_ushort(lhs, rhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (ushort4 lhs, ushort4 rhs) => TestIsFalse(Sse2.cmpeq_epi16(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (ushort4 lhs, ushort4 rhs) => TestIsFalse(Operator.greater_mask_ushort(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (ushort4 lhs, ushort4 rhs) => TestIsFalse(Operator.greater_mask_ushort(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsTrue(v128 input)
        {
            int result = 0x0101_0101 & Sse4_1.extract_epi32((byte4)(ushort4)input, 0);

            return *(bool4*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsFalse(v128 input)
        {
            int result = maxmath.andnot(0x0101_0101, Sse4_1.extract_epi32((byte4)(ushort4)input, 0));

            return *(bool4*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort4 other) => maxmath.tobool(Sse4_1.testc_si128(Sse2.cmpeq_epi16(this, other), new v128(-1L, 0L)));

        public override bool Equals(object obj) => Equals((ushort4)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v64(this);


        public override string ToString() => $"ushort4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}