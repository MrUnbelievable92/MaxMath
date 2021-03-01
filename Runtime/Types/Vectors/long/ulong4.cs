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
    [Serializable]  [StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(ulong))]  [DebuggerTypeProxy(typeof(ulong4.DebuggerProxy))]
    unsafe public struct ulong4 : IEquatable<ulong4>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public ulong x;
            public ulong y;
            public ulong z;
            public ulong w;

            public DebuggerProxy(ulong4 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
                w = v.w;
            }
        }


        [FieldOffset(0)]  private fixed ulong asArray[4];
        
        [FieldOffset(0)]  internal ulong2 _xy;
        [FieldOffset(16)] internal ulong2 _zw;

        [FieldOffset(0)]  public ulong x;
        [FieldOffset(8)]  public ulong y;
        [FieldOffset(16)] public ulong z;
        [FieldOffset(24)] public ulong w;


        public static ulong4 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong y, ulong z, ulong w)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi64x((long)w, (long)z, (long)y, (long)x);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new ulong4
                {
                    _xy = new ulong2(x, y),
                    _zw = new ulong2(z, w)
                };
            }
            else
            {
                this = new ulong4
                {
                    x = x,
                    y = y,
                    z = z,
                    w = w
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong xyzw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set1_epi64x((long)xyzw);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new ulong4
                {
                    _xy = new ulong2(xyzw),
                    _zw = new ulong2(xyzw)
                };
            }
            else
            {
                this = new ulong4
                {
                    x = xyzw,
                    y = xyzw,
                    z = xyzw,
                    w = xyzw
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong2 xy, ulong z, ulong w)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(new ulong2(z, w), xy);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new ulong4
                {
                    _xy = xy,
                    _zw = new ulong2(z, w)
                };
            }
            else
            {
                this = new ulong4
                {
                    x = xy.x,
                    y = xy.y,
                    z = z,
                    w = w
                };
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong2 yz, ulong w)
        {
            if (Avx2.IsAvx2Supported)
            {
                v256 shuf = yz.xxyy;
                shuf.ULong0 = x;
                shuf.ULong3 = w;

                this = shuf;
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.shuffle_epi32(yz, Sse.SHUFFLE(1, 0, 1, 0));
                lo.ULong0 = x;

                v128 hi = Sse2.shuffle_epi32(yz, Sse.SHUFFLE(3, 2, 3, 2));
                hi.ULong1 = w;

                this = new ulong4
                {
                    _xy = lo,
                    _zw = hi
                };
            }
            else
            {
                this = new ulong4
                {
                    x = x,
                    y = yz.x,
                    z = yz.y,
                    w = w
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong y, ulong2 zw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(zw, new ulong2(x, y));
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new ulong4
                {
                    _xy = new ulong2(x, y),
                    _zw = zw
                };
            }
            else
            {
                this = new ulong4
                {
                    x = x,
                    y = y,
                    z = zw.x,
                    w = zw.y,
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong2 xy, ulong2 zw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(zw, xy);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new ulong4
                {
                    _xy = xy,
                    _zw = zw
                };
            }
            else
            {
                this = new ulong4
                {
                    x = xy.x,
                    y = xy.y,
                    z = zw.x,
                    w = zw.y
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong3 xyz, ulong w)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(xyz, (long)w, 3);
            }
            else if (Sse2.IsSse2Supported)
            {
                this = new ulong4
                {
                    _xy = xyz._xy,
                    _zw = new ulong2(xyz.z, w)
                };
            }
            else
            {
                this = new ulong4
                {
                    x = xyz.x,
                    y = xyz.y,
                    z = xyz.z,
                    w = w
                };
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong4(ulong x, ulong3 yzw)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(yzw.xxyz, (long)x, 0);
            }
            else if (Sse2.IsSse2Supported)
            {
                v128 lo = Sse2.shuffle_epi32(yzw._xy, Sse.SHUFFLE(1, 0, 1, 0));
                lo.ULong0 = x;
                ulong2 hi = yzw.yz;

                this = new ulong4
                {
                    _xy = lo,
                    _zw = hi
                };
            }
            else
            {
                this = new ulong4
                {
                    x = x,
                    y = yzw.x,
                    z = yzw.y,
                    w = yzw.z
                };
            }
        }

		
        #region Shuffle
        public  ulong4 xxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this));
				}
				else
				{
					return new ulong4(xx, xx);
				}
			}
		}
		public  ulong4 xxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 0));
				}
				else
				{
					return new ulong4(xx, xy);
				}
			}
		}
		public  ulong4 xxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 0));
				}
				else
				{
					return new ulong4(xx, xz);
				}
			}
		}
		public  ulong4 xxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 0));
				}
				else
				{
					return new ulong4(xx, xw);
				}
			}
		}
		public  ulong4 xxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 0));
				}
				else
				{
					return new ulong4(xx, yx);
				}
			}
		}
		public  ulong4 xxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 0));
				}
				else
				{
					return new ulong4(xx, yy);
				}
			}
		}
		public  ulong4 xxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 0));
				}
				else
				{
					return new ulong4(xx, yz);
				}
			}
		}
		public  ulong4 xxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0));
				}
				else
				{
					return new ulong4(xx, yw);
				}
			}
		}
		public  ulong4 xxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 0));
				}
				else
				{
					return new ulong4(xx, zx);
				}
			}
		}
		public  ulong4 xxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 0));
				}
				else
				{
					return new ulong4(xx, zy);
				}
			}
		}
		public  ulong4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
				}
				else
				{
					return new ulong4(xx, zz);
				}
			}
		}
		public  ulong4 xxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 0));
				}
				else
				{
					return new ulong4(xx, zw);
				}
			}
		}
		public  ulong4 xxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 0));
				}
				else
				{
					return new ulong4(xx, wx);
				}
			}
		}
		public  ulong4 xxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 0));
				}
				else
				{
					return new ulong4(xx, wy);
				}
			}
		}
		public  ulong4 xxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 0));
				}
				else
				{
					return new ulong4(xx, wz);
				}
			}
		}
		public  ulong4 xxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 0));
				}
				else
				{
					return new ulong4(xx, ww);
				}
			}
		}
		public  ulong4 xyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 0));
				}
				else
				{
					return new ulong4(xy, xx);
				}
			}
		}
		public  ulong4 xyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 0));
				}
				else
				{
					return new ulong4(xy, xy);
				}
			}
		}
		public  ulong4 xyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 0));
				}
				else
				{
					return new ulong4(xy, xz);
				}
			}
		}
		public  ulong4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 0));
				}
				else
				{
					return new ulong4(xy, xw);
				}
			}
		}
		public  ulong4 xyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 0));
				}
				else
				{
					return new ulong4(xy, yx);
				}
			}
		}
		public  ulong4 xyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 0));
				}
				else
				{
					return new ulong4(xy, yy);
				}
			}
		}
		public  ulong4 xyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 0));
				}
				else
				{
					return new ulong4(xy, yz);
				}
			}
		}
		public  ulong4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0));
				}
				else
				{
					return new ulong4(xy, yw);
				}
			}
		}
		public  ulong4 xyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 0));
				}
				else
				{
					return new ulong4(xy, zx);
				}
			}
		}
		public  ulong4 xyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 0));
				}
				else
				{
					return new ulong4(xy, zy);
				}
			}
		}
		public  ulong4 xyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 0));
				}
				else
				{
					return new ulong4(xy, zz);
				}
			}
		}
		public  ulong4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 0));
				}
				else
				{
					return new ulong4(xy, wx);
				}
			}
		}
		public  ulong4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 0));
				}
				else
				{
					return new ulong4(xy, wy);
				}
			}
		}
		public			ulong4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 0));
				}
				else
				{
					return new ulong4(xy, wz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xywz;
			}
		}
		public  ulong4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 0));
				}
				else
				{
					return new ulong4(xy, ww);
				}
			}
		}
		public  ulong4 xzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 0));
				}
				else
				{
					return new ulong4(xz, xx);
				}
			}
		}
		public  ulong4 xzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 0));
				}
				else
				{
					return new ulong4(xz, xy);
				}
			}
		}
		public  ulong4 xzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 0));
				}
				else
				{
					return new ulong4(xz, xz);
				}
			}
		}
		public  ulong4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0));
				}
				else
				{
					return new ulong4(xz, xw);
				}
			}
		}
		public  ulong4 xzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 0));
				}
				else
				{
					return new ulong4(xz, yx);
				}
			}
		}
		public  ulong4 xzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 0));
				}
				else
				{
					return new ulong4(xz, yy);
				}
			}
		}
		public  ulong4 xzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 0));
				}
				else
				{
					return new ulong4(xz, yz);
				}
			}
		}
		public			ulong4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0));
				}
				else
				{
					return new ulong4(xz, yw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzyw;
			}
		}
		public  ulong4 xzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 0));
				}
				else
				{
					return new ulong4(xz, zx);
				}
			}
		}
		public  ulong4 xzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 0));
				}
				else
				{
					return new ulong4(xz, zy);
				}
			}
		}
		public  ulong4 xzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 0));
				}
				else
				{
					return new ulong4(xz, zz);
				}
			}
		}
		public  ulong4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0));
				}
				else
				{
					return new ulong4(xz, zw);
				}
			}
		}
		public  ulong4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 0)); ;
				}
				else
				{
					return new ulong4(xz, wx);
				}
			}
		}
		public			ulong4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 0));
				}
				else
				{
					return new ulong4(xz, wy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwyz;
			}
		}
		public  ulong4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 0));
				}
				else
				{
					return new ulong4(xz, wz);
				}
			}
		}
		public  ulong4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new ulong4(xz, ww);
				}
			}
		}
		public  ulong4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 0));
				}
				else
				{
					return new ulong4(xw, xx);
				}
			}
		}
		public  ulong4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 0));
				}
				else
				{
					return new ulong4(xw, xy);
				}
			}
		}
		public  ulong4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 0));
				}
				else
				{
					return new ulong4(xw, xz);
				}
			}
		}
		public  ulong4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 0));
				}
				else
				{
					return new ulong4(xw, xw);
				}
			}
		}
		public  ulong4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 0));
				}
				else
				{
					return new ulong4(xw, yx);
				}
			}
		}
		public  ulong4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 0));
				}
				else
				{
					return new ulong4(xw, yy);
				}
			}
		}
		public			ulong4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 0));
				}
				else
				{
					return new ulong4(xw, yz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xzwy;
			}
		}
		public  ulong4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 0));
				}
				else
				{
					return new ulong4(xw, yw);
				}
			}
		}
		public  ulong4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 0));
				}
				else
				{
					return new ulong4(xw, zx);
				}
			}
		}
		public			ulong4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 0));
				}
				else
				{
					return new ulong4(xw, zy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.xwzy;
			}
		}
		public  ulong4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 0));
				}
				else
				{
					return new ulong4(xw, zz);
				}
			}
		}
		public  ulong4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 0));
				}
				else
				{
					return new ulong4(xw, zw);
				}
			}
		}
		public  ulong4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 0));
				}
				else
				{
					return new ulong4(xw, wx);
				}
			}
		}
		public  ulong4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 0));
				}
				else
				{
					return new ulong4(xw, wy);
				}
			}
		}
		public  ulong4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 0));
				}
				else
				{
					return new ulong4(xw, wz);
				}
			}
		}
		public  ulong4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new ulong4(xw, ww);
				}
			}
		}
		public  ulong4 yxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 1));
				}
				else
				{
					return new ulong4(yx, xx);
				}
			}
		}
        public  ulong4 yxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 1));
				}
				else
				{
					return new ulong4(yx, xy);
				}
			}
		}
        public  ulong4 yxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 1));
				}
				else
				{
					return new ulong4(yx, xz);
				}
			}
		}
        public  ulong4 yxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1));
				}
				else
				{
					return new ulong4(yx, xw);
				}
			}
		}
        public  ulong4 yxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 1));
				}
				else
				{
					return new ulong4(yx, yx);
				}
			}
		}
        public  ulong4 yxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 1));
				}
				else
				{
					return new ulong4(yx, yy);
				}
			}
		}
        public  ulong4 yxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 1));
				}
				else
				{
					return new ulong4(yx, yz);
				}
			}
		}
        public  ulong4 yxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1));
				}
				else
				{
					return new ulong4(yx, yw);
				}
			}
		}
        public  ulong4 yxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 1));
				}
				else
				{
					return new ulong4(yx, zx);
				}
			}
		}
        public  ulong4 yxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 1));
				}
				else
				{
					return new ulong4(yx, zy);
				}
			}
		}
        public  ulong4 yxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 1));
				}
				else
				{
					return new ulong4(yx, zz);
				}
			}
		}
        public			ulong4 yxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1));
				}
				else
				{
					return new ulong4(yx, zw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxzw;
			}
		}
        public  ulong4 yxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 1));
				}
				else
				{
					return new ulong4(yx, wx);
				}
			}
		}
        public  ulong4 yxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 1));
				}
				else
				{
					return new ulong4(yx, wy);
				}
			}
		}
        public			ulong4 yxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new ulong4(yx, wz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yxwz;
			}
		}
        public  ulong4 yxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 1));
				}
				else
				{
					return new ulong4(yx, ww);
				}
			}
		}
        public  ulong4 yyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 1));
				}
				else
				{
					return new ulong4(yy, xx);
				}
			}
		}
        public  ulong4 yyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 1));
				}
				else
				{
					return new ulong4(yy, xy);
				}
			}
		}
        public  ulong4 yyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 1));
				}
				else
				{
					return new ulong4(yy, xz);
				}
			}
		}
        public  ulong4 yyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1));
				}
				else
				{
					return new ulong4(yy, xw);
				}
			}
		}
        public  ulong4 yyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 1));
				}
				else
				{
					return new ulong4(yy, yx);
				}
			}
		}
        public  ulong4 yyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 1));
				}
				else
				{
					return new ulong4(yy, yy);
				}
			}
		}
        public  ulong4 yyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 1));
				}
				else
				{
					return new ulong4(yy, yz);
				}
			}
		}
        public  ulong4 yyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1));
				}
				else
				{
					return new ulong4(yy, yw);
				}
			}
		}
        public  ulong4 yyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 1));
				}
				else
				{
					return new ulong4(yy, zx);
				}
			}
		}
        public  ulong4 yyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 1));
				}
				else
				{
					return new ulong4(yy, zy);
				}
			}
		}
        public  ulong4 yyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 1));
				}
				else
				{
					return new ulong4(yy, zz);
				}
			}
		}
        public  ulong4 yyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1));
				}
				else
				{
					return new ulong4(yy, zw);
				}
			}
		}
        public  ulong4 yywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 1));
				}
				else
				{
					return new ulong4(yy, wx);
				}
			}
		}
        public  ulong4 yywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 1));
				}
				else
				{
					return new ulong4(yy, wy);
				}
			}
		}
        public  ulong4 yywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 1));
				}
				else
				{
					return new ulong4(yy, wz);
				}
			}
		}
        public  ulong4 yyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new ulong4(yy, ww);
				}
			}
		}
        public  ulong4 yzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1));
				}
				else
				{
					return new ulong4(yz, xx);
				}
			}
		}
        public  ulong4 yzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 1));
				}
				else
				{
					return new ulong4(yz, xy);
				}
			}
		}
        public  ulong4 yzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 1));
				}
				else
				{
					return new ulong4(yz, xz);
				}
			}
		}
        public			ulong4 yzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1));
				}
				else
				{
					return new ulong4(yz, xw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxyw;
			}
		}
        public  ulong4 yzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 1));
				}
				else
				{
					return new ulong4(yz, yx);
				}
			}
		}
        public  ulong4 yzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 1));
				}
				else
				{
					return new ulong4(yz, yy);
				}
			}
		}
        public  ulong4 yzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 1));
				}
				else
				{
					return new ulong4(yz, yz);
				}
			}
		}
        public  ulong4 yzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1));
				}
				else
				{
					return new ulong4(yz, yw);
				}
			}
		}
        public  ulong4 yzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 1));
				}
				else
				{
					return new ulong4(yz, zx);
				}
			}
		}
        public  ulong4 yzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 1));
				}
				else
				{
					return new ulong4(yz, zy);
				}
			}
		}
        public  ulong4 yzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 1));
				}
				else
				{
					return new ulong4(yz, zz);
				}
			}
		}
        public  ulong4 yzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1));
				}
				else
				{
					return new ulong4(yz, zw);
				}
			}
		}
        public			ulong4 yzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 1)); ;
				}
				else
				{
					return new ulong4(yz, wx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxyz;
			}
		}
        public  ulong4 yzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 1));
				}
				else
				{
					return new ulong4(yz, wy);
				}
			}
		}
        public  ulong4 yzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 1));
				}
				else
				{
					return new ulong4(yz, wz);
				}
			}
		}
        public  ulong4 yzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1));
				}
				else
				{
					return new ulong4(yz, ww);
				}
			}
		}
        public  ulong4 ywxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 1));
				}
				else
				{
					return new ulong4(yw, xx);
				}
			}
		}
        public  ulong4 ywxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 1));
				}
				else
				{
					return new ulong4(yw, xy);
				}
			}
		}
        public			ulong4 ywxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 1));
				}
				else
				{
					return new ulong4(yw, xz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zxwy;
			}
		}
        public  ulong4 ywxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 1));
				}
				else
				{
					return new ulong4(yw, xw);
				}
			}
		}
        public  ulong4 ywyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 1));
				}
				else
				{
					return new ulong4(yw, yx);
				}
			}
		}
        public  ulong4 ywyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 1));
				}
				else
				{
					return new ulong4(yw, yy);
				}
			}
		}
        public  ulong4 ywyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 1));
				}
				else
				{
					return new ulong4(yw, yz);
				}
			}
		}
        public  ulong4 ywyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 1));
				}
				else
				{
					return new ulong4(yw, yw);
				}
			}
		}
        public			ulong4 ywzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 1));
				}
				else
				{
					return new ulong4(yw, zx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wxzy;
			}
		}
        public  ulong4 ywzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 1));
				}
				else
				{
					return new ulong4(yw, zy);
				}
			}
		}
        public  ulong4 ywzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 1));
				}
				else
				{
					return new ulong4(yw, zz);
				}
			}
		}
        public  ulong4 ywzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 1));
				}
				else
				{
					return new ulong4(yw, zw);
				}
			}
		}
        public  ulong4 ywwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 1));
				}
				else
				{
					return new ulong4(yw, wx);
				}
			}
		}
        public  ulong4 ywwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 1));
				}
				else
				{
					return new ulong4(yw, wy);
				}
			}
		}
        public  ulong4 ywwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 1));
				}
				else
				{
					return new ulong4(yw, wz);
				}
			}
		}
        public  ulong4 ywww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new ulong4(yw, ww);
				}
			}
		}
        public  ulong4 zxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 2));
				}
				else
				{
					return new ulong4(zx, xx);
				}
			}
		}
        public  ulong4 zxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 2));
				}
				else
				{
					return new ulong4(zx, xy);
				}
			}
		}
        public  ulong4 zxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 2));
				}
				else
				{
					return new ulong4(zx, xz);
				}
			}
		}
        public  ulong4 zxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2));
				}
				else
				{
					return new ulong4(zx, xw);
				}
			}
		}
        public  ulong4 zxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 2));
				}
				else
				{
					return new ulong4(zx, yx);
				}
			}
		}
        public  ulong4 zxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 2));
				}
				else
				{
					return new ulong4(zx, yy);
				}
			}
		}
		public  ulong4 zxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 2));
				}
				else
				{
					return new ulong4(zx, yz);
				}
			}
		}
        public			ulong4 zxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2));
				}
				else
				{
					return new ulong4(zx, yw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzxw;
			}
		}
        public  ulong4 zxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 2));
				}
				else
				{
					return new ulong4(zx, zx);
				}
			}
		}
        public  ulong4 zxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 2));
				}
				else
				{
					return new ulong4(zx, zy);
				}
			}
		}
        public  ulong4 zxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 2));
				}
				else
				{
					return new ulong4(zx, zz);
				}
			}
		}
        public  ulong4 zxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2));
				}
				else
				{
					return new ulong4(zx, zw);
				}
			}
		}
        public  ulong4 zxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 2));
				}
				else
				{
					return new ulong4(zx, wx);
				}
			}
		}
        public			ulong4 zxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 2));
				}
				else
				{
					return new ulong4(zx, wy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywxz;
			}
		}
        public  ulong4 zxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 2));
				}
				else
				{
					return new ulong4(zx, wz);
				}
			}
		}
        public  ulong4 zxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new ulong4(zx, ww);
				}
			}
		}
        public  ulong4 zyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 2));
				}
				else
				{
					return new ulong4(zy, xx);
				}
			}
		}
        public  ulong4 zyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 2));
				}
				else
				{
					return new ulong4(zy, xy);
				}
			}
		}
        public  ulong4 zyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 2));
				}
				else
				{
					return new ulong4(zy, xz);
				}
			}
		}
        public			ulong4 zyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2));
				}
				else
				{
					return new ulong4(zy, xw);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zyxw;
			}
		}
        public  ulong4 zyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 2));
				}
				else
				{
					return new ulong4(zy, yx);
				}
			}
		}
        public  ulong4 zyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 2));
				}
				else
				{
					return new ulong4(zy, yy);
				}
			}
		}
        public  ulong4 zyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 2));
				}
				else
				{
					return new ulong4(zy, yz);
				}
			}
		}
        public  ulong4 zyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2));
				}
				else
				{
					return new ulong4(zy, yw);
				}
			}
		}
        public  ulong4 zyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 2));
				}
				else
				{
					return new ulong4(zy, zx);
				}
			}
		}
        public  ulong4 zyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 2));
				}
				else
				{
					return new ulong4(zy, zy);
				}
			}
		}
        public  ulong4 zyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 2));
				}
				else
				{
					return new ulong4(zy, zz);
				}
			}
		}
        public  ulong4 zyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2));
				}
				else
				{
					return new ulong4(zy, zw);
				}
			}
		}
        public			ulong4 zywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 2));
				}
				else
				{
					return new ulong4(zy, wx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyxz;
			}
		}
        public  ulong4 zywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 2));
				}
				else
				{
					return new ulong4(zy, wy);
				}
			}
		}
        public  ulong4 zywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 2));
				}
				else
				{
					return new ulong4(zy, wz);
				}
			}
		}
        public  ulong4 zyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new ulong4(zy, ww);
				}
			}
		}
        public  ulong4 zzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 2));
				}
				else
				{
					return new ulong4(zz, xx);
				}
			}
		}
        public  ulong4 zzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 2));
				}
				else
				{
					return new ulong4(zz, xy);
				}
			}
		}
        public  ulong4 zzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 2));
				}
				else
				{
					return new ulong4(zz, xz);
				}
			}
		}
        public  ulong4 zzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2));
				}
				else
				{
					return new ulong4(zz, xw);
				}
			}
		}
        public  ulong4 zzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 2));
				}
				else
				{
					return new ulong4(zz, yx);
				}
			}
		}
        public  ulong4 zzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 2));
				}
				else
				{
					return new ulong4(zz, yy);
				}
			}
		}
        public  ulong4 zzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 2));
				}
				else
				{
					return new ulong4(zz, yz);
				}
			}
		}
        public  ulong4 zzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2));
				}
				else
				{
					return new ulong4(zz, yw);
				}
			}
		}
        public  ulong4 zzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 2));
				}
				else
				{
					return new ulong4(zz, zx);
				}
			}
		}
        public  ulong4 zzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 2));
				}
				else
				{
					return new ulong4(zz, zy);
				}
			}
		}
        public  ulong4 zzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 2));
				}
				else
				{
					return new ulong4(zz, zz);
				}
			}
		}
        public  ulong4 zzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2));
				}
				else
				{
					return new ulong4(zz, zw);
				}
			}
		}
        public  ulong4 zzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 2)); ;
				}
				else
				{
					return new ulong4(zz, wx);
				}
			}
		}
        public  ulong4 zzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 2));
				}
				else
				{
					return new ulong4(zz, wy);
				}
			}
		}
        public  ulong4 zzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 2));
				}
				else
				{
					return new ulong4(zz, wz);
				}
			}
		}
        public  ulong4 zzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new ulong4(zz, ww);
				}
			}
		}
        public  ulong4 zwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 2));
				}
				else
				{
					return new ulong4(zw, xx);
				}
			}
		}
        public			ulong4 zwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new ulong4(zw, xy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwxy;
			}
		}
        public  ulong4 zwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 2));
				}
				else
				{
					return new ulong4(zw, xz);
				}
			}
		}
        public  ulong4 zwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 2));
				}
				else
				{
					return new ulong4(zw, xw);
				}
			}
		}
        public			ulong4 zwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 2));
				}
				else
				{
					return new ulong4(zw, yx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzxy;
			}
		}
        public  ulong4 zwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 2));
				}
				else
				{
					return new ulong4(zw, yy);
				}
			}
		}
        public  ulong4 zwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 2));
				}
				else
				{
					return new ulong4(zw, yz);
				}
			}
		}
        public  ulong4 zwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 2));
				}
				else
				{
					return new ulong4(zw, yw);
				}
			}
		}
        public  ulong4 zwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 2));
				}
				else
				{
					return new ulong4(zw, zx);
				}
			}
		}
        public  ulong4 zwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 2));
				}
				else
				{
					return new ulong4(zw, zy);
				}
			}
		}
        public  ulong4 zwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 2));
				}
				else
				{
					return new ulong4(zw, zz);
				}
			}
		}
        public  ulong4 zwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new ulong4(zw, zw);
				}
			}
		}
        public  ulong4 zwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 2));
				}
				else
				{
					return new ulong4(zw, wx);
				}
			}
		}
        public  ulong4 zwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 2));
				}
				else
				{
					return new ulong4(zw, wy);
				}
			}
		}
        public  ulong4 zwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 2));
				}
				else
				{
					return new ulong4(zw, wz);
				}
			}
		}
        public  ulong4 zwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 2));
				}
				else
				{
					return new ulong4(zw, ww);
				}
			}
		}
        public  ulong4 wxxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3));
				}
				else
				{
					return new ulong4(wx, xx);
				}
			}
		}
        public  ulong4 wxxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 0, 3));
				}
				else
				{
					return new ulong4(wx, xy);
				}
			}
		}
        public  ulong4 wxxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 0, 3));
				}
				else
				{
					return new ulong4(wx, xz);
				}
			}
		}
        public  ulong4 wxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 3));
				}
				else
				{
					return new ulong4(wx, xw);
				}
			}
		}
        public  ulong4 wxyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 0, 3));
				}
				else
				{
					return new ulong4(wx, yx);
				}
			}
		}
        public  ulong4 wxyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 0, 3));
				}
				else
				{
					return new ulong4(wx, yy);
				}
			}
		}
        public          ulong4 wxyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 0, 3));
				}
				else
				{
					return new ulong4(wx, yz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.yzwx;
			}
		}
        public  ulong4 wxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 3));
				}
				else
				{
					return new ulong4(wx, yw);
				}
			}
		}
        public  ulong4 wxzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 0, 3));
				}
				else
				{
					return new ulong4(wx, zx);
				}
			}
		}
        public          ulong4 wxzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 0, 3));
				}
				else
				{
					return new ulong4(wx, zy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.ywzx;
			}
		}
        public  ulong4 wxzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 0, 3));
				}
				else
				{
					return new ulong4(wx, zz);
				}
			}
		}
        public  ulong4 wxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 3));
				}
				else
				{
					return new ulong4(wx, zw);
				}
			}
		}
        public  ulong4 wxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 0, 3));
				}
				else
				{
					return new ulong4(wx, wx);
				}
			}
		}
        public  ulong4 wxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 0, 3));
				}
				else
				{
					return new ulong4(wx, wy);
				}
			}
		}
        public  ulong4 wxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 0, 3));
				}
				else
				{
					return new ulong4(wx, wz);
				}
			}
		}
        public  ulong4 wxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new ulong4(wx, ww);
				}
			}
		}
        public  ulong4 wyxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 1, 3));
				}
				else
				{
					return new ulong4(wy, xx);
				}
			}
		}
        public  ulong4 wyxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 3));
				}
				else
				{
					return new ulong4(wy, xy);
				}
			}
		}
        public          ulong4 wyxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 1, 3));
				}
				else
				{
					return new ulong4(wy, xz);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zywx;
			}
		}
        public  ulong4 wyxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 3));
				}
				else
				{
					return new ulong4(wy, xw);
				}
			}
		}
        public  ulong4 wyyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 1, 3));
				}
				else
				{
					return new ulong4(wy, yx);
				}
			}
		}
        public  ulong4 wyyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 1, 3));
				}
				else
				{
					return new ulong4(wy, yy);
				}
			}
		}
        public  ulong4 wyyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 1, 3));
				}
				else
				{
					return new ulong4(wy, yz);
				}
			}
		}
        public  ulong4 wyyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 3));
				}
				else
				{
					return new ulong4(wy, yw);
				}
			}
		}
        public          ulong4 wyzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 1, 3));
				}
				else
				{
					return new ulong4(wy, zx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wyzx;
			}
		}
        public  ulong4 wyzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 1, 3));
				}
				else
				{
					return new ulong4(wy, zy);
				}
			}
		}
        public  ulong4 wyzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 1, 3));
				}
				else
				{
					return new ulong4(wy, zz);
				}
			}
		}
        public  ulong4 wyzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 3));
				}
				else
				{
					return new ulong4(wy, zw);
				}
			}
		}
        public  ulong4 wywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 1, 3));
				}
				else
				{
					return new ulong4(wy, wx);
				}
			}
		}
        public  ulong4 wywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 1, 3));
				}
				else
				{
					return new ulong4(wy, wy);
				}
			}
		}
        public  ulong4 wywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 1, 3));
				}
				else
				{
					return new ulong4(wy, wz);
				}
			}
		}
        public  ulong4 wyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new ulong4(wy, ww);
				}
			}
		}
        public  ulong4 wzxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 3));
				}
				else
				{
					return new ulong4(wz, xx);
				}
			}
		}
        public          ulong4 wzxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 2, 3));
				}
				else
				{
					return new ulong4(wz, xy);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.zwyx;
			}
		}
        public  ulong4 wzxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 2, 3));
				}
				else
				{
					return new ulong4(wz, xz);
				}
			}
		}
        public  ulong4 wzxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 3));
				}
				else
				{
					return new ulong4(wz, xw);
				}
			}
		}
        public          ulong4 wzyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 2, 3));
				}
				else
				{
					return new ulong4(wz, yx);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				this = value.wzyx;
			}
		}
        public  ulong4 wzyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 2, 3));
				}
				else
				{
					return new ulong4(wz, yy);
				}
			}
		}
        public  ulong4 wzyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 2, 3));
				}
				else
				{
					return new ulong4(wz, yz);
				}
			}
		}
        public  ulong4 wzyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 3));
				}
				else
				{
					return new ulong4(wz, yw);
				}
			}
		}
        public  ulong4 wzzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 2, 3));
				}
				else
				{
					return new ulong4(wz, zx);
				}
			}
		}
        public  ulong4 wzzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 2, 3));
				}
				else
				{
					return new ulong4(wz, zy);
				}
			}
		}
        public  ulong4 wzzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 2, 3));
				}
				else
				{
					return new ulong4(wz, zz);
				}
			}
		}
        public  ulong4 wzzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 3));
				}
				else
				{
					return new ulong4(wz, zw);
				}
			}
		}
        public  ulong4 wzwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 2, 3)); ;
				}
				else
				{
					return new ulong4(wz, wx);
				}
			}
		}
        public  ulong4 wzwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 2, 3));
				}
				else
				{
					return new ulong4(wz, wy);
				}
			}
		}
        public  ulong4 wzwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 2, 3));
				}
				else
				{
					return new ulong4(wz, wz);
				}
			}
		}
        public  ulong4 wzww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new ulong4(wz, ww);
				}
			}
		}
        public  ulong4 wwxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 3, 3));
				}
				else
				{
					return new ulong4(ww, xx);
				}
			}
		}
        public  ulong4 wwxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 3, 3));
				}
				else
				{
					return new ulong4(ww, xy);
				}
			}
		}
        public  ulong4 wwxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 0, 3, 3));
				}
				else
				{
					return new ulong4(ww, xz);
				}
			}
		}
        public  ulong4 wwxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 3));
				}
				else
				{
					return new ulong4(ww, xw);
				}
			}
		}
        public  ulong4 wwyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 1, 3, 3));
				}
				else
				{
					return new ulong4(ww, yx);
				}
			}
		}
        public  ulong4 wwyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 1, 3, 3));
				}
				else
				{
					return new ulong4(ww, yy);
				}
			}
		}
        public  ulong4 wwyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 1, 3, 3));
				}
				else
				{
					return new ulong4(ww, yz);
				}
			}
		}
        public  ulong4 wwyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 3));
				}
				else
				{
					return new ulong4(ww, yw);
				}
			}
		}
        public  ulong4 wwzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 2, 3, 3));
				}
				else
				{
					return new ulong4(ww, zx);
				}
			}
		}
        public  ulong4 wwzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 2, 3, 3));
				}
				else
				{
					return new ulong4(ww, zy);
				}
			}
		}
        public  ulong4 wwzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 2, 3, 3));
				}
				else
				{
					return new ulong4(ww, zz);
				}
			}
		}
        public  ulong4 wwzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 3));
				}
				else
				{
					return new ulong4(ww, zw);
				}
			}
		}
        public  ulong4 wwwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 3, 3, 3));
				}
				else
				{
					return new ulong4(ww, wx);
				}
			}
		}
        public  ulong4 wwwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 3, 3, 3));
				}
				else
				{
					return new ulong4(ww, wy);
				}
			}
		}
        public  ulong4 wwwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(2, 3, 3, 3));
				}
				else
				{
					return new ulong4(ww, wz);
				}
			}
		}
        public  ulong4 wwww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
				{
					return new ulong4(ww, ww);
				}
			}
		}

        public  ulong3 xxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_broadcastq_epi64(Avx.mm256_castsi256_si128(this));
				}
				else
				{
					return new ulong3(xx, x);
				}
			}
		}
        public  ulong3 xxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 0));
				}
				else
				{
					return new ulong3(xx, y);
				}
			}
		}
        public  ulong3 xxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
				}
				else
				{
					return new ulong3(xx, z);
				}
			}
		}
        public  ulong3 xxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 0));
				}
				else
				{
					return new ulong3(xx, w);
				}
			}
		}
        public  ulong3 xyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 0));
				}
				else
				{
					return new ulong3(xy, x);
				}
			}
		}
        public  ulong3 xyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 0));
				}
				else
				{
					return new ulong3(xy, y);
				}
			}
		}
        public          ulong3 xyz
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return (v256)this;
				}
				else
				{
					return new ulong3(xy, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value, 0b0011_1111);
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
		}
        public          ulong3 xyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 0));
				}
				else
				{
					return new ulong3(xy, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xyzz, 0b1100_1111);
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
        public  ulong3 xzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 0));
				}
				else
				{
					return new ulong3(xz, x);
				}
			}
		}
        public          ulong3 xzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 0));
				}
				else
				{
					return new ulong3(xz, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xzyy, 0b0011_1111);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
		}
        public  ulong3 xzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 0));
				}
				else
				{
					return new ulong3(xz, z);
				}
			}
		}
        public          ulong3 xzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0));
				}
				else
				{
					return new ulong3(xz, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyz, 0b1111_0011);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
        public  ulong3 xwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 0));
				}
				else
				{
					return new ulong3(xw, x);
				}
			}
		}
        public          ulong3 xwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 0));
				}
				else
				{
					return new ulong3(xw, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xzzy, 0b1100_1111);
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
        public          ulong3 xwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 0));
				}
				else
				{
					return new ulong3(xw, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxzy, 0b1111_0011);
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
        public  ulong3 xww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0));
				}
				else
				{
					return new ulong3(xw, w);
				}
			}
		}
        public  ulong3 yxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 1));
				}
				else
				{
					return new ulong3(yx, x);
				}
			}
		}
        public  ulong3 yxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 1));
				}
				else
				{
					return new ulong3(yx, y);
				}
			}
		}
        public          ulong3 yxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 1));
				}
				else
				{
					return new ulong3(yx, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yxzz, 0b0011_1111);
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
        public          ulong3 yxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2));
				}
				else
				{
					return new ulong3(yx, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yxzz, 0b1100_1111);
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
        public  ulong3 yyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 1));
				}
				else
				{
					return new ulong3(yy, x);
				}
			}
		}
        public  ulong3 yyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 1));
				}
				else
				{
					return new ulong3(yy, y);
				}
			}
		}
        public  ulong3 yyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 1));
				}
				else
				{
					return new ulong3(yy, z);
				}
			}
		}
        public  ulong3 yyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new ulong3(yy, w);
				}
			}
		}
        public          ulong3 yzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 1));
				}
				else
				{
					return new ulong3(yz, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zxyy, 0b0011_1111);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
		}
        public  ulong3 yzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 1));
				}
				else
				{
					return new ulong3(yz, y);
				}
			}
		}
        public  ulong3 yzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 1));
				}
				else
				{
					return new ulong3(yz, z);
				}
			}
		}
        public          ulong3 yzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1));
				}
				else
				{
					return new ulong3(yz, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyz, 0b1111_1100);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
					this.w = value.z;
				}
			}
		}
        public          ulong3 ywx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 1));
				}
				else
				{
					return new ulong3(yw, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zxxy, 0b1100_1111);
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
        public  ulong3 ywy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 1));
				}
				else
				{
					return new ulong3(yw, y);
				}
			}
		}
        public          ulong3 ywz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 1));
				}
				else
				{
					return new ulong3(yw, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxzy, 0b1111_1100);
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
					this.z = value.z;
				}
			}
		}
        public  ulong3 yww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1));
				}
				else
				{
					return new ulong3(yw, w);
				}
			}
		}
        public  ulong3 zxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 2));
				}
				else
				{
					return new ulong3(zx, x);
				}
			}
		}
        public          ulong3 zxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 2));
				}
				else
				{
					return new ulong3(zx, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yzxx, 0b0011_1111);
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
        public  ulong3 zxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 2));
				}
				else
				{
					return new ulong3(zx, z);
				}
			}
		}
        public          ulong3 zxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2));
				}
				else
				{
					return new ulong3(zx, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxz, 0b1111_0011);
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
					this.w = value.z;
				}
			}
		}
        public          ulong3 zyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 2));
				}
				else
				{
					return new ulong3(zy, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zyxx, 0b0011_1111);
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
        public  ulong3 zyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 2));
				}
				else
				{
					return new ulong3(zy, y);
				}
			}
		}
        public  ulong3 zyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 2));
				}
				else
				{
					return new ulong3(zy, z);
				}
			}
		}
        public          ulong3 zyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2));
				}
				else
				{
					return new ulong3(zy, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxz, 0b1111_1100);
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
					this.w = value.z;
				}
			}
		}
        public  ulong3 zzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 2));
				}
				else
				{
					return new ulong3(zz, x);
				}
			}
		}
        public  ulong3 zzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 2));
				}
				else
				{
					return new ulong3(zz, y);
				}
			}
		}
        public  ulong3 zzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 2));
				}
				else
				{
					return new ulong3(zz, z);
				}
			}
		}
        public  ulong3 zzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2));
				}
				else
				{
					return new ulong3(zz, w);
				}
			}
		}
        public          ulong3 zwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 2));
				}
				else
				{
					return new ulong3(zw, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zzxy, 0b1111_0011);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.x = value.z;
				}
			}
		}
        public          ulong3 zwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 2));
				}
				else
				{
					return new ulong3(zw, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zzxy, 0b1111_1100);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
					this.y = value.z;
				}
			}
		}
        public  ulong3 zwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 2));
				}
				else
				{
					return new ulong3(zw, z);
				}
			}
		}
        public  ulong3 zww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 2));
				}
				else
				{
					return new ulong3(zw, w);
				}
			}
		}
        public  ulong3 wxx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 0, 3));
				}
				else
				{
					return new ulong3(wx, x);
				}
			}
		}
        public          ulong3 wxy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 0, 3));
				}
				else
				{
					return new ulong3(wx, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yzzx, 0b1100_1111);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.y = value.z;
				}
			}
		}
        public          ulong3 wxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 0, 3));
				}
				else
				{
					return new ulong3(wx, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyzx, 0b1111_0011);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
					this.z = value.z;
				}
			}
		}
        public  ulong3 wxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3));
				}
				else
				{
					return new ulong3(wx, w);
				}
			}
		}
        public          ulong3 wyx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 1, 3));
				}
				else
				{
					return new ulong3(wy, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zyyx, 0b1100_1111);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.x = value.z;
				}
			}
		}
        public  ulong3 wyy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 1, 3));
				}
				else
				{
					return new ulong3(wy, y);
				}
			}
        }
        public          ulong3 wyz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 1, 3));
				}
				else
				{
					return new ulong3(wy, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyzx, 0b1111_1100);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
					this.z = value.z;
				}
			}
        }
        public  ulong3 wyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3));
				}
				else
				{
					return new ulong3(wy, w);
				}
			}
        }
        public          ulong3 wzx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 2, 3));
				}
				else
				{
					return new ulong3(wz, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zzyx, 0b1111_0011);
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.x = value.z;
				}
			}
        }
        public          ulong3 wzy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 2, 3));
				}
				else
				{
					return new ulong3(wz, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.zzyx, 0b1111_1100);
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
					this.y = value.z;
				}
			}
        }
        public  ulong3 wzz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 2, 3));
				}
				else
				{
					return new ulong3(wz, z);
				}
			}
        }
        public  ulong3 wzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3));
				}
				else
				{
					return new ulong3(wz, w);
				}
			}
        }
        public  ulong3 wwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 0, 3, 3));
				}
				else
				{
					return new ulong3(ww, x);
				}
			}
        }
        public  ulong3 wwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 1, 3, 3));
				}
				else
				{
					return new ulong3(ww, y);
				}
			}
        }
        public  ulong3 wwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 2, 3, 3));
				}
				else
				{
					return new ulong3(ww, z);
				}
			}
        }
        public  ulong3 www
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3));
				}
				else
				{
					return new ulong3(ww, w);
				}
			}
        }

        public  ulong2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 1, 0));
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._xy.xx;
				}
				else
				{
					return new ulong2(x, x);
				}
			}
		}
        public          ulong2 xy
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)] 
			 get
			{
				if (Avx.IsAvxSupported)
				{
					return Avx.mm256_castsi256_si128(this);
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._xy;
				}
				else
				{
					return new ulong2(x, y);
				}
            }

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value, 0);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = value;
				}
				else
				{
					this.x = value.x;
					this.y = value.y;
				}
			}
        }
        public          ulong2 xz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 0)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.unpacklo_epi64(this._xy, this._zw);
				}
				else
				{
					return new ulong2(x, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b0011_0011);
				}
				else if (Sse2.IsSse2Supported)
				{
                    if (Sse4_1.IsSse41Supported)
					{
						this._xy = Sse4_1.blend_epi16(this._xy, value, 0b0000_1111);
					}
					else
					{
						this._xy = Mask.BlendEpi16_SSE2(this._xy, value, 0b0000_1111);
					}

					this._zw = Sse2.unpackhi_epi64(value, this._zw);
				}
				else
				{
					this.x = value.x;
					this.z = value.y;
				}
			}
        }
        public          ulong2 xw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0)));
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return Sse4_1.blend_epi16(this._xy, this._zw, 0b1111_0000);
					}
					else
					{
						return Mask.BlendEpi16_SSE2(this._xy, this._zw, 0b1111_0000);
					}
				}
				else
				{
					return new ulong2(x, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b1100_0011);
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this._xy = Sse4_1.blend_epi16(this._xy, value, 0b0000_1111);
						this._zw = Sse4_1.blend_epi16(this._zw, value, 0b1111_0000);
					}
					else
					{
						this._xy = Mask.BlendEpi16_SSE2(this._xy, value, 0b0000_1111);
						this._zw = Mask.BlendEpi16_SSE2(this._zw, value, 0b1111_0000);
					}
				}
				else
				{
					this.x = value.x;
					this.w = value.y;
				}
			}
        }
        public          ulong2 yx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx.IsAvxSupported)
				{
					return Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 3, 2));
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._xy.yx;
				}
				else
				{
					return new ulong2(y, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value.yx, 0);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = value.yx;
				}
				else
				{
					this.y = value.x;
					this.x = value.y;
				}
			}
        }
        public  ulong2 yy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Sse2.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(3, 2, 3, 2));
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._xy.yy;
				}
				else
				{
					return new ulong2(y, y);
				}
			}
        }
        public          ulong2 yz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1)));
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return Sse2.shuffle_epi32(Sse4_1.blend_epi16(this._xy, this._zw, 0b0000_1111), Sse.SHUFFLE(1, 0, 3, 2));
					}
					else
					{
						return Sse2.shuffle_epi32(Mask.BlendEpi16_SSE2(this._xy, this._zw, 0b0000_1111), Sse.SHUFFLE(1, 0, 3, 2));
					}
				}
				else
				{
					return new ulong2(y, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b0011_1100);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = Sse2.unpacklo_epi64(this._xy, value);
					this._zw = Sse2.unpackhi_epi64(value, this._zw);
				}
				else
				{
					this.y = value.x;
					this.z = value.y;
				}
			}
        }
        public          ulong2 yw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 1)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.unpackhi_epi64(this._xy, this._zw);
				}
				else
				{
					return new ulong2(y, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_unpacklo_epi64(this, value.xxyy);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = Sse2.unpacklo_epi64(this._xy, value);

					if (Sse4_1.IsSse41Supported)
					{
						this._zw = Sse4_1.blend_epi16(this._zw, value, 0b1111_0000);
					}
					else
					{
						this._zw = Mask.BlendEpi16_SSE2(this._zw, value, 0b1111_0000);
					}
				}
				else
				{
					this.y = value.x;
					this.w = value.y;
				}
			}
        }
        public          ulong2 zx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 2)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.unpacklo_epi64(this._zw, this._xy);
				}
				else
				{
					return new ulong2(z, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b0011_0011);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = Sse2.unpackhi_epi64(value, this._xy);

					if (Sse4_1.IsSse41Supported)
					{
						this._zw = Sse4_1.blend_epi16(this._zw, value, 0b0000_1111);
					}
					else
					{
						this._zw = Mask.BlendEpi16_SSE2(this._zw, value, 0b0000_1111);
					}
				}
				else
				{
					this.z = value.x;
					this.x = value.y;
				}
			}
        }
        public          ulong2 zy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2)));
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return Sse4_1.blend_epi16(this._xy, this._zw, 0b0000_1111);
					}
					else
					{
						return Mask.BlendEpi16_SSE2(this._xy, this._zw, 0b0000_1111);
					}
				}
				else
				{
					return new ulong2(z, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b0011_1100);
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this._xy = Sse4_1.blend_epi16(this._xy, value, 0b1111_0000);
						this._zw = Sse4_1.blend_epi16(this._zw, value, 0b0000_1111);
					}
					else
					{
						this._xy = Mask.BlendEpi16_SSE2(this._xy, value, 0b1111_0000);
						this._zw = Mask.BlendEpi16_SSE2(this._zw, value, 0b0000_1111);
					}
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
				}
			}
        }
        public  ulong2 zz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 2)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._zw.xx;
				}
				else
				{
					return new ulong2(z, z);
				}
			}
        }
        public          ulong2 zw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_extracti128_si256(this, 1);
				}
				else if (Sse2.IsSse2Supported)
				{
					return this._zw;
				}
				else
				{
					return new ulong2(z, w);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value, 1);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._zw = value;
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
				}
			}
        }
        public          ulong2 wx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3)));
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						return Sse2.shuffle_epi32(Sse4_1.blend_epi16(this._xy, this._zw, 0b1111_0000), Sse.SHUFFLE(1, 0, 3, 2));
					}
					else
					{
						return Sse2.shuffle_epi32(Mask.BlendEpi16_SSE2(this._xy, this._zw, 0b1111_0000), Sse.SHUFFLE(1, 0, 3, 2));
					}
				}
				else
				{
					return new ulong2(w, x);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b1100_0011);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._xy = Sse2.unpackhi_epi64(value, this._xy);
					this._zw = Sse2.unpacklo_epi64(this._zw, value);
				}
				else
				{
					this.w = value.x;
					this.x = value.y;
				}
			}
        }
        public          ulong2 wy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 3)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.unpackhi_epi64(this._zw, this._xy);
				}
				else
				{
					return new ulong2(w, y);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b1100_1100);
				}
				else if (Sse2.IsSse2Supported)
				{
					if (Sse4_1.IsSse41Supported)
					{
						this._xy = Sse4_1.blend_epi16(this._xy, value, 0b1111_0000);
					}
					else
					{
						this._xy = Mask.BlendEpi16_SSE2(this._xy, value, 0b1111_0000);
					}

					this._zw = Sse2.unpacklo_epi64(this._zw, value);
				}
				else
				{
					this.w = value.x;
					this.y = value.y;
				}
			}
        }
        public          ulong2 wz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			 get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 3)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return _zw.yx;
				}
				else
				{
					return new ulong2(w, z);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				if (Avx2.IsAvx2Supported)
				{
					this = Avx2.mm256_inserti128_si256(this, value.yx, 1);
				}
				else if (Sse2.IsSse2Supported)
				{
					this._zw = value.yx;
				}
				else
				{
					this.w = value.x;
					this.z = value.y;
				}
			}
        }
        public  ulong2 ww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 3)));
				}
				else if (Sse2.IsSse2Supported)
                {
					return _zw.yy;
                }
				else
                {
					return new ulong2(w, w);
                }
			}
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx2.mm256_stream_load_si256(void* ptr)   Avx.mm256_load_si256(void* ptr)
        public static implicit operator v256(ulong4 input) => new v256(input.x, input.y, input.z, input.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]  // Burst optimizes this;    (worse) alternatives:   Avx.mm256_storeu_si256(void* ptr, v128 x)
        public static implicit operator ulong4(v256 input) => new ulong4 { x = input.ULong0, y = input.ULong1, z = input.ULong2, w = input.ULong3 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(ulong input) => new ulong4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(long4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return (v256)input;
            }
            else if (Sse2.IsSse2Supported)
            {
                return new ulong4((ulong2)input._xy, (ulong2)input._zw);
            }
            else
            {
                return *(ulong4*)&input;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(uint4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu32_epi64(*(v128*)&input);
            }
            else if (Sse2.IsSse2Supported)
            {
				return new ulong4
				{
					_xy = (ulong2)input.xy,
					_zw = (ulong2)input.zw
				};
			}
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong4(int4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi32_epi64(*(v128*)&input);
            }
            else if (Sse2.IsSse2Supported)
			{
				return new ulong4
				{
					_xy = (ulong2)input.xy,
					_zw = (ulong2)input.zw
				};
			}
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(half4 input) => (ulong4)(int4)(float4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(float4 input) => new ulong4((ulong2)input.xy, (ulong2)input.zw);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong4(double4 input) => new ulong4((ulong2)input.xy, (ulong2)input.zw);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4(ulong4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				v128 temp = Cast.Long4ToInt4(input); 
				
				return *(uint4*)&temp;
			}
			else
			{
				return new uint4((uint2)input._xy, (uint2)input._zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(ulong4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				v128 temp = Cast.Long4ToInt4(input); 
				
				return *(int4*)&temp;
			}
			else
			{
				return new int4((int2)input._xy, (int2)input._zw);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half4(ulong4 input) => (half4)(float4)(ushort4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(ulong4 input) => new float4((float2)input._xy, (float2)input._zw);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(ulong4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Cast.ULong4ToDouble4(input);
			}
			else
			{
				return new double4((double2)input._xy, (double2)input._zw);
			}
		}


        public ulong this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get
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
		public static ulong4 operator + (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_add_epi64(left, right);
			}
			else
			{
				return new ulong4(left._xy + right._xy, left._zw + right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator - (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_sub_epi64(left, right);
			}
			else
			{
				return new ulong4(left._xy - right._xy, left._zw - right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Operator.mul_long(left, right);
			}
			else
			{
				return new ulong4(left._xy * right._xy, left._zw * right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new ulong4(left.x / right.x, left.y / right.y, left.z / right.z, left.w / right.w);
			}
			else
			{
				return new ulong4(left._xy / right._xy, left._zw / right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new ulong4(left.x % right.x, left.y % right.y, left.z % right.z, left.w % right.w);
			}
			else
			{
				return new ulong4(left._xy % right._xy, left._zw % right._zw);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 operator * (ulong left, ulong4 right) => right * left;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, ulong right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new ulong4(left.x * right, left.y * right, left.z * right, left.w * right);
			}
			else
			{
				return new ulong4(left._xy * right, left._zw * right);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, ulong right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new ulong4(left.x / right, left.y / right, left.z / right, left.w / right);
			}
			else
			{
				return new ulong4(left._xy / right, left._zw / right);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, ulong right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return new ulong4(left.x % right, left.y % right, left.z % right, left.w % right);
			}
			else
			{
				return new ulong4(left._xy % right, left._zw % right);
			}
		}
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator & (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_and_si256(left, right);
			}
			else
			{
				return new ulong4(left._xy & right._xy, left._zw & right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator | (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_or_si256(left, right);
			}
			else
			{
				return new ulong4(left._xy | right._xy, left._zw | right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ^ (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_xor_si256(left, right);
			}
			else
			{
				return new ulong4(left._xy ^ right._xy, left._zw ^ right._zw);
			}
		}
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ++ (ulong4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_sub_epi64(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
			}
			else
			{
				return new ulong4(x._xy + 1, x._zw + 1);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator -- (ulong4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_add_epi64(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
			}
			else
			{
				return new ulong4(x._xy - 1, x._zw - 1);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator ~ (ulong4 x)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Avx2.mm256_xor_si256(x, Avx2.mm256_cmpeq_epi32(default(v256), default(v256)));
			}
			else
			{
				return new ulong4(~x._xy, ~x._zw);
			}
		}
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator << (ulong4 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Operator.shl_long(x, n);
			}
			else
			{
				return new ulong4(x._xy << n, x._zw << n);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator >> (ulong4 x, int n)
		{
			if (Avx2.IsAvx2Supported)
			{
				return Operator.shrl_long(x, n);
			}
			else
			{
				return new ulong4(x._xy >> n, x._zw >> n);
			}
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool4 operator == (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsTrue(Avx2.mm256_cmpeq_epi64(left, right));
			}
			else
			{
				return new bool4(left._xy == right._xy, left._zw == right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator < (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsTrue(Operator.greater_mask_ulong(right, left));
			}
			else
			{
				return new bool4(left._xy < right._xy, left._zw < right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator > (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsTrue(Operator.greater_mask_ulong(left, right));
			}
			else
			{
				return new bool4(left._xy > right._xy, left._zw > right._zw);
			}
		}
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator != (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsFalse(Avx2.mm256_cmpeq_epi64(left, right));
			}
			else
			{
				return new bool4(left._xy != right._xy, left._zw != right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator <= (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsFalse(Operator.greater_mask_ulong(left, right));
			}
			else
			{
				return new bool4(left._xy <= right._xy, left._zw <= right._zw);
			}
		}
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool4 operator >= (ulong4 left, ulong4 right)
		{
			if (Avx2.IsAvx2Supported)
			{
				return TestIsFalse(Operator.greater_mask_ulong(right, left));
			}
			else
			{
				return new bool4(left._xy >= right._xy, left._zw >= right._zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsTrue(v256 input)
        {
			if (Avx2.IsAvx2Supported)
			{
				int cast = 0x0101_0101 & Avx2.mm256_movemask_epi8(input);

				return *(bool4*)&cast;
			}
			else throw new CPUFeatureCheckException();
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool4 TestIsFalse(v256 input)
        {
			if (Avx2.IsAvx2Supported)
			{
				int cast = maxmath.andnot(0x0101_0101, Avx2.mm256_movemask_epi8(input));

				return *(bool4*)&cast;
			}
			else throw new CPUFeatureCheckException();
        }
    
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public  bool Equals(ulong4 other)
		{
			if (Avx2.IsAvx2Supported)
			{
				return uint.MaxValue == (uint)Avx2.mm256_movemask_epi8(Avx2.mm256_cmpeq_epi64(this, other));
			}
			else
			{
				return this._xy.Equals(other._xy) & this._zw.Equals(other._zw);
			}
		}

        public override  bool Equals(object obj) => Equals((ulong4)obj);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override  int GetHashCode()
		{
			if (Avx2.IsAvx2Supported)
			{
				return Hash.v256(this);
			}
			else
			{
				return (this._xy ^ this._zw).GetHashCode();
			}
		}
    

        public override  string ToString() => $"ulong4({x}, {y}, {z}, {w})";
        public  string ToString(string format, IFormatProvider formatProvider) => $"ulong4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}