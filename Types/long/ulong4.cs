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
    unsafe public struct ulong4 : IEquatable<ulong4>
    {
        [NoAlias] public ulong x;
        [NoAlias] public ulong y;
        [NoAlias] public ulong z;
        [NoAlias] public ulong w;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x,      ulong y,       ulong z,       ulong w)
        {
            this = Avx.mm256_set_epi64x((long)w, (long)z, (long)y, (long)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong xyzw)
        {
            this = Avx.mm256_set1_epi64x((long)xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong2 xy, ulong z, ulong w)
        {
            this = Avx.mm256_set_m128i(new long2((long)z, (long)w), xy);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong2 yz, ulong w)
        {
            this = Avx.mm256_set_epi64x((long)w, (long)yz.y, (long)yz.x, (long)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong y, ulong2 zw)
        {
            this = Avx.mm256_set_m128i(zw, new ulong2(x, y));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong2 xy, ulong2 zw)
        {
            this = Avx.mm256_set_m128i(zw, xy);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong3 xyz, ulong w)
        {
            this = Avx.mm256_insert_epi64(xyz, (long)w, 3);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong3 yzw)
        {
            this = Avx.mm256_insert_epi64(yzw.xxyz, (long)x, 0);
        }


        #region Shuffle
        public ulong4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this)); }
        public ulong4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 0)); }
        public ulong4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 0)); }
        public ulong4 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 0)); }
        public ulong4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 0)); }
        public ulong4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 0)); }
        public ulong4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 0)); }
        public ulong4 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public ulong4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 0)); }
        public ulong4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 0)); }
        public ulong4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public ulong4 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 0)); }
        public ulong4 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 0)); }
        public ulong4 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 0)); }
        public ulong4 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 0)); }
        public ulong4 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 0)); }
        public ulong4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 0)); }
        public ulong4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public ulong4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 0)); }
        public ulong4 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 0)); }
        public ulong4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 0)); }
        public ulong4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 0)); }
        public ulong4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 0)); }
        public ulong4 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public ulong4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 0)); }
        public ulong4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 0)); }
        public ulong4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 0)); }
        public ulong4 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 0)); }
        public ulong4 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 0)); }
        public ulong4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 0)); }
        public ulong4 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 0)); }
        public ulong4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 0)); }
        public ulong4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 0)); }
        public ulong4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 0)); }
        public ulong4 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public ulong4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 0)); }
        public ulong4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 0)); }
        public ulong4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 0)); }
        public ulong4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0)); }
        public ulong4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 0)); }
        public ulong4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 0)); }
        public ulong4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 0)); }
        public ulong4 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public ulong4 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 0)); }
        public ulong4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 0)); }
        public ulong4 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 0)); }
        public ulong4 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0)); }
        public ulong4 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 0)); }
        public ulong4 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 0)); }
        public ulong4 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 0)); }
        public ulong4 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 0)); }
        public ulong4 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 0)); }
        public ulong4 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 0)); }
        public ulong4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 0)); }
        public ulong4 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 0)); }
        public ulong4 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 0)); }
        public ulong4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 0)); }
        public ulong4 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 0)); }
        public ulong4 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 0)); }
        public ulong4 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 0)); }
        public ulong4 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 0)); }
        public ulong4 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 0)); }
        public ulong4 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0)); }
        public ulong4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 1)); }
        public ulong4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 1)); }
        public ulong4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 1)); }
        public ulong4 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public ulong4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 1)); }
        public ulong4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 1)); }
        public ulong4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 1)); }
        public ulong4 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public ulong4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 1)); }
        public ulong4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 1)); }
        public ulong4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 1)); }
        public ulong4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1)); }
        public ulong4 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 1)); }
        public ulong4 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 1)); }
        public ulong4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2)); }
        public ulong4 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public ulong4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 1)); }
        public ulong4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 1)); }
        public ulong4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 1)); }
        public ulong4 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public ulong4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 1)); }
        public ulong4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 1)); }
        public ulong4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 1)); }
        public ulong4 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public ulong4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 1)); }
        public ulong4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 1)); }
        public ulong4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 1)); }
        public ulong4 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public ulong4 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 1)); }
        public ulong4 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 1)); }
        public ulong4 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 1)); }
        public ulong4 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public ulong4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public ulong4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 1)); }
        public ulong4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 1)); }
        public ulong4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1)); }
        public ulong4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 1)); }
        public ulong4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 1)); }
        public ulong4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 1)); }
        public ulong4 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public ulong4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 1)); }
        public ulong4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 1)); }
        public ulong4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 1)); }
        public ulong4 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public ulong4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 1)); }
        public ulong4 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 1)); }
        public ulong4 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 1)); }
        public ulong4 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1)); }
        public ulong4 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 1)); }
        public ulong4 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 1)); }
        public ulong4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 1)); }
        public ulong4 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 1)); }
        public ulong4 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 1)); }
        public ulong4 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 1)); }
        public ulong4 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 1)); }
        public ulong4 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 1)); }
        public ulong4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 1)); }
        public ulong4 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 1)); }
        public ulong4 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 1)); }
        public ulong4 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 1)); }
        public ulong4 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 1)); }
        public ulong4 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 1)); }
        public ulong4 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 1)); }
        public ulong4 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1)); }
        public ulong4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2)); }
        public ulong4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 2)); }
        public ulong4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 2)); }
        public ulong4 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public ulong4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 2)); }
        public ulong4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 2)); }
        public ulong4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 2)); }
        public ulong4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2)); }
        public ulong4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 2)); }
        public ulong4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 2)); }
        public ulong4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 2)); }
        public ulong4 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public ulong4 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 2)); }
        public ulong4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 2)); }
        public ulong4 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 2)); }
        public ulong4 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2)); }
        public ulong4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 2)); }
        public ulong4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 2)); }
        public ulong4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 2)); }
        public ulong4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2)); }
        public ulong4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 2)); }
        public ulong4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 2)); }
        public ulong4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 2)); }
        public ulong4 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public ulong4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 2)); }
        public ulong4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 2)); }
        public ulong4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 2)); }
        public ulong4 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public ulong4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 2)); }
        public ulong4 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 2)); }
        public ulong4 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 2)); }
        public ulong4 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2)); }
        public ulong4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 2)); }
        public ulong4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 2)); }
        public ulong4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 2)); }
        public ulong4 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public ulong4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 2)); }
        public ulong4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 2)); }
        public ulong4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 2)); }
        public ulong4 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public ulong4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 2)); }
        public ulong4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 2)); }
        public ulong4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 2)); }
        public ulong4 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2)); }
        public ulong4 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 2)); }
        public ulong4 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 2)); }
        public ulong4 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 2)); }
        public ulong4 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        public ulong4 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2)); }
        public ulong4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 2)); }
        public ulong4 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 2)); }
        public ulong4 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 2)); }
        public ulong4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 2)); }
        public ulong4 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 2)); }
        public ulong4 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 2)); }
        public ulong4 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 2)); }
        public ulong4 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 2)); }
        public ulong4 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 2)); }
        public ulong4 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 2)); }
        public ulong4 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public ulong4 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 2)); }
        public ulong4 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 2)); }
        public ulong4 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 2)); }
        public ulong4 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 2)); }
        public ulong4 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)); }
        public ulong4 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 3)); }
        public ulong4 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 3)); }
        public ulong4 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 3)); }
        public ulong4 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 3)); }
        public ulong4 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 3)); }
        public ulong4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 3)); }
        public ulong4 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 3)); }
        public ulong4 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 3)); }
        public ulong4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 3)); }
        public ulong4 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 3)); }
        public ulong4 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 3)); }
        public ulong4 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 3)); }
        public ulong4 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 3)); }
        public ulong4 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 3)); }
        public ulong4 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3)); }
        public ulong4 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 3)); }
        public ulong4 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 3)); }
        public ulong4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 3)); }
        public ulong4 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 3)); }
        public ulong4 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 3)); }
        public ulong4 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 3)); }
        public ulong4 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 3)); }
        public ulong4 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 3)); }
        public ulong4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 3)); }
        public ulong4 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 3)); }
        public ulong4 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 3)); }
        public ulong4 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 3)); }
        public ulong4 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 3)); }
        public ulong4 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 3)); }
        public ulong4 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 3)); }
        public ulong4 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3)); }
        public ulong4 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 3)); }
        public ulong4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 3)); }
        public ulong4 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 3)); }
        public ulong4 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 3)); }
        public ulong4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 3)); }
        public ulong4 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 3)); }
        public ulong4 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 3)); }
        public ulong4 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 3)); }
        public ulong4 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 3)); }
        public ulong4 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 3)); }
        public ulong4 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 3)); }
        public ulong4 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 3)); }
        public ulong4 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 3)); }
        public ulong4 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 3)); }
        public ulong4 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 3)); }
        public ulong4 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3)); }
        public ulong4 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 3)); }
        public ulong4 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 3)); }
        public ulong4 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 3)); }
        public ulong4 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 3)); }
        public ulong4 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 3)); }
        public ulong4 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 3)); }
        public ulong4 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 3)); }
        public ulong4 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 3)); }
        public ulong4 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 3)); }
        public ulong4 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 3)); }
        public ulong4 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 3)); }
        public ulong4 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 3)); }
        public ulong4 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 3)); }
        public ulong4 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 3)); }
        public ulong4 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 3)); }
        public ulong4 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3)); }
               
        public ulong3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this)); }
        public ulong3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public ulong3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public ulong3 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 0)); }
        public ulong3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 0)); }
        public ulong3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public ulong3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v256)this; }
        public ulong3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 0)); }
        public ulong3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public ulong3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0)); }
        public ulong3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public ulong3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0)); }
        public ulong3 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 0)); }
        public ulong3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 0)); }
        public ulong3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 0)); }
        public ulong3 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0)); }
        public ulong3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public ulong3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public ulong3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1)); }
        public ulong3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2)); }
        public ulong3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public ulong3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public ulong3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public ulong3 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public ulong3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1)); }
        public ulong3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public ulong3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public ulong3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1)); }
        public ulong3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 1)); }
        public ulong3 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 1)); }
        public ulong3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 1)); }
        public ulong3 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1)); }
        public ulong3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public ulong3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2)); }
        public ulong3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public ulong3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2)); }
        public ulong3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2)); }
        public ulong3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public ulong3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public ulong3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2)); }
        public ulong3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public ulong3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public ulong3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2)); }
        public ulong3 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        public ulong3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 2)); }
        public ulong3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 2)); }
        public ulong3 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 2)); }
        public ulong3 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 2)); }
        public ulong3 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 3)); }
        public ulong3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 3)); }
        public ulong3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 3)); }
        public ulong3 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3)); }
        public ulong3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 3)); }
        public ulong3 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 3)); }
        public ulong3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 3)); }
        public ulong3 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3)); }
        public ulong3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 3)); }
        public ulong3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 3)); }
        public ulong3 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 3)); }
        public ulong3 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3)); }
        public ulong3 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 3)); }
        public ulong3 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 3)); }
        public ulong3 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 3)); }
        public ulong3 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3)); }
               
        public ulong2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0))); }
        public ulong2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(this); }
        public ulong2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0))); }
        public ulong2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0))); }
        public ulong2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2))); }
        public ulong2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2))); }
        public ulong2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1))); }
        public ulong2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1))); }
        public ulong2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2))); }
        public ulong2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2))); }
        public ulong2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2))); }
        public ulong2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_extracti128_si256(this, 1); }
        public ulong2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3))); }
        public ulong2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3))); }
        public ulong2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3))); }
        public ulong2 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3))); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx2.mm256_stream_load_si256(void* ptr)   Avx.mm256_load_si256(void* ptr)
        public static implicit operator v256(ulong4 input) => new v256(input.x, input.y, input.z, input.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx.mm256_storeu_si256(void* ptr, v128 x)
        public static implicit operator ulong4(v256 input) => new ulong4 { x = input.ULong0, y = input.ULong1, z = input.ULong2, w = input.ULong3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(ulong input) => new ulong4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(long4 input) => (v256)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(uint4 input) => Avx2.mm256_cvtepu32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(int4 input) => Avx2.mm256_cvtepi32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(half4 input) => (ulong4)(int4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(float4 input) => new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(double4 input) => new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(ulong4 input) { v128 t = Cast.Long4ToInt4(input); return *(uint4*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(ulong4 input) { v128 t = Cast.Long4ToInt4(input); return *(int4*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(ulong4 input) => (half4)(float4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(ulong4 input) => new float4((float)input.x, (float)input.y, (float)input.z, (float)input.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(ulong4 input) => new double4((double)input.x, (double)input.y, (double)input.z, (double)input.w);


        public ulong this[[AssumeRange(0, 3)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    return ((ulong*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    ((ulong*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator + (ulong4 lhs, ulong4 rhs) => Avx2.mm256_add_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 lhs, ulong4 rhs) => Avx2.mm256_sub_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 lhs, ulong4 rhs) => new ulong4(lhs.x * rhs.x,    lhs.y * rhs.y,    lhs.z * rhs.z,    lhs.w * rhs.w);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 lhs, ulong4 rhs) => new ulong4(lhs.x / rhs.x,    lhs.y / rhs.y,    lhs.z / rhs.z,    lhs.w / rhs.w);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 lhs, ulong4 rhs) => new ulong4(lhs.x % rhs.x,    lhs.y % rhs.y,    lhs.z % rhs.z,    lhs.w % rhs.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 lhs, ulong rhs) => Operator.div(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 lhs, ulong rhs) => Operator.rem(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 lhs, ulong4 rhs) => Avx2.mm256_and_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 lhs, ulong4 rhs) => Avx2.mm256_or_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 lhs, ulong4 rhs) => Avx2.mm256_xor_si256(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ++ (ulong4 x) => Avx2.mm256_add_epi64(x, new v256(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator -- (ulong4 x) => Avx2.mm256_sub_epi64(x, new v256(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ~ (ulong4 x) => Avx2.mm256_andnot_si256(x, new v256(-1L));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator << (ulong4 x, int n) => Operator.shl_long(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator >> (ulong4 x, int n) => Operator.shrl_long(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (ulong4 lhs, ulong4 rhs) => TestIsTrue(Avx2.mm256_cmpeq_epi64(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]      
        public static bool4 operator < (ulong4 lhs, ulong4 rhs) => TestIsTrue(Operator.greater_mask_ulong(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]        
        public static bool4 operator > (ulong4 lhs, ulong4 rhs) => TestIsTrue(Operator.greater_mask_ulong(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (ulong4 lhs, ulong4 rhs) => TestIsFalse(Avx2.mm256_cmpeq_epi64(lhs, rhs));
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]        
        public static bool4 operator <= (ulong4 lhs, ulong4 rhs) => TestIsFalse(Operator.greater_mask_ulong(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]        
        public static bool4 operator >= (ulong4 lhs, ulong4 rhs) => TestIsFalse(Operator.greater_mask_ulong(rhs, lhs));


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
        public bool Equals(ulong4 other) => maxmath.cvt_boolean(Avx.mm256_testc_si256(Avx2.mm256_cmpeq_epi64(this, other), new v256(-1)));

        public override bool Equals(object obj) => Equals((ulong4)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v256(this);
    

        public override string ToString() => $"ulong4({x}, {y}, {z}, {w})";
    }
}