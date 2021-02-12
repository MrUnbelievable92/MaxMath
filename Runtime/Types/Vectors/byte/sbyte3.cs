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
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(sbyte))]  [DebuggerTypeProxy(typeof(sbyte3.DebuggerProxy))]
    unsafe public struct sbyte3 : IEquatable<sbyte3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public sbyte x;
            public sbyte y;
            public sbyte z;

            public DebuggerProxy(sbyte3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)] private fixed sbyte asArray[3];

        [FieldOffset(0)] public sbyte x;
        [FieldOffset(1)] public sbyte y;
        [FieldOffset(2)] public sbyte z;


        public static sbyte3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte x, sbyte y, sbyte z)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, z, y, x);
            }
            else
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte xyz)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set1_epi8(xyz);
            }
            else
            {
                this.x = this.y = this.z = xyz;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte2 xy, sbyte z)
        {
            if (Sse4_1.IsSse41Supported)
            {
                this = Sse4_1.insert_epi8(xy, (byte)z, 2);
            }
            else
            {
                this.x = xy.x;
                this.y = xy.y;
                this.z = z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public sbyte3(sbyte x, sbyte2 yz)
        {
            if (Sse4_1.IsSse41Supported)
            {
                this = Sse4_1.insert_epi8(Sse2.bslli_si128(yz, sizeof(sbyte)), (byte)x, 0);
            }
            else
            {
                this.x = x;
                this.y = yz.x;
                this.z = yz.y;
            }
        }


        #region Shuffle
        public readonly sbyte4 xxxx
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
                    return new sbyte4(x, x, x, x);
                }
            }
        }
        public readonly sbyte4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 0, 1));
                }
                else
                {
                    return new sbyte4(x, x, x, y);
                }
            }
        }
        public readonly sbyte4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 0, 2));
                }
                else
                {
                    return new sbyte4(x, x, x, z);
                }
            }
        }
        public readonly sbyte4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 1, 0));
                }
                else
                {
                    return new sbyte4(x, x, y, x);
                }
            }
        }
        public readonly sbyte4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 1, 1));
                }
                else
                {
                    return new sbyte4(x, x, y, y);
                }
            }
        }
        public readonly sbyte4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 1, 2));
                }
                else
                {
                    return new sbyte4(x, x, y, z);
                }
            }
        }
        public readonly sbyte4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 2, 0));
                }
                else
                {
                    return new sbyte4(x, x, z, x);
                }
            }
        }
        public readonly sbyte4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 2, 1));
                }
                else
                {
                    return new sbyte4(x, x, z, y);
                }
            }
        }
        public readonly sbyte4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 2, 2));
                }
                else
                {
                    return new sbyte4(x, x, z, z);
                }
            }
        }
        public readonly sbyte4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 0, 0));
                }
                else
                {
                    return new sbyte4(x, y, x, x);
                }
            }
        }
        public readonly sbyte4 xyxy
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
                    return new sbyte4(x, y, x, y);
                }
            }
        }
        public readonly sbyte4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 0, 2));
                }
                else
                {
                    return new sbyte4(x, y, x, z);
                }
            }
        }
        public readonly sbyte4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 1, 0));
                }
                else
                {
                    return new sbyte4(x, y, y, x);
                }
            }
        }
        public readonly sbyte4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 1, 1));
                }
                else
                {
                    return new sbyte4(x, y, y, y);
                }
            }
        }
        public readonly sbyte4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 1, 2));
                }
                else
                {
                    return new sbyte4(x, y, y, z);
                }
            }
        }
        public readonly sbyte4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 2, 0));
                }
                else
                {
                    return new sbyte4(x, y, z, x);
                }
            }
        }
        public readonly sbyte4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 2, 1));
                }
                else
                {
                    return new sbyte4(x, y, z, y);
                }
            }
        }
        public readonly sbyte4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 2, 2));
                }
                else
                {
                    return new sbyte4(x, y, z, z);
                }
            }
        }
        public readonly sbyte4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 0, 0));
                }
                else
                {
                    return new sbyte4(x, z, x, x);
                }
            }
        }
        public readonly sbyte4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 0, 1));
                }
                else
                {
                    return new sbyte4(x, z, x, y);
                }
            }
        }
        public readonly sbyte4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 0, 2));
                }
                else
                {
                    return new sbyte4(x, z, x, z);
                }
            }
        }
        public readonly sbyte4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 1, 0));
                }
                else
                {
                    return new sbyte4(x, z, y, x);
                }
            }
        }
        public readonly sbyte4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 1, 1));
                }
                else
                {
                    return new sbyte4(x, z, y, y);
                }
            }
        }
        public readonly sbyte4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 1, 2));
                }
                else
                {
                    return new sbyte4(x, z, y, z);
                }
            }
        }
        public readonly sbyte4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 2, 0));
                }
                else
                {
                    return new sbyte4(x, z, z, x);
                }
            }
        }
        public readonly sbyte4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 2, 1));
                }
                else
                {
                    return new sbyte4(x, z, z, y);
                }
            }
        }
        public readonly sbyte4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 2, 2));
                }
                else
                {
                    return new sbyte4(x, z, z, z);
                }
            }
        }
        public readonly sbyte4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 0, 0));
                }
                else
                {
                    return new sbyte4(y, x, x, x);
                }
            }
        }
        public readonly sbyte4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 0, 1));
                }
                else
                {
                    return new sbyte4(y, x, x, y);
                }
            }
        }
        public readonly sbyte4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 0, 2));
                }
                else
                {
                    return new sbyte4(y, x, x, z);
                }
            }
        }
        public readonly sbyte4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 1, 0));
                }
                else
                {
                    return new sbyte4(y, x, y, x);
                }
            }
        }
        public readonly sbyte4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 1, 1));
                }
                else
                {
                    return new sbyte4(y, x, y, y);
                }
            }
        }
        public readonly sbyte4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 1, 2));
                }
                else
                {
                    return new sbyte4(y, x, y, z);
                }
            }
        }
        public readonly sbyte4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 2, 0));
                }
                else
                {
                    return new sbyte4(y, x, z, x);
                }
            }
        }
        public readonly sbyte4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 2, 1));
                }
                else
                {
                    return new sbyte4(y, x, z, y);
                }
            }
        }
        public readonly sbyte4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 2, 2));
                }
                else
                {
                    return new sbyte4(y, x, z, z);
                }
            }
        }
        public readonly sbyte4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 0, 0));
                }
                else
                {
                    return new sbyte4(y, y, x, x);
                }
            }
        }
        public readonly sbyte4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 0, 1));
                }
                else
                {
                    return new sbyte4(y, y, x, y);
                }
            }
        }
        public readonly sbyte4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 0, 2));
                }
                else
                {
                    return new sbyte4(y, y, x, z);
                }
            }
        }
        public readonly sbyte4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 1, 0));
                }
                else
                {
                    return new sbyte4(y, y, y, x);
                }
            }
        }
        public readonly sbyte4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 1, 1));
                }
                else
                {
                    return new sbyte4(y, y, y, y);
                }
            }
        }
        public readonly sbyte4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 1, 2));
                }
                else
                {
                    return new sbyte4(y, y, y, z);
                }
            }
        }
        public readonly sbyte4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 2, 0));
                }
                else
                {
                    return new sbyte4(y, y, z, x);
                }
            }
        }
        public readonly sbyte4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 2, 1));
                }
                else
                {
                    return new sbyte4(y, y, z, y);
                }
            }
        }
        public readonly sbyte4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 2, 2));
                }
                else
                {
                    return new sbyte4(y, y, z, z);
                }
            }
        }
        public readonly sbyte4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 0, 0));
                }
                else
                {
                    return new sbyte4(y, z, x, x);
                }
            }
        }
        public readonly sbyte4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 0, 1));
                }
                else
                {
                    return new sbyte4(y, z, x, y);
                }
            }
        }
        public readonly sbyte4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 0, 2));
                }
                else
                {
                    return new sbyte4(y, z, x, z);
                }
            }
        }
        public readonly sbyte4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 1, 0));
                }
                else
                {
                    return new sbyte4(y, z, y, x);
                }
            }
        }
        public readonly sbyte4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 1, 1));
                }
                else
                {
                    return new sbyte4(y, z, y, y);
                }
            }
        }
        public readonly sbyte4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 1, 2));
                }
                else
                {
                    return new sbyte4(y, z, y, z);
                }
            }
        }
        public readonly sbyte4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 2, 0));
                }
                else
                {
                    return new sbyte4(y, z, z, x);
                }
            }
        }
        public readonly sbyte4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 2, 1));
                }
                else
                {
                    return new sbyte4(y, z, z, y);
                }
            }
        }
        public readonly sbyte4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 2, 2));
                }
                else
                {
                    return new sbyte4(y, z, z, z);
                }
            }
        }
        public readonly sbyte4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 0, 0));
                }
                else
                {
                    return new sbyte4(z, x, x, x);
                }
            }
        }
        public readonly sbyte4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 0, 1));
                }
                else
                {
                    return new sbyte4(z, x, x, y);
                }
            }
        }
        public readonly sbyte4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 0, 2));
                }
                else
                {
                    return new sbyte4(z, x, x, z);
                }
            }
        }
        public readonly sbyte4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 1, 0));
                }
                else
                {
                    return new sbyte4(z, x, y, x);
                }
            }
        }
        public readonly sbyte4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 1, 1));
                }
                else
                {
                    return new sbyte4(z, x, y, y);
                }
            }
        }
        public readonly sbyte4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 1, 2));
                }
                else
                {
                    return new sbyte4(z, x, y, z);
                }
            }
        }
        public readonly sbyte4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 2, 0));
                }
                else
                {
                    return new sbyte4(z, x, z, x);
                }
            }
        }
        public readonly sbyte4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 2, 1));
                }
                else
                {
                    return new sbyte4(z, x, z, y);
                }
            }
        }
        public readonly sbyte4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 2, 2));
                }
                else
                {
                    return new sbyte4(z, x, z, z);
                }
            }
        }
        public readonly sbyte4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 0, 0));
                }
                else
                {
                    return new sbyte4(z, y, x, x);
                }
            }
        }
        public readonly sbyte4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 0, 1));
                }
                else
                {
                    return new sbyte4(z, y, x, y);
                }
            }
        }
        public readonly sbyte4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 0, 2));
                }
                else
                {
                    return new sbyte4(z, y, x, z);
                }
            }
        }
        public readonly sbyte4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 1, 0));
                }
                else
                {
                    return new sbyte4(z, y, y, x);
                }
            }
        }
        public readonly sbyte4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 1, 1));
                }
                else
                {
                    return new sbyte4(z, y, y, y);
                }
            }
        }
        public readonly sbyte4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 1, 2));
                }
                else
                {
                    return new sbyte4(z, y, y, z);
                }
            }
        }
        public readonly sbyte4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 2, 0));
                }
                else
                {
                    return new sbyte4(z, y, z, x);
                }
            }
        }
        public readonly sbyte4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 2, 1));
                }
                else
                {
                    return new sbyte4(z, y, z, y);
                }
            }
        }
        public readonly sbyte4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 2, 2));
                }
                else
                {
                    return new sbyte4(z, y, z, z);
                }
            }
        }
        public readonly sbyte4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 0, 0));
                }
                else
                {
                    return new sbyte4(z, z, x, x);
                }
            }
        }
        public readonly sbyte4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 0, 1));
                }
                else
                {
                    return new sbyte4(z, z, x, y);
                }
            }
        }
        public readonly sbyte4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 0, 2));
                }
                else
                {
                    return new sbyte4(z, z, x, z);
                }
            }
        }
        public readonly sbyte4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 1, 0));
                }
                else
                {
                    return new sbyte4(z, z, y, x);
                }
            }
        }
        public readonly sbyte4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 1, 1));
                }
                else
                {
                    return new sbyte4(z, z, y, y);
                }
            }
        }
        public readonly sbyte4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 1, 2));
                }
                else
                {
                    return new sbyte4(z, z, y, z);
                }
            }
        }
        public readonly sbyte4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 2, 0));
                }
                else
                {
                    return new sbyte4(z, z, z, x);
                }
            }
        }
        public readonly sbyte4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 2, 1));
                }
                else
                {
                    return new sbyte4(z, z, z, y);
                }
            }
        }
        public readonly sbyte4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 2, 2));
                }
                else
                {
                    return new sbyte4(z, z, z, z);
                }
            }
        }

        public readonly sbyte3 xxx
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
                    return new sbyte3(x, x, x);
                }
            }
        }
        public readonly sbyte3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 1, 3));
                }
                else
                {
                    return new sbyte3(x, x, y);
                }
            }
        }
        public readonly sbyte3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 0, 2, 3));
                }
                else
                {
                    return new sbyte3(x, x, z);
                }
            }
        }
        public readonly sbyte3 xyx
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
                    return new sbyte3(x, y, x);
                }
            }
        }
        public readonly sbyte3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 1, 1, 3));
                }
                else
                {
                    return new sbyte3(x, y, y);
                }
            }
        }
        public readonly sbyte3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 0, 3));
                }
                else
                {
                    return new sbyte3(x, z, x);
                }
            }
        }
        public sbyte3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 1, 3));
                }
                else
                {
                    return new sbyte3(x, z, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.xzy;
            }
        }
        public readonly sbyte3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 2, 3));
                }
                else
                {
                    return new sbyte3(x, z, z);
                }
            }
        }
        public readonly sbyte3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 0, 3));
                }
                else
                {
                    return new sbyte3(y, x, x);
                }
            }
        }
        public readonly sbyte3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 1, 3));
                }
                else
                {
                    return new sbyte3(y, x, y);
                }
            }
        }
        public sbyte3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 2, 3));
                }
                else
                {
                    return new sbyte3(y, x, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yxz;
            }
        }
        public readonly sbyte3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 0, 3));
                }
                else
                {
                    return new sbyte3(y, y, x);
                }
            }
        }
        public readonly sbyte3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 1, 3));
                }
                else
                {
                    return new sbyte3(y, y, y);
                }
            }
        }
        public readonly sbyte3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 2, 3));
                }
                else
                {
                    return new sbyte3(y, y, z);
                }
            }
        }
        public sbyte3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 0, 3));
                }
                else
                {
                    return new sbyte3(y, z, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zxy;
            }
        }
        public readonly sbyte3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 1, 3));
                }
                else
                {
                    return new sbyte3(y, z, y);
                }
            }
        }
        public readonly sbyte3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 2, 2, 3));
                }
                else
                {
                    return new sbyte3(y, z, z);
                }
            }
        }
        public readonly sbyte3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 0, 3));
                }
                else
                {
                    return new sbyte3(z, x, x);
                }
            }
        }
        public sbyte3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 1, 3));
                }
                else
                {
                    return new sbyte3(z, x, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yzx;
            }
        }
        public readonly sbyte3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 2, 3));
                }
                else
                {
                    return new sbyte3(z, x, z);
                }
            }
        }
        public sbyte3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 0, 3));
                }
                else
                {
                    return new sbyte3(z, y, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zyx;
            }
        }
        public readonly sbyte3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 1, 3));
                }
                else
                {
                    return new sbyte3(z, y, y);
                }
            }
        }
        public readonly sbyte3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 2, 3));
                }
                else
                {
                    return new sbyte3(z, y, z);
                }
            }
        }
        public readonly sbyte3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 0, 3));
                }
                else
                {
                    return new sbyte3(z, z, x);
                }
            }
        }
        public readonly sbyte3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 1, 3));
                }
                else
                {
                    return new sbyte3(z, z, y);
                }
            }
        }
        public readonly sbyte3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 2, 2, 3));
                }
                else
                {
                    return new sbyte3(z, z, z);
                }
            }
        }

        public readonly sbyte2 xx
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
                    return new sbyte2(x, x);
                }
            }
        }
        public sbyte2 xy
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
                    return new sbyte2(x, y);
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
        public sbyte2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(0, 2, 3, 3));
                }
                else
                {
                    return new sbyte2(x, z);
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
        public sbyte2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 0, 3, 3));
                }
                else
                {
                    return new sbyte2(y, x);
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
        public readonly sbyte2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(1, 1, 3, 3));
                }
                else
                {
                    return new sbyte2(y, y);
                }
            }
        }
        public sbyte2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, sizeof(sbyte));
                }
                else
                {
                    return new sbyte2(y, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Mask.BlendV(this, Sse2.bslli_si128(value, sizeof(sbyte)), new byte4(0, 255, 255, 0));
                }
                else
                {
                    this.y = value.x;
                    this.z = value.y;
                }
            }
        }
        public sbyte2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 0, 3, 3));
                }
                else
                {
                    return new sbyte2(z, x);
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
        public sbyte2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Ssse3.IsSsse3Supported)
                {
                    return Ssse3.shuffle_epi8(this, new sbyte4(2, 1, 3, 3));
                }
                else
                {
                    return new sbyte2(z, y);
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
        public readonly sbyte2 zz
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
                    return new sbyte2(z, z);
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(sbyte3 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse4_1.insert_epi8(Sse2.insert_epi16(default(v128), *(ushort*)&input, 0), (byte)input.z, 2);
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
        public static implicit operator sbyte3(v128 input) => new sbyte3 { x = input.SByte0, y = input.SByte1, z = input.SByte2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte3(sbyte input) => new sbyte3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(byte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(sbyte3*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(short3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.ShortToByte(input);
            }
            else
            {
                return new sbyte3((sbyte)input.x, (sbyte)input.y, (sbyte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(ushort3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.ShortToByte(input);
            }
            else
            {
                return new sbyte3((sbyte)input.x, (sbyte)input.y, (sbyte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(int3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToByte4(*(v128*)&input);
            }
            else
            {
                return new sbyte3((sbyte)input.x, (sbyte)input.y, (sbyte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(uint3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToByte4(*(v128*)&input);
            }
            else
            {
                return new sbyte3((sbyte)input.x, (sbyte)input.y, (sbyte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToByte4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new sbyte3(Cast.Long2ToByte2(input._xy), (sbyte)input.z);
            }
            else
            {
                return new sbyte3((sbyte)input.x, (sbyte)input.y, (sbyte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Cast.Long4ToByte4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new sbyte3(Cast.Long2ToByte2(input._xy), (sbyte)input.z);
            }
            else
            {
                return new sbyte3((sbyte)input.x, (sbyte)input.y, (sbyte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(half3 input) => (sbyte3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(float3 input) => (sbyte3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator sbyte3(double3 input) => (sbyte3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(sbyte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.SByteToShort(input);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(sbyte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Cast.SByteToShort(input);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(sbyte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.SByteToInt(input);

                return *(int3*)&temp;
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(sbyte3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.SByteToInt(input);

                return *(uint3*)&temp;
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(sbyte3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
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
        public static explicit operator ulong3(sbyte3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi8_epi64(input);
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
        public static implicit operator half3(sbyte3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(sbyte3 input) => (float3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(sbyte3 input) => (double3)(int3)input;


        public sbyte this[int index]
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
        public static sbyte3 operator + (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new sbyte3((sbyte)(left.x + right.x), (sbyte)(left.y + right.y), (sbyte)(left.z + right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator - (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new sbyte3((sbyte)(left.x - right.x), (sbyte)(left.y - right.y), (sbyte)(left.z - right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator * (sbyte3 left, sbyte3 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (sbyte3)((short3)left * (short3)right);
            }
            else
            {
                return new sbyte3((sbyte)(left.x * right.x), (sbyte)(left.y * right.y), (sbyte)(left.z * right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator / (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_sbyte(left, right);
            }
            else
            {
                return new sbyte3((sbyte)(left.x / right.x), (sbyte)(left.y / right.y), (sbyte)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator % (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vrem_sbyte(left, right);
            }
            else
            {
                return new sbyte3((sbyte)(left.x % right.x), (sbyte)(left.y % right.y), (sbyte)(left.z % right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator * (sbyte left, sbyte3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator * (sbyte3 left, sbyte right)
        {
            return new sbyte3((sbyte)(left.x * right), (sbyte)(left.y * right), (sbyte)(left.z * right));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator / (sbyte3 left, sbyte right)
        {
            return new sbyte3((sbyte)(left.x / right), (sbyte)(left.y / right), (sbyte)(left.z / right));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator % (sbyte3 left, sbyte right)
        {
            return new sbyte3((sbyte)(left.x % right), (sbyte)(left.y % right), (sbyte)(left.z % right));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator & (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new sbyte3((sbyte)(left.x & right.x), (sbyte)(left.y & right.y), (sbyte)(left.z & right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator | (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new sbyte3((sbyte)(left.x | right.x), (sbyte)(left.y | right.y), (sbyte)(left.z | right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ^ (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new sbyte3((sbyte)(left.x ^ right.x), (sbyte)(left.y ^ right.y), (sbyte)(left.z ^ right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator - (sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(default(v128), x);
            }
            else
            {
                return new sbyte3((sbyte)-x.x, (sbyte)-x.y, (sbyte)-x.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ++ (sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(x, new sbyte4(1));
            }
            else
            {
                return new sbyte3((sbyte)(x.x + 1), (sbyte)(x.y + 1), (sbyte)(x.z + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator -- (sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(x, new sbyte4(1));
            }
            else
            {
                return new sbyte3((sbyte)(x.x - 1), (sbyte)(x.y - 1), (sbyte)(x.z - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator ~ (sbyte3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.andnot_si128(x, new sbyte4(-1));
            }
            else
            {
                return new sbyte3((sbyte)(~x.x), (sbyte)(~x.y), (sbyte)(~x.z));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator << (sbyte3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_byte(x, n);
            }
            else
            {
                return new sbyte3((sbyte)(x.x << n), (sbyte)(x.y << n), (sbyte)(x.z << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 operator >> (sbyte3 x, int n)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return (sbyte3)((short3)x >> n);
            }
            else
            {
                return new sbyte3((sbyte)(x.x >> n), (sbyte)(x.y >> n), (sbyte)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (sbyte3 left, sbyte3 right)
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
        public static bool3 operator < (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpgt_epi8(right, left));
            }
            else
            {
                return new bool3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (sbyte3 left, sbyte3 right)
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
        public static bool3 operator <= (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpgt_epi8(left, right));
            }
            else
            {
                return new bool3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (sbyte3 left, sbyte3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpgt_epi8(right, left));
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
        public readonly bool Equals(sbyte3 other)
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

        public override readonly bool Equals(object obj) => Equals((sbyte3)obj);


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


        public override readonly string ToString() => $"sbyte3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"sbyte3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}