using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Burst;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Sequential, Size = 6)]
    unsafe public struct ushort3 : IEquatable<ushort3>, IFormattable
    {
        [NoAlias] public ushort x;
        [NoAlias] public ushort y;
        [NoAlias] public ushort z;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort x, ushort y, ushort z)
        {
            this = Sse2.set_epi16(0, 0, 0, 0, 0, (short)z, (short)y, (short)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort xyz)
        {
            this = Sse2.set1_epi16((short)xyz);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort2 xy, ushort z)
        {
            this = Sse2.insert_epi16(xy, z, 2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort x, ushort2 yz)
        {
            this = Sse2.insert_epi16(Sse2.bslli_si128(yz, sizeof(ushort)), x, 0);
        }


        #region Shuffle
        public ushort8 xxxxxxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort8 yyyyyyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3,   2, 3,   2, 3,   2, 3,   2, 3,   2, 3,   2, 3,   2, 3)); }
        public ushort8 zzzzzzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(4, 5,   4, 5,   4, 5,   4, 5,   4, 5,   4, 5,   4, 5,   4, 5)); }

        public ushort4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0)); }
        public ushort4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 0)); }
        public ushort4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0)); }
        public ushort4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0)); }
        public ushort4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 0)); }
        public ushort4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 0)); }
        public ushort4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 0)); }
        public ushort4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 0)); }
        public ushort4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0)); }
        public ushort4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }
        public ushort4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 0)); }
        public ushort4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0)); }
        public ushort4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0)); }
        public ushort4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 0)); }
        public ushort4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 0)); }
        public ushort4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 0)); }
        public ushort4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 0)); }
        public ushort4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 0)); }
        public ushort4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 0)); }
        public ushort4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 0)); }
        public ushort4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 0)); }
        public ushort4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 0)); }
        public ushort4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 0)); }
        public ushort4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 0)); }
        public ushort4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 0)); }
        public ushort4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 0)); }
        public ushort4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1)); }
        public ushort4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1)); }
        public ushort4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 1)); }
        public ushort4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1)); }
        public ushort4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1)); }
        public ushort4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 1)); }
        public ushort4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 1)); }
        public ushort4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 1)); }
        public ushort4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 1)); }
        public ushort4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1)); }
        public ushort4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1)); }
        public ushort4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 1)); }
        public ushort4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1)); }
        public ushort4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1)); }
        public ushort4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 1)); }
        public ushort4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 1)); }
        public ushort4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 1)); }
        public ushort4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 1)); }
        public ushort4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1)); }
        public ushort4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 1)); }
        public ushort4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 1)); }
        public ushort4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 1)); }
        public ushort4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 1)); }
        public ushort4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 1)); }
        public ushort4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 1)); }
        public ushort4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 1)); }
        public ushort4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 1)); }
        public ushort4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 2)); }
        public ushort4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 2)); }
        public ushort4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 2)); }
        public ushort4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 2)); }
        public ushort4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 2)); }
        public ushort4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 2)); }
        public ushort4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 2)); }
        public ushort4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 2)); }
        public ushort4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 2)); }
        public ushort4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 2)); }
        public ushort4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 2)); }
        public ushort4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 2)); }
        public ushort4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 2)); }
        public ushort4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 2)); }
        public ushort4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 2)); }
        public ushort4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 2)); }
        public ushort4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 2)); }
        public ushort4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 2)); }
        public ushort4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 2)); }
        public ushort4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 2)); }
        public ushort4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 2)); }
        public ushort4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 2)); }
        public ushort4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 2)); }
        public ushort4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 2)); }
        public ushort4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 2)); }
        public ushort4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 2)); }
        public ushort4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 2)); }

        public ushort3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0)); }
        public ushort3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0)); }
        public ushort3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastd_epi32(this); }                  
        public ushort3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0)); }
        public ushort3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0)); }
        public ushort3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0)); }
        public ushort3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0)); }
        public ushort3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1)); }
        public ushort3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1)); }
        public ushort3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1)); }
        public ushort3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1)); }
        public ushort3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1)); }
        public ushort3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1)); }
        public ushort3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1)); }
        public ushort3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1)); }
        public ushort3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1)); }
        public ushort3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2)); }
        public ushort3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2)); }
        public ushort3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2)); }
        public ushort3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2)); }
        public ushort3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2)); }
        public ushort3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2)); }
        public ushort3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2)); }
        public ushort3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2)); }
        public ushort3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2)); }

        public ushort2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }
        public ushort2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public ushort2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0)); }
        public ushort2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public ushort2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        public ushort2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 1)); }          
        public ushort2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2)); }
        public ushort2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2)); }
        public ushort2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]   
        public static implicit operator v128(ushort3 input) => Sse2.insert_epi16(Sse4_1.insert_epi32(default(v128), *(int*)&input, 0), input.z, 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static implicit operator ushort3(v128 input) => new ushort3 { x = Sse2.extract_epi16(input, 0), y = Sse2.extract_epi16(input, 1), z = Sse2.extract_epi16(input, 2) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3(ushort input) => new ushort3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(short3 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(int3 input) => Cast.Int4ToShort4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(uint3 input) => Cast.Int4ToShort4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(long3 input) => Cast.Long4ToShort4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(ulong3 input) => Cast.Long4ToShort4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(half3 input) => (ushort3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(float3 input) => (ushort3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(double3 input) => (ushort3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(ushort3 input) { v128 temp = Sse4_1.cvtepu16_epi32(input); return *(int3*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(ushort3 input) { v128 temp = Sse4_1.cvtepu16_epi32(input); return *(uint3*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(ushort3 input) => Avx2.mm256_cvtepu16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(ushort3 input) => Avx2.mm256_cvtepu16_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(ushort3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(ushort3 input) { v128 t = Cast.UShortToFloat(input); return *(float3*)&t; }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(ushort3 input) => (double3)(int3)input;


        public ushort this[[AssumeRange(0, 2)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);
                
                fixed (void* ptr = &this)
                {
                    return ((ushort*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    ((ushort*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator + (ushort3 lhs, ushort3 rhs) => Sse2.add_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (ushort3 lhs, ushort3 rhs) => Sse2.sub_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort3 lhs, ushort3 rhs) => Sse2.mullo_epi16(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 lhs, ushort3 rhs) => new ushort3((ushort)(lhs.x / rhs.x), (ushort)(lhs.y / rhs.y), (ushort)(lhs.z / rhs.z));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 lhs, ushort3 rhs) => new ushort3((ushort)(lhs.x % rhs.x),    (ushort)(lhs.y % rhs.y),    (ushort)(lhs.z % rhs.z));
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort lhs, ushort3 rhs) => rhs * lhs;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort3 lhs, ushort rhs) => (v128)((ushort8)((v128)lhs) * rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 lhs, ushort rhs) => (v128)((ushort8)((v128)lhs) / rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 lhs, ushort rhs) => (v128)((ushort8)((v128)lhs) % rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (ushort3 lhs, ushort3 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (ushort3 lhs, ushort3 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (ushort3 lhs, ushort3 rhs) => Sse2.xor_si128(lhs, rhs);
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ++ (ushort3 x) => Sse2.add_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator -- (ushort3 x) => Sse2.sub_epi16(x, new v128((ushort)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ~ (ushort3 x) => Sse2.andnot_si128(x, new v128((short)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator << (ushort3 x, int n) => Operator.shl_short(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator >> (ushort3 x, int n) => Operator.shrl_short(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (ushort3 lhs, ushort3 rhs) => TestIsTrue(Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (ushort3 lhs, ushort3 rhs) => TestIsTrue(Operator.greater_mask_ushort(rhs, lhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (ushort3 lhs, ushort3 rhs) => TestIsTrue(Operator.greater_mask_ushort(lhs, rhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (ushort3 lhs, ushort3 rhs) => TestIsFalse(Sse2.cmpeq_epi16(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (ushort3 lhs, ushort3 rhs) => TestIsFalse(Operator.greater_mask_ushort(lhs, rhs));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (ushort3 lhs, ushort3 rhs) => TestIsFalse(Operator.greater_mask_ushort(rhs, lhs));


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsTrue(v128 input)
        {
            input = Sse2.and_si128((byte3)(ushort3)input, new v128(0x0101_0101));

            return *(bool3*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsFalse(v128 input) 
        {
            input = Sse2.andnot_si128((byte3)(ushort3)input, new v128(0x0101_0101));

            return *(bool3*)&input;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort3 other) => maxmath.bitmask32(3 * sizeof(short)) == (maxmath.bitmask32(3 * sizeof(short)) & (Sse2.movemask_epi8(Sse2.cmpeq_epi16(this, other))));

        public override bool Equals(object obj) => Equals((ushort3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Hash.v48(this);


        public override string ToString() => $"ushort3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}