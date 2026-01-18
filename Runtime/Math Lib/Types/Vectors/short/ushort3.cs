using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(ushort))]
    [DebuggerTypeProxy(typeof(ushort3.DebuggerProxy))]
    unsafe public struct ushort3 : IEquatable<ushort3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public ushort x;
            public ushort y;
            public ushort z;

            public DebuggerProxy(ushort3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)] public ushort x;
        [FieldOffset(2)] public ushort y;
        [FieldOffset(4)] public ushort z;


        public static ushort3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort x, ushort y, ushort z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set_epi16(0, 0, 0, 0, 0, (short)z, (short)y, (short)x);
            }
            else
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort xyz)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.shufflelo_epi16(Xse.cvtsi32_si128(xyz), Sse.SHUFFLE(0, 0, 0, 0));
            }
            else
            {
                this.x = this.y = this.z = xyz;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort2 xy, ushort z)
        {
            if (BurstArchitecture.IsInsertExtractSupported)
            {
                this = Xse.insert_epi16(xy, z, 2);
            }
            else
            {
                this.x = xy.x;
                this.y = xy.y;
                this.z = z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort x, ushort2 yz)
        {
            if (BurstArchitecture.IsInsertExtractSupported)
            {
                this = Xse.insert_epi16(Xse.bslli_si128(yz, sizeof(ushort)), x, 0);
            }
            else
            {
                this.x = x;
                this.y = yz.x;
                this.z = yz.y;
            }
        }


        #region Shuffle
        public readonly ushort4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, x, x);
                }
            }
        }
        public readonly ushort4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, x, y);
                }
            }
        }
        public readonly ushort4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, x, z);
                }
            }
        }
        public readonly ushort4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, y, x);
                }
            }
        }
        public readonly ushort4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, y, y);
                }
            }
        }
        public readonly ushort4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, y,z);
                }
            }
        }
        public readonly ushort4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, z, x);
                }
            }
        }
        public readonly ushort4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, z, y);
                }
            }
        }
        public readonly ushort4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, z, z);
                }
            }
        }
        public readonly ushort4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, x, x);
                }
            }
        }
        public readonly ushort4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, x, y);
                }
            }
        }
        public readonly ushort4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, x, z);
                }
            }
        }
        public readonly ushort4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, y, x);
                }
            }
        }
        public readonly ushort4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, y, y);
                }
            }
        }
        public readonly ushort4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, y, z);
                }
            }
        }
        public readonly ushort4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, z, x);
                }
            }
        }
        public readonly ushort4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, z, y);
                }
            }
        }
        public readonly ushort4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, z, z);
                }
            }
        }
        public readonly ushort4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, x, x);
                }
            }
        }
        public readonly ushort4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, x, y);
                }
            }
        }
        public readonly ushort4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, x, z);
                }
            }
        }
        public readonly ushort4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, y, x);
                }
            }
        }
        public readonly ushort4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, y, y);
                }
            }
        }
        public readonly ushort4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, y, z);
                }
            }
        }
        public readonly ushort4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, z, x);
                }
            }
        }
        public readonly ushort4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, z, y);
                }
            }
        }
        public readonly ushort4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, z, z);
                }
            }
        }
        public readonly ushort4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, x,  x);
                }
            }
        }
        public readonly ushort4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, x, y);
                }
            }
        }
        public readonly ushort4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, x, z);
                }
            }
        }
        public readonly ushort4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, y, x);
                }
            }
        }
        public readonly ushort4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, y, y);
                }
            }
        }
        public readonly ushort4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, y, z);
                }
            }
        }
        public readonly ushort4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, z, x);
                }
            }
        }
        public readonly ushort4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, z, y);
                }
            }
        }
        public readonly ushort4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, z, z);
                }
            }
        }
        public readonly ushort4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, x, x);
                }
            }
        }
        public readonly ushort4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, x, y);
                }
            }
        }
        public readonly ushort4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, x, z);
                }
            }
        }
        public readonly ushort4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, y, x);
                }
            }
        }
        public readonly ushort4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, y, y);
                }
            }
        }
        public readonly ushort4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, y, z);
                }
            }
        }
        public readonly ushort4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, z, x);
                }
            }
        }
        public readonly ushort4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, z, y);
                }
            }
        }
        public readonly ushort4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, z, z);
                }
            }
        }
        public readonly ushort4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, x, x);
                }
            }
        }
        public readonly ushort4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, x, y);
                }
            }
        }
        public readonly ushort4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, x, z);
                }
            }
        }
        public readonly ushort4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, y, x);
                }
            }
        }
        public readonly ushort4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, y, y);
                }
            }
        }
        public readonly ushort4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, y, z);
                }
            }
        }
        public readonly ushort4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, z, x);
                }
            }
        }
        public readonly ushort4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, z, y);
                }
            }
        }
        public readonly ushort4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, z, z);
                }
            }
        }
        public readonly ushort4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, x, x);
                }
            }
        }
        public readonly ushort4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, x, y);
                }
            }
        }
        public readonly ushort4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, x, z);
                }
            }
        }
        public readonly ushort4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, y, x);
                }
            }
        }
        public readonly ushort4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, y, y);
                }
            }
        }
        public readonly ushort4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, y, z);
                }
            }
        }
        public readonly ushort4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, z, x);
                }
            }
        }
        public readonly ushort4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, z, y);
                }
            }
        }
        public readonly ushort4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, z, z);
                }
            }
        }
        public readonly ushort4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, x, x);
                }
            }
        }
        public readonly ushort4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, x, y);
                }
            }
        }
        public readonly ushort4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, x, z);
                }
            }
        }
        public readonly ushort4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, y, x);
                }
            }
        }
        public readonly ushort4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, y, y);
                }
            }
        }
        public readonly ushort4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, y, z);
                }
            }
        }
        public readonly ushort4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, z, x);
                }
            }
        }
        public readonly ushort4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, z, y);
                }
            }
        }
        public readonly ushort4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, z, z);
                }
            }
        }
        public readonly ushort4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, x, x);
                }
            }
        }
        public readonly ushort4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, x, y);
                }
            }
        }
        public readonly ushort4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, x, z);
                }
            }
        }
        public readonly ushort4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, y, x);
                }
            }
        }
        public readonly ushort4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, y, y);
                }
            }
        }
        public readonly ushort4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, y, z);
                }
            }
        }
        public readonly ushort4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, z, x);
                }
            }
        }
        public readonly ushort4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, z, y);
                }
            }
        }
        public readonly ushort4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, z, z);
                }
            }
        }

        public readonly ushort3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new ushort3(x, x, x);
                }
            }
        }
        public readonly ushort3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0));
                }
                else
                {
                    return new ushort3(x, x, y);
                }
            }
        }
        public readonly ushort3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0));
                }
                else
                {
                    return new ushort3(x, x, z);
                }
            }
        }
        public readonly ushort3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 0));
                }
                else
                {
                    return new ushort3(x, y, x);
                }
            }
        }
        public readonly ushort3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0));
                }
                else
                {
                    return new ushort3(x, y, y);
                }
            }
        }
        public readonly ushort3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0));
                }
                else
                {
                    return new ushort3(x, z, x);
                }
            }
        }
        public          ushort3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0));
                }
                else
                {
                    return new ushort3(x, z, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.xzy;
            }
        }
        public readonly ushort3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0));
                }
                else
                {
                    return new ushort3(x, z, z);
                }
            }
        }
        public readonly ushort3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1));
                }
                else
                {
                    return new ushort3(y, x, x);
                }
            }
        }
        public readonly ushort3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1));
                }
                else
                {
                    return new ushort3(y, x, y);
                }
            }
        }
        public          ushort3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1));
                }
                else
                {
                    return new ushort3(y, x, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yxz;
            }
        }
        public readonly ushort3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1));
                }
                else
                {
                    return new ushort3(y, y, x);
                }
            }
        }
        public readonly ushort3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1));
                }
                else
                {
                    return new ushort3(y, y, y);
                }
            }
        }
        public readonly ushort3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1));
                }
                else
                {
                    return new ushort3(y, y, z);
                }
            }
        }
        public          ushort3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1));
                }
                else
                {
                    return new ushort3(y, z, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zxy;
            }
        }
        public readonly ushort3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1));
                }
                else
                {
                    return new ushort3(y, z, y);
                }
            }
        }
        public readonly ushort3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1));
                }
                else
                {
                    return new ushort3(y, z, z);
                }
            }
        }
        public readonly ushort3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2));
                }
                else
                {
                    return new ushort3(z, x, x);
                }
            }
        }
        public          ushort3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2));
                }
                else
                {
                    return new ushort3(z, x, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yzx;
            }
        }
        public readonly ushort3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2));
                }
                else
                {
                    return new ushort3(z, x, z);
                }
            }
        }
        public          ushort3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2));
                }
                else
                {
                    return new ushort3(z, y, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zyx;
            }
        }
        public readonly ushort3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2));
                }
                else
                {
                    return new ushort3(z, y, y);
                }
            }
        }
        public readonly ushort3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2));
                }
                else
                {
                    return new ushort3(z, y, z);
                }
            }
        }
        public readonly ushort3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2));
                }
                else
                {
                    return new ushort3(z, z, x);
                }
            }
        }
        public readonly ushort3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2));
                }
                else
                {
                    return new ushort3(z, z, y);
                }
            }
        }
        public readonly ushort3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2));
                }
                else
                {
                    return new ushort3(z, z, z);
                }
            }
        }

        public readonly ushort2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 0));
                }
                else
                {
                    return new ushort2(x, x);
                }
            }
        }
        public          ushort2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return (v128)this;
                }
                else
                {
                    return new ushort2(x, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, value, 0b0011);
                }
                else
                {
                    this.x = value.x;
                    this.y = value.y;
                }
            }
        }
        public          ushort2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0));
                }
                else
                {
                    return new ushort2(x, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, value.xxyy, 0b0101);
                }
                else
                {
                    this.x = value.x;
                    this.z = value.y;
                }
            }
        }
        public          ushort2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
                }
                else
                {
                    return new ushort2(y, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, value.yxyx, 0b0011);
                }
                else
                {
                    this.y = value.x;
                    this.x = value.y;
                }
            }
        }
        public readonly ushort2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
                }
                else
                {
                    return new ushort2(y, y);
                }
            }
        }
        public          ushort2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.bsrli_si128(this, sizeof(ushort));
                }
                else
                {
                    return new ushort2(y, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, Xse.bslli_si128(value, sizeof(ushort)), 0b0110);
                }
                else
                {
                    this.y = value.x;
                    this.z = value.y;
                }
            }
        }
        public          ushort2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2));
                }
                else
                {
                    return new ushort2(z, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, value.yyxx, 0b0101);
                }
                else
                {
                    this.z = value.x;
                    this.x = value.y;
                }
            }
        }
        public          ushort2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2));
                }
                else
                {
                    return new ushort2(z, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    this = Xse.blend_epi16(this, value.yyxx, 0b0110);
                }
                else
                {
                    this.z = value.x;
                    this.y = value.y;
                }
            }
        }
        public readonly ushort2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2));
                }
                else
                {
                    return new ushort2(z, z);
                }
            }
        }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ushort3 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3(v128 input) => RegisterConversion.ToAbstraction128<ushort3>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3(ushort input) => new ushort3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(short3 input) => *(ushort3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(int3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi16(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(uint3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi16(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ushort3(Xse.cvtepi64_epi16(input._xy), (ushort)input.z);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ushort3(Xse.cvtepi64_epi16(input._xy), (ushort)input.z);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu16(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new ushort3((ushort)maxmath.BASE_cvtf16i32(input.x, signed: false, trunc: true),
                                   (ushort)maxmath.BASE_cvtf16i32(input.y, signed: false, trunc: true),
                                   (ushort)maxmath.BASE_cvtf16i32(input.z, signed: false, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(float3 input) => (ushort3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(double3 input) => (ushort3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cvtepu16_epi32(input));
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cvtepu16_epi32(input));
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(ushort3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu16_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new long3((long2)input.xy, (long)input.z);
            }
            else
            {
                return new long3((long)input.x, (long)input.y, (long)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(ushort3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu16_epi64(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
            else
            {
                return new ulong3((ulong)input.x, (ulong)input.y, (ulong)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtepu16_ph(input, (half)float.PositiveInfinity, elements: 3));
            }
            else
            {
                return (half3)(float3)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.cvtepu16_ps(input));
            }
            else
            {
                return (float3)(int3)input;
            }
        }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(ushort3 input) => (double3)(int3)input;


        public ushort this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 4);

                if (constexpr.IS_CONST(index))
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        return Xse.extract_epi16(this, (byte)index);
                    }
                }

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ushort* ptr = &x)
                    {
                        return ptr[index];
                    }
                }
                else
                {
				    return this.GetField<ushort3, ushort>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                if (constexpr.IS_CONST(index))
                {
                    if (BurstArchitecture.IsSIMDSupported)
                    {
                        this = Xse.insert_epi16(this, value, (byte)index);
                    }
                }

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ushort* ptr = &x)
                    {
                        ptr[index] = value;
                    }
                }
                else
                {
                    this.SetField(value, index);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator + (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.add_epi16(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x + right.x), (ushort)(left.y + right.y), (ushort)(left.z + right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sub_epi16(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x - right.x), (ushort)(left.y - right.y), (ushort)(left.z - right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi16(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x * right.x), (ushort)(left.y * right.y), (ushort)(left.z * right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu16(left, right, 3);
            }
            else
            {
                return new ushort3((ushort)(left.x / right.x), (ushort)(left.y / right.y), (ushort)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu16(left, right, 3);
            }
            else
            {
                return new ushort3((ushort)(left.x % right.x), (ushort)(left.y % right.y), (ushort)(left.z % right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort left, ushort3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return (v128)((ushort8)((v128)left) * right);
                }
            }

            return left * (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu16(left, right, 3);
                }
            }

            return left / (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu16(left, right, 3);
                }
            }

            return left % (ushort3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x & right.x), (ushort)(left.y & right.y), (ushort)(left.z & right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.or_si128(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x | right.x), (ushort)(left.y | right.y), (ushort)(left.z | right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.xor_si128(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x ^ right.x), (ushort)(left.y ^ right.y), (ushort)(left.z ^ right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ++ (ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi16(x);
            }
            else
            {
                return new ushort3((ushort)(x.x + 1), (ushort)(x.y + 1), (ushort)(x.z + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator -- (ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi16(x);
            }
            else
            {
                return new ushort3((ushort)(x.x - 1), (ushort)(x.y - 1), (ushort)(x.z - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ~ (ushort3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new ushort3((ushort)(~x.x), (ushort)(~x.y), (ushort)(~x.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator << (ushort3 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.slli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort3((ushort)(x.x << n), (ushort)(x.y << n), (ushort)(x.z << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator >> (ushort3 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi16(x, n, inRange: true);
            }
            else
            {
                return new ushort3((ushort)(x.x >> n), (ushort)(x.y >> n), (ushort)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmpeq_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x == right.x, left.y == right.y, left.z == right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmplt_epu16(left, right, 3));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmpgt_epu16(left, right, 3));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsFalse16(Xse.cmpeq_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x != right.x, left.y != right.y, left.z != right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmple_epu16(left, right, 3));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (ushort3 left, ushort3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmpge_epu16(left, right, 3));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ushort3 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return bitmask64(48ul) == (bitmask64(48ul) & Xse.cmpeq_epi16(this, other).ULong0);
            }
            else
            {
                return this.x == other.x & this.y == other.y & this.z == other.z;
            }
        }

        public override readonly bool Equals(object obj) => obj is ushort3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Hash.v48(this);
            }
            else
            {
                return (x | (y << 16)) ^ (z | (z << 16));
            }
        }


        public override readonly string ToString() => $"ushort3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ushort3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}