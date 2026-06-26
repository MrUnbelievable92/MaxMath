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
    internal sealed class ulong2DebuggerProxy
    {
        public ulong x;
        public ulong y;

        public ulong2DebuggerProxy(ulong2 v)
        {
            x  = v.x;
            y  = v.y;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(ulong2DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct ulong2 : IEquatable<ulong2>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        public ulong __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        public ulong __x1;
        
        public ref ulong x { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ulong2* ptr = &this) { return ref *((ulong*)ptr +  0); } } }
        public ref ulong y { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(ulong2* ptr = &this) { return ref *((ulong*)ptr +  1); } } }


        public static ulong2 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(ulong x, ulong y)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set_epi64x((long)y, (long)x);
            }
            else
            {
                __x0 = Uninitialized<ulong>.Create();
                __x1 = Uninitialized<ulong>.Create();

                this.x = x;
                this.y = y;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(ulong xy)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                this = Xse.set1_epi64x(xy);
            }
            else
            {
                __x0 = Uninitialized<ulong>.Create();
                __x1 = Uninitialized<ulong>.Create();

                this.x = this.y = xy;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(bool v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(bool2 v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(mask8x2 v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(mask16x2 v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(mask32x2 v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(mask64x2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(byte v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(byte2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(sbyte v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(sbyte2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(ushort v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(ushort2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(short v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(short2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(uint v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(uint2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(int v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(int2 v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(ulong2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(long v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(long2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(UInt128 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(Int128 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(quarter v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(quarter2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(half v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(half2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(float v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(float2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(double v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(double2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(quadruple v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(Unity.Mathematics.bool2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(Unity.Mathematics.uint2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(Unity.Mathematics.int2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(Unity.Mathematics.half v)
        {
            this = (ulong2)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(Unity.Mathematics.half2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(Unity.Mathematics.float2 v)
        {
            this = (ulong2)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong2(Unity.Mathematics.double2 v)
        {
            this = (ulong2)v;
        }

        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_broadcastq_epi64(this);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    ulong2 _xx = xx;

                    return new ulong4(_xx, _xx);
                }
                else
                {
                    return new ulong4(x, x, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 0, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(yx, xx);
                }
                else
                {
                    return new ulong4(y, x, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 1, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(this, xx);
                }
                else
                {
                    return new ulong4(x, y, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 0, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(xx, yx);
                }
                else
                {
                    return new ulong4(x, x, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 0, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(xx, this);
                }
                else
                {
                    return new ulong4(x, x, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 0, 1, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(yy, xx);
                }
                else
                {
                    return new ulong4(y, y, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 0, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    ulong2 _yx = yx;

                    return new ulong4(_yx, _yx);
                }
                else
                {
                    return new ulong4(y, x, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 0, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(yx, this);
                }
                else
                {
                    return new ulong4(y, x, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 1, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(this, yx);
                }
                else
                {
                    return new ulong4(x, y, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 1, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(this, this);
                }
                else
                {
                    return new ulong4(x, y, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 0, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(xx, yy);
                }
                else
                {
                    return new ulong4(x, x, y, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(0, 1, 1, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(yy, yx);
                }
                else
                {
                    return new ulong4(y, y, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 1, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(yy, this);
                }
                else
                {
                    return new ulong4(y, y, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 0, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(yx, yy);
                }
                else
                {
                    return new ulong4(y, x, y, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 1, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong4(this, yy);
                }
                else
                {
                    return new ulong4(x, y, y, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong4 yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 1, 1, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    ulong2 _yy = yy;

                    return new ulong4(_yy, _yy);
                }
                else
                {
                    return new ulong4(y, y, y, y);
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_broadcastq_epi64(this);
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong3(xx, x);
                }
                else
                {
                    return new ulong3(x, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 0, 0, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong3(yx, x);
                }
                else
                {
                    return new ulong3(y, x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(1, 0, 1, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong3(this, x);
                }
                else
                {
                    return new ulong3(x, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 0, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong3(xx, y);
                }
                else
                {
                    return new ulong3(x, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 0, 1, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong3(yy, x);
                }
                else
                {
                    return new ulong3(y, y, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 0, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong3(yx, y);
                }
                else
                {
                    return new ulong3(y, x, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 1, 0));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong3(this, y);
                }
                else
                {
                    return new ulong3(x, y, y);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong3 yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(this), Sse.SHUFFLE(3, 1, 1, 1));
                }
                else if (BurstArchitecture.IsSIMDSupported)
                {
                    return new ulong3(yy, y);
                }
                else
                {
                    return new ulong3(y, y, y);
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new ulong2(x, x);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                return this;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value;
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shuffle_epi32(this, Sse.SHUFFLE(1, 0, 3, 2));
                }
                else
                {
                    return new ulong2(y, x);
                }
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this = value.yx;
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public ulong2 yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (BurstArchitecture.IsSIMDSupported)
                {
                    return Xse.shuffle_epi32(this, Sse.SHUFFLE(3, 2, 3, 2));
                }
                else
                {
                    return new ulong2(y, y);
                }
            }
        }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v128(ulong2 input)
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

            result.ULong0 = input.__x0;
            result.ULong1 = input.__x1;

            return result;
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(v128 input) => new ulong2{ __x0 = input.ULong0, __x1 = input.ULong1 };

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(bool2 x) => (ulong2)(mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(Unity.Mathematics.bool2 x) => (ulong2)(mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(mask8x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong2)(mask64x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(mask16x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong2)(mask64x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(mask32x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (ulong2)(mask64x2)x;
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(mask64x2 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.neg_epi64(x);
            }
            else
            {
                return *(byte2*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool2(ulong2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.bool2(ulong2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x2(ulong2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x2(ulong2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x2(ulong2 x) => (mask64x2)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask64x2(ulong2 x) => x != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong2(byte x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(sbyte x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong2(ushort x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(short x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator ulong2(uint x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(int x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(long x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(UInt128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(Int128 x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(quarter x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(half x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(float x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(double x) => (ulong)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(quadruple x) => (ulong)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(Unity.Mathematics.half x) => (ulong2)(half)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(Unity.Mathematics.half2 x) => (ulong2)(half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(Unity.Mathematics.float2 x) => (ulong2)(float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(Unity.Mathematics.double2 x) => (ulong2)(double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(Unity.Mathematics.uint2 x) => (ulong2)(uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(Unity.Mathematics.int2 x) => (ulong2)(int2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.half2(ulong2 x) => (half2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.float2(ulong2 x) => (float2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Unity.Mathematics.double2(ulong2 x) => (double2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.uint2(ulong2 x) => (uint2)x;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Unity.Mathematics.int2(ulong2 x) => (int2)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(ulong input) => new ulong2(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(long2 input) => *(ulong2*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong2(uint2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu32_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(int2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi32_epi64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(float2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttps_epu64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong2(double2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvttpd_epu64(input);
            }
            else
            {
                return new ulong2((ulong)input.x, (ulong)input.y);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(ulong2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_epi32(input);
            }
            else
            {
                return new uint2((uint)input.x, (uint)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(ulong2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepi64_epi32(input);
            }
            else
            {
                return new int2((int)input.x, (int)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(ulong2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu64_ps(input);
            }
            else
            {
                return new float2((float)input.x, (float)input.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(ulong2 input)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.cvtepu64_pd(input);
            }
            else
            {
                return new double2((double)input.x, (double)input.y);
            }
        }

        
        public ulong this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
Assert.IsWithinArrayBounds(index, 2);

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
					    return Xse.extract_epi64(this, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ulong2* ptr = &this)
                    {
                        return ((ulong*)ptr)[index];
                    }
                }
                else
                {
                    return this.GetField<ulong2, ulong>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 2);

				if (constexpr.IS_CONST(index))
				{
					if (BurstArchitecture.IsSIMDSupported)
					{
						this = Xse.insert_epi64(this, value, (byte)index);
					}
				}

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (ulong2* ptr = &this)
                    {
                        ((ulong*)ptr)[index] = value;
                    }
                }
                else
                {
                    this.SetField(value, index);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.add_epi64(left, right);
			}
			else
			{
				return new ulong2(left.x + right.x, left.y + right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.sub_epi64(left, right);
			}
			else
			{
				return new ulong2(left.x - right.x, left.y - right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.mullo_epi64(left, right);
			}
			else
			{
				return new ulong2(left.x * right.x, left.y * right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epu64(left, right);
			}
			else
			{
				return new ulong2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epu64(left, right);
			}
			else
			{
				return new ulong2(left.x % right.x, left.y % right.y);
			}
		}

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ulong2 left, byte right) => left + (byte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ulong2 left, ushort right) => left + (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ulong2 left, uint right) => left + (uint2)right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 operator + (ulong2 left, ulong right) => left + (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, byte right) => left - (byte2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, ushort right) => left - (ushort2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, uint right) => left - (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, ulong right) => left - (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, byte right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, ushort right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, uint right) => right * left;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, ulong right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				if (constexpr.IS_CONST(right))
				{
					return new ulong2(left.x * right, left.y * right);
				}
			}

            return new ulong2(left.x * right, left.y * right);
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (ulong)right;
                }
            }

            return left / (byte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (ulong)right;
                }
            }

            return left / (ushort2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left / (ulong)right;
                }
            }

            return left / (uint2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, ulong right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constdiv_epu64(left, right);
                }
            }

            return new ulong2(left.x / right, left.y / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, byte right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (ulong)right;
                }
            }

            return left % (byte2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, ushort right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (ulong)right;
                }
            }

            return left % (ushort2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, uint right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return left % (ulong)right;
                }
            }

            return left % (uint2)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, ulong right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.constrem_epu64(left, right);
                }
            }

            return new ulong2(left.x % right, left.y % right);
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (byte left, ulong2 right) => (byte2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ushort left, ulong2 right) => (ushort2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (uint left, ulong2 right) => (uint2)left + right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 operator + (ulong left, ulong2 right) => (ulong2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (byte left, ulong2 right) => (byte2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ushort left, ulong2 right) => (ushort2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (uint left, ulong2 right) => (uint2)left - right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 operator - (ulong left, ulong2 right) => (ulong2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (byte left, ulong2 right) => (ulong)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ushort left, ulong2 right) => (ulong)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (uint left, ulong2 right) => (ulong)left * right;
        
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ulong2 operator * (ulong left, ulong2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (byte left, ulong2 right) => (byte2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ushort left, ulong2 right) => (ushort2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (uint left, ulong2 right) => (uint2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong left, ulong2 right) => (ulong2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (byte left, ulong2 right) => (byte2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ushort left, ulong2 right) => (ushort2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (uint left, ulong2 right) => (uint2)left % right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong left, ulong2 right) => (ulong2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ulong2 left, byte2 right) => left + (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (byte2 left, ulong2 right) => (ulong2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, byte2 right) => left - (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (byte2 left, ulong2 right) => (ulong2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, byte2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi64(left, (ulong2)right, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (byte2 left, ulong2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (byte2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epu64(Xse.cvtepu8_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new ulong2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, byte2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epu64(left, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new ulong2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (byte2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epu64(Xse.cvtepu8_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new ulong2(left.x % right.x, left.y % right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, byte2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epu64(left, Xse.cvtepu8_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new ulong2(left.x % right.x, left.y % right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ulong2 left, ushort2 right) => left + (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ushort2 left, ulong2 right) => (ulong2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, ushort2 right) => left - (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ushort2 left, ulong2 right) => (ulong2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, ushort2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi64(left, (ulong2)right, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ushort2 left, ulong2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ushort2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epu64(Xse.cvtepu16_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new ulong2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, ushort2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epu64(left, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new ulong2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ushort2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epu64(Xse.cvtepu16_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new ulong2(left.x % right.x, left.y % right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, ushort2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epu64(left, Xse.cvtepu16_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new ulong2(left.x % right.x, left.y % right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ulong2 left, uint2 right) => left + (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (uint2 left, ulong2 right) => (ulong2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, uint2 right) => left - (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (uint2 left, ulong2 right) => (ulong2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, uint2 right)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.mullo_epi64(left, (ulong2)right, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong2(left.x * right.x, left.y * right.y);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (uint2 left, ulong2 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (uint2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epu64(Xse.cvtepu32_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new ulong2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, uint2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.div_epu64(left, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new ulong2(left.x / right.x, left.y / right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (uint2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epu64(Xse.cvtepu32_pd(left), right, useFPU: true, aIsDbl: true, aLEu32max: true);
			}
			else
			{
				return new ulong2(left.x % right.x, left.y % right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, uint2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
                return Xse.rem_epu64(left, Xse.cvtepu32_pd(right), useFPU: true, bIsDbl: true, bLEu32max: true);
			}
			else
			{
				return new ulong2(left.x % right.x, left.y % right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (ulong2 left, Unity.Mathematics.uint2 right) => left + (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (ulong2 left, Unity.Mathematics.uint2 right) => left - (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (ulong2 left, Unity.Mathematics.uint2 right) => left * (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (ulong2 left, Unity.Mathematics.uint2 right) => left / (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (ulong2 left, Unity.Mathematics.uint2 right) => left % (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator + (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator - (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator * (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator / (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator % (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (ulong2 left, Unity.Mathematics.float2 right) => left + (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (ulong2 left, Unity.Mathematics.float2 right) => left - (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (ulong2 left, Unity.Mathematics.float2 right) => left * (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (ulong2 left, Unity.Mathematics.float2 right) => left / (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (ulong2 left, Unity.Mathematics.float2 right) => left % (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator + (Unity.Mathematics.float2 left, ulong2 right) => (float2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator - (Unity.Mathematics.float2 left, ulong2 right) => (float2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator * (Unity.Mathematics.float2 left, ulong2 right) => (float2)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator / (Unity.Mathematics.float2 left, ulong2 right) => (float2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator % (Unity.Mathematics.float2 left, ulong2 right) => (float2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (ulong2 left, Unity.Mathematics.double2 right) => left + (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (ulong2 left, Unity.Mathematics.double2 right) => left - (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (ulong2 left, Unity.Mathematics.double2 right) => left * (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (ulong2 left, Unity.Mathematics.double2 right) => left / (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (ulong2 left, Unity.Mathematics.double2 right) => left % (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator + (Unity.Mathematics.double2 left, ulong2 right) => (double2)left + right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator - (Unity.Mathematics.double2 left, ulong2 right) => (double2)left - right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator * (Unity.Mathematics.double2 left, ulong2 right) => (double2)left * right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator / (Unity.Mathematics.double2 left, ulong2 right) => (double2)left / right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 operator % (Unity.Mathematics.double2 left, ulong2 right) => (double2)left % right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.and_si128(left, right);
			}
			else
			{
				return new ulong2(left.x & right.x, left.y & right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.or_si128(left, right);
			}
			else
			{
				return new ulong2(left.x | right.x, left.y | right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.xor_si128(left, right);
			}
			else
			{
				return new ulong2(left.x ^ right.x, left.y ^ right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, byte2 right) => left & (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, byte2 right) => left | (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, byte2 right) => left ^ (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (byte2 left, ulong2 right) => (ulong2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (byte2 left, ulong2 right) => (ulong2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (byte2 left, ulong2 right) => (ulong2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, ushort2 right) => left & (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, ushort2 right) => left | (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, ushort2 right) => left ^ (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ushort2 left, ulong2 right) => (ulong2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ushort2 left, ulong2 right) => (ulong2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ushort2 left, ulong2 right) => (ulong2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, uint2 right) => left & (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, uint2 right) => left | (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, uint2 right) => left ^ (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (uint2 left, ulong2 right) => (ulong2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (uint2 left, ulong2 right) => (ulong2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (uint2 left, ulong2 right) => (ulong2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, Unity.Mathematics.uint2 right) => left & (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, Unity.Mathematics.uint2 right) => left | (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, Unity.Mathematics.uint2 right) => left ^ (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (Unity.Mathematics.uint2 left, ulong2 right) => (ulong2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (Unity.Mathematics.uint2 left, ulong2 right) => (ulong2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (Unity.Mathematics.uint2 left, ulong2 right) => (ulong2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, byte right) => left & (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, byte right) => left | (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, byte right) => left ^ (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (byte left, ulong2 right) => (ulong2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (byte left, ulong2 right) => (ulong2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (byte left, ulong2 right) => (ulong2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, ushort right) => left & (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, ushort right) => left | (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, ushort right) => left ^ (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ushort left, ulong2 right) => (ulong2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ushort left, ulong2 right) => (ulong2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ushort left, ulong2 right) => (ulong2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, uint right) => left & (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, uint right) => left | (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, uint right) => left ^ (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (uint left, ulong2 right) => (ulong2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (uint left, ulong2 right) => (ulong2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (uint left, ulong2 right) => (ulong2)left ^ right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong2 left, ulong right) => left & (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong2 left, ulong right) => left | (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong2 left, ulong right) => left ^ (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator & (ulong left, ulong2 right) => (ulong2)left & right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator | (ulong left, ulong2 right) => (ulong2)left | right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ^ (ulong left, ulong2 right) => (ulong2)left ^ right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ++ (ulong2 x)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.inc_epi64(x);
			}
			else
			{
				return new ulong2(x.x + 1, x.y + 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator -- (ulong2 x)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.dec_epi64(x);
			}
			else
			{
				return new ulong2(x.x - 1, x.y - 1);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator ~ (ulong2 x)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.not_si128(x);
			}
			else
			{
				return new ulong2(~x.x, ~x.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator << (ulong2 x, int n)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.slli_epi64(x, n);
			}
			else
			{
				return new ulong2(x.x << n, x.y << n);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 operator >> (ulong2 x, int n)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.srli_epi64(x, n);
			}
			else
			{
				return new ulong2(x.x >> n, x.y >> n);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cmpeq_epi64(left, right);
			}
			else
			{
				return new mask64x2(left.x == right.x, left.y == right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cmplt_epu64(left, right);
			}
			else
			{
				return new mask64x2(left.x < right.x, left.y < right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.cmpgt_epu64(left, right);
			}
			else
			{
				return new mask64x2(left.x > right.x, left.y > right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.not_si128(Xse.cmpeq_epi64(left, right));
			}
			else
			{
				return new mask64x2(left.x != right.x, left.y != right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.not_si128(Xse.cmpgt_epu64(left, right));
			}
			else
			{
				return new mask64x2(left.x <= right.x, left.y <= right.y);
			}
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, ulong2 right)
		{
			if (BurstArchitecture.IsSIMDSupported)
			{
				return Xse.not_si128(Xse.cmplt_epu64(left, right));
			}
			else
			{
				return new mask64x2(left.x >= right.x, left.y >= right.y);
			}
		}


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, byte right) => left == (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (byte left, ulong2 right) => (ulong2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, byte right) => left != (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (byte left, ulong2 right) => (ulong2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, byte right) => left < (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (byte left, ulong2 right) => (ulong2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, byte right) => left > (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (byte left, ulong2 right) => (ulong2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, byte right) => left <= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (byte left, ulong2 right) => (ulong2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, byte right) => left >= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (byte left, ulong2 right) => (ulong2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, ushort right) => left == (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ushort left, ulong2 right) => (ulong2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, ushort right) => left != (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ushort left, ulong2 right) => (ulong2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, ushort right) => left < (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ushort left, ulong2 right) => (ulong2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, ushort right) => left > (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ushort left, ulong2 right) => (ulong2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, ushort right) => left <= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ushort left, ulong2 right) => (ulong2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, ushort right) => left >= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ushort left, ulong2 right) => (ulong2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, uint right) => left == (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (uint left, ulong2 right) => (ulong2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, uint right) => left != (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (uint left, ulong2 right) => (ulong2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, uint right) => left < (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (uint left, ulong2 right) => (ulong2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, uint right) => left > (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (uint left, ulong2 right) => (ulong2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, uint right) => left <= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (uint left, ulong2 right) => (ulong2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, uint right) => left >= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (uint left, ulong2 right) => (ulong2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, ulong right) => left == (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong left, ulong2 right) => (ulong2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, ulong right) => left != (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong left, ulong2 right) => (ulong2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, ulong right) => left < (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong left, ulong2 right) => (ulong2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, ulong right) => left > (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong left, ulong2 right) => (ulong2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, ulong right) => left <= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong left, ulong2 right) => (ulong2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, ulong right) => left >= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong left, ulong2 right) => (ulong2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, byte2 right) => left == (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (byte2 left, ulong2 right) => (ulong2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, byte2 right) => left != (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (byte2 left, ulong2 right) => (ulong2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, byte2 right) => left < (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (byte2 left, ulong2 right) => (ulong2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, byte2 right) => left > (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (byte2 left, ulong2 right) => (ulong2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, byte2 right) => left <= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (byte2 left, ulong2 right) => (ulong2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, byte2 right) => left >= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (byte2 left, ulong2 right) => (ulong2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, ushort2 right) => left == (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ushort2 left, ulong2 right) => (ulong2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, ushort2 right) => left != (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ushort2 left, ulong2 right) => (ulong2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, ushort2 right) => left < (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ushort2 left, ulong2 right) => (ulong2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, ushort2 right) => left > (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ushort2 left, ulong2 right) => (ulong2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, ushort2 right) => left <= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ushort2 left, ulong2 right) => (ulong2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, ushort2 right) => left >= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ushort2 left, ulong2 right) => (ulong2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, uint2 right) => left == (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (uint2 left, ulong2 right) => (ulong2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, uint2 right) => left != (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (uint2 left, ulong2 right) => (ulong2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, uint2 right) => left < (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (uint2 left, ulong2 right) => (ulong2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, uint2 right) => left > (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (uint2 left, ulong2 right) => (ulong2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, uint2 right) => left <= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (uint2 left, ulong2 right) => (ulong2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, uint2 right) => left >= (ulong2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (uint2 left, ulong2 right) => (ulong2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, Unity.Mathematics.uint2 right) => left == (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, Unity.Mathematics.uint2 right) => left != (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, Unity.Mathematics.uint2 right) => left < (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, Unity.Mathematics.uint2 right) => left > (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, Unity.Mathematics.uint2 right) => left <= (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, Unity.Mathematics.uint2 right) => left >= (uint2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.uint2 left, ulong2 right) => (uint2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, Unity.Mathematics.float2 right) => left == (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.float2 left, ulong2 right) => (float2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, Unity.Mathematics.float2 right) => left != (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.float2 left, ulong2 right) => (float2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, Unity.Mathematics.float2 right) => left < (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.float2 left, ulong2 right) => (float2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, Unity.Mathematics.float2 right) => left > (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.float2 left, ulong2 right) => (float2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, Unity.Mathematics.float2 right) => left <= (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.float2 left, ulong2 right) => (float2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, Unity.Mathematics.float2 right) => left >= (float2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.float2 left, ulong2 right) => (float2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (ulong2 left, Unity.Mathematics.double2 right) => left == (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator == (Unity.Mathematics.double2 left, ulong2 right) => (double2)left == right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (ulong2 left, Unity.Mathematics.double2 right) => left != (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator != (Unity.Mathematics.double2 left, ulong2 right) => (double2)left != right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (ulong2 left, Unity.Mathematics.double2 right) => left < (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator < (Unity.Mathematics.double2 left, ulong2 right) => (double2)left < right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (ulong2 left, Unity.Mathematics.double2 right) => left > (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator > (Unity.Mathematics.double2 left, ulong2 right) => (double2)left > right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (ulong2 left, Unity.Mathematics.double2 right) => left <= (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator <= (Unity.Mathematics.double2 left, ulong2 right) => (double2)left <= right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (ulong2 left, Unity.Mathematics.double2 right) => left >= (double2)right;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask64x2 operator >= (Unity.Mathematics.double2 left, ulong2 right) => (double2)left >= right;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(ulong2 other)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return Xse.alltrue_epi128<ulong>(Xse.cmpeq_epi64(this, other));
            }
            else
            {
                return this.x == other.x & this.y == other.y;
            }
        }

        public override bool Equals(object obj) => obj is ulong2 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"ulong2({x}, {y})";
        public string ToString(string format, IFormatProvider formatProvider) => $"ulong2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
    }
}