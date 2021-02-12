using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(byte))]  [DebuggerTypeProxy(typeof(byte3.DebuggerProxy))]
    unsafe public struct byte3 : IEquatable<byte3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public byte x;
            public byte y;
            public byte z;

            public DebuggerProxy(byte3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)] private fixed byte asArray[3];

        [FieldOffset(0)] public byte x;
        [FieldOffset(1)] public byte y;
        [FieldOffset(2)] public byte z;


        public static byte3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte x, byte y, byte z)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)z, (sbyte)y, (sbyte)x);
            }
            else
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte xyz)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set1_epi8((sbyte)xyz);
            }
            else
            {
                this.x = this.y = this.z = xyz;
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte2 xy, byte z)
        {
            if (Sse4_1.IsSse41Supported)
            {
                this = Sse4_1.insert_epi8(xy, z, 2);
            }
            else
            {
                this.x = xy.x;
                this.y = xy.y;
                this.z = z;
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte x, byte2 yz)
        {
            if (Sse4_1.IsSse41Supported)
            {
                this = Sse4_1.insert_epi8(Sse2.bslli_si128(yz, sizeof(byte)), x, 0);
            }
            else
            {
                this.x = x;
                this.y = yz.x;
                this.z = yz.y;
            }
        }


        #region Shuffle
        public readonly byte4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, default(v128));
                }
                else
                {
                    return new byte4(x, x, x, x);
                }
            }
        }
        public readonly byte4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 0, 1));
                }
                else
                {
                    return new byte4(x, x, x, y);
                }
            }
        }
        public readonly byte4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 0, 2));
                }
                else
                {
                    return new byte4(x, x, x, z);
                }
            }
        }
        public readonly byte4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 0));
                }
                else
                {
                    return new byte4(x, x, y, x);
                }
            }
        }
        public readonly byte4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 1));
                }
                else
                {
                    return new byte4(x, x, y, y);
                }
            }
        }
        public readonly byte4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 2));
                }
                else
                {
                    return new byte4(x, x, y,z);
                }
            }
        }
        public readonly byte4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 2, 0));
                }
                else
                {
                    return new byte4(x, x, z, x);
                }
            }
        }
        public readonly byte4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 2, 1));
                }
                else
                {
                    return new byte4(x, x, z, y);
                }
            }
        }
        public readonly byte4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 2, 2));
                }
                else
                {
                    return new byte4(x, x, z, z);
                }
            }
        }
        public readonly byte4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 0, 0));
                }
                else
                {
                    return new byte4(x, y, x, x);
                }
            }
        }
        public readonly byte4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new byte4(x, y, x, y);
                }
            }
        }
        public readonly byte4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 0, 2));
                }
                else
                {
                    return new byte4(x, y, x, z);
                }
            }
        }
        public readonly byte4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 0));
                }
                else
                {
                    return new byte4(x, y, y, x);
                }
            }
        }
        public readonly byte4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 1));
                }
                else
                {
                    return new byte4(x, y, y, y);
                }
            }
        }
        public readonly byte4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 2));
                }
                else
                {
                    return new byte4(x, y, y, z);
                }
            }
        }
        public readonly byte4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 2, 0));
                }
                else
                {
                    return new byte4(x, y, z, x);
                }
            }
        }
        public readonly byte4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 2, 1));
                }
                else
                {
                    return new byte4(x, y, z, y);
                }
            }
        }
        public readonly byte4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 2, 2));
                }
                else
                {
                    return new byte4(x, y, z, z);
                }
            }
        }
        public readonly byte4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 0, 0));
                }
                else
                {
                    return new byte4(x, z, x, x);
                }
            }
        }
        public readonly byte4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 0, 1));
                }
                else
                {
                    return new byte4(x, z, x, y);
                }
            }
        }
        public readonly byte4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 0, 2));
                }
                else
                {
                    return new byte4(x, z, x, z);
                }
            }
        }
        public readonly byte4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 1, 0));
                }
                else
                {
                    return new byte4(x, z, y, x);
                }
            }
        }
        public readonly byte4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 1, 1));
                }
                else
                {
                    return new byte4(x, z, y, y);
                }
            }
        }
        public readonly byte4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 1, 2));
                }
                else
                {
                    return new byte4(x, z, y, z);
                }
            }
        }
        public readonly byte4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 2, 0));
                }
                else
                {
                    return new byte4(x, z, z, x);
                }
            }
        }
        public readonly byte4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 2, 1));
                }
                else
                {
                    return new byte4(x, z, z, y);
                }
            }
        }
        public readonly byte4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 2, 2));
                }
                else
                {
                    return new byte4(x, z, z, z);
                }
            }
        }
        public readonly byte4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 0));
                }
                else
                {
                    return new byte4(y, x, x,  x);
                }
            }
        }
        public readonly byte4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 1));
                }
                else
                {
                    return new byte4(y, x, x, y);
                }
            }
        }
        public readonly byte4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 2));
                }
                else
                {
                    return new byte4(y, x, x, z);
                }
            }
        }
        public readonly byte4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 0));
                }
                else
                {
                    return new byte4(y, x, y, x);
                }
            }
        }
        public readonly byte4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 1));
                }
                else
                {
                    return new byte4(y, x, y, y);
                }
            }
        }
        public readonly byte4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 2));
                }
                else
                {
                    return new byte4(y, x, y, z);
                }
            }
        }
        public readonly byte4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 2, 0));
                }
                else
                {
                    return new byte4(y, x, z, x);
                }
            }
        }
        public readonly byte4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 2, 1));
                }
                else
                {
                    return new byte4(y, x, z, y);
                }
            }
        }
        public readonly byte4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 2, 2));
                }
                else
                {
                    return new byte4(y, x, z, z);
                }
            }
        }
        public readonly byte4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 0));
                }
                else
                {
                    return new byte4(y, y, x, x);
                }
            }
        }
        public readonly byte4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 1));
                }
                else
                {
                    return new byte4(y, y, x, y);
                }
            }
        }
        public readonly byte4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 2));
                }
                else
                {
                    return new byte4(y, y, x, z);
                }
            }
        }
        public readonly byte4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 0));
                }
                else
                {
                    return new byte4(y, y, y, x);
                }
            }
        }
        public readonly byte4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 1));
                }
                else
                {
                    return new byte4(y, y, y, y);
                }
            }
        }
        public readonly byte4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 2));
                }
                else
                {
                    return new byte4(y, y, y, z);
                }
            }
        }
        public readonly byte4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 2, 0));
                }
                else
                {
                    return new byte4(y, y, z, x);
                }
            }
        }
        public readonly byte4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 2, 1));
                }
                else
                {
                    return new byte4(y, y, z, y);
                }
            }
        }
        public readonly byte4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 2, 2));
                }
                else
                {
                    return new byte4(y, y, z, z);
                }
            }
        }
        public readonly byte4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 0, 0));
                }
                else
                {
                    return new byte4(y, z, x, x);
                }
            }
        }
        public readonly byte4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 0, 1));
                }
                else
                {
                    return new byte4(y, z, x, y);
                }
            }
        }
        public readonly byte4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 0, 2));
                }
                else
                {
                    return new byte4(y, z, x, z);
                }
            }
        }
        public readonly byte4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 1, 0));
                }
                else
                {
                    return new byte4(y, z, y, x);
                }
            }
        }
        public readonly byte4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 1, 1));
                }
                else
                {
                    return new byte4(y, z, y, y);
                }
            }
        }
        public readonly byte4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 1, 2));
                }
                else
                {
                    return new byte4(y, z, y, z);
                }
            }
        }
        public readonly byte4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 2, 0));
                }
                else
                {
                    return new byte4(y, z, z, x);
                }
            }
        }
        public readonly byte4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                { 
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 2, 1));
                }
                else
                {
                    return new byte4(y, z, z, y);
                }
            }
        }
        public readonly byte4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 2, 2));
                }
                else
                {
                    return new byte4(y, z, z, z);
                }
            }
        }
        public readonly byte4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 0, 0));
                }
                else
                {
                    return new byte4(z, x, x, x);
                }
            }
        }
        public readonly byte4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 0, 1));
                }
                else
                {
                    return new byte4(z, x, x, y);
                }
            }
        }
        public readonly byte4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 0, 2));
                }
                else
                {
                    return new byte4(z, x, x, z);
                }
            }
        }
        public readonly byte4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 1, 0));
                }
                else
                {
                    return new byte4(z, x, y, x);
                }
            }
        }
        public readonly byte4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 1, 1));
                }
                else
                {
                    return new byte4(z, x, y, y);
                }
            }
        }
        public readonly byte4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 1, 2));
                }
                else
                {
                    return new byte4(z, x, y, z);
                }
            }
        }
        public readonly byte4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 2, 0));
                }
                else
                {
                    return new byte4(z, x, z, x);
                }
            }
        }
        public readonly byte4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 2, 1));
                }
                else
                {
                    return new byte4(z, x, z, y);
                }
            }
        }
        public readonly byte4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 2, 2));
                }
                else
                {
                    return new byte4(z, x, z, z);
                }
            }
        }
        public readonly byte4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 0, 0));
                }
                else
                {
                    return new byte4(z, y, x, x);
                }
            }
        }
        public readonly byte4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 0, 1));
                }
                else
                {
                    return new byte4(z, y, x, y);
                }
            }
        }
        public readonly byte4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 0, 2));
                }
                else
                {
                    return new byte4(z, y, x, z);
                }
            }
        }
        public readonly byte4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 1, 0));
                }
                else
                {
                    return new byte4(z, y, y, x);
                }
            }
        }
        public readonly byte4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 1, 1));
                }
                else
                {
                    return new byte4(z, y, y, y);
                }
            }
        }
        public readonly byte4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 1, 2));
                }
                else
                {
                    return new byte4(z, y, y, z);
                }
            }
        }
        public readonly byte4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 2, 0));
                }
                else
                {
                    return new byte4(z, y, z, x);
                }
            }
        }
        public readonly byte4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 2, 1));
                }
                else
                {
                    return new byte4(z, y, z, y);
                }
            }
        }
        public readonly byte4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 2, 2));
                }
                else
                {
                    return new byte4(z, y, z, z);
                }
            }
        }
        public readonly byte4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 0, 0));
                }
                else
                {
                    return new byte4(z, z, x, x);
                }
            }
        }
        public readonly byte4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 0, 1));
                }
                else
                {
                    return new byte4(z, z, x, y);
                }
            }
        }
        public readonly byte4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 0, 2));
                }
                else
                {
                    return new byte4(z, z, x, z);
                }
            }
        }
        public readonly byte4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 1, 0));
                }
                else
                {
                    return new byte4(z, z, y, x);
                }
            }
        }
        public readonly byte4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 1, 1));
                }
                else
                {
                    return new byte4(z, z, y, y);
                }
            }
        }
        public readonly byte4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 1, 2));
                }
                else
                {
                    return new byte4(z, z, y, z);
                }
            }
        }
        public readonly byte4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 2, 0));
                }
                else
                {
                    return new byte4(z, z, z, x);
                }
            }
        }
        public readonly byte4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 2, 1));
                }
                else
                {
                    return new byte4(z, z, z, y);
                }
            }
        }
        public readonly byte4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 2, 2));
                }
                else
                {
                    return new byte4(z, z, z, z);
                }
            }
        }

        public readonly byte3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, default(v128));
                }
                else
                {
                    return new byte3(x, x, x);
                }
            }
        }
        public readonly byte3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 1, 3));
                }
                else
                {
                    return new byte3(x, x, y);
                }
            }
        }
        public readonly byte3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 0, 2, 3));
                }
                else
                {
                    return new byte3(x, x, z);
                }
            }
        }
        public readonly byte3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new byte3(x, y, x);
                }
            }
        }
        public readonly byte3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 1, 1, 3));
                }
                else
                {
                    return new byte3(x, y, y);
                }
            }
        }
        public readonly byte3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 0, 3));
                }
                else
                {
                    return new byte3(x, z, x);
                }
            }
        }
        public          byte3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 1, 3));
                }
                else
                {
                    return new byte3(x, z, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.xzy;
            }
        }
        public readonly byte3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 2, 3));
                }
                else
                {
                    return new byte3(x, z, z);
                }
            }
        }
        public readonly byte3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 0, 3));
                }
                else
                {
                    return new byte3(y, x, x);
                }
            }
        }
        public readonly byte3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 1, 3));
                }
                else
                {
                    return new byte3(y, x, y);
                }
            }
        }
        public          byte3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 2, 3));
                }
                else
                {
                    return new byte3(y, x, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yxz;
            }
        }
        public readonly byte3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 0, 3));
                }
                else
                {
                    return new byte3(y, y, x);
                }
            }
        }
        public readonly byte3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 1, 3));
                }
                else
                {
                    return new byte3(y, y, y);
                }
            }
        }
        public readonly byte3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 2, 3));
                }
                else
                {
                    return new byte3(y, y, z);
                }
            }
        }
        public          byte3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 0, 3));
                }
                else
                {
                    return new byte3(y, z, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zxy;
            }
        }
        public readonly byte3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 1, 3));
                }
                else
                {
                    return new byte3(y, z, y);
                }
            }
        }
        public readonly byte3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 2, 2, 3));
                }
                else
                {
                    return new byte3(y, z, z);
                }
            }
        }
        public readonly byte3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 0, 3));
                }
                else
                {
                    return new byte3(z, x, x);
                }
            }
        }
        public          byte3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 1, 3));
                }
                else
                {
                    return new byte3(z, x, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yzx;
            }
        }
        public readonly byte3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 2, 3));
                }
                else
                {
                    return new byte3(z, x, z);
                }
            }
        }
        public          byte3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 0, 3));
                }
                else
                {
                    return new byte3(z, y, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zyx;
            }
        }
        public readonly byte3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 1, 3));
                }
                else
                {
                    return new byte3(z, y, y);
                }
            }
        }
        public readonly byte3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 2, 3));
                }
                else
                {
                    return new byte3(z, y, z);
                }
            }
        }
        public readonly byte3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 0, 3));
                }
                else
                {
                    return new byte3(z, z, x);
                }
            }
        }
        public readonly byte3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 1, 3));
                }
                else
                {
                    return new byte3(z, z, y);
                }
            }
        }
        public readonly byte3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 2, 3));
                }
                else
                {
                    return new byte3(z, z, z);
                }
            }
        }

        public readonly byte2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, default(v128));
                }
                else
                {
                    return new byte2(x, x);
                }
            }
        }
        public          byte2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return (v128)this;
                }
                else
                {
                    return new byte2(x, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16(this, value, 0b0001);
                }
                else
                {
                    this.x = value.x;
                    this.y = value.y;
                }
            }
        }
        public          byte2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(0, 2, 3, 3));
                }
                else
                {
                    return new byte2(x, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, value.xxyy, new byte4(255, 0, 255, 0));
                }
                else
                {
                    this.x = value.x;
                    this.z = value.y;
                }
            }
        }
        public          byte2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 0, 3, 3));
                }
                else
                {
                    return new byte2(y, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendEpi16(this, value.yxyx, 0b0001);
                }
                else
                {
                    this.y = value.x;
                    this.x = value.y;
                }
            }
        }
        public readonly byte2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(1, 1, 3, 3));
                }
                else
                {
                    return new byte2(y, y);
                }
            }
        }
        public          byte2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, sizeof(byte));
                }
                else
                {
                    return new byte2(y, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, sizeof(byte)), new byte4(0, 255, 255, 0));
                }
                else
                {
                    this.y = value.x;
                    this.z = value.y;
                } 
            }
        }
        public          byte2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 0, 3, 3));
                }
                else
                {
                    return new byte2(z, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, value.yyxx, new byte4(255, 0, 255, 0));
                }
                else
                {
                    this.z = value.x;
                    this.x = value.y;
                }
            }
        }
        public          byte2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 1, 3, 3));
                }
                else
                {
                    return new byte2(z, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, value.yyxx, new byte4(0, 255, 255, 0));
                }
                else
                {
                    this.z = value.x;
                    this.y = value.y;
                }
            }
        }
        public readonly byte2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new byte4(2, 2, 3, 3));
                }
                else
                {
                    return new byte2(z, z);
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte3 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.insert_epi8(Sse2.insert_epi16(default(v128), *(ushort*)&input, 0), input.z, 2);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.set_epi32(0, 0, 0, *(int*)&input);
            }
            else
            {
                return new v128(*(int*)&input, 0, 0, 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte3(v128 input) => new byte3 { x = input.Byte0, y = input.Byte1, z = input.Byte2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte3(byte input) => new byte3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(sbyte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(byte3*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(short3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.ShortToByte(input);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(ushort3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.ShortToByte(input);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(int3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToByte4(*(v128*)&input);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(uint3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToByte4(*(v128*)&input);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToByte4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new byte3(Cast.Long2ToByte2(input._xy), (byte)input.z);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToByte4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new byte3(Cast.Long2ToByte2(input._xy), (byte)input.z);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(half3 input) => (byte3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(float3 input) => (byte3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(double3 input) => (byte3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(byte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.ByteToShort(input);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3(byte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.ByteToShort(input);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(byte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.ByteToInt(input);

                return *(int3*)&temp;
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(byte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.ByteToInt(input);

                return *(uint3*)&temp;
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(byte3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi64(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new long3((long2)input.xy, (long)input.z);
            }
            else
            {
                return new long3((long)input.x, (long)input.y, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(byte3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi64(input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
            else
            {
                return new ulong3((ulong)input.x, (ulong)input.y, (ulong)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half3(byte3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(byte3 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                v128 temp = Cast.ByteToFloat(input);

                return *(float3*)&temp;
            }
            else
            {
                return new float3((float)input.x, (float)input.y, (float)input.z);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(byte3 input) => (double3)(int3)input;


        public byte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 3);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                asArray[index] = value;
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator + (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new byte3((byte)(left.x + right.x), (byte)(left.y + right.y), (byte)(left.z + right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator - (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new byte3((byte)(left.x - right.x), (byte)(left.y - right.y), (byte)(left.z - right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator * (byte3 left, byte3 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (byte3)((ushort3)left * (ushort3)right);
            }
            else
            {
                return new byte3((byte)(left.x * right.x), (byte)(left.y * right.y), (byte)(left.z * right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator / (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_byte(left, right);
            }
            else
            {
                return new byte3((byte)(left.x / right.x), (byte)(left.y / right.y), (byte)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator % (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vrem_byte(left, right);
            }
            else
            {
                return new byte3((byte)(left.x % right.x), (byte)(left.y % right.y), (byte)(left.z % right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator * (byte left, byte3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator * (byte3 left, byte right)
        {
            return new byte3((byte)(left.x * right), (byte)(left.y * right), (byte)(left.z * right));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator / (byte3 left, byte right)
        {
            return new byte3((byte)(left.x / right), (byte)(left.y / right), (byte)(left.z / right));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator % (byte3 left, byte right)
        {
            return new byte3((byte)(left.x % right), (byte)(left.y % right), (byte)(left.z % right));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator & (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new byte3((byte)(left.x & right.x), (byte)(left.y & right.y), (byte)(left.z & right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator | (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new byte3((byte)(left.x | right.x), (byte)(left.y | right.y), (byte)(left.z | right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ^ (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new byte3((byte)(left.x ^ right.x), (byte)(left.y ^ right.y), (byte)(left.z ^ right.z));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ++ (byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(x, new byte4(1));
            }
            else
            {
                return new byte3((byte)(x.x + 1), (byte)(x.y + 1), (byte)(x.z + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator -- (byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(x, new byte4(1));
            }
            else
            {
                return new byte3((byte)(x.x - 1), (byte)(x.y - 1), (byte)(x.z - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ~ (byte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(x, new sbyte4(-1));
            }
            else
            {
                return new byte3((byte)(~x.x), (byte)(~x.y), (byte)(~x.z));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator << (byte3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_byte(x, n);
            }
            else
            {
                return new byte3((byte)(x.x << n), (byte)(x.y << n), (byte)(x.z << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator >> (byte3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shrl_byte(x, n);
            }
            else
            {
                return new byte3((byte)(x.x >> n), (byte)(x.y >> n), (byte)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool3(left.x == right.x, left.y == right.y, left.z == right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(right, left));
            }
            else
            {
                return new bool3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_byte(left, right));
            }
            else
            {
                return new bool3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool3(left.x != right.x, left.y != right.y, left.z != right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(Sse2.min_epu8(left, right), left));
            }
            else
            {
                return new bool3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (byte3 left, byte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi8(Sse2.max_epu8(left, right), left));
            }
            else
            {
                return new bool3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsTrue(v128 input)
        {
            input = -((sbyte16)input);

            return *(bool3*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsFalse(v128 input)
        {
            if (Sse2.IsSse2Supported)
            {
                input = Sse2.andnot_si128(input, new byte4(1));

                return *(bool3*)&input;
            }
            else throw new BurstCompilerException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(byte3 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return maxmath.bitmask32(24u) == (maxmath.bitmask32(24u) & Sse2.cmpeq_epi8(this, other).UInt0);
            }
            else
            {
                return this.x == other.x & this.y == other.y & this.z == other.z;
            }
        }

        public override readonly bool Equals(object obj) => Equals((byte3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v24(this);
            }
            else
            {
                return x | (y << 8) | (z << 16);
            }
        }


        public override readonly string ToString() => $"byte3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"byte3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}