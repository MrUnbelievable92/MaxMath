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
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 24)]
    unsafe public struct ulong3 : IEquatable<ulong3>
    {
        [NoAlias] public ulong x;
        [NoAlias] public ulong y;
        [NoAlias] public ulong z;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong x,      ulong y,       ulong z)
        {
            this = Avx.mm256_set_epi64x(0L, (long)z, (long)y, (long)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong xyz)
        {
            this = Avx.mm256_set1_epi64x((long)xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong2 xy, ulong z)
        {
            this = Avx.mm256_insert_epi64(Avx.mm256_castsi128_si256(xy), (long)z, 2);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong x, ulong2 yz)
        {
            this = Avx.mm256_insert_epi64(yz.xxy, (long)x, 0);
        }


        #region Shuffle
        public ulong4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this)); }
        public ulong4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 0)); }
        public ulong4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 0)); }
        public ulong4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 0)); }
        public ulong4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 0)); }
        public ulong4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 0)); }
        public ulong4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 0)); }
        public ulong4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 0)); }
        public ulong4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public ulong4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 0)); }
        public ulong4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastsi128_si256(Avx.mm256_castsi256_si128(this)); }
        public ulong4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 0)); }
        public ulong4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 0)); }
        public ulong4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 0)); }
        public ulong4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 0)); }
        public ulong4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 0)); }
        public ulong4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 0)); }
        public ulong4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 0)); }
        public ulong4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 0)); }
        public ulong4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 0)); }
        public ulong4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 0)); }
        public ulong4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 0)); }
        public ulong4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 0)); }
        public ulong4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 0)); }
        public ulong4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 0)); }
        public ulong4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 0)); }
        public ulong4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 0)); }
        public ulong4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 1)); }
        public ulong4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 1)); }
        public ulong4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 1)); }
        public ulong4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 1)); }
        public ulong4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 1)); }
        public ulong4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 1)); }
        public ulong4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 1)); }
        public ulong4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 1)); }
        public ulong4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 1)); }
        public ulong4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 1)); }
        public ulong4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 1)); }
        public ulong4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 1)); }
        public ulong4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 1)); }
        public ulong4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 1)); }
        public ulong4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 1)); }
        public ulong4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 1)); }
        public ulong4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 1)); }
        public ulong4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 1)); }
        public ulong4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public ulong4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 1)); }
        public ulong4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 1)); }
        public ulong4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 1)); }
        public ulong4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 1)); }
        public ulong4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 1)); }
        public ulong4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 1)); }
        public ulong4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 1)); }
        public ulong4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 1)); }
        public ulong4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2)); }
        public ulong4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 2)); }
        public ulong4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 2)); }
        public ulong4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 2)); }
        public ulong4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 2)); }
        public ulong4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 2)); }
        public ulong4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 2)); }
        public ulong4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 2)); }
        public ulong4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 2)); }
        public ulong4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 2)); }
        public ulong4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 2)); }
        public ulong4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 2)); }
        public ulong4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 2)); }
        public ulong4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 2)); }
        public ulong4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 2)); }
        public ulong4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 2)); }
        public ulong4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 2)); }
        public ulong4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 2)); }
        public ulong4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 2)); }
        public ulong4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 2)); }
        public ulong4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 2)); }
        public ulong4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 2)); }
        public ulong4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 2)); }
        public ulong4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 2)); }
        public ulong4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 2)); }
        public ulong4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 2)); }
        public ulong4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 2)); }
               
        public ulong3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this)); }
        public ulong3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public ulong3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public ulong3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastsi128_si256(Avx.mm256_castsi256_si128(this)); }
        public ulong3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public ulong3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public ulong3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0)); }
        public ulong3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public ulong3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public ulong3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public ulong3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1)); }
        public ulong3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public ulong3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public ulong3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public ulong3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1)); }
        public ulong3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public ulong3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public ulong3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public ulong3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2)); }
        public ulong3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public ulong3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2)); }
        public ulong3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public ulong3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public ulong3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public ulong3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public ulong3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2)); }
               
        public ulong2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0))); }
        public ulong2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(this); }
        public ulong2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0))); }
        public ulong2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2))); }
        public ulong2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2))); }
        public ulong2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1))); }       
        public ulong2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2))); }
        public ulong2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2))); }
        public ulong2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2))); } 
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx2.mm256_stream_load_si256(void* ptr)   Avx.mm256_load_si256(void* ptr)
        public static implicit operator v256(ulong3 input) => new v256(input.x, input.y, input.z, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx.mm256_storeu_si256(void* ptr, v128 x)
        public static implicit operator ulong3(v256 input) => new ulong3 { x = input.ULong0, y = input.ULong1, z = input.ULong2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(ulong input) => new ulong3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(long3 input) => (v256)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(uint3 input) => Avx2.mm256_cvtepu32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(int3 input) => Avx2.mm256_cvtepi32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(half3 input) => (ulong3)(int3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(float3 input) => new ulong3((ulong)input.x, (ulong)input.y, (ulong)input.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(double3 input) => new ulong3((ulong)input.x, (ulong)input.y, (ulong)input.z);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(ulong3 input) { v128 t = Cast.Long4ToInt4(input); return *(uint3*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(ulong3 input) { v128 t = Cast.Long4ToInt4(input); return *(int3*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(ulong3 input) => (half3)(float3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(ulong3 input) => new float3((float)input.x, (float)input.y, (float)input.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(ulong3 input) => new double3((double)input.x, (double)input.y, (double)input.z);


        public ulong this[[AssumeRange(0, 2)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ((ulong*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    ((ulong*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ulong3 lhs, ulong3 rhs) => Avx2.mm256_add_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 lhs, ulong3 rhs) => Avx2.mm256_sub_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 lhs, ulong3 rhs) => new ulong3(lhs.x * rhs.x,    lhs.y * rhs.y,    lhs.z * rhs.z);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 lhs, ulong3 rhs) => new ulong3(lhs.x / rhs.x,    lhs.y / rhs.y,    lhs.z / rhs.z);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 lhs, ulong3 rhs) => new ulong3(lhs.x % rhs.x,    lhs.y % rhs.y,    lhs.z % rhs.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 lhs, ulong rhs) => Operator.div(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 lhs, ulong rhs) => Operator.rem(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 lhs, ulong3 rhs) => Avx2.mm256_and_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 lhs, ulong3 rhs) => Avx2.mm256_or_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 lhs, ulong3 rhs) => Avx2.mm256_xor_si256(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ++ (ulong3 x) => Avx2.mm256_add_epi64(x, new v256(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator -- (ulong3 x) => Avx2.mm256_sub_epi64(x, new v256(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ~ (ulong3 x) => Avx2.mm256_andnot_si256(x, new v256(-1L));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator << (ulong3 x, int n) => Operator.shl_long(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator >> (ulong3 x, int n) => Operator.shrl_long(x, n);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (ulong3 lhs, ulong3 rhs) => TestIsTrue(Avx2.mm256_cmpeq_epi64(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <(ulong3 lhs, ulong3 rhs) => TestIsTrue(Operator.greater_mask_ulong(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]        
        public static bool3 operator > (ulong3 lhs, ulong3 rhs) => TestIsTrue(Operator.greater_mask_ulong(lhs, rhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (ulong3 lhs, ulong3 rhs) => TestIsFalse(Avx2.mm256_cmpeq_epi64(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]        
        public static bool3 operator <= (ulong3 lhs, ulong3 rhs) => TestIsFalse(Operator.greater_mask_ulong(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]      
        public static bool3 operator >= (ulong3 lhs, ulong3 rhs) => TestIsFalse(Operator.greater_mask_ulong(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsTrue(v256 input)
        {
            int cast = 0x0001_0101 & Avx2.mm256_movemask_epi8(input);

            return *(bool3*)&cast;
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsFalse(v256 input)
        {
            int cast = maxmath.andnot(0x0001_0101, Avx2.mm256_movemask_epi8(input));

            return *(bool3*)&cast;
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong3 other) => maxmath.tobool(Avx.mm256_testc_si256(Avx2.mm256_cmpeq_epi64(this, other), new v256(-1L, -1L, -1L, 0L)));

        public override bool Equals(object obj) => Equals((ulong3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v192(this);


        public override string ToString() => $"ulong3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}