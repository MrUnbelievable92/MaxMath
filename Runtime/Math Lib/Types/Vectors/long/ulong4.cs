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

namespace MaxMath
{
    [Serializable] 
	[StructLayout(LayoutKind.Explicit, Size = 4 * sizeof(ulong))]
	[DebuggerTypeProxy(typeof(ulong4.DebuggerProxy))]
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
        public readonly ulong4 xxxx
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
		public readonly ulong4 xxxy
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
		public readonly ulong4 xxxz
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
		public readonly ulong4 xxxw
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
		public readonly ulong4 xxyx
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
		public readonly ulong4 xxyy
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
		public readonly ulong4 xxyz
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
		public readonly ulong4 xxyw
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
		public readonly ulong4 xxzx
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
		public readonly ulong4 xxzy
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
		public readonly ulong4 xxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_unpacklo_epi64(this, this);
				}
				else
				{
					return new ulong4(xx, zz);
				}
			}
		}
		public readonly ulong4 xxzw
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
		public readonly ulong4 xxwx
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
		public readonly ulong4 xxwy
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
		public readonly ulong4 xxwz
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
		public readonly ulong4 xxww
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
		public readonly ulong4 xyxx
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
		public readonly ulong4 xyxy
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
		public readonly ulong4 xyxz
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
		public readonly ulong4 xyxw
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
		public readonly ulong4 xyyx
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
		public readonly ulong4 xyyy
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
		public readonly ulong4 xyyz
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
		public readonly ulong4 xyyw
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
		public readonly ulong4 xyzx
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
		public readonly ulong4 xyzy
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
		public readonly ulong4 xyzz
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
		public readonly ulong4 xywx
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
		public readonly ulong4 xywy
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
			readonly get
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
		public readonly ulong4 xyww
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
		public readonly ulong4 xzxx
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
		public readonly ulong4 xzxy
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
		public readonly ulong4 xzxz
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
		public readonly ulong4 xzxw
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
		public readonly ulong4 xzyx
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
		public readonly ulong4 xzyy
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
		public readonly ulong4 xzyz
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
			readonly get
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
		public readonly ulong4 xzzx
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
		public readonly ulong4 xzzy
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
		public readonly ulong4 xzzz
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
		public readonly ulong4 xzzw
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
		public readonly ulong4 xzwx
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
			readonly get
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
		public readonly ulong4 xzwz
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
		public readonly ulong4 xzww
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
		public readonly ulong4 xwxx
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
		public readonly ulong4 xwxy
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
		public readonly ulong4 xwxz
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
		public readonly ulong4 xwxw
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
		public readonly ulong4 xwyx
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
		public readonly ulong4 xwyy
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
			readonly get
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
		public readonly ulong4 xwyw
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
		public readonly ulong4 xwzx
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
			readonly get
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
		public readonly ulong4 xwzz
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
		public readonly ulong4 xwzw
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
		public readonly ulong4 xwwx
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
		public readonly ulong4 xwwy
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
		public readonly ulong4 xwwz
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
		public readonly ulong4 xwww
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
		public readonly ulong4 yxxx
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
        public readonly ulong4 yxxy
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
        public readonly ulong4 yxxz
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
        public readonly ulong4 yxxw
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
        public readonly ulong4 yxyx
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
        public readonly ulong4 yxyy
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
        public readonly ulong4 yxyz
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
        public readonly ulong4 yxyw
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
        public readonly ulong4 yxzx
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
        public readonly ulong4 yxzy
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
        public readonly ulong4 yxzz
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
			readonly get
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
        public readonly ulong4 yxwx
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
        public readonly ulong4 yxwy
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
			readonly get
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
        public readonly ulong4 yxww
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
        public readonly ulong4 yyxx
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
        public readonly ulong4 yyxy
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
        public readonly ulong4 yyxz
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
        public readonly ulong4 yyxw
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
        public readonly ulong4 yyyx
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
        public readonly ulong4 yyyy
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
        public readonly ulong4 yyyz
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
        public readonly ulong4 yyyw
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
        public readonly ulong4 yyzx
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
        public readonly ulong4 yyzy
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
        public readonly ulong4 yyzz
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
        public readonly ulong4 yyzw
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
        public readonly ulong4 yywx
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
        public readonly ulong4 yywy
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
        public readonly ulong4 yywz
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
        public readonly ulong4 yyww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_unpackhi_epi64(this, this);
				}
				else
				{
					return new ulong4(yy, ww);
				}
			}
		}
        public readonly ulong4 yzxx
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
        public readonly ulong4 yzxy
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
        public readonly ulong4 yzxz
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
			readonly get
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
        public readonly ulong4 yzyx
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
        public readonly ulong4 yzyy
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
        public readonly ulong4 yzyz
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
        public readonly ulong4 yzyw
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
        public readonly ulong4 yzzx
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
        public readonly ulong4 yzzy
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
        public readonly ulong4 yzzz
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
        public readonly ulong4 yzzw
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
			readonly get
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
        public readonly ulong4 yzwy
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
        public readonly ulong4 yzwz
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
        public readonly ulong4 yzww
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
        public readonly ulong4 ywxx
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
        public readonly ulong4 ywxy
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
			readonly get
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
        public readonly ulong4 ywxw
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
        public readonly ulong4 ywyx
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
        public readonly ulong4 ywyy
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
        public readonly ulong4 ywyz
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
        public readonly ulong4 ywyw
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
			readonly get
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
        public readonly ulong4 ywzy
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
        public readonly ulong4 ywzz
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
        public readonly ulong4 ywzw
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
        public readonly ulong4 ywwx
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
        public readonly ulong4 ywwy
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
        public readonly ulong4 ywwz
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
        public readonly ulong4 ywww
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
        public readonly ulong4 zxxx
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
        public readonly ulong4 zxxy
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
        public readonly ulong4 zxxz
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
        public readonly ulong4 zxxw
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
        public readonly ulong4 zxyx
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
        public readonly ulong4 zxyy
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
		public readonly ulong4 zxyz
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
			readonly get
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
        public readonly ulong4 zxzx
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
        public readonly ulong4 zxzy
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
        public readonly ulong4 zxzz
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
        public readonly ulong4 zxzw
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
        public readonly ulong4 zxwx
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
			readonly get
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
        public readonly ulong4 zxwz
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
        public readonly ulong4 zxww
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
        public readonly ulong4 zyxx
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
        public readonly ulong4 zyxy
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
        public readonly ulong4 zyxz
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
			readonly get
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
        public readonly ulong4 zyyx
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
        public readonly ulong4 zyyy
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
        public readonly ulong4 zyyz
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
        public readonly ulong4 zyyw
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
        public readonly ulong4 zyzx
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
        public readonly ulong4 zyzy
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
        public readonly ulong4 zyzz
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
        public readonly ulong4 zyzw
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
			readonly get
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
        public readonly ulong4 zywy
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
        public readonly ulong4 zywz
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
        public readonly ulong4 zyww
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
        public readonly ulong4 zzxx
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
        public readonly ulong4 zzxy
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
        public readonly ulong4 zzxz
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
        public readonly ulong4 zzxw
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
        public readonly ulong4 zzyx
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
        public readonly ulong4 zzyy
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
        public readonly ulong4 zzyz
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
        public readonly ulong4 zzyw
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
        public readonly ulong4 zzzx
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
        public readonly ulong4 zzzy
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
        public readonly ulong4 zzzz
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
        public readonly ulong4 zzzw
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
        public readonly ulong4 zzwx
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
        public readonly ulong4 zzwy
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
        public readonly ulong4 zzwz
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
        public readonly ulong4 zzww
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
        public readonly ulong4 zwxx
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
			readonly get
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
        public readonly ulong4 zwxz
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
        public readonly ulong4 zwxw
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
			readonly get
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
        public readonly ulong4 zwyy
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
        public readonly ulong4 zwyz
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
        public readonly ulong4 zwyw
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
        public readonly ulong4 zwzx
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
        public readonly ulong4 zwzy
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
        public readonly ulong4 zwzz
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
        public readonly ulong4 zwzw
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
        public readonly ulong4 zwwx
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
        public readonly ulong4 zwwy
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
        public readonly ulong4 zwwz
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
        public readonly ulong4 zwww
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
        public readonly ulong4 wxxx
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
        public readonly ulong4 wxxy
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
        public readonly ulong4 wxxz
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
        public readonly ulong4 wxxw
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
        public readonly ulong4 wxyx
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
        public readonly ulong4 wxyy
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
			readonly get
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
        public readonly ulong4 wxyw
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
        public readonly ulong4 wxzx
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
			readonly get
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
        public readonly ulong4 wxzz
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
        public readonly ulong4 wxzw
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
        public readonly ulong4 wxwx
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
        public readonly ulong4 wxwy
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
        public readonly ulong4 wxwz
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
        public readonly ulong4 wxww
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
        public readonly ulong4 wyxx
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
        public readonly ulong4 wyxy
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
			readonly get
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
        public readonly ulong4 wyxw
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
        public readonly ulong4 wyyx
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
        public readonly ulong4 wyyy
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
        public readonly ulong4 wyyz
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
        public readonly ulong4 wyyw
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
			readonly get
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
        public readonly ulong4 wyzy
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
        public readonly ulong4 wyzz
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
        public readonly ulong4 wyzw
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
        public readonly ulong4 wywx
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
        public readonly ulong4 wywy
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
        public readonly ulong4 wywz
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
        public readonly ulong4 wyww
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
        public readonly ulong4 wzxx
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
			readonly get
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
        public readonly ulong4 wzxz
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
        public readonly ulong4 wzxw
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
			readonly get
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
        public readonly ulong4 wzyy
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
        public readonly ulong4 wzyz
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
        public readonly ulong4 wzyw
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
        public readonly ulong4 wzzx
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
        public readonly ulong4 wzzy
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
        public readonly ulong4 wzzz
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
        public readonly ulong4 wzzw
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
        public readonly ulong4 wzwx
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
        public readonly ulong4 wzwy
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
        public readonly ulong4 wzwz
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
        public readonly ulong4 wzww
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
        public readonly ulong4 wwxx
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
        public readonly ulong4 wwxy
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
        public readonly ulong4 wwxz
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
        public readonly ulong4 wwxw
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
        public readonly ulong4 wwyx
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
        public readonly ulong4 wwyy
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
        public readonly ulong4 wwyz
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
        public readonly ulong4 wwyw
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
        public readonly ulong4 wwzx
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
        public readonly ulong4 wwzy
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
        public readonly ulong4 wwzz
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
        public readonly ulong4 wwzw
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
        public readonly ulong4 wwwx
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
        public readonly ulong4 wwwy
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
        public readonly ulong4 wwwz
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
        public readonly ulong4 wwww
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

        public readonly ulong3 xxx
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
        public readonly ulong3 xxy
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
        public readonly ulong3 xxz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_unpacklo_epi64(this, this);
				}
				else
				{
					return new ulong3(xx, z);
				}
			}
		}
        public readonly ulong3 xxw
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
        public readonly ulong3 xyx
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
        public readonly ulong3 xyy
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
			readonly get
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
			readonly get
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
        public readonly ulong3 xzx
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
			readonly get
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
        public readonly ulong3 xzz
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
			readonly get
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
        public readonly ulong3 xwx
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
			readonly get
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
			readonly get
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
        public readonly ulong3 xww
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
        public readonly ulong3 yxx
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
        public readonly ulong3 yxy
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
			readonly get
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
			readonly get
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
        public readonly ulong3 yyx
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
        public readonly ulong3 yyy
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
        public readonly ulong3 yyz
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
        public readonly ulong3 yyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx2.mm256_unpackhi_epi64(this, this);
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
			readonly get
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
        public readonly ulong3 yzy
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
        public readonly ulong3 yzz
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
			readonly get
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
			readonly get
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
        public readonly ulong3 ywy
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
			readonly get
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
        public readonly ulong3 yww
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
        public readonly ulong3 zxx
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
			readonly get
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
        public readonly ulong3 zxz
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
			readonly get
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
			readonly get
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
        public readonly ulong3 zyy
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
        public readonly ulong3 zyz
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
			readonly get
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
        public readonly ulong3 zzx
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
        public readonly ulong3 zzy
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
        public readonly ulong3 zzz
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
        public readonly ulong3 zzw
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
			readonly get
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
			readonly get
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
        public readonly ulong3 zwz
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
        public readonly ulong3 zww
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
        public readonly ulong3 wxx
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
			readonly get
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
			readonly get
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
        public readonly ulong3 wxw
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
			readonly get
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
        public readonly ulong3 wyy
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
			readonly get
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
        public readonly ulong3 wyw
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
			readonly get
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
			readonly get
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
        public readonly ulong3 wzz
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
        public readonly ulong3 wzw
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
        public readonly ulong3 wwx
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
        public readonly ulong3 wwy
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
        public readonly ulong3 wwz
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
        public readonly ulong3 www
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

        public readonly ulong2 xx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Sse2.unpacklo_epi64(Avx.mm256_castsi256_si128(this), Avx.mm256_castsi256_si128(this));
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
			readonly get
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
			readonly get
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
                    this._xy = Xse.blend_epi16(this._xy, value, 0b0000_1111);
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
			readonly get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 3, 0)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Xse.blend_epi16(this._xy, this._zw, 0b1111_0000);
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
					this._xy = Xse.blend_epi16(this._xy, value, 0b0000_1111);
					this._zw = Xse.blend_epi16(this._zw, value, 0b1111_0000);
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
			readonly get
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
        public readonly ulong2 yy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				if (Avx.IsAvxSupported)
				{
					return Sse2.unpackhi_epi64(Avx.mm256_castsi256_si128(this), Avx.mm256_castsi256_si128(this) );
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
			readonly get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 2, 1)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.shuffle_epi32(Xse.blend_epi16(this._xy, this._zw, 0b0000_1111), Sse.SHUFFLE(1, 0, 3, 2));
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
			readonly get
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
					this._zw = Xse.blend_epi16(this._zw, value, 0b1111_0000);
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
			readonly get
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
					this._zw = Xse.blend_epi16(this._zw, value, 0b0000_1111);
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
			readonly get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 1, 2)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Xse.blend_epi16(this._xy, this._zw, 0b0000_1111);
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
					this._xy = Xse.blend_epi16(this._xy, value, 0b1111_0000);
					this._zw = Xse.blend_epi16(this._zw, value, 0b0000_1111);
				}
				else
				{
					this.z = value.x;
					this.y = value.y;
				}
			}
        }
        public readonly ulong2 zz
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
			readonly get
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
			readonly get
			{
				if (Avx2.IsAvx2Supported)
				{
					return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(3, 3, 0, 3)));
				}
				else if (Sse2.IsSse2Supported)
				{
					return Sse2.shuffle_epi32(Xse.blend_epi16(this._xy, this._zw, 0b1111_0000), Sse.SHUFFLE(1, 0, 3, 2));
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
			readonly get
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
					this._xy = Xse.blend_epi16(this._xy, value, 0b1111_0000);
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
			readonly get
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
        public readonly ulong2 ww
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

		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(ulong4 input) => new v256 { ULong0 = input.x, ULong1 = input.y, ULong2 = input.z, ULong3 = input.w };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
				return Avx2.mm256_cvtepu32_epi64(RegisterConversion.ToV128(input));
            }
            else if (Sse2.IsSse2Supported)
            {
                return (ulong4)Cast.UInt4ToLong4(RegisterConversion.ToV128(input));
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
				return Avx2.mm256_cvtepi32_epi64(RegisterConversion.ToV128(input));
            }
            else if (Sse2.IsSse2Supported)
            {
                return (ulong4)Cast.Int4ToLong4(RegisterConversion.ToV128(input));
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
        public static explicit operator ulong4(double4 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epu64(RegisterConversion.ToV256(input), 4);
            }
            else
            {
                return new ulong4((ulong2)input.xy, (ulong2)input.zw);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator uint4(ulong4 input)
		{
			if (Avx2.IsAvx2Supported)
			{
				return RegisterConversion.ToUInt4(Xse.mm256_cvtepi64_epi32(input));
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
				return RegisterConversion.ToInt4(Xse.mm256_cvtepi64_epi32(input));
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
                return RegisterConversion.ToDouble4(Xse.mm256_cvtepu64_pd(input, 4));
            }
			else
			{
				return new double4((double2)input._xy, (double2)input._zw);
			}
		}


        public ulong this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 4);

                if (Avx2.IsAvx2Supported)
                {
                    return Xse.mm256_extract_epi64(this, (byte)index);
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Constant.IsConstantExpression(index))
                    {
                        if (index < 2)
                        {
                            return Xse.extract_epi64(_xy, (byte)index);
                        }
                        else
                        {
                            return Xse.extract_epi64(_zw, (byte)(index - 2));
                        }
                    }
                }

                ulong4 onStack = this;

                return *((ulong*)&onStack + index);
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 4);

                if (Avx2.IsAvx2Supported)
                {
                    this = Xse.mm256_insert_epi64(this, value, (byte)index);

                    return;
                }
                else if (Sse2.IsSse2Supported)
                {
                    if (Constant.IsConstantExpression(index))
                    {
                        if (index < 2)
                        {
                            _xy = Xse.insert_epi64(_xy, value, (byte)index);
                        }
                        else
                        {
                            _zw = Xse.insert_epi64(_zw, value, (byte)(index - 2));
                        }

                        return;
                    }
                }

                ulong4 onStack = this;
                *((ulong*)&onStack + index) = value;
                this = onStack;
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
				return Xse.mm256_mullo_epi64(left, right, 4);
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
                return Xse.mm256_div_epu64(left, right, 4);
            }
            else
            {
                return new ulong4(left.xy / right.xy, left.zw / right.zw);
            }
        }
    
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, ulong4 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rem_epu64(left, right, 4);
            }
            else
            {
                return new ulong4(left.xy % right.xy, left.zw % right.zw);
            }
        }


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong4 operator * (ulong left, ulong4 right) => right * left;
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator * (ulong4 left, ulong right)
		{
			if (Avx2.IsAvx2Supported)
			{
				if (Constant.IsConstantExpression(right))
				{
					return new ulong4(left.x * right, left.y * right, left.z * right, left.w * right);
				}
				else
				{
					return left * (ulong4)right;
				}
			}
			else
			{
				return new ulong4(left._xy * right, left._zw * right);
			}
		}
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator / (ulong4 left, ulong right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.mm256_div_epu64(left, right, 4);
                }
            }
                
            return left / (ulong4)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 operator % (ulong4 left, ulong right)
        {
            if (Sse2.IsSse2Supported)
            {
                if (Constant.IsConstantExpression(right))
                {
                    return Xse.constexpr.mm256_rem_epu64(left, right, 4);
                }
            }
                
            return left % (ulong4)right;
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
				return Xse.mm256_inc_epi64(x);
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
				return Xse.mm256_dec_epi64(x);
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
                return Xse.mm256_not_si256(x);
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
				return Xse.mm256_slli_epi64(x, n);
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
				return Xse.mm256_srli_epi64(x, n);
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
				int results = RegisterConversion.IsTrue64(Avx2.mm256_cmpeq_epi64(left, right));

				return *(bool4*)&results;
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
				int results = RegisterConversion.IsTrue64(Xse.mm256_cmplt_epu64(left, right));

				return *(bool4*)&results;
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
				int results = RegisterConversion.IsTrue64(Xse.mm256_cmpgt_epu64(left, right));

				return *(bool4*)&results;
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
				int results = RegisterConversion.IsFalse64(Avx2.mm256_cmpeq_epi64(left, right));

				return *(bool4*)&results;
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
				int results = RegisterConversion.IsFalse64(Xse.mm256_cmpgt_epu64(left, right));

				return *(bool4*)&results;
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
				int results = RegisterConversion.IsFalse64(Xse.mm256_cmplt_epu64(left, right));

				return *(bool4*)&results;
			}
			else
			{
				return new bool4(left._xy >= right._xy, left._zw >= right._zw);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool Equals(ulong4 other)
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

        public override readonly bool Equals(object obj) => obj is ulong4 converted && this.Equals(converted);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override readonly int GetHashCode()
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
    

        public override readonly string ToString() => $"ulong4({x}, {y}, {z}, {w})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ulong4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}