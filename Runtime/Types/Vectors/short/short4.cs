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
    unsafe public struct short4 : IEquatable<short4>, IFormattable
    {
        // otherhwise LLVM/Burst goes crazy with bitshifts and masks etc. -.-
        [FieldOffset(0)] internal long cast_long;

        [FieldOffset(0)] public short x;
        [FieldOffset(2)] public short y;
        [FieldOffset(4)] public short z;
        [FieldOffset(6)] public short w;


        public static short4 zero => default(short4);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short y, short z, short w)
        {
            this = Sse2.set_epi16(0, 0, 0, 0, w, z, y, x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short xyzw)
        {
            this = Sse2.set1_epi16(xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short2 xy, short z, short w)
        {
            this = Sse2.insert_epi16(Sse2.insert_epi16(xy, z, 2), w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short2 yz, short w)
        {
            this = Sse2.insert_epi16(Sse2.insert_epi16(Sse2.bslli_si128(yz, sizeof(short)), x, 0), w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short y, short2 zw)
        {
            this = Sse2.insert_epi16(Sse2.insert_epi16(Sse2.bslli_si128(zw, 2 * sizeof(short)), x, 0), y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short2 xy, short2 zw)
        {
            this = Sse2.unpacklo_epi32(xy, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short3 xyz, short w)
        {
            this = Sse2.insert_epi16(xyz, w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short4(short x, short3 yzw)
        {
            this = Sse2.insert_epi16(Sse2.bslli_si128(yzw, sizeof(short)), x, 0);
        }


        #region Shuffle
        public short4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }                        
        public short4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0)); }
        public short4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 0)); }
        public short4 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 0)); }
        public short4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0)); }
        public short4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0)); }
        public short4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 0)); }
        public short4 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public short4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 0)); }
        public short4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 0)); }
        public short4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 0)); }
        public short4 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0)); }
        public short4 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 0)); }
        public short4 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 0)); }
        public short4 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 0)); }
        public short4 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 0)); }
        public short4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0)); }
        public short4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }                       
        public short4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 0)); }
        public short4 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 0)); }
        public short4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0)); }
        public short4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0)); }
        public short4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 0)); }
        public short4 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public short4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 0)); }
        public short4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 0)); }
        public short4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 0)); }
        public short4 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 0)); }
        public short4 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 0)); }
        public short4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xywz; }
        public short4 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 0)); }
        public short4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 0)); }
        public short4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 0)); }
        public short4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 0)); }
        public short4 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public short4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 0)); }
        public short4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 0)); }
        public short4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 0)); }
        public short4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzyw; }
        public short4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 0)); }
        public short4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 0)); }
        public short4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 0)); }
        public short4 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public short4 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 0)); }
        public short4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwyz; }
        public short4 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 0)); }
        public short4 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0)); }
        public short4 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 0)); }
        public short4 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 0)); }
        public short4 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 0)); }
        public short4 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 0)); }
        public short4 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 0)); }
        public short4 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 0)); }
        public short4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzwy; }
        public short4 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 0)); }
        public short4 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 0)); }
        public short4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwzy; }
        public short4 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 0)); }
        public short4 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 0)); }
        public short4 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 0)); }
        public short4 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 0)); }
        public short4 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 0)); }
        public short4 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0)); }
        public short4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1)); }
        public short4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1)); }
        public short4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 1)); }
        public short4 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public short4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1)); }
        public short4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1)); }
        public short4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 1)); }
        public short4 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public short4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 1)); }
        public short4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 1)); }
        public short4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 1)); }
        public short4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxzw; }
        public short4 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 1)); }
        public short4 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 1)); }
        public short4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxwz; }
        public short4 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public short4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1)); }
        public short4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1)); }
        public short4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 1)); }
        public short4 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public short4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1)); }
        public short4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1)); }
        public short4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 1)); }
        public short4 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public short4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 1)); }
        public short4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 1)); }
        public short4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 1)); }
        public short4 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public short4 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 1)); }
        public short4 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 1)); }
        public short4 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 1)); }
        public short4 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        public short4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public short4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 1)); }
        public short4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 1)); }
        public short4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxyw; }
        public short4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 1)); }
        public short4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 1)); }
        public short4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 1)); }
        public short4 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public short4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 1)); }
        public short4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 1)); }
        public short4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 1)); }
        public short4 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public short4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxyz; }
        public short4 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 1)); }
        public short4 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 1)); }
        public short4 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1)); }
        public short4 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 1)); }
        public short4 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 1)); }
        public short4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxwy; }
        public short4 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 1)); }
        public short4 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 1)); }
        public short4 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 1)); }
        public short4 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 1)); }
        public short4 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 1)); }
        public short4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxzy; }
        public short4 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 1)); }
        public short4 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 1)); }
        public short4 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 1)); }
        public short4 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 1)); }
        public short4 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 1)); }
        public short4 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 1)); }
        public short4 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1)); }
        public short4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 2)); }
        public short4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 2)); }
        public short4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 2)); }
        public short4 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public short4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 2)); }
        public short4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 2)); }
        public short4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 2)); }
        public short4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzxw; }
        public short4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 2)); }
        public short4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 2)); }
        public short4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 2)); }
        public short4 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public short4 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 2)); }
        public short4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywxz; }
        public short4 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 2)); }
        public short4 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2)); }
        public short4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 2)); }
        public short4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 2)); }
        public short4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 2)); }
        public short4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zyxw; }
        public short4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 2)); }
        public short4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 2)); }
        public short4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 2)); }
        public short4 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public short4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 2)); }
        public short4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 2)); }
        public short4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 2)); }
        public short4 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public short4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyxz; }
        public short4 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 2)); }
        public short4 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 2)); }
        public short4 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2)); }
        public short4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 2)); }
        public short4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 2)); }
        public short4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 2)); }
        public short4 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public short4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 2)); }
        public short4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 2)); }
        public short4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 2)); }
        public short4 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public short4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 2)); }
        public short4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 2)); }
        public short4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 2)); }
        public short4 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2)); }
        public short4 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 2)); }
        public short4 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 2)); }
        public short4 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 2)); }
        public short4 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        public short4 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public short4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwxy; }
        public short4 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 2)); }
        public short4 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 2)); }
        public short4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzxy; }
        public short4 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 2)); }
        public short4 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 2)); }
        public short4 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 2)); }
        public short4 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 2)); }
        public short4 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 2)); }
        public short4 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 2)); }
        public short4 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public short4 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 2)); }
        public short4 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 2)); }
        public short4 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 2)); }
        public short4 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2)); }
        public short4 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 3)); }
        public short4 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 3)); }
        public short4 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 3)); }
        public short4 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 3)); }
        public short4 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 3)); }
        public short4 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 3)); }
        public short4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzwx; }
        public short4 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 3)); }
        public short4 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 3)); }
        public short4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywzx; }
        public short4 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 3)); }
        public short4 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 3)); }
        public short4 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 0, 3)); }
        public short4 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 0, 3)); }
        public short4 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 0, 3)); }
        public short4 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3)); }
        public short4 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 3)); }
        public short4 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 3)); }
        public short4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zywx; }
        public short4 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 3)); }
        public short4 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 3)); }
        public short4 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 3)); }
        public short4 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 3)); }
        public short4 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 3)); }
        public short4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyzx; }
        public short4 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 3)); }
        public short4 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 3)); }
        public short4 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 3)); }
        public short4 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 1, 3)); }
        public short4 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 1, 3)); }
        public short4 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 1, 3)); }
        public short4 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3)); }
        public short4 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 3)); }
        public short4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwyx; }
        public short4 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 3)); }
        public short4 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 3)); }
        public short4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzyx; }
        public short4 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 3)); }
        public short4 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 3)); }
        public short4 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 3)); }
        public short4 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 3)); }
        public short4 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 3)); }
        public short4 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 3)); }
        public short4 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 3)); }
        public short4 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 2, 3)); }
        public short4 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 2, 3)); }
        public short4 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 2, 3)); }
        public short4 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3)); }
        public short4 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 3, 3)); }
        public short4 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 3, 3)); }
        public short4 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 3, 3)); }
        public short4 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 3)); }
        public short4 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 3, 3)); }
        public short4 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 3, 3)); }
        public short4 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 3, 3)); }
        public short4 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 3)); }
        public short4 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 3, 3)); }
        public short4 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 3, 3)); }
        public short4 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 3, 3)); }
        public short4 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 3)); }
        public short4 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 3, 3, 3)); }
        public short4 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 3, 3, 3)); }
        public short4 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 3, 3, 3)); }
        public short4 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3)); }

        public short3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public short3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public short3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0)); }
        public short3 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 0)); }
        public short3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }                                         
        public short3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public short3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                                          [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value, 0b0111); }         
        public short3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xyzz, 0b1011); }
        public short3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0)); } 
        public short3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xzyy, 0b0111); }
        public short3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public short3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xxyz, 0b1101); }
        public short3 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 0)); }
        public short3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xzzy, 0b1011); }
        public short3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xxzy, 0b1101); }
        public short3 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0)); }
        public short3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public short3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public short3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yxzz, 0b0111); }
        public short3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yxzz, 0b1011); }
        public short3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public short3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public short3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public short3 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        public short3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.zxyy, 0b0111); }
        public short3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public short3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public short3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xxyz, 0b1110); }
        public short3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.zxxy, 0b1011); }
        public short3 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 1)); }
        public short3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xxzy, 0b1110); }
        public short3 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1)); }
        public short3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public short3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yzxx, 0b0111); }
        public short3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public short3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yyxz, 0b1101); }
        public short3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.zyxx, 0b0111); }
        public short3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public short3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public short3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yyxz, 0b1110); }
        public short3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public short3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public short3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2)); }
        public short3 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        public short3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.zzxy, 0b1101); }
        public short3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.zzxy, 0b1110); }
        public short3 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 2)); }                       
        public short3 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2)); }
        public short3 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 3)); }
        public short3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yzzx, 0b1011); }
        public short3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yyzx, 0b1101); }
        public short3 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3)); }
        public short3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.zyyx, 0b1011); }
        public short3 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 3)); }
        public short3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yyzx, 0b1110); }
        public short3 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3)); }
        public short3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.zzyx, 0b1101); }
        public short3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.zzyx, 0b1110); }
        public short3 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 3)); }
        public short3 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3)); }
        public short3 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 3, 3)); }
        public short3 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 3, 3)); }
        public short3 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 3, 3)); }
        public short3 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3)); }

        public short2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public short2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                                          [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value, 0b0011); }
        public short2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xxyy, 0b0101); }
        public short2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xxyy, 0b1001); }
        public short2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yx, 0b0011); }
        public short2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        public short2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xxyy, 0b0110); }
        public short2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 1)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xxyy, 0b1010); }
        public short2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yyxx, 0b0101); }
        public short2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yyxx, 0b0110); }
        public short2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2)); }    
        public short2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 2)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xyxy, 0b1100); }    
        public short2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yyxx, 0b1001); }
        public short2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yyxx, 0b1010); }
        public short2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 3)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yxyx, 0b1100); }
        public short2 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 3, 3)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short4 input) => new v128(input.cast_long, 0L);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(v128 input) => new short4 { cast_long = input.SLong0 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(short input) => new short4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(ushort4 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(int4 input) => Cast.Int4ToShort4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(uint4 input) => Cast.Int4ToShort4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(long4 input) => Cast.Long4ToShort4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(ulong4 input) => Cast.Long4ToShort4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(half4 input) => (short4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(float4 input) => (short4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short4(double4 input) => (short4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(short4 input) { v128 temp = Sse4_1.cvtepi16_epi32(input); return *(int4*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(short4 input) { v128 temp = Sse4_1.cvtepi16_epi32(input); return *(uint4*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(short4 input) => Avx2.mm256_cvtepi16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(short4 input) => Avx2.mm256_cvtepi16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(short4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(short4 input) => (float4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(short4 input) => (double4)(int4)input;


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);
                
                fixed (void* ptr = &this)
                {
                    return ((short*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    ((short*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator + (short4 lhs, short4 rhs) => Sse2.add_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator - (short4 lhs, short4 rhs) => Sse2.sub_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator * (short4 lhs, short4 rhs) => Sse2.mullo_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator / (short4 lhs, short4 rhs) => Operator.vdiv_short(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator % (short4 lhs, short4 rhs) => Operator.vrem_short(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator * (short lhs, short4 rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator * (short4 lhs, short rhs) => (v128)((short8)((v128)lhs) * rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator / (short4 lhs, short rhs) => (v128)((short8)((v128)lhs) / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator % (short4 lhs, short rhs) => (v128)((short8)((v128)lhs) % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator & (short4 lhs, short4 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator | (short4 lhs, short4 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator ^ (short4 lhs, short4 rhs) => Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator - (short4 x) => Ssse3.sign_epi16(x, new v128((short)-1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator ++ (short4 x) => Sse2.add_epi16(x, new v128((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator -- (short4 x) => Sse2.sub_epi16(x, new v128((short)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator ~ (short4 x) => Sse2.andnot_si128(x, new v128((short)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator << (short4 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 operator >> (short4 x, int n) => Operator.shra_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (short4 lhs, short4 rhs) => TestIsTrue(Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (short4 lhs, short4 rhs) => TestIsTrue(Sse2.cmpgt_epi16(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (short4 lhs, short4 rhs) => TestIsTrue(Sse2.cmpgt_epi16(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (short4 lhs, short4 rhs) => TestIsFalse(Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (short4 lhs, short4 rhs) => TestIsFalse(Sse2.cmpgt_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (short4 lhs, short4 rhs) => TestIsFalse(Sse2.cmpgt_epi16(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsTrue(v128 input)
        {
            input = Sse2.and_si128((byte4)(ushort4)input, new v128(0x0101_0101));

            return *(bool4*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsFalse(v128 input)
        {
            input = Sse2.andnot_si128((byte4)(ushort4)input, new v128(0x0101_0101));

            return *(bool4*)&input;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(short4 other) => maxmath.bitmask32(4 * sizeof(short)) == (maxmath.bitmask32(4 * sizeof(short)) & (Sse2.movemask_epi8(Sse2.cmpeq_epi16(this, other))));

        public override bool Equals(object obj) => Equals((short4)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v64(this);


        public override string ToString() => $"short4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"short4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}