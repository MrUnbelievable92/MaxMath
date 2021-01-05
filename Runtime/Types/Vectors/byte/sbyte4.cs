using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 4)]
    unsafe public struct sbyte4 : IEquatable<sbyte4>, IFormattable
    {
        [NoAlias] public sbyte x;
        [NoAlias] public sbyte y;
        [NoAlias] public sbyte z;
        [NoAlias] public sbyte w;


        public static sbyte4 zero => default(sbyte4);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte y, sbyte z, sbyte w)
        {
            this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, w, z, y, x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte xyzw)
        {
            this = Sse2.set1_epi8(xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte2 xy, sbyte z, sbyte w)
        {
            this = Sse4_1.insert_epi8(Sse4_1.insert_epi8(xy, (byte)z, 2), (byte)w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte2 yz, sbyte w)
        {
            this = Sse4_1.insert_epi8(Sse4_1.insert_epi8(Sse2.bslli_si128(yz, sizeof(sbyte)), (byte)x, 0), (byte)w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte y, sbyte2 zw)
        {
            this = Sse4_1.insert_epi8(Sse4_1.insert_epi8(Sse2.bslli_si128(zw, 2 * sizeof(sbyte)), (byte)x, 0), (byte)y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte2 xy, sbyte2 zw)
        {
            this = Sse2.unpacklo_epi16(xy, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte3 xyz, sbyte w)
        {
            this = Sse4_1.insert_epi8(xyz, (byte)w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte4(sbyte x, sbyte3 yzw)
        {
            this = Sse4_1.insert_epi8(Sse2.bslli_si128(yzw, sizeof(sbyte)), (byte)x, 0);
        }


        #region Shuffle
        public sbyte4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }                                                          
        public sbyte4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public sbyte4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xywz; }
        public sbyte4 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzyw; }
        public sbyte4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwyz; }
        public sbyte4 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xzwy; }
        public sbyte4 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.xwzy; }
        public sbyte4 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxzw; }
        public sbyte4 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yxwz; }
        public sbyte4 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxyw; }
        public sbyte4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxyz; }
        public sbyte4 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zxwy; }
        public sbyte4 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wxzy; }
        public sbyte4 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzxw; }
        public sbyte4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywxz; }
        public sbyte4 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zyxw; }
        public sbyte4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyxz; }
        public sbyte4 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));                                  [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwxy; }
        public sbyte4 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzxy; }
        public sbyte4 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }                                
        public sbyte4 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.yzwx; }
        public sbyte4 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.ywzx; }
        public sbyte4 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zywx; }
        public sbyte4 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wyzx; }
        public sbyte4 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.zwyx; }
        public sbyte4 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = value.wzyx; }
        public sbyte4 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (0 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (0 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (0 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (1 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (1 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (1 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (2 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (2 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (2 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte4 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (3 << 16) | (0 << 24),   0, 0, 0)); }
        public sbyte4 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (3 << 16) | (1 << 24),   0, 0, 0)); }
        public sbyte4 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (3 << 16) | (2 << 24),   0, 0, 0)); }
        public sbyte4 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }

        public sbyte3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public sbyte3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }                                                                          
        public sbyte3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                                                                           [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value, new byte4(255, 255, 255, 0)); }     
        public sbyte3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xyzz, new byte4(255, 255, 0, 255)); }
        public sbyte3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); } 
        public sbyte3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xzyy, new byte4(255, 255, 255, 0)); }
        public sbyte3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xxyz, new byte4(255, 0, 255, 255)); }
        public sbyte3 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xzzy, new byte4(255, 255, 0, 255)); }
        public sbyte3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xxzy, new byte4(255, 0, 255, 255)); }
        public sbyte3 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yxzz, new byte4(255, 255, 255, 0)); }
        public sbyte3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yxzz, new byte4(255, 255, 0, 255)); }
        public sbyte3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.zxyy, new byte4(255, 255, 255, 0)); }
        public sbyte3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (2 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 1);                                                         [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xxyz, new byte4(0, 255, 255, 255)); }
        public sbyte3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.zxxy, new byte4(255, 255, 0, 255)); }
        public sbyte3 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xxzy, new byte4(0, 255, 255, 255)); }
        public sbyte3 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yzxx, new byte4(255, 255, 255, 0)); }
        public sbyte3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyxz, new byte4(255, 0, 255, 255)); }
        public sbyte3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.zyxx, new byte4(255, 255, 255, 0)); }
        public sbyte3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyxz, new byte4(0, 255, 255, 255)); }
        public sbyte3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));                                  [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.zzxy, new byte4(255, 0, 255, 255)); }
        public sbyte3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.zzxy, new byte4(0, 255, 255, 255)); }
        public sbyte3 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }                                                       
        public sbyte3 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yzzx, new byte4(255, 255, 0, 255)); }
        public sbyte3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyzx, new byte4(255, 0, 255, 255)); }
        public sbyte3 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.zyyx, new byte4(255, 255, 0, 255)); }
        public sbyte3 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyzx, new byte4(0, 255, 255, 255)); }
        public sbyte3 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.zzyx, new byte4(255, 0, 255, 255)); }
        public sbyte3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.zzyx, new byte4(0, 255, 255, 255)); }
        public sbyte3 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (0 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (1 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (2 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte3 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }

    public sbyte2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public sbyte2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this;                                                                          [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value, 0b01); }
        public sbyte2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xxyy, new byte4(255, 0, 255, 0)); }
        public sbyte2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xxyy, new byte4(255, 0, 0, 255)); }
        public sbyte2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yx, 0b01); }
        public sbyte2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }
        public sbyte2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 1);                                                         [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xxyy, new byte4(0, 255, 255, 0)); }
        public sbyte2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1 | (3 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.xxyy, new byte4(0, 255, 0, 255)); }
        public sbyte2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyxx, new byte4(255, 0, 255, 0)); }
        public sbyte2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyxx, new byte4(0, 255, 255, 0)); }
        public sbyte2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); }    
        public sbyte2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)maxmath.vshr(this, 2);                                                         [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.xyxy, 0b10); }
        public sbyte2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (0 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyxx, new byte4(255, 0, 0, 255)); }
        public sbyte2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (1 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blendv_epi8(this, value.yyxx, new byte4(0, 255, 0, 255)); }
        public sbyte2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3 | (2 << 8) | (3 << 16) | (3 << 24),   0, 0, 0)); [MethodImpl(MethodImplOptions.AggressiveInlining)] set => this = Sse4_1.blend_epi16(this, value.yxyx, 0b10); }
        public sbyte2 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte4 input) => new v128(*(int*)&input, 0, 0, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4(v128 input) { int x = input.SInt0; return *(sbyte4*)&x; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte4(sbyte input) => new sbyte4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(byte4 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(short4 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(ushort4 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(int4 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(uint4 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(long4 input) => Cast.Long4ToByte4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(ulong4 input) => Cast.Long4ToByte4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(half4 input) => (sbyte4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(float4 input) => (sbyte4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte4(double4 input) => (sbyte4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(sbyte4 input) => Sse4_1.cvtepi8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort4(sbyte4 input) => Sse4_1.cvtepi8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(sbyte4 input) { v128 temp = Sse4_1.cvtepi8_epi32(input); return *(int4*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(sbyte4 input) { v128 temp = Sse4_1.cvtepi8_epi32(input); return *(uint4*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(sbyte4 input) => Avx2.mm256_cvtepi8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(sbyte4 input) => Avx2.mm256_cvtepi8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(sbyte4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(sbyte4 input) => (float4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(sbyte4 input) => (double4)(int4)input;


        public sbyte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);
                
                fixed (void* ptr = &this)
                {
                    return ((sbyte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    ((sbyte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator + (sbyte4 left, sbyte4 right) => Sse2.add_epi8(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator - (sbyte4 left, sbyte4 right) => Sse2.sub_epi8(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator * (sbyte4 left, sbyte4 right) => (sbyte4)((ushort4)left * (ushort4)right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator / (sbyte4 left, sbyte4 right) => Operator.vdiv_sbyte(left, right);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator % (sbyte4 left, sbyte4 right) => Operator.vrem_sbyte(left, right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator & (sbyte4 left, sbyte4 right) => Sse2.and_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator | (sbyte4 left, sbyte4 right) => Sse2.or_si128(left, right);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ^ (sbyte4 left, sbyte4 right) => Sse2.xor_si128(left, right);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator - (sbyte4 x) => Ssse3.sign_epi8(x, new v128((sbyte)-1));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ++ (sbyte4 x) => Sse2.add_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator -- (sbyte4 x) => Sse2.sub_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator ~ (sbyte4 x) => Sse2.andnot_si128(x, new v128((sbyte)-1));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator << (sbyte4 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 operator >> (sbyte4 x, int n) => (sbyte4)((short4) x >> n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (sbyte4 left, sbyte4 right) => TestIsTrue(Sse2.cmpeq_epi8(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (sbyte4 left, sbyte4 right) => TestIsTrue(Sse2.cmpgt_epi8(right, left));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (sbyte4 left, sbyte4 right) => TestIsTrue(Sse2.cmpgt_epi8(left, right));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (sbyte4 left, sbyte4 right) => TestIsFalse(Sse2.cmpeq_epi8(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (sbyte4 left, sbyte4 right) => TestIsFalse(Sse2.cmpgt_epi8(left, right));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (sbyte4 left, sbyte4 right) => TestIsFalse(Sse2.cmpgt_epi8(right, left));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsTrue(v128 input)
        {
            input = Sse2.and_si128(input, new v128(0x0101_0101));

            return *(bool4*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsFalse(v128 input)
        {
            input = Sse2.andnot_si128(input, new v128(0x0101_0101));

            return *(bool4*)&input;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(sbyte4 other) => maxmath.bitmask32(4 * sizeof(sbyte)) == (maxmath.bitmask32(4 * sizeof(sbyte)) & (Sse2.movemask_epi8(Sse2.cmpeq_epi8(this, other))));

        public override bool Equals(object obj) => Equals((sbyte4)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => ((v128)this).SInt0;


        public override string ToString() => $"sbyte4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"sbyte4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}