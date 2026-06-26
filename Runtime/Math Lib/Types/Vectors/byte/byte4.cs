using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
#if DEBUG
    internal sealed class byte4DebuggerProxy
    {
	    public byte x;
	    public byte y;
	    public byte z;
	    public byte w;
        
	    public byte4DebuggerProxy(byte4 v)
	    {
	    	x = v.x;
	    	y = v.y;
	    	z = v.z;
	    	w = v.w;
	    }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(byte4DebuggerProxy))]
#endif
    [Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct byte4 : IEquatable<byte4>, IFormattable
	{
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal uint __x0;
		
        public ref byte x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte4* ptr = &this) { return ref *((byte*)ptr + 0); } } }
        public ref byte y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte4* ptr = &this) { return ref *((byte*)ptr + 1); } } }
        public ref byte z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte4* ptr = &this) { return ref *((byte*)ptr + 2); } } }
        public ref byte w { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte4* ptr = &this) { return ref *((byte*)ptr + 3); } } }


        public static byte4 zero => default;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte y, byte z, byte w)
        {
            if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)w, (sbyte)z, (sbyte)y, (sbyte)x);
			}
			else
            {
				__x0 = Uninitialized<uint>.Create();

				this.x = x;
				this.y = y;
				this.z = z;
				this.w = w;
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte xyzw)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.set1_epi8(xyzw, 4);
			}
			else
			{
				__x0 = Uninitialized<uint>.Create();

				this.x = this.y = this.z = this.w = xyzw;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte2 xy, byte z, byte w)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
				this = Xse.unpacklo_epi16(xy, new byte2(z, w));
			}
			else
            {
				__x0 = Uninitialized<uint>.Create();

				this.x = xy.x;
				this.y = xy.y;
				this.z = z;
				this.w = w;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte2 yz, byte w)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.set_epi8(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, (sbyte)w, (sbyte)yz.y, (sbyte)yz.x, (sbyte)x);
			}
			else
			{
				__x0 = Uninitialized<uint>.Create();

				this.x = x;
				this.y = yz.x;
				this.z = yz.y;
				this.w = w;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte y, byte2 zw)
        {
			this = new byte4(new byte2(x, y), zw);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte2 xy, byte2 zw)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				this = Join.v2v2_epi8(xy, zw);
			}
			else
			{
				__x0 = Uninitialized<uint>.Create();

				this.x = xy.x;
				this.y = xy.y;
				this.z = zw.x;
				this.w = zw.y;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte3 xyz, byte w)
        {
			if (BurstArchitecture.IsInsertExtractSupported)
			{
				this = Xse.insert_epi8(xyz, w, 3);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.blendv_epi8(xyz, Xse.bslli_si128(Xse.cvtsi32_si128(w), 3 * sizeof(byte)), new byte4(0, 0, 0, 255));
			}
			else
			{
				__x0 = Uninitialized<uint>.Create();

				this.x = xyz.x;
				this.y = xyz.y;
				this.z = xyz.z;
				this.w = w;
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte x, byte3 yzw)
        {
			if (BurstArchitecture.IsInsertExtractSupported)
			{
				this = Xse.insert_epi8(Xse.bslli_si128(yzw, sizeof(byte)), x, 0);
			}
			else if (BurstArchitecture.IsSIMDSupported)
			{
				this = Xse.or_si128(Xse.bslli_si128(yzw, sizeof(byte)), Xse.cvtsi32_si128(x));
			}
			else
			{
				__x0 = Uninitialized<uint>.Create();

				this.x = x;
				this.y = yzw.x;
				this.z = yzw.y;
				this.w = yzw.z;
			}
        }
		
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(bool v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(bool4 v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(mask8x4 v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(mask16x4 v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(mask32x4 v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(mask64x4 v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(byte4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(sbyte v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(sbyte4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(ushort v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(ushort4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(short v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(short4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(uint v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(uint4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(int v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(int4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(ulong v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(ulong4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(long v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(long4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(UInt128 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(Int128 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(quarter v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(quarter4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(half v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(half4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(float v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(float4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(double v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(double4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(quadruple v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(Unity.Mathematics.bool4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(Unity.Mathematics.uint4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(Unity.Mathematics.int4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(Unity.Mathematics.half v)
        {
            this = (byte4)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(Unity.Mathematics.half4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(Unity.Mathematics.float4 v)
        {
            this = (byte4)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte4(Unity.Mathematics.double4 v)
        {
            this = (byte4)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxxw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxxw(this);
                }
				else
				{
					return new byte4(x, x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxyw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxyw(this);
                }
				else
				{
					return new byte4(x, x, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxzw
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxzw(this);
                }
				else
				{
					return new byte4(x, x, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxwx
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxwx(this);
                }
				else
				{
					return new byte4(x, x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxwy
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxwy(this);
                }
				else
				{
					return new byte4(x, x, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxwz
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxwz(this);
                }
				else
				{
					return new byte4(x, x, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xxww
        {
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxww(this);
                }
				else
				{
					return new byte4(x, x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyxw(this);
                }
				else
				{
					return new byte4(x, y, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyyw(this);
                }
				else
				{
					return new byte4(x, y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return this;
            }

            set
            {
                this = value;
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xywx(this);
                }
				else
				{
					return new byte4(x, y, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xywy(this);
                }
				else
				{
					return new byte4(x, y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xyww(this);
                }
				else
				{
					return new byte4(x, y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzxw(this);
                }
				else
				{
					return new byte4(x, z, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzzw(this);
                }
				else
				{
					return new byte4(x, z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzwx(this);
                }
				else
				{
					return new byte4(x, z, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzwz(this);
                }
				else
				{
					return new byte4(x, z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xzww(this);
                }
				else
				{
					return new byte4(x, z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwxx(this);
                }
				else
				{
					return new byte4(x, w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwxy(this);
                }
				else
				{
					return new byte4(x, w, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwxz(this);
                }
				else
				{
					return new byte4(x, w, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwxw(this);
                }
				else
				{
					return new byte4(x, w, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwyx(this);
                }
				else
				{
					return new byte4(x, w, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwyy(this);
                }
				else
				{
					return new byte4(x, w, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwyw(this);
                }
				else
				{
					return new byte4(x, w, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwzx(this);
                }
				else
				{
					return new byte4(x, w, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwzz(this);
                }
				else
				{
					return new byte4(x, w, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwzw(this);
                }
				else
				{
					return new byte4(x, w, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwwx(this);
                }
				else
				{
					return new byte4(x, w, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwwy(this);
                }
				else
				{
					return new byte4(x, w, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwwz(this);
                }
				else
				{
					return new byte4(x, w, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 xwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwww(this);
                }
				else
				{
					return new byte4(x, w, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxxw(this);
                }
				else
				{
					return new byte4(y, x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxyw(this);
                }
				else
				{
					return new byte4(y, x, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxwx(this);
                }
				else
				{
					return new byte4(y, x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxwy(this);
                }
				else
				{
					return new byte4(y, x, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yxww(this);
                }
				else
				{
					return new byte4(y, x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyxw(this);
                }
				else
				{
					return new byte4(y, y, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyyw(this);
                }
				else
				{
					return new byte4(y, y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyzw(this);
                }
				else
				{
					return new byte4(y, y, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yywx(this);
                }
				else
				{
					return new byte4(y, y, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yywy(this);
                }
				else
				{
					return new byte4(y, y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yywz(this);
                }
				else
				{
					return new byte4(y, y, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyww(this);
                }
				else
				{
					return new byte4(y, y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzyw(this);
                }
				else
				{
					return new byte4(y, z, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzzw(this);
                }
				else
				{
					return new byte4(y, z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzwy(this);
                }
				else
				{
					return new byte4(y, z, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzwz(this);
                }
				else
				{
					return new byte4(y, z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 yzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yzww(this);
                }
				else
				{
					return new byte4(y, z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywxx(this);
                }
				else
				{
					return new byte4(y, w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywxy(this);
                }
				else
				{
					return new byte4(y, w, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywxw(this);
                }
				else
				{
					return new byte4(y, w, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywyx(this);
                }
				else
				{
					return new byte4(y, w, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywyy(this);
                }
				else
				{
					return new byte4(y, w, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywyz(this);
                }
				else
				{
					return new byte4(y, w, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywyw(this);
                }
				else
				{
					return new byte4(y, w, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywzy(this);
                }
				else
				{
					return new byte4(y, w, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywzz(this);
                }
				else
				{
					return new byte4(y, w, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywzw(this);
                }
				else
				{
					return new byte4(y, w, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywwx(this);
                }
				else
				{
					return new byte4(y, w, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywwy(this);
                }
				else
				{
					return new byte4(y, w, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywwz(this);
                }
				else
				{
					return new byte4(y, w, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 ywww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywww(this);
                }
				else
				{
					return new byte4(y, w, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxxw(this);
                }
				else
				{
					return new byte4(z, x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxzw(this);
                }
				else
				{
					return new byte4(z, x, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxwx(this);
                }
				else
				{
					return new byte4(z, x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxwz(this);
                }
				else
				{
					return new byte4(z, x, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zxww(this);
                }
				else
				{
					return new byte4(z, x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyyw(this);
                }
				else
				{
					return new byte4(z, y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyzw(this);
                }
				else
				{
					return new byte4(z, y, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zywy(this);
                }
				else
				{
					return new byte4(z, y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zywz(this);
                }
				else
				{
					return new byte4(z, y, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zyww(this);
                }
				else
				{
					return new byte4(z, y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzxw(this);
                }
				else
				{
					return new byte4(z, z, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzyw(this);
                }
				else
				{
					return new byte4(z, z, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzzw(this);
                }
				else
				{
					return new byte4(z, z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzwx(this);
                }
				else
				{
					return new byte4(z, z, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzwy(this);
                }
				else
				{
					return new byte4(z, z, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzwz(this);
                }
				else
				{
					return new byte4(z, z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzww(this);
                }
				else
				{
					return new byte4(z, z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwxx(this);
                }
				else
				{
					return new byte4(z, w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwxz(this);
                }
				else
				{
					return new byte4(z, w, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwxw(this);
                }
				else
				{
					return new byte4(z, w, xw);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwyy(this);
                }
				else
				{
					return new byte4(z, w, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwyz(this);
                }
				else
				{
					return new byte4(z, w, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwyw(this);
                }
				else
				{
					return new byte4(z, w, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwzx(this);
                }
				else
				{
					return new byte4(z, w, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwzy(this);
                }
				else
				{
					return new byte4(z, w, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwzz(this);
                }
				else
				{
					return new byte4(z, w, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwzw(this);
                }
				else
				{
					return new byte4(z, w, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwwx(this);
                }
				else
				{
					return new byte4(z, w, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwwy(this);
                }
				else
				{
					return new byte4(z, w, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwwz(this);
                }
				else
				{
					return new byte4(z, w, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 zwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwww(this);
                }
				else
				{
					return new byte4(z, w, ww);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxxx(this);
                }
				else
				{
					return new byte4(w, x, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxxy(this);
                }
				else
				{
					return new byte4(w, x, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxxz(this);
                }
				else
				{
					return new byte4(w, x, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxxw(this);
                }
				else
				{
					return new byte4(w, x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxyx(this);
                }
				else
				{
					return new byte4(w, x, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxyy(this);
                }
				else
				{
					return new byte4(w, x, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxyw(this);
                }
				else
				{
					return new byte4(w, x, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxzx(this);
                }
				else
				{
					return new byte4(w, x, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxzz(this);
                }
				else
				{
					return new byte4(w, x, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxzw(this);
                }
				else
				{
					return new byte4(w, x, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxwx(this);
                }
				else
				{
					return new byte4(w, x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxwy(this);
                }
				else
				{
					return new byte4(w, x, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxwz(this);
                }
				else
				{
					return new byte4(w, x, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wxww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxww(this);
                }
				else
				{
					return new byte4(w, x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyxx(this);
                }
				else
				{
					return new byte4(w, y, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyxy(this);
                }
				else
				{
					return new byte4(w, y, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyxw(this);
                }
				else
				{
					return new byte4(w, y, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyyx(this);
                }
				else
				{
					return new byte4(w, y, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyyy(this);
                }
				else
				{
					return new byte4(w, y, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyyz(this);
                }
				else
				{
					return new byte4(w, y, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyyw(this);
                }
				else
				{
					return new byte4(w, y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyzy(this);
                }
				else
				{
					return new byte4(w, y, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyzz(this);
                }
				else
				{
					return new byte4(w, y, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyzw(this);
                }
				else
				{
					return new byte4(w, y, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wywx(this);
                }
				else
				{
					return new byte4(w, y, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wywy(this);
                }
				else
				{
					return new byte4(w, y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wywz(this);
                }
				else
				{
					return new byte4(w, y, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wyww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyww(this);
                }
				else
				{
					return new byte4(w, y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzxx(this);
                }
				else
				{
					return new byte4(w, z, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzxz(this);
                }
				else
				{
					return new byte4(w, z, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzxw(this);
                }
				else
				{
					return new byte4(w, z, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzyy(this);
                }
				else
				{
					return new byte4(w, z, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzyz(this);
                }
				else
				{
					return new byte4(w, z, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzyw(this);
                }
				else
				{
					return new byte4(w, z, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzzx(this);
                }
				else
				{
					return new byte4(w, z, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzzy(this);
                }
				else
				{
					return new byte4(w, z, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzzz(this);
                }
				else
				{
					return new byte4(w, z, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzzw(this);
                }
				else
				{
					return new byte4(w, z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzwx(this);
                }
				else
				{
					return new byte4(w, z, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzwy(this);
                }
				else
				{
					return new byte4(w, z, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzwz(this);
                }
				else
				{
					return new byte4(w, z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wzww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzww(this);
                }
				else
				{
					return new byte4(w, z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwxx(this);
                }
				else
				{
					return new byte4(w, w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwxy(this);
                }
				else
				{
					return new byte4(w, w, x, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwxz(this);
                }
				else
				{
					return new byte4(w, w, x, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwxw(this);
                }
				else
				{
					return new byte4(w, w, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwyx(this);
                }
				else
				{
					return new byte4(w, w, y, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwyy(this);
                }
				else
				{
					return new byte4(w, w, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwyz(this);
                }
				else
				{
					return new byte4(w, w, y, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwyw(this);
                }
				else
				{
					return new byte4(w, w, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwzx(this);
                }
				else
				{
					return new byte4(w, w, z, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwzy(this);
                }
				else
				{
					return new byte4(w, w, z, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwzz(this);
                }
				else
				{
					return new byte4(w, w, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwzw(this);
                }
				else
				{
					return new byte4(w, w, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwwx(this);
                }
				else
				{
					return new byte4(w, w, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwwy(this);
                }
				else
				{
					return new byte4(w, w, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwwz(this);
                }
				else
				{
					return new byte4(w, w, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte4 wwww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwww(this);
                }
				else
				{
					return new byte4(w, w, w, w);
				}
			}
		}


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xxw(this);
                }
				else
				{
					return new byte3(x, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xwx(this);
                }
				else
				{
					return new byte3(x, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 xww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.xww(this);
                }
				else
				{
					return new byte3(x, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yxy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yyx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yyw(this);
                }
				else
				{
					return new byte3(y, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 ywx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 ywy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.ywy(this);
                }
				else
				{
					return new byte3(y, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 ywz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 yww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.yww(this);
                }
				else
				{
					return new byte3(y, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zxx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zxz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zyy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zyz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zzx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zzy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zzz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zzw(this);
                }
				else
				{
					return new byte3(z, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zwz(this);
                }
				else
				{
					return new byte3(z, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 zww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.zww(this);
                }
				else
				{
					return new byte3(z, w, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wxx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxx(this);
                }
				else
				{
					return new byte3(w, x, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wxy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wxz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wxw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wxw(this);
                }
				else
				{
					return new byte3(w, x, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wyx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wyy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyy(this);
                }
				else
				{
					return new byte3(w, y, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wyz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wyw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wyw(this);
                }
				else
				{
					return new byte3(w, y, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wzx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wzy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wzz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzz(this);
                }
				else
				{
					return new byte3(w, z, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wzw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wzw(this);
                }
				else
				{
					return new byte3(w, z, w);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wwx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwx(this);
                }
				else
				{
					return new byte3(w, w, x);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wwy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwy(this);
                }
				else
				{
					return new byte3(w, w, y);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 wwz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.wwz(this);
                }
				else
				{
					return new byte3(w, w, z);
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte3 www
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
                {
					return Shuffle.Bytes.Get.www(this);
                }
				else
				{
					return new byte3(w, w, w);
				}
			}
		}


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 xx
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 xz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 xw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 yy
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 yz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 yw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 zx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 zy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 zz
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 zw
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
				{
					this = Xse.unpacklo_epi16(this, value);
				}
				else
				{
					this.z = value.x;
					this.w = value.y;
				}
			}
		}

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 wx
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 wy
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public byte2 wz
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
				if (BurstArchitecture.IsSIMDSupported)
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
		public byte2 ww
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
                if (BurstArchitecture.IsSIMDSupported)
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
		
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte4 input)
        {
            v128 result;
            if (Avx.IsAvxSupported)
            {
                result = Avx.undefined_si128();
            }
            else
            {
                result = Uninitialized<v128>.Create();
            }

            result.UInt0 = input.__x0;
            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4(v128 input) => new byte4 { __x0 = input.UInt0 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(bool4 x) => (byte4)(mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(Unity.Mathematics.bool4 x) => (byte4)(mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(mask8x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(mask16x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte4)(mask8x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(mask32x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte4)(mask8x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(mask64x4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte4)(mask8x4)x;
            }
            else
            {
                return *(byte4*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool4(byte4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool4(byte4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x4(byte4 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x4(byte4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x4(byte4 x) => (mask8x4)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x4(byte4 x) => (mask8x4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(sbyte x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(ushort x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(short x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(uint x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(int x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(ulong x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(long x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(UInt128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(Int128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(quarter x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(half x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(float x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(double x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(quadruple x) => (byte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(Unity.Mathematics.half x) => (byte4)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(Unity.Mathematics.half4 x) => (byte4)(half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(Unity.Mathematics.float4 x) => (byte4)(float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(Unity.Mathematics.double4 x) => (byte4)(double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(Unity.Mathematics.uint4 x) => (byte4)(uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(Unity.Mathematics.int4 x) => (byte4)(int4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half4(byte4 x) => (half4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float4(byte4 x) => (float4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double4(byte4 x) => (double4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint4(byte4 x) => (uint4)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int4(byte4 x) => (int4)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte4(byte input) => new byte4(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(sbyte4 input) => *(byte4*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(short4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi8(input, 4);
            }
			else
			{
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(uint4 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi8(input, 4);
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
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new byte4(Xse.cvtepi64_epi8(input.__x0), Xse.cvtepi64_epi8(input.__x2));
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
            else if (BurstArchitecture.IsSIMDSupported)
            {
                return new byte4(Xse.cvtepi64_epi8(input.__x0), Xse.cvtepi64_epi8(input.__x2));
            }
            else
			{
				return new byte4((byte)input.x, (byte)input.y, (byte)input.z, (byte)input.w);
			}
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(float4 input) => (byte4)(int4)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte4(double4 input) => (byte4)(int4)input;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short4(byte4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
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
			if (BurstArchitecture.IsSIMDSupported)
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
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cvtepu8_epi32(input);
            }
            else
            {
                return new int4((int)input.x, (int)input.y, (int)input.z, (int)input.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4(byte4 input)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cvtepu8_epi32(input);
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
            else if (BurstArchitecture.IsSIMDSupported)
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
            else if (BurstArchitecture.IsSIMDSupported)
			{
                return new ulong4((ulong2)input.xy, (ulong2)input.zw);
            }
            else
            {
                return new ulong4((ulong)input.x, (ulong)input.y, (ulong)input.z, (ulong)input.w);
            }
        }

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator float4(byte4 input)
		{
            if (BurstArchitecture.IsSIMDSupported)
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
            get
            {
Assert.IsWithinArrayBounds(index, 4);

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
					    return Xse.extract_epi8(this, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (byte4* ptr = &this)
                    {
                        return ((byte*)ptr)[index];
                    }
                }
                else
                {
                    return this.GetField<byte4, byte>(index);
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
						this = Xse.insert_epi8(this, value, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (byte4* ptr = &this)
                    {
                        ((byte*)ptr)[index] = value;
                    }
                }
                else
                {
                    this.SetField(value, index);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator + (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.add_epi8(left, right);
            }
            else
            {
                return new byte4((byte)(left.x + right.x), (byte)(left.y + right.y), (byte)(left.z + right.z), (byte)(left.w + right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator - (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.sub_epi8(left, right);
            }
            else
            {
                return new byte4((byte)(left.x - right.x), (byte)(left.y - right.y), (byte)(left.z - right.z), (byte)(left.w - right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.rem_epu8(left, right, 4);
            }
            else
            {
                return new byte4((byte)(left.x % right.x), (byte)(left.y % right.y), (byte)(left.z % right.z), (byte)(left.w % right.w));
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator + (byte4 left, byte right) => left + (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator + (byte left, byte4 right) => (byte4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator - (byte4 left, byte right) => left - (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator - (byte left, byte4 right) => (byte4)left - right;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte left, byte4 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator * (byte4 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constmullo_epu8(left, right, 4);
                }
            }

			return left * (byte4)right;
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator / (byte4 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
					return Xse.constdiv_epu8(left, right, 4);
                }
            }

			return left / (byte4)right;
		}
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator / (byte left, byte4 right) => (byte4)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator % (byte4 left, byte right)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(right))
				{
					return Xse.constrem_epu8(left, right, 4);
				}
			}

			return left % (byte4)right;
		}
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator % (byte left, byte4 right) => (byte4)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator + (byte4 left, Unity.Mathematics.int4 right) => left + (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator + (Unity.Mathematics.int4 left, byte4 right) => (int4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator - (byte4 left, Unity.Mathematics.int4 right) => left - (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator - (Unity.Mathematics.int4 left, byte4 right) => (int4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator * (byte4 left, Unity.Mathematics.int4 right) => left * (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator * (Unity.Mathematics.int4 left, byte4 right) => (int4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator / (byte4 left, Unity.Mathematics.int4 right) => left / (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator / (Unity.Mathematics.int4 left, byte4 right) => (int4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator % (byte4 left, Unity.Mathematics.int4 right) => left % (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator % (Unity.Mathematics.int4 left, byte4 right) => (int4)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator + (byte4 left, Unity.Mathematics.uint4 right) => left + (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator + (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator - (byte4 left, Unity.Mathematics.uint4 right) => left - (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator - (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator * (byte4 left, Unity.Mathematics.uint4 right) => left * (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator * (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator / (byte4 left, Unity.Mathematics.uint4 right) => left / (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator / (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator % (byte4 left, Unity.Mathematics.uint4 right) => left % (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator % (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (byte4 left, Unity.Mathematics.float4 right) => left + (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator + (Unity.Mathematics.float4 left, byte4 right) => (float4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (byte4 left, Unity.Mathematics.float4 right) => left - (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator - (Unity.Mathematics.float4 left, byte4 right) => (float4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (byte4 left, Unity.Mathematics.float4 right) => left * (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator * (Unity.Mathematics.float4 left, byte4 right) => (float4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (byte4 left, Unity.Mathematics.float4 right) => left / (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator / (Unity.Mathematics.float4 left, byte4 right) => (float4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (byte4 left, Unity.Mathematics.float4 right) => left % (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 operator % (Unity.Mathematics.float4 left, byte4 right) => (float4)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (byte4 left, Unity.Mathematics.double4 right) => left + (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator + (Unity.Mathematics.double4 left, byte4 right) => (double4)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (byte4 left, Unity.Mathematics.double4 right) => left - (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator - (Unity.Mathematics.double4 left, byte4 right) => (double4)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (byte4 left, Unity.Mathematics.double4 right) => left * (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator * (Unity.Mathematics.double4 left, byte4 right) => (double4)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (byte4 left, Unity.Mathematics.double4 right) => left / (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator / (Unity.Mathematics.double4 left, byte4 right) => (double4)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (byte4 left, Unity.Mathematics.double4 right) => left % (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator % (Unity.Mathematics.double4 left, byte4 right) => (double4)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator & (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.and_si128(left, right);
            }
            else
            {
                return new byte4((byte)(left.x & right.x), (byte)(left.y & right.y), (byte)(left.z & right.z), (byte)(left.w & right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator | (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.or_si128(left, right);
            }
            else
            {
                return new byte4((byte)(left.x | right.x), (byte)(left.y | right.y), (byte)(left.z | right.z), (byte)(left.w | right.w));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ^ (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.xor_si128(left, right);
            }
            else
            {
                return new byte4((byte)(left.x ^ right.x), (byte)(left.y ^ right.y), (byte)(left.z ^ right.z), (byte)(left.w ^ right.w));
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator & (byte4 left, byte right) => left & (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator & (byte left, byte4 right) => (byte4)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator | (byte4 left, byte right) => left | (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator | (byte left, byte4 right) => (byte4)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ^ (byte4 left, byte right) => left ^ (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ^ (byte left, byte4 right) => (byte4)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator & (byte4 left, Unity.Mathematics.int4 right) => left & (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator & (Unity.Mathematics.int4 left, byte4 right) => (int4)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator | (byte4 left, Unity.Mathematics.int4 right) => left | (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator | (Unity.Mathematics.int4 left, byte4 right) => (int4)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ^ (byte4 left, Unity.Mathematics.int4 right) => left ^ (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 operator ^ (Unity.Mathematics.int4 left, byte4 right) => (int4)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator & (byte4 left, Unity.Mathematics.uint4 right) => left & (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator & (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator | (byte4 left, Unity.Mathematics.uint4 right) => left | (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator | (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ^ (byte4 left, Unity.Mathematics.uint4 right) => left ^ (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ^ (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator ++ (byte4 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
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
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.slli_epi8(x, n, inRange: true);
            }
            else
            {
                return new byte4((byte)(x.x << n), (byte)(x.y << n), (byte)(x.z << n), (byte)(x.w << n));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 operator >> (byte4 x, int n)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.srli_epi8(x, n, inRange: true);
            }
            else
            {
                return new byte4((byte)(x.x >> n), (byte)(x.y >> n), (byte)(x.z >> n), (byte)(x.w >> n));
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_epi8(left, right);
            }
            else
            {
                return new mask8x4(left.x == right.x, left.y == right.y, left.z == right.z, left.w == right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epu8(left, right, 4);
            }
            else
            {
                return new mask8x4(left.x < right.x, left.y < right.y, left.z < right.z, left.w < right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epu8(left, right, 4);
            }
            else
            {
                return new mask8x4(left.x > right.x, left.y > right.y, left.z > right.z, left.w > right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpeq_epi8(left, right));
            }
            else
            {
                return new mask8x4(left.x != right.x, left.y != right.y, left.z != right.z, left.w != right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (byte4 left, byte4 right)
        {
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.cmple_epu8(left, right, 4);
			}
			else
            {
                return new mask8x4(left.x <= right.x, left.y <= right.y, left.z <= right.z, left.w <= right.w);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (byte4 left, byte4 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_epu8(left, right, 4);
			}
            else
            {
                return new mask8x4(left.x >= right.x, left.y >= right.y, left.z >= right.z, left.w >= right.w);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (byte4 left, byte right) => left == (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (byte left, byte4 right) => (byte4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (byte4 left, byte right) => left != (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (byte left, byte4 right) => (byte4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (byte4 left, byte right) => left < (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (byte left, byte4 right) => (byte4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (byte4 left, byte right) => left > (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (byte left, byte4 right) => (byte4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (byte4 left, byte right) => left <= (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (byte left, byte4 right) => (byte4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (byte4 left, byte right) => left >= (byte4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (byte left, byte4 right) => (byte4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (byte4 left, Unity.Mathematics.int4 right) => left == (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.int4 left, byte4 right) => (int4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (byte4 left, Unity.Mathematics.int4 right) => left != (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.int4 left, byte4 right) => (int4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (byte4 left, Unity.Mathematics.int4 right) => left < (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.int4 left, byte4 right) => (int4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (byte4 left, Unity.Mathematics.int4 right) => left > (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.int4 left, byte4 right) => (int4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (byte4 left, Unity.Mathematics.int4 right) => left <= (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.int4 left, byte4 right) => (int4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (byte4 left, Unity.Mathematics.int4 right) => left >= (int4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.int4 left, byte4 right) => (int4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (byte4 left, Unity.Mathematics.uint4 right) => left == (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (byte4 left, Unity.Mathematics.uint4 right) => left != (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (byte4 left, Unity.Mathematics.uint4 right) => left < (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (byte4 left, Unity.Mathematics.uint4 right) => left > (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (byte4 left, Unity.Mathematics.uint4 right) => left <= (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (byte4 left, Unity.Mathematics.uint4 right) => left >= (uint4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.uint4 left, byte4 right) => (uint4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (byte4 left, Unity.Mathematics.half4 right) => left == (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.half4 left, byte4 right) => (half4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (byte4 left, Unity.Mathematics.half4 right) => left != (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.half4 left, byte4 right) => (half4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (byte4 left, Unity.Mathematics.half4 right) => left < (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.half4 left, byte4 right) => (half4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (byte4 left, Unity.Mathematics.half4 right) => left > (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.half4 left, byte4 right) => (half4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (byte4 left, Unity.Mathematics.half4 right) => left <= (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.half4 left, byte4 right) => (half4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (byte4 left, Unity.Mathematics.half4 right) => left >= (half4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.half4 left, byte4 right) => (half4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (byte4 left, Unity.Mathematics.float4 right) => left == (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.float4 left, byte4 right) => (float4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (byte4 left, Unity.Mathematics.float4 right) => left != (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.float4 left, byte4 right) => (float4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (byte4 left, Unity.Mathematics.float4 right) => left < (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.float4 left, byte4 right) => (float4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (byte4 left, Unity.Mathematics.float4 right) => left > (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.float4 left, byte4 right) => (float4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (byte4 left, Unity.Mathematics.float4 right) => left <= (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.float4 left, byte4 right) => (float4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (byte4 left, Unity.Mathematics.float4 right) => left >= (float4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.float4 left, byte4 right) => (float4)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (byte4 left, Unity.Mathematics.double4 right) => left == (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator == (Unity.Mathematics.double4 left, byte4 right) => (double4)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (byte4 left, Unity.Mathematics.double4 right) => left != (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator != (Unity.Mathematics.double4 left, byte4 right) => (double4)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (byte4 left, Unity.Mathematics.double4 right) => left < (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator < (Unity.Mathematics.double4 left, byte4 right) => (double4)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (byte4 left, Unity.Mathematics.double4 right) => left > (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator > (Unity.Mathematics.double4 left, byte4 right) => (double4)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (byte4 left, Unity.Mathematics.double4 right) => left <= (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator <= (Unity.Mathematics.double4 left, byte4 right) => (double4)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (byte4 left, Unity.Mathematics.double4 right) => left >= (double4)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x4 operator >= (Unity.Mathematics.double4 left, byte4 right) => (double4)left >= right;


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(byte4 other)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return uint.MaxValue == Xse.cmpeq_epi8(this, other).UInt0;

			}
			else
			{
				return (this.x == other.x & this.y == other.y) & (this.z == other.z & this.w == other.w);
			}
		}

		public override bool Equals(object obj) => obj is byte4 converted && this.Equals(converted);


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


		public override string ToString() => $"byte4({x}, {y}, {z}, {w})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
    }
}