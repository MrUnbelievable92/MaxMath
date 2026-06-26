using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;
using static MaxMath.math;

namespace MaxMath
{
#if DEBUG
    internal sealed class byte3DebuggerProxy
    {
        public byte x;
        public byte y;
        public byte z;
        
        public byte3DebuggerProxy(byte3 v)
        {
            x = v.x;
            y = v.y;
            z = v.z;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(byte3DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct byte3 : IEquatable<byte3>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal ushort __x0;

#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal byte __x2;
        
        public ref byte x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte3* ptr = &this) { return ref *((byte*)ptr +  0); } } }
        public ref byte y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte3* ptr = &this) { return ref *((byte*)ptr +  1); } } }
        public ref byte z { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(byte3* ptr = &this) { return ref *((byte*)ptr +  2); } } }


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
                __x0 = Uninitialized<ushort>.Create();
                __x2 = Uninitialized<byte>.Create();

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
                __x0 = Uninitialized<ushort>.Create();
                __x2 = Uninitialized<byte>.Create();

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
                __x0 = Uninitialized<ushort>.Create();
                __x2 = Uninitialized<byte>.Create();

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
                __x0 = Uninitialized<ushort>.Create();
                __x2 = Uninitialized<byte>.Create();

                this.x = x;
                this.y = yz.x;
                this.z = yz.y;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(bool v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(bool3 v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(mask8x3 v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(mask16x3 v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(mask32x3 v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(mask64x3 v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(byte3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(sbyte v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(sbyte3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(ushort v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(ushort3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(short v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(short3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(uint v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(uint3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(int v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(int3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(ulong v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(ulong3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(long v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(long3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(UInt128 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(Int128 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(quarter v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(quarter3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(half v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(half3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(float v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(float3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(double v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(double3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(quadruple v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(Unity.Mathematics.bool3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(Unity.Mathematics.uint3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(Unity.Mathematics.int3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(Unity.Mathematics.half v)
        {
            this = (byte3)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(Unity.Mathematics.half3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(Unity.Mathematics.float3 v)
        {
            this = (byte3)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte3(Unity.Mathematics.double3 v)
        {
            this = (byte3)v;
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
		#endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(byte3 input)
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

            result.UShort0 = input.__x0;
            result.Byte2 = input.__x2;
            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte3(v128 input) => new byte3 { __x0 = input.UShort0, __x2 = input.Byte2 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(bool3 x) => (byte3)(mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(Unity.Mathematics.bool3 x) => (byte3)(mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(mask8x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi8(x);
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(mask16x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte3)(mask8x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(mask32x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte3)(mask8x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(mask64x3 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (byte3)(mask8x3)x;
            }
            else
            {
                return *(byte3*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool3(byte3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool3(byte3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x3(byte3 x) => x != 0;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x3(byte3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x3(byte3 x) => (mask8x3)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x3(byte3 x) => (mask8x3)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(sbyte x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(ushort x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(short x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(uint x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(int x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(ulong x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(long x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(UInt128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(Int128 x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(quarter x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(half x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(float x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(double x) => (byte)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(quadruple x) => (byte)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(Unity.Mathematics.half x) => (byte3)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(Unity.Mathematics.half3 x) => (byte3)(half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(Unity.Mathematics.float3 x) => (byte3)(float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(Unity.Mathematics.double3 x) => (byte3)(double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(Unity.Mathematics.uint3 x) => (byte3)(uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator byte3(Unity.Mathematics.int3 x) => (byte3)(int3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.half3(byte3 x) => (half3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float3(byte3 x) => (float3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double3(byte3 x) => (double3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.uint3(byte3 x) => (uint3)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.int3(byte3 x) => (int3)x;


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
                return Xse.cvtepi32_epi8(input, 3);
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
                return Xse.cvtepi32_epi8(input, 3);
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
                return new byte3(Xse.cvtepi64_epi8(input.__x0), (byte)input.z);
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
                return new byte3(Xse.cvtepi64_epi8(input.__x0), (byte)input.z);
            }
            else
            {
                return new byte3((byte)input.x, (byte)input.y, (byte)input.z);
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
                return Xse.cvtepu8_epi32(input);
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
                return Xse.cvtepu8_epi32(input);
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
        public static implicit operator float3(byte3 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu8_ps(input);
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
            get
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
                    fixed (byte3* ptr = &this)
                    {
                        return ((byte*)ptr)[index];
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
                    fixed (byte3* ptr = &this)
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
        public static byte3 operator + (byte3 left, byte right) => left + (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator + (byte left, byte3 right) => (byte3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator - (byte3 left, byte right) => left - (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator - (byte left, byte3 right) => (byte3)left - right;

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
        public static byte3 operator / (byte left, byte3 right) => (byte3)left / right;

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
        public static byte3 operator % (byte left, byte3 right) => (byte3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (byte3 left, Unity.Mathematics.int3 right) => left + (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator + (Unity.Mathematics.int3 left, byte3 right) => (int3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (byte3 left, Unity.Mathematics.int3 right) => left - (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator - (Unity.Mathematics.int3 left, byte3 right) => (int3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (byte3 left, Unity.Mathematics.int3 right) => left * (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator * (Unity.Mathematics.int3 left, byte3 right) => (int3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (byte3 left, Unity.Mathematics.int3 right) => left / (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator / (Unity.Mathematics.int3 left, byte3 right) => (int3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (byte3 left, Unity.Mathematics.int3 right) => left % (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator % (Unity.Mathematics.int3 left, byte3 right) => (int3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (byte3 left, Unity.Mathematics.uint3 right) => left + (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator + (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (byte3 left, Unity.Mathematics.uint3 right) => left - (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator - (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (byte3 left, Unity.Mathematics.uint3 right) => left * (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator * (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (byte3 left, Unity.Mathematics.uint3 right) => left / (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator / (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (byte3 left, Unity.Mathematics.uint3 right) => left % (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator % (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (byte3 left, Unity.Mathematics.float3 right) => left + (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator + (Unity.Mathematics.float3 left, byte3 right) => (float3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (byte3 left, Unity.Mathematics.float3 right) => left - (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator - (Unity.Mathematics.float3 left, byte3 right) => (float3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (byte3 left, Unity.Mathematics.float3 right) => left * (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator * (Unity.Mathematics.float3 left, byte3 right) => (float3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (byte3 left, Unity.Mathematics.float3 right) => left / (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator / (Unity.Mathematics.float3 left, byte3 right) => (float3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (byte3 left, Unity.Mathematics.float3 right) => left % (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator % (Unity.Mathematics.float3 left, byte3 right) => (float3)left % right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (byte3 left, Unity.Mathematics.double3 right) => left + (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator + (Unity.Mathematics.double3 left, byte3 right) => (double3)left + right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (byte3 left, Unity.Mathematics.double3 right) => left - (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator - (Unity.Mathematics.double3 left, byte3 right) => (double3)left - right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (byte3 left, Unity.Mathematics.double3 right) => left * (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator * (Unity.Mathematics.double3 left, byte3 right) => (double3)left * right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (byte3 left, Unity.Mathematics.double3 right) => left / (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator / (Unity.Mathematics.double3 left, byte3 right) => (double3)left / right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (byte3 left, Unity.Mathematics.double3 right) => left % (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator % (Unity.Mathematics.double3 left, byte3 right) => (double3)left % right;


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
        public static byte3 operator & (byte3 left, byte right) => left & (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator & (byte left, byte3 right) => (byte3)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator | (byte3 left, byte right) => left | (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator | (byte left, byte3 right) => (byte3)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ^ (byte3 left, byte right) => left ^ (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 operator ^ (byte left, byte3 right) => (byte3)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (byte3 left, Unity.Mathematics.int3 right) => left & (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator & (Unity.Mathematics.int3 left, byte3 right) => (int3)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (byte3 left, Unity.Mathematics.int3 right) => left | (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator | (Unity.Mathematics.int3 left, byte3 right) => (int3)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (byte3 left, Unity.Mathematics.int3 right) => left ^ (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^ (Unity.Mathematics.int3 left, byte3 right) => (int3)left ^ right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (byte3 left, Unity.Mathematics.uint3 right) => left & (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator & (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left & right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (byte3 left, Unity.Mathematics.uint3 right) => left | (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator | (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left | right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (byte3 left, Unity.Mathematics.uint3 right) => left ^ (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^ (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left ^ right;


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
        public static mask8x3 operator == (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpeq_epi8(left, right);
            }
            else
            {
                return new mask8x3(left.x == right.x, left.y == right.y, left.z == right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmplt_epu8(left, right, 3);
            }
            else
            {
                return new mask8x3(left.x < right.x, left.y < right.y, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpgt_epu8(left, right, 3);
            }
            else
            {
                return new mask8x3(left.x > right.x, left.y > right.y, left.z > right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.not_si128(Xse.cmpeq_epi8(left, right));
            }
            else
            {
                return new mask8x3(left.x != right.x, left.y != right.y, left.z != right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmple_epu8(left, right, 3);
            }
            else
            {
                return new mask8x3(left.x <= right.x, left.y <= right.y, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (byte3 left, byte3 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cmpge_epu8(left, right, 3);
            }
            else
            {
                return new mask8x3(left.x >= right.x, left.y >= right.y, left.z >= right.z);
            }
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (byte3 left, byte right) => left == (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (byte left, byte3 right) => (byte3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (byte3 left, byte right) => left != (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (byte left, byte3 right) => (byte3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (byte3 left, byte right) => left < (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (byte left, byte3 right) => (byte3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (byte3 left, byte right) => left > (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (byte left, byte3 right) => (byte3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (byte3 left, byte right) => left <= (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (byte left, byte3 right) => (byte3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (byte3 left, byte right) => left >= (byte3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (byte left, byte3 right) => (byte3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (byte3 left, Unity.Mathematics.int3 right) => left == (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.int3 left, byte3 right) => (int3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (byte3 left, Unity.Mathematics.int3 right) => left != (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.int3 left, byte3 right) => (int3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (byte3 left, Unity.Mathematics.int3 right) => left < (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.int3 left, byte3 right) => (int3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (byte3 left, Unity.Mathematics.int3 right) => left > (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.int3 left, byte3 right) => (int3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (byte3 left, Unity.Mathematics.int3 right) => left <= (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.int3 left, byte3 right) => (int3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (byte3 left, Unity.Mathematics.int3 right) => left >= (int3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.int3 left, byte3 right) => (int3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (byte3 left, Unity.Mathematics.uint3 right) => left == (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (byte3 left, Unity.Mathematics.uint3 right) => left != (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (byte3 left, Unity.Mathematics.uint3 right) => left < (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (byte3 left, Unity.Mathematics.uint3 right) => left > (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (byte3 left, Unity.Mathematics.uint3 right) => left <= (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (byte3 left, Unity.Mathematics.uint3 right) => left >= (uint3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.uint3 left, byte3 right) => (uint3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (byte3 left, Unity.Mathematics.half3 right) => left == (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.half3 left, byte3 right) => (half3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (byte3 left, Unity.Mathematics.half3 right) => left != (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.half3 left, byte3 right) => (half3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (byte3 left, Unity.Mathematics.half3 right) => left < (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.half3 left, byte3 right) => (half3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (byte3 left, Unity.Mathematics.half3 right) => left > (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.half3 left, byte3 right) => (half3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (byte3 left, Unity.Mathematics.half3 right) => left <= (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.half3 left, byte3 right) => (half3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (byte3 left, Unity.Mathematics.half3 right) => left >= (half3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.half3 left, byte3 right) => (half3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (byte3 left, Unity.Mathematics.float3 right) => left == (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.float3 left, byte3 right) => (float3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (byte3 left, Unity.Mathematics.float3 right) => left != (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.float3 left, byte3 right) => (float3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (byte3 left, Unity.Mathematics.float3 right) => left < (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.float3 left, byte3 right) => (float3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (byte3 left, Unity.Mathematics.float3 right) => left > (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.float3 left, byte3 right) => (float3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (byte3 left, Unity.Mathematics.float3 right) => left <= (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.float3 left, byte3 right) => (float3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (byte3 left, Unity.Mathematics.float3 right) => left >= (float3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.float3 left, byte3 right) => (float3)left >= right;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (byte3 left, Unity.Mathematics.double3 right) => left == (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator == (Unity.Mathematics.double3 left, byte3 right) => (double3)left == right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (byte3 left, Unity.Mathematics.double3 right) => left != (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator != (Unity.Mathematics.double3 left, byte3 right) => (double3)left != right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (byte3 left, Unity.Mathematics.double3 right) => left < (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator < (Unity.Mathematics.double3 left, byte3 right) => (double3)left < right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (byte3 left, Unity.Mathematics.double3 right) => left > (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator > (Unity.Mathematics.double3 left, byte3 right) => (double3)left > right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (byte3 left, Unity.Mathematics.double3 right) => left <= (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator <= (Unity.Mathematics.double3 left, byte3 right) => (double3)left <= right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (byte3 left, Unity.Mathematics.double3 right) => left >= (double3)right;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask8x3 operator >= (Unity.Mathematics.double3 left, byte3 right) => (double3)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(byte3 other)
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

        public override bool Equals(object obj) => obj is byte3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"byte3({x}, {y}, {z})";
        public string ToString(string format, IFormatProvider formatProvider) => $"byte3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}