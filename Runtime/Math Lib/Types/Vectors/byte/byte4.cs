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
	[StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(byte))]  
	[DebuggerTypeProxy(typeof(byte4.DebuggerProxy))]
    unsafe public struct byte4 : IEquatable<byte4>, IFormattable
	{
		internal sealed class DebuggerProxy
		{
			public byte x;
			public byte y;
			public byte z;
			public byte w;

			public DebuggerProxy(byte4 v)
			{
				x = v.x;
				y = v.y;
				z = v.z;
				w = v.w;
			}
		}


		[FieldOffset(0)] private fixed byte asArray[4];

        [FieldOffset(0)] public byte x;
        [FieldOffset(1)] public byte y;
        [FieldOffset(2)] public byte z;
        [FieldOffset(3)] public byte w;


        public static byte4 zero => default;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte y, byte z, byte w)
        {
            if (Sse2.IsSse2Supported)
			{
                if (Constant.IsConstantExpression(x) && Constant.IsConstantExpression(y) && Constant.IsConstantExpression(z) && Constant.IsConstantExpression(w))
                {
                    this = Sse2.cvtsi32_si128((int)maxmath.bitfield(x, y, z, w));
                }
                else
                {
					this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)w, (sbyte)z, (sbyte)y, (sbyte)x);
                }
			}
			else
            {
				this.x = x;
				this.y = y;
				this.z = z;
				this.w = w;
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte xyzw)
        {
			if (Sse2.IsSse2Supported)
			{
                if (Constant.IsConstantExpression(xyzw))
                {
					this = Sse2.cvtsi32_si128((int)maxmath.bitfield(xyzw, xyzw, xyzw, xyzw));
                }
				else
				{
					this = Sse2.set1_epi8((sbyte)xyzw);
				}
			}
			else
			{
				this.x = this.y = this.z = this.w = xyzw;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte2 xy, byte z, byte w)
        {
            if (Sse2.IsSse2Supported)
            {
				this = Sse2.unpacklo_epi16(xy, new byte2(z, w));
			}
			else
            {
				this.x = xy.x;
				this.y = xy.y;
				this.z = z;
				this.w = w;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte2 yz, byte w)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)w, (sbyte)yz.y, (sbyte)yz.x, (sbyte)x);
			}
			else
			{
				this.x = x;
				this.y = yz.x;
				this.z = yz.y;
				this.w = w;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte y, byte2 zw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.unpacklo_epi16(new byte2(x, y), zw);
			}
			else
			{
				this.x = x;
				this.y = y;
				this.z = zw.x;
				this.w = zw.y;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte2 xy, byte2 zw)
        {
			if (Sse2.IsSse2Supported)
			{
				this = Sse2.unpacklo_epi16(xy, zw);
			}
			else
			{
				this.x = xy.x;
				this.y = xy.y;
				this.z = zw.x;
				this.w = zw.y;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte3 xyz, byte w)
        {
			if (Sse4_1.IsSse41Supported)
			{
				this = Sse4_1.insert_epi8(xyz, w, 3);
			}
			else if (Sse2.IsSse2Supported)
			{
				this = Sse2.or_si128(xyz, Sse2.bslli_si128(Sse2.cvtsi32_si128(w), 3 * sizeof(byte)));
			}
			else
			{
				this.x = xyz.x;
				this.y = xyz.y;
				this.z = xyz.z;
				this.w = w;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte3 yzw)
        {
			if (Sse4_1.IsSse41Supported)
			{
				this = Sse4_1.insert_epi8(Sse2.bslli_si128(yzw, sizeof(byte)), x, 0);
			}
			else if (Sse2.IsSse2Supported)
			{
				this = Sse2.or_si128(Sse2.bslli_si128(yzw, sizeof(byte)), Sse2.cvtsi32_si128(x));
			}
			else
			{
				this.x = x;
				this.y = yzw.x;
				this.z = yzw.y;
				this.w = yzw.z;
			}
        }

		
        #region Shuffle
		public readonly byte4 xxxx
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)] 
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxxz(this);
                }
                else
                {
                    return new byte4(x, x, x, z);
                }
            }
        }
        public readonly byte4 xxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxxw(this);
                }
				else
				{
					return new byte4(x, x, x, w);
				}
			}
		}
        public readonly byte4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxyz(this);
                }
                else
                {
                    return new byte4(x, x, y,z);
                }
            }
        }
        public readonly byte4 xxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxyw(this);
                }
				else
				{
					return new byte4(x, x, y, w);
				}
			}
		}
        public readonly byte4 xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxzz(this);
                }
                else
                {
                    return new byte4(x, x, z, z);
                }
            }
        }
        public readonly byte4 xxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxzw(this);
                }
				else
				{
					return new byte4(x, x, z, w);
				}
			}
		}
        public readonly byte4 xxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxwx(this);
                }
				else
				{
					return new byte4(x, x, w, x);
				}
			}
		}
        public readonly byte4 xxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxwy(this);
                }
				else
				{
					return new byte4(x, x, w, y);
				}
			}
		}
        public readonly byte4 xxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxwz(this);
                }
				else
				{
					return new byte4(x, x, w, z);
				}
			}
		}
        public readonly byte4 xxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxww(this);
                }
				else
				{
					return new byte4(x, x, w, w);
				}
			}
		}
        public readonly byte4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyxz(this);
                }
                else
                {
                    return new byte4(x, y, x, z);
                }
            }
        }
		public readonly byte4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyxw(this);
                }
				else
				{
					return new byte4(x, y, x, w);
				}
			}
		}
		public readonly byte4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyyz(this);
                }
                else
                {
                    return new byte4(x, y, y, z);
                }
            }
        }
		public readonly byte4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyyw(this);
                }
				else
				{
					return new byte4(x, y, y, w);
				}
			}
		}
		public readonly byte4 xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyzz(this);
                }
                else
                {
                    return new byte4(x, y, z, z);
                }
            }
        }
		public readonly byte4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xywx(this);
                }
				else
				{
					return new byte4(x, y, w, x);
				}
			}
		}
		public readonly byte4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xywy(this);
                }
				else
				{
					return new byte4(x, y, w, y);
				}
			}
		}
		public byte4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xywz(this);
                }
				else
				{
					return new byte4(x, y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xywz;
			}
		}
		public readonly byte4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyww(this);
                }
				else
				{
					return new byte4(x, y, w, w);
				}
			}
		}
		public readonly byte4 xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzxz(this);
                }
                else
                {
                    return new byte4(x, z, x, z);
                }
            }
        }
		public readonly byte4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzxw(this);
                }
				else
				{
					return new byte4(x, z, x, w);
				}
			}
		}
		public readonly byte4 xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzyz(this);
                }
                else
                {
                    return new byte4(x, z, y, z);
                }
            }
        }
		public byte4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzyw(this);
                }
				else
				{
					return new byte4(x, z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzyw;
			}
		}
		public readonly byte4 xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzzz(this);
                }
                else
                {
                    return new byte4(x, z, z, z);
                }
            }
        }
		public readonly byte4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzzw(this);
                }
				else
				{
					return new byte4(x, z, z, w);
				}
			}
		}
		public readonly byte4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzwx(this);
                }
				else
				{
					return new byte4(x, z, w, x);
				}
			}
		}
		public byte4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzwy(this);
                }
				else
				{
					return new byte4(x, z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwyz;
			}
		}
		public readonly byte4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzwz(this);
                }
				else
				{
					return new byte4(x, z, w, z);
				}
			}
		}
		public readonly byte4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzww(this);
                }
				else 
				{
					return new byte4(x, z, w, w);
				}
			}
		}
		public readonly byte4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwxx(this);
                }
				else
				{
					return new byte4(x, w, x, x);
				}
			}
		}
		public readonly byte4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwxy(this);
                }
				else
				{
					return new byte4(x, w, x, y);
				}
			}
		}
		public readonly byte4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwxz(this);
                }
				else
				{
					return new byte4(x, w, x, z);
				}
			}
		}
		public readonly byte4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwxw(this);
                }
				else
				{
					return new byte4(x, w, x, w);
				}
			}
		}
		public readonly byte4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwyx(this);
                }
				else
				{
					return new byte4(x, w, y, x);
				}
			}
		}
		public readonly byte4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwyy(this);
                }
				else
				{
					return new byte4(x, w, y, y);
				}
			}
		}
		public byte4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwyz(this);
                }
				else
				{
					return new byte4(x, w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzwy;
			}
		}
		public readonly byte4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwyw(this);
                }
				else
				{
					return new byte4(x, w, y, w);
				}
			}
		}
		public readonly byte4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwzx(this);
                }
				else
				{
					return new byte4(x, w, z, x);
				}
			}
		}
		public byte4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwzy(this);
                }
				else
				{
					return new byte4(x, w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwzy;
			}
		}
		public readonly byte4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwzz(this);
                }
				else
				{
					return new byte4(x, w, z, z);
				}
			}
		}
		public readonly byte4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwzw(this);
                }
				else
				{
					return new byte4(x, w, z, w);
				}
			}
		}
		public readonly byte4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwwx(this);
                }
				else
				{
					return new byte4(x, w, w, x);
				}
			}
		}
		public readonly byte4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwwy(this);
                }
				else
				{
					return new byte4(x, w, w, y);
				}
			}
		}
		public readonly byte4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwwz(this);
                }
				else
				{
					return new byte4(x, w, w, z);
				}
			}
		}
		public readonly byte4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwww(this);
                }
				else
				{
					return new byte4(x, w, w, w);
				}
			}
		}
		public readonly byte4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxxz(this);
                }
                else
                {
                    return new byte4(y, x, x, z);
                }
            }
        }
		public readonly byte4 yxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxxw(this);
                }
				else
				{
					return new byte4(y, x, x, w);
				}
			}
		}
		public readonly byte4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxyz(this);
                }
                else
                {
                    return new byte4(y, x, y, z);
                }
            }
        }
		public readonly byte4 yxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxyw(this);
                }
				else
				{
					return new byte4(y, x, y, w);
				}
			}
		}
		public readonly byte4 yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxzz(this);
                }
                else
                {
                    return new byte4(y, x, z, z);
                }
            }
        }
		public byte4 yxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxzw(this);
                }
				else
				{
					return new byte4(y, x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxzw;
			}
		}
		public readonly byte4 yxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxwx(this);
                }
				else
				{
					return new byte4(y, x, w, x);
				}
			}
		}
		public readonly byte4 yxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxwy(this);
                }
				else
				{
					return new byte4(y, x, w, y);
				}
			}
		}
		public byte4 yxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxwz(this);
                }
				else
				{
					return new byte4(y, x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxwz;
			}
		}
		public readonly byte4 yxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxww(this);
                }
				else
				{
					return new byte4(y, x, w, w);
				}
			}
		}
		public readonly byte4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyxz(this);
                }
                else
                {
                    return new byte4(y, y, x, z);
                }
            }
        }
		public readonly byte4 yyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyxw(this);
                }
				else
				{
					return new byte4(y, y, x, w);
				}
			}
		}
		public readonly byte4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyyz(this);
                }
                else
                {
                    return new byte4(y, y, y, z);
                }
            }
        }
		public readonly byte4 yyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyyw(this);
                }
				else
				{
					return new byte4(y, y, y, w);
				}
			}
		}
		public readonly byte4 yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyzz(this);
                }
                else
                {
                    return new byte4(y, y, z, z);
                }
            }
        }
		public readonly byte4 yyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyzw(this);
                }
				else
				{
					return new byte4(y, y, z, w);
				}
			}
		}
		public readonly byte4 yywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yywx(this);
                }
				else
				{
					return new byte4(y, y, w, x);
				}
			}
		}
		public readonly byte4 yywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yywy(this);
                }
				else
				{
					return new byte4(y, y, w, y);
				}
			}
		}
		public readonly byte4 yywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yywz(this);
                }
				else
				{
					return new byte4(y, y, w, z);
				}
			}
		}
		public readonly byte4 yyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyww(this);
                }
				else
				{
					return new byte4(y, y, w, w);
				}
			}
		}
		public readonly byte4 yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzxz(this);
                }
                else
                {
                    return new byte4(y, z, x, z);
                }
            }
        }
		public byte4 yzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzxw(this);
                }
				else
				{
					return new byte4(y, z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxyw;
			}
		}
		public readonly byte4 yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzyz(this);
                }
                else
                {
                    return new byte4(y, z, y, z);
                }
            }
        }
		public readonly byte4 yzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzyw(this);
                }
				else
				{
					return new byte4(y, z, y, w);
				}
			}
		}
		public readonly byte4 yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzzz(this);
                }
                else
                {
                    return new byte4(y, z, z, z);
                }
            }
        }
		public readonly byte4 yzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzzw(this);
                }
				else
				{
					return new byte4(y, z, z, w);
				}
			}
		}
		public byte4 yzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzwx(this);
                }
				else
				{
					return new byte4(y, z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxyz;
			}
		}
		public readonly byte4 yzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzwy(this);
                }
				else
				{
					return new byte4(y, z, w, y);
				}
			}
		}
		public readonly byte4 yzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzwz(this);
                }
				else
				{
					return new byte4(y, z, w, z);
				}
			}
		}
		public readonly byte4 yzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzww(this);
                }
				else
				{
					return new byte4(y, z, w, w);
				}
			}
		}
		public readonly byte4 ywxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywxx(this);
                }
				else
				{
					return new byte4(y, w, x, x);
				}
			}
		}
		public readonly byte4 ywxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywxy(this);
                }
				else
				{
					return new byte4(y, w, x, y);
				}
			}
		}
		public byte4 ywxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywxz(this);
                }
				else
				{
					return new byte4(y, w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxwy;
			}
		}
		public readonly byte4 ywxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywxw(this);
                }
				else
				{
					return new byte4(y, w, x, w);
				}
			}
		}
		public readonly byte4 ywyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywyx(this);
                }
				else
				{
					return new byte4(y, w, y, x);
				}
			}
		}
		public readonly byte4 ywyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywyy(this);
                }
				else
				{
					return new byte4(y, w, y, y);
				}
			}
		}
		public readonly byte4 ywyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywyz(this);
                }
				else
				{
					return new byte4(y, w, y, z);
				}
			}
		}
		public readonly byte4 ywyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywyw(this);
                }
				else
				{
					return new byte4(y, w, y, w);
				}
			}
		}
		public byte4 ywzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywzx(this);
                }
				else
				{
					return new byte4(y, w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxzy;
			}
		}
		public readonly byte4 ywzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywzy(this);
                }
				else
				{
					return new byte4(y, w, z, y);
				}
			}
		}
		public readonly byte4 ywzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywzz(this);
                }
				else
				{
					return new byte4(y, w, z, z);
				}
			}
		}
		public readonly byte4 ywzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywzw(this);
                }
				else
				{
					return new byte4(y, w, z, w);
				}
			}
		}
		public readonly byte4 ywwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywwx(this);
                }
				else
				{
					return new byte4(y, w, w, x);
				}
			}
		}
		public readonly byte4 ywwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywwy(this);
                }
				else
				{
					return new byte4(y, w, w, y);
				}
			}
		}
		public readonly byte4 ywwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywwz(this);
                }
				else
				{
					return new byte4(y, w, w, z);
				}
			}
		}
		public readonly byte4 ywww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywww(this);
                }
				else
				{
					return new byte4(y, w, w, w);
				}
			}
		}
		public readonly byte4 zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxxz(this);
                }
                else
                {
                    return new byte4(z, x, x, z);
                }
            }
        }
		public readonly byte4 zxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxxw(this);
                }
				else
				{
					return new byte4(z, x, x, w);
				}
			}
		}
		public readonly byte4 zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxyz(this);
                }
                else
                {
                    return new byte4(z, x, y, z);
                }
            }
        }
		public byte4 zxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxyw(this);
                }
				else
				{
					return new byte4(z, x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzxw;
			}
		}
		public readonly byte4 zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxzz(this);
                }
                else
                {
                    return new byte4(z, x, z, z);
                }
            }
        }
		public readonly byte4 zxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxzw(this);
                }
				else
				{
					return new byte4(z, x, z, w);
				}
			}
		}
		public readonly byte4 zxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxwx(this);
                }
				else
				{
					return new byte4(z, x, w, x);
				}
			}
		}
		public byte4 zxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxwy(this);
                }
				else
				{
					return new byte4(z, x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywxz;
			}
		}
		public readonly byte4 zxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxwz(this);
                }
				else
				{
					return new byte4(z, x, w, z);
				}
			}
		}
		public readonly byte4 zxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxww(this);
                }
				else
				{
					return new byte4(z, x, w, w);
				}
			}
		}
		public readonly byte4 zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyxz(this);
                }
                else
                {
                    return new byte4(z, y, x, z);
                }
            }
        }
		public byte4 zyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyxw(this);
                }
				else
				{
					return new byte4(z, y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zyxw;
			}
		}
		public readonly byte4 zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyyz(this);
                }
                else
                {
                    return new byte4(z, y, y, z);
                }
            }
        }
		public readonly byte4 zyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyyw(this);
                }
				else
				{
					return new byte4(z, y, y, w);
				}
			}
		}
		public readonly byte4 zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyzz(this);
                }
                else
                {
                    return new byte4(z, y, z, z);
                }
            }
        }
		public readonly byte4 zyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyzw(this);
                }
				else
				{
					return new byte4(z, y, z, w);
				}
			}
		}
		public byte4 zywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zywx(this);
                }
				else
				{
					return new byte4(z, y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyxz;
			}
		}
		public readonly byte4 zywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zywy(this);
                }
				else
				{
					return new byte4(z, y, w, y);
				}
			}
		}
		public readonly byte4 zywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zywz(this);
                }
				else
				{
					return new byte4(z, y, w, z);
				}
			}
		}
		public readonly byte4 zyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyww(this);
                }
				else
				{
					return new byte4(z, y, w, w);
				}
			}
		}
		public readonly byte4 zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzxz(this);
                }
                else
                {
                    return new byte4(z, z, x, z);
                }
            }
        }
		public readonly byte4 zzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzxw(this);
                }
				else
				{
					return new byte4(z, z, x, w);
				}
			}
		}
		public readonly byte4 zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzyz(this);
                }
                else
                {
                    return new byte4(z, z, y, z);
                }
            }
        }
		public readonly byte4 zzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzyw(this);
                }
				else
				{
					return new byte4(z, z, y, w);
				}
			}
		}
		public readonly byte4 zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzzz(this);
                }
                else
                {
                    return new byte4(z, z, z, z);
                }
            }
        }
		public readonly byte4 zzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzzw(this);
                }
				else
				{
					return new byte4(z, z, z, w);
				}
			}
		}
		public readonly byte4 zzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzwx(this);
                }
				else
				{
					return new byte4(z, z, w, x);
				}
			}
		}
		public readonly byte4 zzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzwy(this);
                }
				else
				{
					return new byte4(z, z, w, y);
				}
			}
		}
		public readonly byte4 zzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzwz(this);
                }
				else
				{
					return new byte4(z, z, w, z);
				}
			}
		}
		public readonly byte4 zzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzww(this);
                }
				else
				{
					return new byte4(z, z, w, w);
				}
			}
		}
		public readonly byte4 zwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwxx(this);
                }
				else
				{
					return new byte4(z, w, x, x);
				}
			}
		}
		public byte4 zwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwxy(this);
                }
				else
				{
					return new byte4(z, w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwxy;
			}
		}
		public readonly byte4 zwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwxz(this);
                }
				else
				{
					return new byte4(z, w, x, z);
				}
			}
		}
		public readonly byte4 zwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwxw(this);
                }
				else
				{
					return new byte4(z, w, xw);
				}
			}
		}
		public byte4 zwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwyx(this);
                }
				else
				{
					return new byte4(z, w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzxy;
			}
		}
		public readonly byte4 zwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwyy(this);
                }
				else
				{
					return new byte4(z, w, y, y);
				}
			}
		}
		public readonly byte4 zwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwyz(this);
                }
				else
				{
					return new byte4(z, w, y, z);
				}
			}
		}
		public readonly byte4 zwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwyw(this);
                }
				else
				{
					return new byte4(z, w, y, w);
				}
			}
		}
		public readonly byte4 zwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwzx(this);
                }
				else
				{
					return new byte4(z, w, z, x);
				}
			}
		}
		public readonly byte4 zwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwzy(this);
                }
				else
				{
					return new byte4(z, w, z, y);
				}
			}
		}
		public readonly byte4 zwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwzz(this);
                }
				else
				{
					return new byte4(z, w, z, z);
				}
			}
		}
		public readonly byte4 zwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwzw(this);
                }
				else
				{
					return new byte4(z, w, z, w);
				}
			}
		}
		public readonly byte4 zwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwwx(this);
                }
				else
				{
					return new byte4(z, w, w, x);
				}
			}
		}
		public readonly byte4 zwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwwy(this);
                }
				else
				{
					return new byte4(z, w, w, y);
				}
			}
		}
		public readonly byte4 zwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwwz(this);
                }
				else
				{
					return new byte4(z, w, w, z);
				}
			}
		}
		public readonly byte4 zwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwww(this);
                }
				else
				{
					return new byte4(z, w, ww);
				}
			}
		}
		public readonly byte4 wxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxxx(this);
                }
				else
				{
					return new byte4(w, x, x, x);
				}
			}
		}
		public readonly byte4 wxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxxy(this);
                }
				else
				{
					return new byte4(w, x, x, y);
				}
			}
		}
		public readonly byte4 wxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxxz(this);
                }
				else
				{
					return new byte4(w, x, x, z);
				}
			}
		}
		public readonly byte4 wxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxxw(this);
                }
				else
				{
					return new byte4(w, x, x, w);
				}
			}
		}
		public readonly byte4 wxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxyx(this);
                }
				else
				{
					return new byte4(w, x, y, x);
				}
			}
		}
		public readonly byte4 wxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxyy(this);
                }
				else
				{
					return new byte4(w, x, y, y);
				}
			}
		}
		public byte4 wxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxyz(this);
                }
				else
				{
					return new byte4(w, x, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzwx;
			}
		}
		public readonly byte4 wxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxyw(this);
                }
				else
				{
					return new byte4(w, x, y, w);
				}
			}
		}
		public readonly byte4 wxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxzx(this);
                }
				else
				{
					return new byte4(w, x, z, x);
				}
			}
		}
		public byte4 wxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxzy(this);
                }
				else
				{
					return new byte4(w, x, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywzx;
			}
		}
		public readonly byte4 wxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxzz(this);
                }
				else
				{
					return new byte4(w, x, z, z);
				}
			}
		}
		public readonly byte4 wxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxzw(this);
                }
				else
				{
					return new byte4(w, x, z, w);
				}
			}
		}
		public readonly byte4 wxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxwx(this);
                }
				else
				{
					return new byte4(w, x, w, x);
				}
			}
		}
		public readonly byte4 wxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxwy(this);
                }
				else
				{
					return new byte4(w, x, w, y);
				}
			}
		}
		public readonly byte4 wxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxwz(this);
                }
				else
				{
					return new byte4(w, x, w, z);
				}
			}
		}
		public readonly byte4 wxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxww(this);
                }
				else
				{
					return new byte4(w, x, w, w);
				}
			}
		}
		public readonly byte4 wyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyxx(this);
                }
				else
				{
					return new byte4(w, y, x, x);
				}
			}
		}
		public readonly byte4 wyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyxy(this);
                }
				else
				{
					return new byte4(w, y, x, y);
				}
			}
		}
		public byte4 wyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyxz(this);
                }
				else
				{
					return new byte4(w, y, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zywx;
			}
		}
		public readonly byte4 wyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyxw(this);
                }
				else
				{
					return new byte4(w, y, x, w);
				}
			}
		}
		public readonly byte4 wyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyyx(this);
                }
				else
				{
					return new byte4(w, y, y, x);
				}
			}
		}
		public readonly byte4 wyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyyy(this);
                }
				else
				{
					return new byte4(w, y, y, y);
				}
			}
		}
		public readonly byte4 wyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyyz(this);
                }
				else
				{
					return new byte4(w, y, y, z);
				}
			}
		}
		public readonly byte4 wyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyyw(this);
                }
				else
				{
					return new byte4(w, y, y, w);
				}
			}
		}
		public byte4 wyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyzx(this);
                }
				else
				{
					return new byte4(w, y, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyzx;
			}
		}
		public readonly byte4 wyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyzy(this);
                }
				else
				{
					return new byte4(w, y, z, y);
				}
			}
		}
		public readonly byte4 wyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyzz(this);
                }
				else
				{
					return new byte4(w, y, z, z);
				}
			}
		}
		public readonly byte4 wyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyzw(this);
                }
				else
				{
					return new byte4(w, y, z, w);
				}
			}
		}
		public readonly byte4 wywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wywx(this);
                }
				else
				{
					return new byte4(w, y, w, x);
				}
			}
		}
		public readonly byte4 wywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wywy(this);
                }
				else
				{
					return new byte4(w, y, w, y);
				}
			}
		}
		public readonly byte4 wywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wywz(this);
                }
				else
				{
					return new byte4(w, y, w, z);
				}
			}
		}
		public readonly byte4 wyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyww(this);
                }
				else
				{
					return new byte4(w, y, w, w);
				}
			}
		}
		public readonly byte4 wzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzxx(this);
                }
				else
				{
					return new byte4(w, z, x, x);
				}
			}
		}
		public byte4 wzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzxy(this);
                }
				else
				{
					return new byte4(w, z, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwyx;
			}
		}
		public readonly byte4 wzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzxz(this);
                }
				else
				{
					return new byte4(w, z, x, z);
				}
			}
		}
		public readonly byte4 wzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzxw(this);
                }
				else
				{
					return new byte4(w, z, x, w);
				}
			}
		}
		public byte4 wzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzyx(this);
                }
				else
				{
					return new byte4(w, z, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzyx;
			}
		}
		public readonly byte4 wzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzyy(this);
                }
				else
				{
					return new byte4(w, z, y, y);
				}
			}
		}
		public readonly byte4 wzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzyz(this);
                }
				else
				{
					return new byte4(w, z, y, z);
				}
			}
		}
		public readonly byte4 wzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzyw(this);
                }
				else
				{
					return new byte4(w, z, y, w);
				}
			}
		}
		public readonly byte4 wzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzzx(this);
                }
				else
				{
					return new byte4(w, z, z, x);
				}
			}
		}
		public readonly byte4 wzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzzy(this);
                }
				else
				{
					return new byte4(w, z, z, y);
				}
			}
		}
		public readonly byte4 wzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzzz(this);
                }
				else
				{
					return new byte4(w, z, z, z);
				}
			}
		}
		public readonly byte4 wzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzzw(this);
                }
				else
				{
					return new byte4(w, z, z, w);
				}
			}
		}
		public readonly byte4 wzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzwx(this);
                }
				else
				{
					return new byte4(w, z, w, x);
				}
			}
		}
		public readonly byte4 wzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzwy(this);
                }
				else
				{
					return new byte4(w, z, w, y);
				}
			}
		}
		public readonly byte4 wzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzwz(this);
                }
				else
				{
					return new byte4(w, z, w, z);
				}
			}
		}
		public readonly byte4 wzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzww(this);
                }
				else
				{
					return new byte4(w, z, w, w);
				}
			}
		}
		public readonly byte4 wwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwxx(this);
                }
				else
				{
					return new byte4(w, w, x, x);
				}
			}
		}
		public readonly byte4 wwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwxy(this);
                }
				else
				{
					return new byte4(w, w, x, y);
				}
			}
		}
		public readonly byte4 wwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwxz(this);
                }
				else
				{
					return new byte4(w, w, x, z);
				}
			}
		}
		public readonly byte4 wwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwxw(this);
                }
				else
				{
					return new byte4(w, w, x, w);
				}
			}
		}
		public readonly byte4 wwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwyx(this);
                }
				else
				{
					return new byte4(w, w, y, x);
				}
			}
		}
		public readonly byte4 wwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwyy(this);
                }
				else
				{
					return new byte4(w, w, y, y);
				}
			}
		}
		public readonly byte4 wwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwyz(this);
                }
				else
				{
					return new byte4(w, w, y, z);
				}
			}
		}
		public readonly byte4 wwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwyw(this);
                }
				else
				{
					return new byte4(w, w, y, w);
				}
			}
		}
		public readonly byte4 wwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwzx(this);
                }
				else
				{
					return new byte4(w, w, z, x);
				}
			}
		}
		public readonly byte4 wwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwzy(this);
                }
				else
				{
					return new byte4(w, w, z, y);
				}
			}
		}
		public readonly byte4 wwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwzz(this);
                }
				else
				{
					return new byte4(w, w, z, z);
				}
			}
		}
		public readonly byte4 wwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwzw(this);
                }
				else
				{
					return new byte4(w, w, z, w);
				}
			}
		}
		public readonly byte4 wwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwwx(this);
                }
				else
				{
					return new byte4(w, w, w, x);
				}
			}
		}
		public readonly byte4 wwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwwy(this);
                }
				else
				{
					return new byte4(w, w, w, y);
				}
			}
		}
		public readonly byte4 wwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwwz(this);
                }
				else
				{
					return new byte4(w, w, w, z);
				}
			}
		}
		public readonly byte4 wwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwww(this);
                }
				else
				{
					return new byte4(w, w, w, w);
				}
			}
		}

		public readonly byte3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxz(this);
                }
                else
                {
                    return new byte3(x, x, z);
                }
            }
        }
		public readonly byte3 xxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xxw(this);
                }
				else
				{
					return new byte3(x, x, w);
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
		public byte3 xyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xyw(this);
                }
				else
				{
					return new byte3(x, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.xyzz, new byte4(255, 255, 0, 255));
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
		public readonly byte3 xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzz(this);
                }
                else
                {
                    return new byte3(x, z, z);
                }
            }
        }
		public byte3 xzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xzw(this);
                }
				else
				{
					return new byte3(x, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.xxyz, new byte4(255, 0, 255, 255));
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
		public readonly byte3 xwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwx(this);
                }
				else
				{
					return new byte3(x, w, x);
				}
			}
		}
		public byte3 xwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwy(this);
                }
				else
				{
					return new byte3(x, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.xzzy, new byte4(255, 255, 0, 255));
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
		public byte3 xwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xwz(this);
                }
				else
				{
					return new byte3(x, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.xxzy, new byte4(255, 0, 255, 255));
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
		public readonly byte3 xww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xww(this);
                }
				else
				{
					return new byte3(x, w, w);
				}
			}
		}
		public readonly byte3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
		public byte3 yxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yxw(this);
                }
				else
				{
					return new byte3(y, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.yxzz, new byte4(255, 255, 0, 255));
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
		public readonly byte3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyz(this);
                }
                else
                {
                    return new byte3(y, y, z);
                }
            }
        }
		public readonly byte3 yyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yyw(this);
                }
				else
				{
					return new byte3(y, y, w);
				}
			}
		}
		public          byte3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzz(this);
                }
                else
                {
                    return new byte3(y, z, z);
                }
            }
        }
		public byte3 yzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yzw(this);
                }
				else
				{
					return new byte3(y, z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.xxyz, new byte4(0, 255, 255, 255));
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
		public byte3 ywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywx(this);
                }
				else
				{
					return new byte3(y, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.zxxy, new byte4(255, 255, 0, 255));
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
		public readonly byte3 ywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywy(this);
                }
				else
				{
					return new byte3(y, w, y);
				}
			}
		}
		public byte3 ywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ywz(this);
                }
				else
				{
					return new byte3(y, w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.xxzy, new byte4(0, 255, 255, 255));
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
		public readonly byte3 yww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yww(this);
                }
				else
				{
					return new byte3(y, w, w);
				}
			}
		}
		public readonly byte3 zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxz(this);
                }
                else
                {
                    return new byte3(z, x, z);
                }
            }
        }
		public byte3 zxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zxw(this);
                }
				else
				{
					return new byte3(z, x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.yyxz, new byte4(255, 0, 255, 255));
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
		public          byte3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyz(this);
                }
                else
                {
                    return new byte3(z, y, z);
                }
            }
        }
		public byte3 zyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zyw(this);
                }
				else
				{
					return new byte3(z, y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.yyxz, new byte4(0, 255, 255, 255));
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
		public readonly byte3 zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzz(this);
                }
                else
                {
                    return new byte3(z, z, z);
                }
            }
        }
		public readonly byte3 zzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zzw(this);
                }
				else
				{
					return new byte3(z, z, w);
				}
			}
		}
		public byte3 zwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwx(this);
                }
				else
				{
					return new byte3(z, w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.zzxy, new byte4(255, 0, 255, 255));
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
		public byte3 zwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwy(this);
                }
				else
				{
					return new byte3(z, w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.zzxy, new byte4(0, 255, 255, 255));
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
		public readonly byte3 zwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zwz(this);
                }
				else
				{
					return new byte3(z, w, z);
				}
			}
		}
		public readonly byte3 zww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zww(this);
                }
				else
				{
					return new byte3(z, w, w);
				}
			}
		}
		public readonly byte3 wxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxx(this);
                }
				else
				{
					return new byte3(w, x, x);
				}
			}
		}
		public byte3 wxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxy(this);
                }
				else
				{
					return new byte3(w, x, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.yzzx, new byte4(255, 255, 0, 255));
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
		public byte3 wxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxz(this);
                }
				else
				{
					return new byte3(w, x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.yyzx, new byte4(255, 0, 255, 255));
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
		public readonly byte3 wxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wxw(this);
                }
				else
				{
					return new byte3(w, x, w);
				}
			}
		}
		public byte3 wyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyx(this);
                }
				else
				{
					return new byte3(w, y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.zyyx, new byte4(255, 255, 0, 255));
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
		public readonly byte3 wyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyy(this);
                }
				else
				{
					return new byte3(w, y, y);
				}
			}
		}
		public byte3 wyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyz(this);
                }
				else
				{
					return new byte3(w, y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.yyzx, new byte4(0, 255, 255, 255));
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
		}
		public readonly byte3 wyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wyw(this);
                }
				else
				{
					return new byte3(w, y, w);
				}
			}
		}
		public byte3 wzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzx(this);
                }
				else
				{
					return new byte3(w, z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.zzyx, new byte4(255, 0, 255, 255));
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
		}
		public byte3 wzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzy(this);
                }
				else
				{
					return new byte3(w, z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.zzyx, new byte4(0, 255, 255, 255));
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
		}
		public readonly byte3 wzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzz(this);
                }
				else
				{
					return new byte3(w, z, z);
				}
			}
		}
		public readonly byte3 wzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wzw(this);
                }
				else
				{
					return new byte3(w, z, w);
				}
			}
		}
		public readonly byte3 wwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwx(this);
                }
				else
				{
					return new byte3(w, w, x);
				}
			}
		}
		public readonly byte3 wwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwy(this);
                }
				else
				{
					return new byte3(w, w, y);
				}
			}
		}
		public readonly byte3 wwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wwz(this);
                }
				else
				{
					return new byte3(w, w, z);
				}
			}
		}
		public readonly byte3 www
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.www(this);
                }
				else
				{
					return new byte3(w, w, w);
				}
			}
		}

		public readonly byte2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
		public byte2 xw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.xw(this);
                }
				else
				{
					return new byte2(x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.xxyy, new byte4(255, 0, 0, 255));
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
				}
			}
		}
		public          byte2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
		public byte2 yw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.yw(this);
                }
				else
				{
					return new byte2(y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.xxyy, new byte4(0, 255, 0, 255));
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
				}
			}
		}
		public          byte2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
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
				if (Sse2.IsSse2Supported)
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
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zz(this);
                }
                else
                {
                    return new byte2(z, z);
                }
            }
        }
		public byte2 zw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.zw(this);
                }
				else
				{
					return new byte2(z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Sse2.unpacklo_epi16(this, value);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
				}
			}
		}
		public byte2 wx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wx(this);
                }
				else
				{
					return new byte2(w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.yyxx, new byte4(255, 0, 0, 255));
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
				}
			}
		}
		public byte2 wy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wy(this);
                }
				else
				{
					return new byte2(w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blendv_si128(this, value.yyxx, new byte4(0, 255, 0, 255));
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
				}
			}
		}
		public byte2 wz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			readonly get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.wz(this);
                }
				else
				{
					return new byte2(w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Sse2.IsSse2Supported)
				{
					this = Xse.blend_epi16(this, value.yxyx, 0b10);
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
				}
			}
		}
		public readonly byte2 ww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Sse2.IsSse2Supported)
                {
					return Shuffle.Bytes.Get.ww(this);
                }
				else
				{
					return new byte2(w, w);
				}
			}
		}
		#endregion
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte4 input) => RegisterConversion.ToV128(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4(v128 input) => RegisterConversion.ToType<byte4>(input);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4(byte input) => new byte4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(sbyte4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return (v128)input;
            }
            else
            {
                return *(byte4*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(short4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi16_epi8(input, 4);
            }
            else
            {
                return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(ushort4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi16_epi8(input, 4);
            }
			else
			{
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(int4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 4);
            }
			else
			{
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(uint4 input)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.cvtepi32_epi8(RegisterConversion.ToV128(input), 4);
            }
			else
			{
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi8(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new byte4(Xse.cvtepi64_epi8(input._xy), Xse.cvtepi64_epi8(input._zw));
            }
            else
			{
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(ulong4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepi64_epi8(input);
            }
            else if (Ssse3.IsSsse3Supported)
            {
                return new byte4(Xse.cvtepi64_epi8(input._xy), Xse.cvtepi64_epi8(input._zw));
            }
            else
			{
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(half4 input) => (byte4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(float4 input) => (byte4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(double4 input) => (byte4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(byte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return Xse.cvtepu8_epi16(input);
			}
            else
            {
                return new short4((short)input.x, (short)input.y, (short)input.z, (short)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort4(byte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return Xse.cvtepu8_epi16(input);
			}
            else
            {
                return new ushort4((ushort)input.x, (ushort)input.y, (ushort)input.z, (ushort)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(byte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return RegisterConversion.ToType<int4>(Xse.cvtepu8_epi32(input));
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4(byte4 input)
        {
			if (Sse2.IsSse2Supported)
			{
				return RegisterConversion.ToType<uint4>(Xse.cvtepu8_epi32(input));
            }
            else
            {
                return new uint4((uint)input.x, (uint)input.y, (uint)input.z, (uint)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long4(byte4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi64(input);
            }
            else if (Sse2.IsSse2Supported)
			{
                return new long4((long2)input.xy, (long2)input.zw);
            }
            else
            {
                return new long4((long)input.x, (long)input.y, (long)input.z, (long)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(byte4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu8_epi64(input);
            }
            else if (Sse2.IsSse2Supported)
			{
                return new ulong4((ulong2)input.xy, (ulong2)input.zw);
            }
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half4(byte4 input) => (half4)(float4)input;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(byte4 input)
		{
            if (Sse2.IsSse2Supported)
            {
                v128 result = Xse.cvtepu8_ps(input);

                return *(float4*)&result;
            }
            else
            {
                return (float4)(int4)input;
            }
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(byte4 input) => (double4)(int4)input;


        public byte this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 4);

                return asArray[index];
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                asArray[index] = value;
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator + (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.add_epi8(left, right);
            }
            else
            {
                return new byte4((byte)(left.x + right.x), (byte)(left.y + right.y), (byte)(left.z + right.z), (byte)(left.w + right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator - (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.sub_epi8(left, right);
            }
            else
            {
                return new byte4((byte)(left.x - right.x), (byte)(left.y - right.y), (byte)(left.z - right.z), (byte)(left.w - right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
			{
                return Xse.mullo_epi8(left, right, 4);
            }
            else
            {
                return new byte4((byte)(left.x * right.x), (byte)(left.y * right.y), (byte)(left.z * right.z), (byte)(left.w * right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator / (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.div_epu8(left, right, 4);
            }
            else
            {
                return new byte4((byte)(left.x / right.x), (byte)(left.y / right.y), (byte)(left.z / right.z), (byte)(left.w / right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator % (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rem_epu8(left, right, 4);
            }
            else
            {
                return new byte4((byte)(left.x % right.x), (byte)(left.y % right.y), (byte)(left.z % right.z), (byte)(left.w % right.w));
            }
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte left, byte4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte4 left, byte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.mullo_epu8(left, right, 4);
                }
            }
            
			return left * (byte4)right;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator / (byte4 left, byte right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
					return Xse.constexpr.div_epu8(left, right, 4);
                }
            }

			return left / (byte4)right;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator % (byte4 left, byte right)
        {
			if (Sse2.IsSse2Supported)
			{
				if (Constant.IsConstantExpression(right))
				{
					return Xse.constexpr.rem_epu8(left, right, 4);
				}
			}

			return left % (byte4)right;
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator & (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.and_si128(left, right);
            }
            else
            {
                return new byte4((byte)(left.x & right.x), (byte)(left.y & right.y), (byte)(left.z & right.z), (byte)(left.w & right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator | (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.or_si128(left, right);
            }
            else
            {
                return new byte4((byte)(left.x | right.x), (byte)(left.y | right.y), (byte)(left.z | right.z), (byte)(left.w | right.w));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ^ (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return Sse2.xor_si128(left, right);
            }
            else
            {
                return new byte4((byte)(left.x ^ right.x), (byte)(left.y ^ right.y), (byte)(left.z ^ right.z), (byte)(left.w ^ right.w));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ++ (byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.inc_epi8(x);
			}
            else
            {
                return new byte4((byte)(x.x + 1), (byte)(x.y + 1), (byte)(x.z + 1), (byte)(x.w + 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator -- (byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.dec_epi8(x);
			}
            else
            {
                return new byte4((byte)(x.x - 1), (byte)(x.y - 1), (byte)(x.z - 1), (byte)(x.w - 1));
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ~ (byte4 x)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.not_si128(x);
			}
            else
            {
                return new byte4((byte)(~x.x), (byte)(~x.y), (byte)(~x.z), (byte)(~x.w));
            }
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator << (byte4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.slli_epi8(x, n);
            }
            else
            {
                return new byte4((byte)(x.x << n), (byte)(x.y << n), (byte)(x.z << n), (byte)(x.w << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator >> (byte4 x, int n)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.srli_epi8(x, n);
            }
            else
            {
                return new byte4((byte)(x.x >> n), (byte)(x.y >> n), (byte)(x.z >> n), (byte)(x.w >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator == (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool4>(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool4(left.x == right.x, left.y == right.y, left.z == right.z, left.w == right.w);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool4>(Xse.cmplt_epu8(left, right, 4));
            }
            else
            {
                return new bool4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool4>(Xse.cmpgt_epu8(left, right, 4));
            }
            else
            {
                return new bool4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsFalse8<bool4>(Sse2.cmpeq_epi8(left, right));
            }
            else
            {
                return new bool4(left.x != right.x, left.y != right.y, left.z != right.z, left.w != right.w);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (byte4 left, byte4 right)
        {
			if (Sse2.IsSse2Supported)
			{
				return RegisterConversion.IsTrue8<bool4>(Xse.cmple_epu8(left, right, 4));
			}
			else
            {
                return new bool4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (byte4 left, byte4 right)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.IsTrue8<bool4>(Xse.cmpge_epu8(left, right, 4));
			}
            else
            {
                return new bool4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(byte4 other)
		{
			if (Sse2.IsSse2Supported)
			{
				return uint.MaxValue == Sse2.cmpeq_epi8(this, other).UInt0;

			}
			else
			{
				return (this.x == other.x & this.y == other.y) & (this.z == other.z & this.w == other.w);
			}
		}

		public override readonly bool Equals(object obj) => obj is byte4 converted && this.Equals(converted);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
		{
			if (Sse2.IsSse2Supported)
			{
				return ((v128)this).SInt0;
			}
			else
			{
				byte4 temp = this;

				return *(int*)&temp;
			}
		}


		public override readonly string ToString() => $"byte4({x}, {y}, {z}, {w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"byte4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}