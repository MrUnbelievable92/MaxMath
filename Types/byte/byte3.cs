using DevTools;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using Unity.Burst;

namespace MaxMath
{
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 3)]
    unsafe public struct byte3 : IEquatable<byte3>
    {
        [NoAlias] [FieldOffset(0)] public byte x;
        [NoAlias] [FieldOffset(1)] public byte y;
        [NoAlias] [FieldOffset(2)] public byte z;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte x, byte y, byte z)
        {
            this = X86.Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)z, (sbyte)y, (sbyte)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte xyz)
        {
            this = X86.Sse2.set1_epi8((sbyte)xyz);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte2 xy, byte z)
        {
            this = X86.Sse4_1.insert_epi8(xy, z, 2);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte x, byte2 yz)
        {
            this = X86.Sse4_1.insert_epi8(X86.Sse2.bslli_si128(yz, sizeof(byte)), x, 0);
        }


        #region Shuffle
        public byte16 xxxxxxxxxxxxxxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastb_epi8(this); }
        public byte16 yyyyyyyyyyyyyyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)); }
        public byte16 zzzzzzzzzzzzzzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2)); }

        public byte8 xxxxxxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastb_epi8(this); }
        public byte8 yyyyyyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 1, 1, 1, 1, 1,     0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte8 zzzzzzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 2, 2, 2, 2, 2,     0, 0, 0, 0, 0, 0, 0, 0)); }

        public byte4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastb_epi8(this); }
        public byte4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastw_epi16(this); }
        public byte4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }

        public byte3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastb_epi8(this); }
        public byte3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastw_epi16(this); }
        public byte3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }

        public byte2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Avx2.broadcastb_epi8(this); }
        public byte2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(0, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => X86.Ssse3.shuffle_epi8(this, new v128(2, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        #endregion

                                                            
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte3 input) => X86.Sse4_1.insert_epi8(X86.Sse2.set1_epi32(*(int*)&input), input.z, 2);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte3(v128 input) => new byte3 { x = X86.Sse4_1.extract_epi8(input, 0), y = X86.Sse4_1.extract_epi8(input, 1), z = X86.Sse4_1.extract_epi8(input, 2) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte3(byte input) => new byte3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(sbyte3 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(short3 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(ushort3 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(int3 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(uint3 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(long3 input) => Cast.Long4ToByte4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(ulong3 input) => Cast.Long4ToByte4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(half3 input) => (byte3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(float3 input) => (byte3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(double3 input) => (byte3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(byte3 input) => X86.Sse4_1.cvtepu8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3(byte3 input) => X86.Sse4_1.cvtepu8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(byte3 input) { v128 temp = X86.Sse4_1.cvtepu8_epi32(input); return *(int3*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(byte3 input) { v128 temp = X86.Sse4_1.cvtepu8_epi32(input); return *(uint3*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(byte3 input) => X86.Avx2.mm256_cvtepu8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(byte3 input) => X86.Avx2.mm256_cvtepu8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(byte3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(byte3 input) => (float3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(byte3 input) => (double3)(int3)input;


        public byte this[[AssumeRange(0, 2)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 3);
                
                fixed (void* ptr = &this)
                {
                    return ((byte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                fixed (void* ptr = &this)
                {
                    ((byte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator + (byte3 lhs, byte3 rhs) => X86.Sse2.add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator - (byte3 lhs, byte3 rhs) => X86.Sse2.sub_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator * (byte3 lhs, byte3 rhs) => (byte3)((short3)lhs * (short3)rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator / (byte3 lhs, byte3 rhs) => new byte3((byte)(lhs.x / rhs.x),    (byte)(lhs.y / rhs.y),    (byte)(lhs.z / rhs.z));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator % (byte3 lhs, byte3 rhs) => new byte3((byte)(lhs.x % rhs.x),    (byte)(lhs.y % rhs.y),    (byte)(lhs.z % rhs.z));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator / (byte3 lhs, byte rhs) => Operator.div(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator % (byte3 lhs, byte rhs) => Operator.rem(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator & (byte3 lhs, byte3 rhs) => X86.Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator | (byte3 lhs, byte3 rhs) => X86.Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ^ (byte3 lhs, byte3 rhs) => X86.Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ++ (byte3 x) => X86.Sse2.add_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator -- (byte3 x) => X86.Sse2.sub_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ~ (byte3 x) => X86.Sse2.andnot_si128(x, new v128((sbyte)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator << (byte3 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator >> (byte3 x, int n) => Operator.shrl_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (byte3 lhs, byte3 rhs) => TestIsTrue(X86.Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (byte3 lhs, byte3 rhs) => (short3)lhs < (short3)rhs;
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (byte3 lhs, byte3 rhs) => (short3)lhs > (short3)rhs;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (byte3 lhs, byte3 rhs) => TestIsFalse(X86.Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (byte3 lhs, byte3 rhs) => (short3)lhs <= (short3)rhs;
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (byte3 lhs, byte3 rhs) => (short3)lhs >= (short3)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsTrue(v128 input)
        {
            int result = 0x0001_0101 & X86.Sse4_1.extract_epi32(input, 0);

            return *(bool3*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsFalse(v128 input)
        {
            int result = maxmath.andn(0x0001_0101, X86.Sse4_1.extract_epi32(input, 0));

            return *(bool3*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte3 other) => maxmath.cvt_boolean(X86.Sse4_1.testc_si128(X86.Sse2.cmpeq_epi8(this, other), new v128(0x0000_0000_00FF_FFFFul, 0ul)));

        public override bool Equals(object obj) => Equals((byte3)obj);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => X86.Sse4_1.extract_epi32(this, 0) & (int)maxmath.bitmask32(24);


        public override string ToString() => $"byte3({x}, {y}, {z})";
    }
}