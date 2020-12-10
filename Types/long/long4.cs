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
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 32)]
    unsafe public struct long4 : IEquatable<long4>
    {
        [NoAlias] public long x;
        [NoAlias] public long y;
        [NoAlias] public long z;
        [NoAlias] public long w;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x,      long y,       long z,       long w)
        {
            this = Avx.mm256_set_epi64x(w, z, y, x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long xyzw)
        {
            this = Avx.mm256_set1_epi64x(xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long2 xy, long z, long w)
        {
            this = Avx.mm256_set_m128i(new long2(z, w), xy);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long2 yz, long w)
        {
            this = Avx.mm256_set_epi64x(w, yz.y, yz.x, x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long y, long2 zw)
        {
            this = Avx.mm256_set_m128i(zw, new long2(x, y));
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long2 xy, long2 zw)
        {
            this = Avx.mm256_set_m128i(zw, xy);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long3 xyz, long w)
        {
            this = Avx.mm256_insert_epi64(xyz, w, 3);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long4(long x, long3 yzw)
        {
            this = Avx.mm256_insert_epi64(yzw.xxyz, x, 0);
        }


        #region Shuffle
        public long4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this)); }
        public long4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 0)); }
        public long4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 0)); }
        public long4 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 0)); }
        public long4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 0)); }
        public long4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 0)); }
        public long4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 0)); }
        public long4 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public long4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 0)); }
        public long4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 0)); }
        public long4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public long4 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 0)); }
        public long4 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 0)); }
        public long4 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 0)); }
        public long4 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 0)); }
        public long4 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 0)); }
        public long4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 0)); }
        public long4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public long4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 0)); }
        public long4 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 0)); }
        public long4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 0)); }
        public long4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 0)); }
        public long4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 0)); }
        public long4 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public long4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 0)); }
        public long4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 0)); }
        public long4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 0)); }
        public long4 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 0)); }
        public long4 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 0)); }
        public long4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 0)); }
        public long4 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 0)); }
        public long4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 0)); }
        public long4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 0)); }
        public long4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 0)); }
        public long4 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public long4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 0)); }
        public long4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 0)); }
        public long4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 0)); }
        public long4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0)); }
        public long4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 0)); }
        public long4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 0)); }
        public long4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 0)); }
        public long4 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public long4 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 0)); }
        public long4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 0)); }
        public long4 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 0)); }
        public long4 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0)); }
        public long4 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 0)); }
        public long4 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 0)); }
        public long4 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 0)); }
        public long4 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 0)); }
        public long4 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 0)); }
        public long4 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 0)); }
        public long4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 0)); }
        public long4 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 0)); }
        public long4 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 0)); }
        public long4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 0)); }
        public long4 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 0)); }
        public long4 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 0)); }
        public long4 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 0)); }
        public long4 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 0)); }
        public long4 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 0)); }
        public long4 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0)); }
        public long4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 1)); }
        public long4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 1)); }
        public long4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 1)); }
        public long4 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public long4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 1)); }
        public long4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 1)); }
        public long4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 1)); }
        public long4 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public long4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 1)); }
        public long4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 1)); }
        public long4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 1)); }
        public long4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1)); }
        public long4 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 1)); }
        public long4 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 1)); }
        public long4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2)); }
        public long4 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public long4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 1)); }
        public long4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 1)); }
        public long4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 1)); }
        public long4 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public long4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 1)); }
        public long4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 1)); }
        public long4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 1)); }
        public long4 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public long4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 1)); }
        public long4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 1)); }
        public long4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 1)); }
        public long4 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public long4 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 1)); }
        public long4 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 1)); }
        public long4 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 1)); }
        public long4 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public long4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public long4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 1)); }
        public long4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 1)); }
        public long4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1)); }
        public long4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 1)); }
        public long4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 1)); }
        public long4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 1)); }
        public long4 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public long4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 1)); }
        public long4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 1)); }
        public long4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 1)); }
        public long4 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public long4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 1)); }
        public long4 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 1)); }
        public long4 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 1)); }
        public long4 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1)); }
        public long4 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 1)); }
        public long4 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 1)); }
        public long4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 1)); }
        public long4 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 1)); }
        public long4 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 1)); }
        public long4 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 1)); }
        public long4 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 1)); }
        public long4 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 1)); }
        public long4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 1)); }
        public long4 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 1)); }
        public long4 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 1)); }
        public long4 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 1)); }
        public long4 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 1)); }
        public long4 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 1)); }
        public long4 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 1)); }
        public long4 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1)); }
        public long4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2)); }
        public long4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 2)); }
        public long4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 2)); }
        public long4 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public long4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 2)); }
        public long4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 2)); }
        public long4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 2)); }
        public long4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2)); }
        public long4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 2)); }
        public long4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 2)); }
        public long4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 2)); }
        public long4 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public long4 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 2)); }
        public long4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 2)); }
        public long4 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 2)); }
        public long4 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2)); }
        public long4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 2)); }
        public long4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 2)); }
        public long4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 2)); }
        public long4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2)); }
        public long4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 2)); }
        public long4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 2)); }
        public long4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 2)); }
        public long4 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public long4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 2)); }
        public long4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 2)); }
        public long4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 2)); }
        public long4 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public long4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 2)); }
        public long4 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 2)); }
        public long4 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 2)); }
        public long4 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2)); }
        public long4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 2)); }
        public long4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 2)); }
        public long4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 2)); }
        public long4 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public long4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 2)); }
        public long4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 2)); }
        public long4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 2)); }
        public long4 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public long4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 2)); }
        public long4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 2)); }
        public long4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 2)); }
        public long4 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2)); }
        public long4 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 2)); }
        public long4 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 2)); }
        public long4 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 2)); }
        public long4 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        public long4 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public long4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 2)); }
        public long4 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 2)); }
        public long4 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 2)); }
        public long4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 2)); }
        public long4 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 2)); }
        public long4 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 2)); }
        public long4 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 2)); }
        public long4 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 2)); }
        public long4 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 2)); }
        public long4 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 2)); }
        public long4 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public long4 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 2)); }
        public long4 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 2)); }
        public long4 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 2)); }
        public long4 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 2)); }
        public long4 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)); }
        public long4 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 3)); }
        public long4 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 3)); }
        public long4 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 3)); }
        public long4 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 3)); }
        public long4 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 3)); }
        public long4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 3)); }
        public long4 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 3)); }
        public long4 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 3)); }
        public long4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 3)); }
        public long4 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 3)); }
        public long4 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 3)); }
        public long4 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 3)); }
        public long4 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 3)); }
        public long4 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 3)); }
        public long4 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3)); }
        public long4 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 3)); }
        public long4 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 3)); }
        public long4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 3)); }
        public long4 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 3)); }
        public long4 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 3)); }
        public long4 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 3)); }
        public long4 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 3)); }
        public long4 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 3)); }
        public long4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 3)); }
        public long4 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 3)); }
        public long4 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 3)); }
        public long4 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 3)); }
        public long4 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 3)); }
        public long4 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 3)); }
        public long4 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 3)); }
        public long4 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3)); }
        public long4 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 3)); }
        public long4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 3)); }
        public long4 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 3)); }
        public long4 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 3)); }
        public long4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 3)); }
        public long4 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 3)); }
        public long4 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 3)); }
        public long4 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 3)); }
        public long4 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 3)); }
        public long4 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 3)); }
        public long4 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 3)); }
        public long4 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 3)); }
        public long4 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 3)); }
        public long4 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 3)); }
        public long4 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 3)); }
        public long4 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3)); }
        public long4 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 3)); }
        public long4 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 3)); }
        public long4 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 3)); }
        public long4 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 3)); }
        public long4 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 3)); }
        public long4 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 3)); }
        public long4 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 3)); }
        public long4 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 3)); }
        public long4 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 3)); }
        public long4 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 3)); }
        public long4 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 3)); }
        public long4 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 3)); }
        public long4 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 3)); }
        public long4 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 3)); }
        public long4 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 3)); }
        public long4 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3)); }

        public long3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this)); }
        public long3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public long3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public long3 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 0)); }
        public long3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 0)); }                  
        public long3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public long3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v256)this; }                        
        public long3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 0)); }
        public long3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public long3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0)); }
        public long3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public long3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0)); }
        public long3 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 0)); }
        public long3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 0)); }
        public long3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 0)); }
        public long3 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0)); }
        public long3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public long3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public long3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1)); }
        public long3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2)); }
        public long3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public long3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public long3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public long3 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public long3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1)); }
        public long3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public long3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public long3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1)); }       
        public long3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 1)); }
        public long3 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 1)); }
        public long3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 1)); }
        public long3 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1)); }
        public long3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public long3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2)); }
        public long3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public long3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2)); }
        public long3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2)); }
        public long3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public long3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public long3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2)); }
        public long3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public long3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public long3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2)); }
        public long3 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        public long3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 2)); }
        public long3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 2)); }
        public long3 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 2)); }                       
        public long3 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 2)); }
        public long3 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 3)); }
        public long3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 3)); }
        public long3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 3)); }
        public long3 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3)); }
        public long3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 3)); }
        public long3 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 3)); }
        public long3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 3)); }
        public long3 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3)); }
        public long3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 3)); }
        public long3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 3)); }
        public long3 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 3)); }
        public long3 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3)); }
        public long3 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 3)); }
        public long3 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 3)); }
        public long3 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 3)); }
        public long3 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3)); }

        public long2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0))); }
        public long2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(this); }
        public long2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0))); }
        public long2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0))); }
        public long2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2))); }
        public long2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2))); }
        public long2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1))); }
        public long2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1))); }
        public long2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2))); }
        public long2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2))); }
        public long2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2))); }    
        public long2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_extracti128_si256(this, 1); }                     
        public long2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3))); }
        public long2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3))); }
        public long2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3))); }    
        public long2 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3))); }    
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx2.mm256_stream_load_si256(void* ptr)   Avx.mm256_load_si256(void* ptr)
        public static implicit operator v256(long4 input) => new v256(input.x, input.y, input.z, input.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx.mm256_storeu_si256(void* ptr, v128 x)
        public static implicit operator long4(v256 input) => new long4 { x = input.SLong0, y = input.SLong1, z = input.SLong2, w = input.SLong3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(long input) => new long4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(ulong4 input) => (v256)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(uint4 input) => Avx2.mm256_cvtepu32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(int4 input) => Avx2.mm256_cvtepi32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(half4 input) => (long4)(int4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(float4 input) => new long4((long)input.x, (long)input.y, (long)input.z, (long)input.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long4(double4 input) => new long4((long)input.x, (long)input.y, (long)input.z, (long)input.w);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(long4 input) { v128 t = Cast.Long4ToInt4(input); return *(uint4*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(long4 input) { v128 t = Cast.Long4ToInt4(input); return *(int4*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(long4 input) => (half4)(float4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(long4 input) => new float4((float)input.x, (float)input.y, (float)input.z, (float)input.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(long4 input) => new double4((double)input.x, (double)input.y, (double)input.z, (double)input.w);


        
        


        public long this[[AssumeRange(0, 3)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    return ((long*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    ((long*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator + (long4 lhs, long4 rhs) => Avx2.mm256_add_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 lhs, long4 rhs) => Avx2.mm256_sub_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator * (long4 lhs, long4 rhs) => new long4(lhs.x * rhs.x,    lhs.y * rhs.y,    lhs.z * rhs.z,    lhs.w * rhs.w);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator / (long4 lhs, long4 rhs) => new long4(lhs.x / rhs.x,    lhs.y / rhs.y,    lhs.z / rhs.z,    lhs.w / rhs.w);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator % (long4 lhs, long4 rhs) => new long4(lhs.x % rhs.x,    lhs.y % rhs.y,    lhs.z % rhs.z,    lhs.w % rhs.w);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator & (long4 lhs, long4 rhs) => Avx2.mm256_and_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator | (long4 lhs, long4 rhs) => Avx2.mm256_or_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ^ (long4 lhs, long4 rhs) => Avx2.mm256_xor_si256(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator - (long4 x) => Avx2.mm256_sub_epi64(default(v256), x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ++ (long4 x) => Avx2.mm256_add_epi64(x, new v256(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator -- (long4 x) => Avx2.mm256_sub_epi64(x, new v256(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator ~ (long4 x) => Avx2.mm256_andnot_si256(x, new v256(-1L));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator << (long4 x, int n) => Operator.shl_long(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 operator >> (long4 x, int n) => Operator.shra_long(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (long4 lhs, long4 rhs) => TestIsTrue(Avx2.mm256_cmpeq_epi64(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (long4 lhs, long4 rhs) => TestIsTrue(Avx2.mm256_cmpgt_epi64(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (long4 lhs, long4 rhs) => TestIsTrue(Avx2.mm256_cmpgt_epi64(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (long4 lhs, long4 rhs) => TestIsFalse(Avx2.mm256_cmpeq_epi64(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (long4 lhs, long4 rhs) => TestIsFalse(Avx2.mm256_cmpgt_epi64(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (long4 lhs, long4 rhs) => TestIsFalse(Avx2.mm256_cmpgt_epi64(rhs, lhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsTrue(v256 input)
        {
            int cast = 0x0101_0101 & Avx2.mm256_movemask_epi8(input);
    
            return *(bool4*)&cast;
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsFalse(v256 input)
        {
            int cast = maxmath.andn(0x0101_0101, Avx2.mm256_movemask_epi8(input));
    
            return *(bool4*)&cast;
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(long4 other) => maxmath.cvt_boolean(Avx.mm256_testc_si256(Avx2.mm256_cmpeq_epi64(this, other), new v256(-1)));

        public override bool Equals(object obj) => Equals((long4)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash._256bit(this);


        public override string ToString() => $"long4({x}, {y}, {z}, {w})";
    }
}