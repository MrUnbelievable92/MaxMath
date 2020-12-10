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
    [Serializable] [StructLayout(LayoutKind.Explicit, Size = 4)]
    unsafe public struct byte4 : IEquatable<byte4>
    {
        [FieldOffset(0)] internal int cast_int;

        [FieldOffset(0)] public byte x;
        [FieldOffset(1)] public byte y;
        [FieldOffset(2)] public byte z;
        [FieldOffset(3)] public byte w;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte y, byte z, byte w)
        {
            this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)w, (sbyte)z, (sbyte)y, (sbyte)x);
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte xyzw)
        {
            this = Sse2.set1_epi8((sbyte)xyzw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte2 xy, byte z, byte w)
        {
            this = Sse4_1.insert_epi8(Sse4_1.insert_epi8(xy, z, 2), w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte2 yz, byte w)
        {
            this = Sse4_1.insert_epi8(Sse4_1.insert_epi8(Sse2.bslli_si128(yz, sizeof(byte)), x, 0), w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte y, byte2 zw)
        {
            this = Sse4_1.insert_epi8(Sse4_1.insert_epi8(Sse2.bslli_si128(zw, 2 * sizeof(byte)), x, 0), y, 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte2 xy, byte2 zw)
        {
            this = Sse2.unpacklo_epi16(xy, zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte3 xyz, byte w)
        {
            this = Sse4_1.insert_epi8(xyz, w, 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte3 yzw)
        {
            this = Sse4_1.insert_epi8(Sse2.bslli_si128(yzw, sizeof(sbyte)), x, 0);
        }


        #region Shuffle
        public byte4 xxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public byte4 xxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }                  
        public byte4 xyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 xwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 yzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 ywww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public byte4 zwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        public byte4 zwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 zwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wxww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wyww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wzww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 0, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 0, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 0, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 1, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 1, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 1, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 2, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 2, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 2, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 3, 0,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 3, 1,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 3, 2,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte4 wwww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }

        public byte3 xxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public byte3 xxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastw_epi16(this); }               
        public byte3 xyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }        
        public byte3 xyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 xww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }      
        public byte3 ywx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 ywy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 ywz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 yww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1)); }
        public byte3 zwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 zwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1)); }
        public byte3 zww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wxx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wxy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wxz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wxw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wyx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wyy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wyz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wyw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wzx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wzy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wzz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wzw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wwx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 0, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wwy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 1, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 wwz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 2, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte3 www { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }

        public byte2 xx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Avx2.broadcastb_epi8(this); }
        public byte2 xy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => (v128)this; }
        public byte2 xz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 xw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(0, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 yx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 yy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 yz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }   
        public byte2 yw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(1, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 zx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 zy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 zz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 zw { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(2, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 wx { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 0, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 wy { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 1, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 wz { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 2, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        public byte2 ww { [MethodImpl(MethodImplOptions.AggressiveInlining)] get => Ssse3.shuffle_epi8(this, new v128(3, 3, 3, 3,   0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)); }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte4 input) => Sse2.set1_epi32(input.cast_int);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4(v128 input) => new byte4{ cast_int = Sse4_1.extract_epi32(input, 0) };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4(byte input) => new byte4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(sbyte4 input) => (v128)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(short4 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(ushort4 input) => Cast.ShortToByte(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(int4 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(uint4 input) => Cast.Int4ToByte4(*(v128*)&input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(long4 input) => Cast.Long4ToByte4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(ulong4 input) => Cast.Long4ToByte4(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(half4 input) => (byte4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(float4 input) => (byte4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(double4 input) => (byte4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(byte4 input) => Sse4_1.cvtepu8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4(byte4 input) => Sse4_1.cvtepu8_epi16(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(byte4 input) { v128 temp = Sse4_1.cvtepu8_epi32(input); return *(int4*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4(byte4 input) { v128 temp = Sse4_1.cvtepu8_epi32(input); return *(uint4*)&temp; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(byte4 input) => Avx2.mm256_cvtepu8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(byte4 input) => Avx2.mm256_cvtepu8_epi64(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(byte4 input) => (half4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(byte4 input) => (float4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(byte4 input) => (double4)(int4)input;


        public byte this[[AssumeRange(0, 3)] int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 4);
                
                fixed (void* ptr = &this)
                {
                    return ((byte*)ptr)[index];
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                fixed (void* ptr = &this)
                {
                    ((byte*)ptr)[index] = value;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator + (byte4 lhs, byte4 rhs) => Sse2.add_epi8(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator - (byte4 lhs, byte4 rhs) => Sse2.sub_epi8(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte4 lhs, byte4 rhs) => (byte4)((short4)lhs * (short4)rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator / (byte4 lhs, byte4 rhs) => new byte4((byte)(lhs.x / rhs.x),    (byte)(lhs.y / rhs.y),    (byte)(lhs.z / rhs.z),    (byte)(lhs.w / rhs.w));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator % (byte4 lhs, byte4 rhs) => new byte4((byte)(lhs.x % rhs.x),    (byte)(lhs.y % rhs.y),    (byte)(lhs.z % rhs.z),    (byte)(lhs.w % rhs.w));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator / (byte4 lhs, byte rhs) => Operator.div(lhs, rhs);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator % (byte4 lhs, byte rhs) => Operator.rem(lhs, rhs);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator & (byte4 lhs, byte4 rhs) => Sse2.and_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator | (byte4 lhs, byte4 rhs) => Sse2.or_si128(lhs, rhs);
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ^ (byte4 lhs, byte4 rhs) => Sse2.xor_si128(lhs, rhs);
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ++ (byte4 x) => Sse2.add_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator -- (byte4 x) => Sse2.sub_epi8(x, new v128((sbyte)1));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ~ (byte4 x) => Sse2.andnot_si128(x, new v128((sbyte)-1));
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator << (byte4 x, int n) => Operator.shl_byte(x, n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator >> (byte4 x, int n) => Operator.shrl_byte(x, n);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (byte4 lhs, byte4 rhs) => TestIsTrue(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (byte4 lhs, byte4 rhs) => (short4)lhs < (short4)rhs;
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (byte4 lhs, byte4 rhs) => (short4)lhs > (short4)rhs;
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (byte4 lhs, byte4 rhs) => TestIsFalse(Sse2.cmpeq_epi8(lhs, rhs));
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (byte4 lhs, byte4 rhs) => (short4)lhs <= (short4)rhs;
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (byte4 lhs, byte4 rhs) => (short4)lhs >= (short4)rhs;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsTrue(v128 input)
        {
            int result = 0x0101_0101 & Sse4_1.extract_epi32(input, 0);

            return *(bool4*)&result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsFalse(v128 input)
        {
            int result = maxmath.andn(0x0101_0101, Sse4_1.extract_epi32(input, 0));

            return *(bool4*)&result;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte4 other) => maxmath.cvt_boolean(Sse4_1.testc_si128(Sse2.cmpeq_epi8(this, other), new v128(-1, -1, 0, 0, 0, 0, 0, 0)));

        public override bool Equals(object obj) => Equals((byte4)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => Sse4_1.extract_epi32(this, 0);


        public override string ToString() => $"byte4({x}, {y}, {z}, {w})";
    }
}