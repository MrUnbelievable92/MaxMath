using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;
using DevTools;

using static Unity.Burst.Intrinsics.X86;

namespace MaxMath
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit, Size = 3 * sizeof(ulong))]
    [DebuggerTypeProxy(typeof(long3.DebuggerProxy))]
    unsafe public struct ulong3 : IEquatable<ulong3>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public ulong x;
            public ulong y;
            public ulong z;

            public DebuggerProxy(ulong3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }


        [FieldOffset(0)]  internal ulong2 _xy;

        [FieldOffset(0)]  public ulong x;
        [FieldOffset(8)]  public ulong y;
        [FieldOffset(16)] public ulong z;


        public static ulong3 zero => default;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong x, ulong y, ulong z)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi64x(0L, (long)z, (long)y, (long)x);
            }
            else if (Architecture.IsSIMDSupported)
            {
                this = new ulong3 { _xy = new ulong2(x, y), z = z };
            }
            else
            {
                this = new ulong3 { x = x, y = y, z = z };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong xyz)
        {
            if (Avx.IsAvxSupported)
            {
                this = Xse.mm256_set1_epi64x(xyz);
            }
            else if (Architecture.IsSIMDSupported)
            {
                this = new ulong3 { _xy = new ulong2(xyz), z = xyz };
            }
            else
            {
                this = new ulong3 { x = xyz, y = xyz, z = xyz };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong2 xy, ulong z)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(Avx.mm256_castsi128_si256(xy), (long)z, 2);
            }
            else
            {
                this = new ulong3 { _xy = xy, z = z };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ulong3(ulong x, ulong2 yz)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_insert_epi64(yz.xxy, (long)x, 0);
            }
            else if (Architecture.IsSIMDSupported)
            {
                yz = yz.yx;
                ulong z = yz.x;
                yz.x = x;

                this = new ulong3 { _xy = yz, z = z };
            }
            else
            {
                this = new ulong3 { x = x, y = yz.x, z = yz.y };
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
                    return new ulong4(xx, _xy);
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
                    return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new ulong4(xx, zz);
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
                    return new ulong4(_xy, xx);
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
                    return new ulong4(_xy, _xy);
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
                    return new ulong4(_xy, xz);
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
                    return new ulong4(_xy, yx);
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
                    return new ulong4(_xy, yy);
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
                    return new ulong4(_xy, yz);
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
                    return new ulong4(_xy, zx);
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
                    return new ulong4(_xy, zy);
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
                    return new ulong4(_xy, zz);
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
                    return new ulong4(xz, _xy);
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
                    return new ulong4(yx, _xy);
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
                    return new ulong4(yy, _xy);
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
                    return new ulong4(yz, _xy);
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
                    return new ulong4(zx, _xy);
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
                    return new ulong4(zy, _xy);
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
                    return new ulong4(zz, _xy);
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
                    return Avx2.mm256_shuffle_epi32(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new ulong3(xx, z);
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
                    return Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return new ulong3(_xy, x);
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
                    return new ulong3(_xy, y);
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
                this = value.xzy;
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
                this = value.yxz;
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
                this = value.zxy;
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
                this = value.yzx;
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
                this = value.zyx;
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

        public readonly ulong2 xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 1, 0));
                }
                else
                {
                    return _xy.xx;
                }
            }
        }
        public          ulong2 xy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(this);
                }
                else
                {
                    return _xy;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_inserti128_si256(this, value, 0);
                }
                else
                {
                    this._xy = value;
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
                else
                {
                    ulong2 _xz = _xy;
                    _xz.y = z;
                    return _xz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, value.xxyy, 0b0011_0011);
                }
                else
                {
                    this.x = value.x;
                    this.z = value.y;
                }
            }
        }
        public          ulong2 yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(1, 0, 3, 2));
                }
                else
                {
                    return _xy.yx;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_inserti128_si256(this, value.yx, 0);
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
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.shuffle_epi32(Avx.mm256_castsi256_si128(this), Sse.SHUFFLE(3, 2, 3, 2));
                }
                else
                {
                    return _xy.yy;
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
                    this = Avx2.mm256_blend_epi32(this, value.yxyx, 0b0011_1100);
                }
                else
                {
                    this.y = value.x;
                    this.z = value.y;
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
                else
                {
                    ulong2 _zy = _xy;
                    _zy.x = z;
                    return _zy;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, value.yyxx, 0b0011_1100);
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
                else
                {
                    return new ulong2(z, z);
                }
            }
        }
        #endregion


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(ulong3 input)
        {
            if (Avx.IsAvxSupported)
            {
                v256 result = Avx.mm256_undefined_si256();

                result.ULong0 = input.x;
                result.ULong1 = input.y;
                result.ULong2 = input.z;

                return result;
            }
            else
            {
                return new v256(input.x, input.y, input.z, 0);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(v256 input) => new ulong3 { x = input.ULong0, y = input.ULong1, z = input.ULong2 };


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(ulong input) => new ulong3(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(long3 input) => *(ulong3*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong3(uint3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepu32_epi64(RegisterConversion.ToV128(input));
            }
            else
            {
                return new ulong3
                {
                    _xy = (ulong2)input.xy,
                    z = (ulong)input.z
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(int3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cvtepi32_epi64(RegisterConversion.ToV128(input));
            }
            else
            {
                return new ulong3
                {
                    _xy = (ulong2)input.xy,
                    z = (ulong)input.z
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(half3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epu64(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new ulong3((ulong2)input.xy, maxmath.BASE_cvtf16i32(input.z, signed: false, trunc: true));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(float3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epu64(RegisterConversion.ToV128(input), 3);
            }
            else
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator ulong3(double3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttpd_epu64(RegisterConversion.ToV256(input), 3);
            }
            else
            {
                return new ulong3((ulong2)input.xy, (ulong)input.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToUInt3(Xse.mm256_cvtepi64_epi32(input));
            }
            else if (Architecture.IsSIMDSupported)
            {
                v128 temp = Xse.cvtepi64_epi32(input._xy);

                return RegisterConversion.ToUInt3(Xse.unpacklo_epi64(temp, Xse.cvtsi32_si128((int)input.z)));
            }
            else
            {
                return new uint3((uint2)input.xy, (uint)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToInt3(Xse.mm256_cvtepi64_epi32(input));
            }
            else if (Architecture.IsSIMDSupported)
            {
                v128 temp = Xse.cvtepi64_epi32(input._xy);

                return RegisterConversion.ToInt3(Xse.unpacklo_epi64(temp, Xse.cvtsi32_si128((int)input.z)));
            }
            else
            {
                return new int3((int2)input.xy, (int)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator half3(ulong3 input) => (half3)(float3)(uint3)input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToFloat3(Xse.mm256_cvtepu64_ps(input, 3));
            }
            else
            {
                return new float3((float2)input._xy, (float)input.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(ulong3 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToDouble3(Xse.mm256_cvtepu64_pd(input, 3));
            }
            else
            {
                return new double3((double2)input._xy, (double)input.z);
            }
        }


        public ulong this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 3);

                if (Avx2.IsAvx2Supported)
                {
                    return Xse.mm256_extract_epi64(this, (byte)index);
                }
                else if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(index))
                    {
                        if (index < 2)
                        {
                            return Xse.extract_epi64(_xy, (byte)index);
                        }
                        else
                        {
                            return z;
                        }
                    }
                }
                
                return this.GetField<ulong3, ulong>(index);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 3);

                if (Avx2.IsAvx2Supported)
                {
                    this = Xse.mm256_insert_epi64(this, value, (byte)index);

                    return;
                }
                else if (Architecture.IsSIMDSupported)
                {
                    if (constexpr.IS_CONST(index))
                    {
                        if (index < 2)
                        {
                            _xy = Xse.insert_epi64(_xy, value, (byte)index);
                        }
                        else
                        {
                            z = value;
                        }

                        return;
                    }
                }
                
                this.SetField(value, index);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator + (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi64(left, right);
            }
            else
            {
                return new ulong3(left._xy + right._xy, left.z + right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator - (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi64(left, right);
            }
            else
            {
                return new ulong3(left._xy - right._xy, left.z - right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, right, 3);
            }
            else
            {
                return new ulong3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, uint3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (ulong3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (uint3 left, ulong3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, ushort3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (ulong3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ushort3 left, ulong3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, byte3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_mullo_epi64(left, (ulong3)right, 3, unsigned_B_lessequalU32Max: true);
            }
            else
            {
                return new ulong3(left.xy * right.xy, left.z * right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (byte3 left, ulong3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_div_epu64(left, right, elements: 3);
            }
            else
            {
                return new ulong3(left.xy / right.xy, left.z / right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rem_epu64(left, right, elements: 3);
            }
            else
            {
                return new ulong3(left.xy % right.xy, left.z % right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong left, ulong3 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator * (ulong3 left, ulong right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return (v256)((ulong4)((v256)left) * right);
                }
                else
                {
                    return new ulong3(left.x * right, left.y * right, left.z * right);
                }
            }
            else
            {
                return new ulong3(left._xy * right, left.z * right);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator / (ulong3 left, ulong right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_constdiv_epu64(left, right, 3);
                    }
                    else
                    {
                        return new ulong3(Xse.constdiv_epu64(left.xy, right), left.z / right);
                    }
                }
            }

            return left / (ulong3)right;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator % (ulong3 left, ulong right)
        {
            if (Architecture.IsSIMDSupported)
            {
                if (constexpr.IS_CONST(right))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_constrem_epu64(left, right, 3);
                    }
                    else
                    {
                        return new ulong3(Xse.constrem_epu64(left.xy, right), left.z % right);
                    }
                }
            }

            return left % (ulong3)right;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator & (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_and_si256(left, right);
            }
            else
            {
                return new ulong3(left._xy & right._xy, left.z & right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator | (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_or_si256(left, right);
            }
            else
            {
                return new ulong3(left._xy | right._xy, left.z | right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ^ (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_xor_si256(left, right);
            }
            else
            {
                return new ulong3(left._xy ^ right._xy, left.z ^ right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ++ (ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_epi64(x);
            }
            else
            {
                return new ulong3(x._xy + 1, x.z + 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator -- (ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_epi64(x);
            }
            else
            {
                return new ulong3(x._xy - 1, x.z - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator ~ (ulong3 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_not_si256(x);
            }
            else
            {
                return new ulong3(~x._xy, ~x.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator << (ulong3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_slli_epi64(x, n);
            }
            else
            {
                return new ulong3(x._xy << n, x.z << n);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 operator >> (ulong3 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srli_epi64(x, n);
            }
            else
            {
                return new ulong3(x._xy >> n, x.z >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator == (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Avx2.mm256_cmpeq_epi64(left, right)));
            }
            else
            {
                return new bool3(left._xy == right._xy, left.z == right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator < (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmplt_epu64(left, right, 3)));
            }
            else
            {
                return new bool3(left._xy < right._xy, left.z < right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator > (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsTrue64(Xse.mm256_cmpgt_epu64(left, right)));
            }
            else
            {
                return new bool3(left._xy > right._xy, left.z > right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator != (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Avx2.mm256_cmpeq_epi64(left, right)));
            }
            else
            {
                return new bool3(left._xy != right._xy, left.z != right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator <= (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Xse.mm256_cmpgt_epu64(left, right)));
            }
            else
            {
                return new bool3(left._xy <= right._xy, left.z <= right.z);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool3 operator >= (ulong3 left, ulong3 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToBool3(RegisterConversion.IsFalse64(Xse.mm256_cmplt_epu64(left, right, 3)));
            }
            else
            {
                return new bool3(left._xy >= right._xy, left.z >= right.z);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(ulong3 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<ulong>(Avx2.mm256_cmpeq_epi64(this, other), 3);
            }
            else
            {
                return this._xy.Equals(other._xy) & this.z == other.z;
            }
        }

        public override readonly bool Equals(object obj) => obj is ulong3 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode()
        {
            if (Avx2.IsAvx2Supported)
            {
                return Hash.v192(this);
            }
            else if (Architecture.IsSIMDSupported)
            {
                return Hash.v128(_xy ^ new ulong2(z));
            }
            else
            {
                return ((x ^ z) ^ (y ^ z)).GetHashCode();
            }
        }


        public override readonly string ToString() => $"ulong3({x}, {y}, {z})";
        public readonly string ToString(string format, IFormatProvider formatProvider) => $"ulong3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
    }
}