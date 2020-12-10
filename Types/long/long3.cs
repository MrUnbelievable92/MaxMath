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
    unsafe public struct long3 : IEquatable<long3>
    {
        [NoAlias] public long x;
        [NoAlias] public long y;
        [NoAlias] public long z;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long x,      long y,       long z)
        {
            this = Avx.mm256_set_epi64x(0L, z, y, x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long xyz)
        {
            this = Avx.mm256_set1_epi64x(xyz);
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long2 xy, long z)
        {
            this = Avx.mm256_insert_epi64(Avx.mm256_castsi128_si256(xy), z, 2);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public long3(long x, long2 yz)
        {
            this = Avx.mm256_insert_epi64(yz.xxy, x, 0);
        }


        #region Shuffle
        public long4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this)); }
        public long4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 0)); }
        public long4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 0)); }
        public long4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 0)); }
        public long4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 0)); }
        public long4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 0)); }
        public long4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 0)); }
        public long4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 0)); }
        public long4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public long4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 0)); }
        public long4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastsi128_si256(Avx.mm256_castsi256_si128(this)); }
        public long4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 0)); }
        public long4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 0)); }
        public long4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 0)); }
        public long4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 0)); }
        public long4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 0)); }
        public long4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 0)); }
        public long4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 0)); }
        public long4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 0)); }
        public long4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 0)); }
        public long4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 0)); }
        public long4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 0)); }
        public long4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 0)); }
        public long4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 0)); }
        public long4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 0)); }
        public long4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 0)); }
        public long4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 0)); }
        public long4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 1)); }
        public long4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 1)); }
        public long4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 1)); }
        public long4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 1)); }
        public long4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 1)); }
        public long4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 1)); }
        public long4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 1)); }
        public long4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 1)); }
        public long4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 1)); }
        public long4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 1)); }
        public long4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 1)); }
        public long4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 1)); }
        public long4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 1)); }
        public long4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 1)); }
        public long4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 1)); }
        public long4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 1)); }
        public long4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 1)); }
        public long4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 1)); }
        public long4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public long4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 1)); }
        public long4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 1)); }
        public long4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 1)); }
        public long4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 1)); }
        public long4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 1)); }
        public long4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 1)); }
        public long4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 1)); }
        public long4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 1)); }
        public long4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2)); }
        public long4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 2)); }
        public long4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 2)); }
        public long4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 2)); }
        public long4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 2)); }
        public long4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 2)); }
        public long4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 2)); }
        public long4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 2)); }
        public long4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 2)); }
        public long4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 2)); }
        public long4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 2)); }
        public long4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 2)); }
        public long4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 2)); }
        public long4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 2)); }
        public long4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 2)); }
        public long4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 2)); }
        public long4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 2)); }
        public long4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 2)); }
        public long4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 2)); }
        public long4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 2)); }
        public long4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 2)); }
        public long4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 2)); }
        public long4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 2)); }
        public long4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 2)); }
        public long4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 2)); }
        public long4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 2)); }
        public long4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 2)); }

        public long3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this)); }
        public long3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public long3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0)); }
        public long3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_broadcastsi128_si256(Avx.mm256_castsi256_si128(this)); }
        public long3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public long3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public long3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0)); }
        public long3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public long3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public long3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public long3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1)); }
        public long3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public long3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public long3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public long3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1)); }
        public long3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public long3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public long3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public long3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2)); }
        public long3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public long3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2)); }
        public long3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public long3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public long3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public long3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public long3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2)); }

        public long2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0))); }
        public long2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(this); }
        public long2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0))); }
        public long2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2))); }
        public long2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2))); }
        public long2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1))); }
        public long2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2))); }
        public long2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2))); }
        public long2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2))); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx2.mm256_stream_load_si256(void* ptr)   Avx.mm256_load_si256(void* ptr)
        public static implicit operator v256(long3 input) => new v256(input.x, input.y, input.z, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx.mm256_storeu_si256(void* ptr, v128 x)
        public static implicit operator long3(v256 input) => new long3 { x = input.SLong0, y = input.SLong1, z = input.SLong2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(long input) => new long3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(ulong3 input) => (v256)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(uint3 input) => Avx2.mm256_cvtepu32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(int3 input) => Avx2.mm256_cvtepi32_epi64(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(half3 input) => (long3)(int3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(float3 input) => new long3((long)input.x, (long)input.y, (long)input.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator long3(double3 input) => new long3((long)input.x, (long)input.y, (long)input.z);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(long3 input) { v128 t = Cast.Long4ToInt4(input); return *(uint3*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(long3 input) { v128 t = Cast.Long4ToInt4(input); return *(int3*)&t; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(long3 input) => (half3)(float3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(long3 input) => new float3((float)input.x, (float)input.y, (float)input.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(long3 input) => new double3((double)input.x, (double)input.y, (double)input.z);
    

        public long this[[AssumeRange(0, 2)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    return ((long*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    ((long*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator + (long3 lhs, long3 rhs) => Avx2.mm256_add_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 lhs, long3 rhs) => Avx2.mm256_sub_epi64(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator * (long3 lhs, long3 rhs) => new long3(lhs.x * rhs.x,    lhs.y * rhs.y,    lhs.z * rhs.z);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator / (long3 lhs, long3 rhs) => new long3(lhs.x / rhs.x,    lhs.y / rhs.y,    lhs.z / rhs.z);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator % (long3 lhs, long3 rhs) => new long3(lhs.x % rhs.x,    lhs.y % rhs.y,    lhs.z % rhs.z);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator & (long3 lhs, long3 rhs) => Avx2.mm256_and_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator | (long3 lhs, long3 rhs) => Avx2.mm256_or_si256(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ^ (long3 lhs, long3 rhs) => Avx2.mm256_xor_si256(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator - (long3 x) => Avx2.mm256_sub_epi64(default(v256), x);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ++ (long3 x) => Avx2.mm256_add_epi64(x, new v256(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator -- (long3 x) => Avx2.mm256_sub_epi64(x, new v256(1L));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator ~ (long3 x) => Avx2.mm256_andnot_si256(x, new v256(-1L));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator << (long3 x, int n) => Operator.shl_long(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 operator >> (long3 x, int n) => Operator.shra_long(x, n);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (long3 lhs, long3 rhs) => TestIsTrue(Avx2.mm256_cmpeq_epi64(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (long3 lhs, long3 rhs) => TestIsTrue(Avx2.mm256_cmpgt_epi64(rhs, lhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (long3 lhs, long3 rhs) => TestIsTrue(Avx2.mm256_cmpgt_epi64(lhs, rhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (long3 lhs, long3 rhs) => TestIsFalse(Avx2.mm256_cmpeq_epi64(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (long3 lhs, long3 rhs) => TestIsFalse(Avx2.mm256_cmpgt_epi64(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (long3 lhs, long3 rhs) => TestIsFalse(Avx2.mm256_cmpgt_epi64(rhs, lhs));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsTrue(v256 input)
        {
            int cast = 0x0001_0101 & Avx2.mm256_movemask_epi8(input);

            return *(bool3*)&cast;
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsFalse(v256 input) 
        {
            int cast = maxmath.andn(0x0001_0101, Avx2.mm256_movemask_epi8(input));

            return *(bool3*)&cast;
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(long3 other) => maxmath.cvt_boolean(Avx.mm256_testc_si256(Avx2.mm256_cmpeq_epi64(this, other), new v256(-1L, -1L, -1L, 0L)));

        public override bool Equals(object obj) => Equals((long3)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => ((Hash._128bit(this.xy) << 32) | z.GetHashCode()).GetHashCode();


        public override string ToString() => $"long3({x}, {y}, {z})";
    }
}