using DevTools;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(ushort))]  [DebuggerTypeProxy(typeof(ushort3.DebuggerProxy))]
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


        [FieldOffset(0)] private fixed ushort asArray[3];

        [FieldOffset(0)] public ushort x;
        [FieldOffset(2)] public ushort y;
        [FieldOffset(4)] public ushort z;


        public static ushort3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort x, ushort y, ushort z)
        {
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set_epi16(0, 0, 0, 0, 0, (short)z, (short)y, (short)x);
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
            if (Sse2.IsSse2Supported)
            {
                this = Sse2.set1_epi16((short)xyz);
            }
            else
            {
                this.x = this.y = this.z = xyz;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort3(ushort2 xy, ushort z)
        {
            if (Sse4_1.IsSse41Supported)
            {
                this = Sse2.insert_epi16(xy, z, 2);
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
            if (Sse4_1.IsSse41Supported)
            {
                this = Sse2.insert_epi16(Sse2.bslli_si128(yz, sizeof(ushort)), x, 0);
            }
            else
            {
                this.x = x;
                this.y = yz.x;
                this.z = yz.y;
            }
        }


        #region Shuffle
        public ushort4 xxxx
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
                    return new ushort4(x, x, x, x);
                }
            }
        }
        public ushort4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, x, y);
                }
            }
        }
        public ushort4 xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, x, z);
                }
            }
        }
        public ushort4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, y, x);
                }
            }
        }
        public ushort4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, y, y);
                }
            }
        }
        public ushort4 xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, y,z);
                }
            }
        }
        public ushort4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, z, x);
                }
            }
        }
        public ushort4 xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, z, y);
                }
            }
        }
        public ushort4 xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 0));
                }
                else
                {
                    return new ushort4(x, x, z, z);
                }
            }
        }
        public ushort4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, x, x);
                }
            }
        }
        public ushort4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, x, y);
                }
            }
        }
        public ushort4 xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, x, z);
                }
            }
        }
        public ushort4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, y, x);
                }
            }
        }
        public ushort4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, y, y);
                }
            }
        }
        public ushort4 xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, y, z);
                }
            }
        }
        public ushort4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, z, x);
                }
            }
        }
        public ushort4 xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, z, y);
                }
            }
        }
        public ushort4 xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 0));
                }
                else
                {
                    return new ushort4(x, y, z, z);
                }
            }
        }
        public ushort4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, x, x);
                }
            }
        }
        public ushort4 xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, x, y);
                }
            }
        }
        public ushort4 xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, x, z);
                }
            }
        }
        public ushort4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, y, x);
                }
            }
        }
        public ushort4 xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, y, y);
                }
            }
        }
        public ushort4 xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, y, z);
                }
            }
        }
        public ushort4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, z, x);
                }
            }
        }
        public ushort4 xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, z, y);
                }
            }
        }
        public ushort4 xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 0));
                }
                else
                {
                    return new ushort4(x, z, z, z);
                }
            }
        }
        public ushort4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, x,  x);
                }
            }
        }
        public ushort4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, x, y);
                }
            }
        }
        public ushort4 yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, x, z);
                }
            }
        }
        public ushort4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, y, x);
                }
            }
        }
        public ushort4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, y, y);
                }
            }
        }
        public ushort4 yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, y, z);
                }
            }
        }
        public ushort4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, z, x);
                }
            }
        }
        public ushort4 yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, z, y);
                }
            }
        }
        public ushort4 yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 1));
                }
                else
                {
                    return new ushort4(y, x, z, z);
                }
            }
        }
        public ushort4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, x, x);
                }
            }
        }
        public ushort4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, x, y);
                }
            }
        }
        public ushort4 yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, x, z);
                }
            }
        }
        public ushort4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, y, x);
                }
            }
        }
        public ushort4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, y, y);
                }
            }
        }
        public ushort4 yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, y, z);
                }
            }
        }
        public ushort4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, z, x);
                }
            }
        }
        public ushort4 yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, z, y);
                }
            }
        }
        public ushort4 yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 1));
                }
                else
                {
                    return new ushort4(y, y, z, z);
                }
            }
        }
        public ushort4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, x, x);
                }
            }
        }
        public ushort4 yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, x, y);
                }
            }
        }
        public ushort4 yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, x, z);
                }
            }
        }
        public ushort4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, y, x);
                }
            }
        }
        public ushort4 yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, y, y);
                }
            }
        }
        public ushort4 yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, y, z);
                }
            }
        }
        public ushort4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, z, x);
                }
            }
        }
        public ushort4 yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                { 
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, z, y);
                }
            }
        }
        public ushort4 yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 1));
                }
                else
                {
                    return new ushort4(y, z, z, z);
                }
            }
        }
        public ushort4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, x, x);
                }
            }
        }
        public ushort4 zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, x, y);
                }
            }
        }
        public ushort4 zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, x, z);
                }
            }
        }
        public ushort4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, y, x);
                }
            }
        }
        public ushort4 zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, y, y);
                }
            }
        }
        public ushort4 zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, y, z);
                }
            }
        }
        public ushort4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, z, x);
                }
            }
        }
        public ushort4 zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, z, y);
                }
            }
        }
        public ushort4 zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 0, 2));
                }
                else
                {
                    return new ushort4(z, x, z, z);
                }
            }
        }
        public ushort4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, x, x);
                }
            }
        }
        public ushort4 zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, x, y);
                }
            }
        }
        public ushort4 zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, x, z);
                }
            }
        }
        public ushort4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, y, x);
                }
            }
        }
        public ushort4 zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, y, y);
                }
            }
        }
        public ushort4 zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, y, z);
                }
            }
        }
        public ushort4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, z, x);
                }
            }
        }
        public ushort4 zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, z, y);
                }
            }
        }
        public ushort4 zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 1, 2));
                }
                else
                {
                    return new ushort4(z, y, z, z);
                }
            }
        }
        public ushort4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 0, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, x, x);
                }
            }
        }
        public ushort4 zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 0, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, x, y);
                }
            }
        }
        public ushort4 zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 0, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, x, z);
                }
            }
        }
        public ushort4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 1, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, y, x);
                }
            }
        }
        public ushort4 zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 1, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, y, y);
                }
            }
        }
        public ushort4 zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 1, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, y, z);
                }
            }
        }
        public ushort4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(0, 2, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, z, x);
                }
            }
        }
        public ushort4 zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(1, 2, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, z, y);
                }
            }
        }
        public ushort4 zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(2, 2, 2, 2));
                }
                else
                {
                    return new ushort4(z, z, z, z);
                }
            }
        }

        public ushort3 xxx
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
                    return new ushort3(x, x, x);
                }
            }
        }
        public ushort3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 0));
                }
                else
                {
                    return new ushort3(x, x, y);
                }
            }
        }
        public ushort3 xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 0));
                }
                else
                {
                    return new ushort3(x, x, z);
                }
            }
        }
        public ushort3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 0));
                }
                else
                {
                    return new ushort3(x, y, x);
                }
            }
        }
        public ushort3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 0));
                }
                else
                {
                    return new ushort3(x, y, y);
                }
            }
        }
        public ushort3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 0));
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0));
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
        public ushort3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 0));
                }
                else
                {
                    return new ushort3(x, z, z);
                }
            }
        }
        public ushort3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 1));
                }
                else
                {
                    return new ushort3(y, x, x);
                }
            }
        }
        public ushort3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 1));
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1));
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
        public ushort3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 1));
                }
                else
                {
                    return new ushort3(y, y, x);
                }
            }
        }
        public ushort3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 1));
                }
                else
                {
                    return new ushort3(y, y, y);
                }
            }
        }
        public ushort3 yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 1));
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1));
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
        public ushort3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 1));
                }
                else
                {
                    return new ushort3(y, z, y);
                }
            }
        }
        public ushort3 yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 1));
                }
                else
                {
                    return new ushort3(y, z, z);
                }
            }
        }
        public ushort3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 0, 2));
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2));
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
        public ushort3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 2));
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2));
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
        public ushort3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 1, 2));
                }
                else
                {
                    return new ushort3(z, y, y);
                }
            }
        }
        public ushort3 zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 1, 2));
                }
                else
                {
                    return new ushort3(z, y, z);
                }
            }
        }
        public ushort3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 2));
                }
                else
                {
                    return new ushort3(z, z, x);
                }
            }
        }
        public ushort3 zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 2));
                }
                else
                {
                    return new ushort3(z, z, y);
                }
            }
        }
        public ushort3 zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 2, 2));
                }
                else
                {
                    return new ushort3(z, z, z);
                }
            }
        }

        public ushort2 xx
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
                    return new ushort2(x, x);
                }
            }
        }
        public          ushort2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, value, 0b0011);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, value, 0b0011);
                    }
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0));
                }
                else
                {
                    return new ushort2(x, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, value.xxyy, 0b0101);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, value.xxyy, 0b0101);
                    }
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
                }
                else
                {
                    return new ushort2(y, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, value.yxyx, 0b0011);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, value.yxyx, 0b0011);
                    }
                }
                else
                {
                    this.y = value.x;
                    this.x = value.y;
                }
            }
        }
        public ushort2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 1));
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, sizeof(ushort));
                }
                else
                {
                    return new ushort2(y, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, Sse2.bslli_si128(value, sizeof(ushort)), 0b0110);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, Sse2.bslli_si128(value, sizeof(ushort)), 0b0110);
                    }
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2));
                }
                else
                {
                    return new ushort2(z, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, value.yyxx, 0b0101);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, value.yyxx, 0b0101);
                    }
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
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2));
                }
                else
                {
                    return new ushort2(z, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    if (Sse4_1.IsSse41Supported)
                    {
                        this = Sse4_1.blend_epi16(this, value.yyxx, 0b0110);
                    }
                    else
                    {
                        this = Mask.BlendEpi16_SSE2(this, value.yyxx, 0b0110);
                    }
                }
                else
                {
                    this.z = value.x;
                    this.y = value.y;
                }
            }
        }
        public ushort2 zz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 2));
                }
                else
                {
                    return new ushort2(z, z);
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ushort3 input)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return Sse2.insert_epi16(Sse4_1.insert_epi32(default(v128), *(int*)&input, 0), input.z, 2);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Sse2.set_epi64x(0, *(long*)&input);
            }
            else
            {
                return new v128(*(long*)&input, 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)] 
        public static implicit operator ushort3(v128 input) => new ushort3 { x = input.UShort0, y = input.UShort1, z = input.UShort2 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3(ushort input) => new ushort3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(short3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(ushort3*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(int3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToShort4(*(v128*)&input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Int3To_U_Short3_SSE2(*(v128*)&input);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(uint3 input)
        {
            if (Ssse3.IsSsse3Supported)
            {
                return Cast.Int4ToShort4(*(v128*)&input);
            }
            else if (Sse2.IsSse2Supported)
            {
                return Cast.Int3To_U_Short3_SSE2(*(v128*)&input);
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
                return Cast.Long4ToShort4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new ushort3(Cast.Long2ToShort2(input._xy), (ushort)input.z);
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
                return Cast.Long4ToShort4(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new ushort3(Cast.Long2ToShort2(input._xy), (ushort)input.z);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(half3 input) => (ushort3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(float3 input) => (ushort3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ushort3(double3 input) => (ushort3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(ushort3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.UShortToInt(input);

                return *(int3*)&temp;
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(ushort3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 temp = Cast.UShortToInt(input);

                return *(uint3*)&temp;
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
        public static implicit operator ulong3(ushort3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu16_epi64(input);
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
        public static explicit operator half3(ushort3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(ushort3 input) 
        {
            return (float3)(int3)input;
        }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(ushort3 input) => (double3)(int3)input;


        public ushort this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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
        public static ushort3 operator + (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x + right.x), (ushort)(left.y + right.y), (ushort)(left.z + right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator - (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x - right.x), (ushort)(left.y - right.y), (ushort)(left.z - right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator * (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.mullo_epi16(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x * right.x), (ushort)(left.y * right.y), (ushort)(left.z * right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vdiv_ushort(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x / right.x), (ushort)(left.y / right.y), (ushort)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.vrem_ushort(left, right);
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
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return (v128)((ushort8)((v128)left) * right);
                }
            }

            return left * (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator / (ushort3 left, ushort right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return (v128)((ushort8)((v128)left) / right);
                }
            }

            return left / (ushort3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator % (ushort3 left, ushort right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return (v128)((ushort8)((v128)left) % right);
                }
            }

            return left % (ushort3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator & (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x & right.x), (ushort)(left.y & right.y), (ushort)(left.z & right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator | (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x | right.x), (ushort)(left.y | right.y), (ushort)(left.z | right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ^ (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new ushort3((ushort)(left.x ^ right.x), (ushort)(left.y ^ right.y), (ushort)(left.z ^ right.z));
            }
        }
    

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ++ (ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new ushort3((ushort)(x.x + 1), (ushort)(x.y + 1), (ushort)(x.z + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator -- (ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new ushort3((ushort)(x.x - 1), (ushort)(x.y - 1), (ushort)(x.z - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator ~ (ushort3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(x, Sse2.cmpeq_epi32(default(v128), default(v128)));
            }
            else
            {
                return new ushort3((ushort)(~x.x), (ushort)(~x.y), (ushort)(~x.z));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator << (ushort3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shl_short(x, n);
            }
            else
            {
                return new ushort3((ushort)(x.x << n), (ushort)(x.y << n), (ushort)(x.z << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 operator >> (ushort3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Operator.shrl_short(x, n);
            }
            else
            {
                return new ushort3((ushort)(x.x >> n), (ushort)(x.y >> n), (ushort)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool3(left.x == right.x, left.y == right.y, left.z == right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_ushort(right, left));
            }
            else
            {
                return new bool3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsTrue(Operator.greater_mask_ushort(left, right));
            }
            else
            {
                return new bool3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (ushort3 left, ushort3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Sse2.cmpeq_epi16(left, right));
            }
            else
            {
                return new bool3(left.x != right.x, left.y != right.y, left.z != right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (ushort3 left, ushort3 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi16(Sse4_1.min_epu16(left, right), left));
            }
            else if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Operator.greater_mask_ushort(left, right));
            }
            else
            {
                return new bool3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (ushort3 left, ushort3 right)
        {
            if (Sse4_1.IsSse41Supported)
            {
                return TestIsTrue(Sse2.cmpeq_epi16(Sse4_1.max_epu16(left, right), left));
            }
            else if (Sse2.IsSse2Supported)
            {
                return TestIsFalse(Operator.greater_mask_ushort(right, left));
            }
            else
            {
                return new bool3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsTrue(v128 input)
        {
            input = (v128)((byte8)(-(short8)input));

            return *(bool3*)&input;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool3 TestIsFalse(v128 input) 
        {
            if (Sse2.IsSse2Supported)
            {
                input = Sse2.andnot_si128((byte3)(ushort3)input, new ushort4(0x0101));

                return *(bool3*)&input;
            }
            else throw new CPUFeatureCheckException();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ushort3 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return maxmath.bitmask64(48ul) == (maxmath.bitmask64(48ul) & Sse2.cmpeq_epi16(this, other).ULong0);
            }
            else
            {
                return this.x == other.x & this.y == other.y & this.z == other.z;
            }
        }

        public override bool Equals(object obj) => Equals((ushort3)obj);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v48(this);
            }
            else
            {
                return (x | (y << 16)) ^ (z | (z << 16));
            }
        }


        public override string ToString() => $"ushort3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ushort3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}