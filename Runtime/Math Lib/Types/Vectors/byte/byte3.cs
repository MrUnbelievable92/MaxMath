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
    [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(byte))]
    [DebuggerTypeProxy(typeof(byte3.DebuggerProxy))]
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


        [FieldOffset(0)] public byte x;
        [FieldOffset(1)] public byte y;
        [FieldOffset(2)] public byte z;


        public static byte3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte x, byte y, byte z)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)z, (sbyte)y, (sbyte)x);
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set1_epi8(xyz, 3);
            }
            else
            {
                this.x = this.y = this.z = xyz;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte2 xy, byte z)
        {
            if (BurstArchitecture.IsInsertExtractSupported)
            {
                this = Xse.insert_epi8(xy, z, 2);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                v128 _z = Xse.cvtsi32_si128(z);

                this = Xse.unpacklo_epi16(xy, _z);
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
            if (BurstArchitecture.IsInsertExtractSupported)
            {
                this = Xse.insert_epi8(Xse.bslli_si128(yz, sizeof(byte)), x, 0);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.or_si128(Xse.bslli_si128(yz, sizeof(byte)), Xse.cvtsi32_si128(x));
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxxx(this);
                }
                else
                {
                    return new byte4(y, x, x, x);
                }
            }
        }
        public readonly byte4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyy(this);
                }
                else
                {
                    return new byte3(x, y, y);
                }
            }
        }
		public byte3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyz(this);
                }
				else
				{
					return new byte3(x, y, z);
				}
			}

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value, new byte4(255, 255, 255, 0));
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
		}
		public readonly byte3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzy(this);
                }
                else
                {
                    return new byte3(x, z, y);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value.xzyy, new byte4(255, 255, 255, 0));
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
        }
        public readonly byte3 xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxz(this);
                }
                else
                {
                    return new byte3(y, x, z);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value.yxzz, new byte4(255, 255, 255, 0));
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
        }
		public readonly byte3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzx(this);
                }
                else
                {
                    return new byte3(y, z, x);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value.zxyy, new byte4(255, 255, 255, 0));
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
        }
        public readonly byte3 yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxy(this);
                }
                else
                {
                    return new byte3(z, x, y);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value.yzxx, new byte4(255, 255, 255, 0));
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
        }
        public readonly byte3 zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyx(this);
                }
                else
                {
                    return new byte3(z, y, x);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value.zyxx, new byte4(255, 255, 255, 0));
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
        }
        public readonly byte3 zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzz(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xx(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xy(this);
                }
                else
                {
                    return new byte2(x, y);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blend_epi16(this, value, 0b01);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xz(this);
                }
                else
                {
                    return new byte2(x, z);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value.xxyy, new byte4(255, 0, 255, 0));
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yx(this);
                }
                else
                {
                    return new byte2(y, x);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blend_epi16(this, value.yx, 0b01);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yy(this);
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yz(this);
                }
                else
                {
                    return new byte2(y, z);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value.xxyy, new byte4(0, 255, 255, 0));
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zx(this);
                }
                else
                {
                    return new byte2(z, x);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value.yyxx, new byte4(255, 0, 255, 0));
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zy(this);
                }
                else
                {
                    return new byte2(z, y);
                }
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.blendv_si128(this, value.yyxx, new byte4(0, 255, 255, 0));
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
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zz(this);
                }
                else
                {
                    return new byte2(z, z);
                }
            }
        }
		#endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte3 input) => RegisterConversion.ToRegister128(input);
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte3(v128 input) => RegisterConversion.ToAbstraction128<byte3>(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte3(byte input) => new byte3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(sbyte3 input) => *(byte3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(short3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi8(input, 3);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(ushort3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi16_epi8(input, 3);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(int3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(uint3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 3);
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
                return Xse.mm256_cvtepi64_epi8(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new byte3(Xse.cvtepi64_epi8(input._xy), (byte)input.z);
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
                return Xse.mm256_cvtepi64_epi8(input);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new byte3(Xse.cvtepi64_epi8(input._xy), (byte)input.z);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(half3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttph_epu8(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new byte3((byte)maxmath.BASE_cvtf16i32(input.x, signed: false, trunc: true),
                                 (byte)maxmath.BASE_cvtf16i32(input.y, signed: false, trunc: true),
                                 (byte)maxmath.BASE_cvtf16i32(input.z, signed: false, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(float3 input) => (byte3)(int3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(double3 input) => (byte3)(int3)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short3(byte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi16(input);
            }
            else
            {
                return new short3((short)input.x, (short)input.y, (short)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort3(byte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_epi16(input);
            }
            else
            {
                return new ushort3((ushort)input.x, (ushort)input.y, (ushort)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(byte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToInt3(Xse.cvtepu8_epi32(input));
            }
            else
            {
                return new int3((int)input.x, (int)input.y, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(byte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToUInt3(Xse.cvtepu8_epi32(input));
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
        public static implicit operator ulong3(byte3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi64(input);
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
        public static implicit operator half3(byte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToHalf3(Xse.cvtepu8_ph(input, elements: 3));
            }
            else
            {
                return (half3)(float3)input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(byte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return RegisterConversion.ToFloat3(Xse.cvtepu8_ps(input));
            }
            else
            {
                return (float3)(int3)input;
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

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
					    return Xse.extract_epi8(this, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (byte* ptr = &x)
                    {
                        return ptr[index];
                    }
                }
                else
                {
                    return this.GetField<byte3, byte>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
						this = Xse.insert_epi8(this, value, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (byte* ptr = &x)
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
        public static byte3 operator + (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.add_epi8(left, right);
            }
            else
            {
                return new byte3((byte)(left.x + right.x), (byte)(left.y + right.y), (byte)(left.z + right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator - (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sub_epi8(left, right);
            }
            else
            {
                return new byte3((byte)(left.x - right.x), (byte)(left.y - right.y), (byte)(left.z - right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator * (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi8(left, right, 3);
            }
            else
            {
                return new byte3((byte)(left.x * right.x), (byte)(left.y * right.y), (byte)(left.z * right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator / (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.div_epu8(left, right, 3);
            }
            else
            {
                return new byte3((byte)(left.x / right.x), (byte)(left.y / right.y), (byte)(left.z / right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator % (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu8(left, right, 3);
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constmullo_epu8(left, right, 3);
                }
            }

            return left * (byte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator / (byte3 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
					return Xse.constdiv_epu8(left, right, 3);
                }
            }

            return left / (byte3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator % (byte3 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
					return Xse.constrem_epu8(left, right, 3);
                }
            }

            return left % (byte3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator & (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(left, right);
            }
            else
            {
                return new byte3((byte)(left.x & right.x), (byte)(left.y & right.y), (byte)(left.z & right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator | (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.or_si128(left, right);
            }
            else
            {
                return new byte3((byte)(left.x | right.x), (byte)(left.y | right.y), (byte)(left.z | right.z));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ^ (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.xor_si128(left, right);
            }
            else
            {
                return new byte3((byte)(left.x ^ right.x), (byte)(left.y ^ right.y), (byte)(left.z ^ right.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ++ (byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.inc_epi8(x);
            }
            else
            {
                return new byte3((byte)(x.x + 1), (byte)(x.y + 1), (byte)(x.z + 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator -- (byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.dec_epi8(x);
            }
            else
            {
                return new byte3((byte)(x.x - 1), (byte)(x.y - 1), (byte)(x.z - 1));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ~ (byte3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(x);
            }
            else
            {
                return new byte3((byte)(~x.x), (byte)(~x.y), (byte)(~x.z));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator << (byte3 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.slli_epi8(x, n, inRange: true);
            }
            else
            {
                return new byte3((byte)(x.x << n), (byte)(x.y << n), (byte)(x.z << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator >> (byte3 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi8(x, n, inRange: true);
            }
            else
            {
                return new byte3((byte)(x.x >> n), (byte)(x.y >> n), (byte)(x.z >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = RegisterConversion.IsTrue8(Xse.cmpeq_epi8(left, right));

                return *(bool3*)&result;
            }
            else
            {
                return new bool3(left.x == right.x, left.y == right.y, left.z == right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = RegisterConversion.IsTrue8(Xse.cmplt_epu8(left, right, 3));

                return *(bool3*)&result;
            }
            else
            {
                return new bool3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = RegisterConversion.IsTrue8(Xse.cmpgt_epu8(left, right, 3));

                return *(bool3*)&result;
            }
            else
            {
                return new bool3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = RegisterConversion.IsFalse8(Xse.cmpeq_epi8(left, right));

                return *(bool3*)&result;
            }
            else
            {
                return new bool3(left.x != right.x, left.y != right.y, left.z != right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = RegisterConversion.IsTrue8(Xse.cmple_epu8(left, right, 3));

                return *(bool3*)&result;
            }
            else
            {
                return new bool3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                v128 result = RegisterConversion.IsTrue8(Xse.cmpge_epu8(left, right, 3));

                return *(bool3*)&result;
            }
            else
            {
                return new bool3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(byte3 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return bitmask32(24u) == (bitmask32(24u) & Xse.cmpeq_epi8(this, other).UInt0);
            }
            else
            {
                return this.x == other.x & this.y == other.y & this.z == other.z;
            }
        }

        public override readonly bool Equals(object obj) => obj is byte3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (BurstArchitecture.IsSIMDSupported)
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