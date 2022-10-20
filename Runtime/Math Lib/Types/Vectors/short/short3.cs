using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using Unity.Burst.CompilerServices;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.maxmath;

namespace MaxMath
{
    [Serializable] 
    [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(short))] 
    [DebuggerTypeProxy(typeof(short3.DebuggerProxy))]
    unsafe public struct short3 : IEquatable<short3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public short x;
            public short y;
            public short z;

            public DebuggerProxy(short3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)] public short x;
        [FieldOffset(2)] public short y;
        [FieldOffset(4)] public short z;


        public static short3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short x, short y, short z)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(x) && Constant.IsConstantExpression(y) && Constant.IsConstantExpression(z))
                {
                    this = Sse2.cvtsi64x_si128((long)maxmath.bitfield(x, y, z, (short)0));
                }
                else
                {
                    this = Sse2.set_epi16(0, 0, 0, 0, 0, z, y, x);
                }
            }
            else
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short xyz)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(xyz))
                {
                    this = Sse2.cvtsi64x_si128((long)maxmath.bitfield(xyz, xyz, xyz, (short)0));
                }
                else
                {
				    this = Sse2.shufflelo_epi16(Sse2.cvtsi32_si128((ushort)xyz), Sse.SHUFFLE(0, 0, 0, 0));
                }
            }
            else
            {
                this.x = this.y = this.z = xyz;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short2 xy, short z)
        {
            if (Sse4_1.IsSse41Supported)
            {
                this = Xse.insert_epi16(xy, (ushort)z, 2);
            }
            else
            {
                this.x = xy.x;
                this.y = xy.y;
                this.z = z;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public short3(short x, short2 yz)
        {
            if (Sse4_1.IsSse41Supported)
            {
                this = Xse.insert_epi16(Sse2.bslli_si128(yz, sizeof(short)), (ushort)x, 0);
            }
            else
            {
                this.x = x;
                this.y = yz.x;
                this.z = yz.y;
            }
        }


        #region Shuffle
        public readonly short4 xxxx
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
                    return new short4(x, x, x, x);
                }
            }
        }
        public readonly short4 xxxy
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
                    return new short4(x, x, x, y);
                }
            }
        }
        public readonly short4 xxxz
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
                    return new short4(x, x, x, z);
                }
            }
        }
        public readonly short4 xxyx
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
                    return new short4(x, x, y, x);
                }
            }
        }
        public readonly short4 xxyy
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
                    return new short4(x, x, y, y);
                }
            }
        }
        public readonly short4 xxyz
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
                    return new short4(x, x, y,z);
                }
            }
        }
        public readonly short4 xxzx
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
                    return new short4(x, x, z, x);
                }
            }
        }
        public readonly short4 xxzy
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
                    return new short4(x, x, z, y);
                }
            }
        }
        public readonly short4 xxzz
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
                    return new short4(x, x, z, z);
                }
            }
        }
        public readonly short4 xyxx
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
                    return new short4(x, y, x, x);
                }
            }
        }
        public readonly short4 xyxy
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
                    return new short4(x, y, x, y);
                }
            }
        }
        public readonly short4 xyxz
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
                    return new short4(x, y, x, z);
                }
            }
        }
        public readonly short4 xyyx
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
                    return new short4(x, y, y, x);
                }
            }
        }
        public readonly short4 xyyy
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
                    return new short4(x, y, y, y);
                }
            }
        }
        public readonly short4 xyyz
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
                    return new short4(x, y, y, z);
                }
            }
        }
        public readonly short4 xyzx
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
                    return new short4(x, y, z, x);
                }
            }
        }
        public readonly short4 xyzy
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
                    return new short4(x, y, z, y);
                }
            }
        }
        public readonly short4 xyzz
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
                    return new short4(x, y, z, z);
                }
            }
        }
        public readonly short4 xzxx
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
                    return new short4(x, z, x, x);
                }
            }
        }
        public readonly short4 xzxy
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
                    return new short4(x, z, x, y);
                }
            }
        }
        public readonly short4 xzxz
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
                    return new short4(x, z, x, z);
                }
            }
        }
        public readonly short4 xzyx
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
                    return new short4(x, z, y, x);
                }
            }
        }
        public readonly short4 xzyy
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
                    return new short4(x, z, y, y);
                }
            }
        }
        public readonly short4 xzyz
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
                    return new short4(x, z, y, z);
                }
            }
        }
        public readonly short4 xzzx
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
                    return new short4(x, z, z, x);
                }
            }
        }
        public readonly short4 xzzy
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
                    return new short4(x, z, z, y);
                }
            }
        }
        public readonly short4 xzzz
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
                    return new short4(x, z, z, z);
                }
            }
        }
        public readonly short4 yxxx
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
                    return new short4(y, x, x,  x);
                }
            }
        }
        public readonly short4 yxxy
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
                    return new short4(y, x, x, y);
                }
            }
        }
        public readonly short4 yxxz
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
                    return new short4(y, x, x, z);
                }
            }
        }
        public readonly short4 yxyx
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
                    return new short4(y, x, y, x);
                }
            }
        }
        public readonly short4 yxyy
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
                    return new short4(y, x, y, y);
                }
            }
        }
        public readonly short4 yxyz
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
                    return new short4(y, x, y, z);
                }
            }
        }
        public readonly short4 yxzx
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
                    return new short4(y, x, z, x);
                }
            }
        }
        public readonly short4 yxzy
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
                    return new short4(y, x, z, y);
                }
            }
        }
        public readonly short4 yxzz
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
                    return new short4(y, x, z, z);
                }
            }
        }
        public readonly short4 yyxx
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
                    return new short4(y, y, x, x);
                }
            }
        }
        public readonly short4 yyxy
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
                    return new short4(y, y, x, y);
                }
            }
        }
        public readonly short4 yyxz
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
                    return new short4(y, y, x, z);
                }
            }
        }
        public readonly short4 yyyx
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
                    return new short4(y, y, y, x);
                }
            }
        }
        public readonly short4 yyyy
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
                    return new short4(y, y, y, y);
                }
            }
        }
        public readonly short4 yyyz
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
                    return new short4(y, y, y, z);
                }
            }
        }
        public readonly short4 yyzx
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
                    return new short4(y, y, z, x);
                }
            }
        }
        public readonly short4 yyzy
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
                    return new short4(y, y, z, y);
                }
            }
        }
        public readonly short4 yyzz
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
                    return new short4(y, y, z, z);
                }
            }
        }
        public readonly short4 yzxx
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
                    return new short4(y, z, x, x);
                }
            }
        }
        public readonly short4 yzxy
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
                    return new short4(y, z, x, y);
                }
            }
        }
        public readonly short4 yzxz
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
                    return new short4(y, z, x, z);
                }
            }
        }
        public readonly short4 yzyx
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
                    return new short4(y, z, y, x);
                }
            }
        }
        public readonly short4 yzyy
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
                    return new short4(y, z, y, y);
                }
            }
        }
        public readonly short4 yzyz
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
                    return new short4(y, z, y, z);
                }
            }
        }
        public readonly short4 yzzx
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
                    return new short4(y, z, z, x);
                }
            }
        }
        public readonly short4 yzzy
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
                    return new short4(y, z, z, y);
                }
            }
        }
        public readonly short4 yzzz
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
                    return new short4(y, z, z, z);
                }
            }
        }
        public readonly short4 zxxx
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
                    return new short4(z, x, x, x);
                }
            }
        }
        public readonly short4 zxxy
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
                    return new short4(z, x, x, y);
                }
            }
        }
        public readonly short4 zxxz
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
                    return new short4(z, x, x, z);
                }
            }
        }
        public readonly short4 zxyx
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
                    return new short4(z, x, y, x);
                }
            }
        }
        public readonly short4 zxyy
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
                    return new short4(z, x, y, y);
                }
            }
        }
        public readonly short4 zxyz
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
                    return new short4(z, x, y, z);
                }
            }
        }
        public readonly short4 zxzx
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
                    return new short4(z, x, z, x);
                }
            }
        }
        public readonly short4 zxzy
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
                    return new short4(z, x, z, y);
                }
            }
        }
        public readonly short4 zxzz
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
                    return new short4(z, x, z, z);
                }
            }
        }
        public readonly short4 zyxx
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
                    return new short4(z, y, x, x);
                }
            }
        }
        public readonly short4 zyxy
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
                    return new short4(z, y, x, y);
                }
            }
        }
        public readonly short4 zyxz
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
                    return new short4(z, y, x, z);
                }
            }
        }
        public readonly short4 zyyx
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
                    return new short4(z, y, y, x);
                }
            }
        }
        public readonly short4 zyyy
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
                    return new short4(z, y, y, y);
                }
            }
        }
        public readonly short4 zyyz
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
                    return new short4(z, y, y, z);
                }
            }
        }
        public readonly short4 zyzx
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
                    return new short4(z, y, z, x);
                }
            }
        }
        public readonly short4 zyzy
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
                    return new short4(z, y, z, y);
                }
            }
        }
        public readonly short4 zyzz
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
                    return new short4(z, y, z, z);
                }
            }
        }
        public readonly short4 zzxx
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
                    return new short4(z, z, x, x);
                }
            }
        }
        public readonly short4 zzxy
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
                    return new short4(z, z, x, y);
                }
            }
        }
        public readonly short4 zzxz
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
                    return new short4(z, z, x, z);
                }
            }
        }
        public readonly short4 zzyx
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
                    return new short4(z, z, y, x);
                }
            }
        }
        public readonly short4 zzyy
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
                    return new short4(z, z, y, y);
                }
            }
        }
        public readonly short4 zzyz
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
                    return new short4(z, z, y, z);
                }
            }
        }
        public readonly short4 zzzx
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
                    return new short4(z, z, z, x);
                }
            }
        }
        public readonly short4 zzzy
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
                    return new short4(z, z, z, y);
                }
            }
        }
        public readonly short4 zzzz
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
                    return new short4(z, z, z, z);
                }
            }
        }

        public readonly short3 xxx
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
                    return new short3(x, x, x);
                }
            }
        }
        public readonly short3 xxy
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
                    return new short3(x, x, y);
                }
            }
        }
        public readonly short3 xxz
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
                    return new short3(x, x, z);
                }
            }
        }
        public readonly short3 xyx
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
                    return new short3(x, y, x);
                }
            }
        }
        public readonly short3 xyy
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
                    return new short3(x, y, y);
                }
            }
        }
        public readonly short3 xzx
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
                    return new short3(x, z, x);
                }
            }
        }
        public          short3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 2, 0));
                }
                else
                {
                    return new short3(x, z, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.xzy;
            }
        }
        public readonly short3 xzz
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
                    return new short3(x, z, z);
                }
            }
        }
        public readonly short3 yxx
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
                    return new short3(y, x, x);
                }
            }
        }
        public readonly short3 yxy
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
                    return new short3(y, x, y);
                }
            }
        }
        public          short3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 2, 0, 1));
                }
                else
                {
                    return new short3(y, x, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yxz;
            }
        }
        public readonly short3 yyx
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
                    return new short3(y, y, x);
                }
            }
        }
        public readonly short3 yyy
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
                    return new short3(y, y, y);
                }
            }
        }
        public readonly short3 yyz
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
                    return new short3(y, y, z);
                }
            }
        }
        public          short3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 2, 1));
                }
                else
                {
                    return new short3(y, z, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zxy;
            }
        }
        public readonly short3 yzy
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
                    return new short3(y, z, y);
                }
            }
        }
        public readonly short3 yzz
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
                    return new short3(y, z, z);
                }
            }
        }
        public readonly short3 zxx
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
                    return new short3(z, x, x);
                }
            }
        }
        public          short3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 1, 0, 2));
                }
                else
                {
                    return new short3(z, x, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yzx;
            }
        }
        public readonly short3 zxz
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
                    return new short3(z, x, z);
                }
            }
        }
        public          short3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 0, 1, 2));
                }
                else
                {
                    return new short3(z, y, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.zyx;
            }
        }
        public readonly short3 zyy
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
                    return new short3(z, y, y);
                }
            }
        }
        public readonly short3 zyz
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
                    return new short3(z, y, z);
                }
            }
        }
        public readonly short3 zzx
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
                    return new short3(z, z, x);
                }
            }
        }
        public readonly short3 zzy
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
                    return new short3(z, z, y);
                }
            }
        }
        public readonly short3 zzz
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
                    return new short3(z, z, z);
                }
            }
        }

        public readonly short2 xx
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
                    return new short2(x, x);
                }
            }
        }
        public          short2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return (v128)this;
                }
                else
                {
                    return new short2(x, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
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
        public          short2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 2, 0));
                }
                else
                {
                    return new short2(x, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
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
        public          short2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 1));
                }
                else
                {
                    return new short2(y, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
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
        public readonly short2 yy
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
                    return new short2(y, y);
                }
            }
        }
        public          short2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.bsrli_si128(this, sizeof(short));
                }
                else
                {
                    return new short2(y, z);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
                {
                    this = Xse.blend_epi16(this, Sse2.bslli_si128(value, sizeof(short)), 0b0110);
                }
                else
                {
                    this.y = value.x;
                    this.z = value.y;
                } 
            }
        }
        public          short2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 0, 2));
                }
                else
                {
                    return new short2(z, x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
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
        public          short2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
                {
                    return Sse2.shufflelo_epi16(this, Sse.SHUFFLE(3, 3, 1, 2));
                }
                else
                {
                    return new short2(z, y);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Sse2.IsSse2Supported)
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
        public readonly short2 zz
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
                    return new short2(z, z);
                }
            }
        }
        #endregion

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(short3 input)
        {
            v128 result;

            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                v128* dummyPtr = &result;
            }

            result.SShort0 = input.x;
            result.SShort1 = input.y;
            result.SShort2 = input.z;
            
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(v128 input) => new short3 { x = input.SShort0, y = input.SShort1, z = input.SShort2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(short input) => new short3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(ushort3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(short3*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(int3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi16(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(uint3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi16(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(long3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new short3(Xse.cvtepi64_epi16(input._xy), (short)input.z);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi16(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new short3(Xse.cvtepi64_epi16(input._xy), (short)input.z);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(half3 input) => (short3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(float3 input) => (short3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator short3(double3 input) => (short3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(short3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(short3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.cvtepi16_epi32(input));
            }
            else
            {
                return new uint3((uint)input.x, (uint)input.y, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long3(short3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
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
        public static explicit operator ulong3(short3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi16_epi64(input);
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
        public static implicit operator half3(short3 input) => (half3)(float3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(short3 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToFloat3(Xse.cvtepi16_ps(input));
            }
            else
            {
                return (float3)(int3)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(short3 input) => (double3)(int3)input;


        public short this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 3);

                if (Sse2.IsSse2Supported)
                {
                    return (short)Xse.extract_epi16(this, (byte)index);
                }
                else
                {
                    short3 onStack = this;

                    return *((short*)&onStack + index);
                }
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                if (Sse2.IsSse2Supported)
                {
                    this = Xse.insert_epi16(this, (ushort)value, (byte)index);
                }
                else
                {
                    short3 onStack = this;
                    *((short*)&onStack + index) = value;
                    this = onStack;
                }
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator + (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi16(left, right);
            }
            else
            {
                return new short3((short)(left.x + right.x), (short)(left.y + right.y), (short)(left.z + right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi16(left, right);
            }
            else
            {
                return new short3((short)(left.x - right.x), (short)(left.y - right.y), (short)(left.z - right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.mullo_epi16(left, right);
            }
            else
            {
                return new short3((short)(left.x * right.x), (short)(left.y * right.y), (short)(left.z * right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.div_epi16(left, right, false, 3);
            }
            else
            {
                return new short3((short)(left.x / right.x), (short)(left.y / right.y), (short)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rem_epi16(left, right, 3);
            }
            else
            {
                return new short3((short)(left.x % right.x), (short)(left.y % right.y), (short)(left.z % right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short left, short3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator * (short3 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return (v128)((short8)((v128)left) * right);
                }
            }

            return left * (short3)right;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator / (short3 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.div_epi16(left, right, 3);
                }
            }
                
            return left / (short3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator % (short3 left, short right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.rem_epi16(left, right, 3);
                }
            }
                
            return left % (short3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator & (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new short3((short)(left.x & right.x), (short)(left.y & right.y), (short)(left.z & right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator | (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new short3((short)(left.x | right.x), (short)(left.y | right.y), (short)(left.z | right.z));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ^ (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new short3((short)(left.x ^ right.x), (short)(left.y ^ right.y), (short)(left.z ^ right.z));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator - (short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.neg_epi16(x);
            }
            else
            {
                return new short3((short)-x.x, (short)-x.y, (short)-x.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ++ (short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.inc_epi16(x);
            }
            else
            {
                return new short3((short)(x.x + 1), (short)(x.y + 1), (short)(x.z + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator -- (short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.dec_epi16(x);
            }
            else
            {
                return new short3((short)(x.x - 1), (short)(x.y - 1), (short)(x.z - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator ~ (short3 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new short3((short)(~x.x), (short)(~x.y), (short)(~x.z));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator << (short3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.slli_epi16(x, n);
            }
            else
            {
                return new short3((short)(x.x << n), (short)(x.y << n), (short)(x.z << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 operator >> (short3 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srai_epi16(x, n);
            }
            else
            {
                return new short3((short)(x.x >> n), (short)(x.y >> n), (short)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue16(Sse2.cmpeq_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x == right.x, left.y == right.y, left.z == right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue16(Xse.cmplt_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsTrue16(Sse2.cmpgt_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsFalse16(Sse2.cmpeq_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x != right.x, left.y != right.y, left.z != right.z);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsFalse16(Sse2.cmpgt_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (short3 left, short3 right)
        {
            if (Sse2.IsSse2Supported)
            {
                v128 results = RegisterConversion.IsFalse16(Xse.cmplt_epi16(left, right));

				return *(bool3*)&results;
            }
            else
            {
                return new bool3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(short3 other)
        {
            if (Sse2.IsSse2Supported)
            {
                return bitmask64(48ul) == (bitmask64(48ul) & Sse2.cmpeq_epi16(this, other).ULong0);
            }
            else
            {
                return this.x == other.x & this.y == other.y & this.z == other.z;
            }
        }

        public override readonly bool Equals(object obj) => obj is short3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Sse2.IsSse2Supported)
            {
                return Hash.v48(this);
            }
            else
            {
                return ((int)x | ((int)y << 16)) ^ ((int)z | ((int)z << 16));
            }
        }


        public override readonly string ToString() => $"short3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"short3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}