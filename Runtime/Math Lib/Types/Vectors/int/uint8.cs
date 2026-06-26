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
    internal sealed class uint8DebuggerProxy
    {
        public uint x0;
        public uint x1;
        public uint x2;
        public uint x3;
        public uint x4;
        public uint x5;
        public uint x6;
        public uint x7;
        
        public uint8DebuggerProxy(uint8 v)
        {
            x0 = v.x0;
            x1 = v.x1;
            x2 = v.x2;
            x3 = v.x3;
            x4 = v.x4;
            x5 = v.x5;
            x6 = v.x6;
            x7 = v.x7;
        }
    }

    [System.Diagnostics.DebuggerTypeProxy(typeof(uint8DebuggerProxy))]
#endif
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    unsafe public struct uint8 : IEquatable<uint8>, IFormattable
    {
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal uint4 __x0;
#if UNITY_EDITOR
        [UnityEngine.SerializeField]
#endif
        internal uint4 __x4;
        
        public ref uint x0 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint8* ptr = &this) { return ref *((uint*)ptr + 0); } } }
        public ref uint x1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint8* ptr = &this) { return ref *((uint*)ptr + 1); } } }
        public ref uint x2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint8* ptr = &this) { return ref *((uint*)ptr + 2); } } }
        public ref uint x3 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint8* ptr = &this) { return ref *((uint*)ptr + 3); } } }
        public ref uint x4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint8* ptr = &this) { return ref *((uint*)ptr + 4); } } }
        public ref uint x5 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint8* ptr = &this) { return ref *((uint*)ptr + 5); } } }
        public ref uint x6 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint8* ptr = &this) { return ref *((uint*)ptr + 6); } } }
        public ref uint x7 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { fixed(uint8* ptr = &this) { return ref *((uint*)ptr + 7); } } }


        public static uint8 zero => default;

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint x0, uint x1, uint x2, uint x3, uint x4, uint x5, uint x6, uint x7)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_epi32((int)x7, (int)x6, (int)x5, (int)x4, (int)x3, (int)x2, (int)x1, (int)x0);
            }
            else
            {
                this = new uint8
                {
                    __x0 = new uint4(x0, x1, x2, x3),
                    __x4 = new uint4(x4, x5, x6, x7),
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint x0x8)
        {
            if (Avx.IsAvxSupported)
            {
                this = Xse.mm256_set1_epi32((int)x0x8);
            }
            else
            {
                this = new uint8
                {
                    __x0 = new uint4(x0x8),
                    __x4 = new uint4(x0x8),
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint2 x23, uint2 x45, uint2 x67)
        {
            this = new uint8(new uint4(x01, x23), new uint4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint3 x234, uint3 x567)
        {
            if (Avx2.IsAvx2Supported)
            {
                this = Join.mm256_v2v3v3_epi32(x01, x234, x567);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Join.v2v3v3_epi32(x01, x234, x567, out v128 lo, out v128 hi);

                this = new uint8(lo, hi);
            }
            else
            {
                this = new uint8
                {
                    __x0 = new uint4(x01, x234.xy),
                    __x4 = new uint4(x234.z, x567)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint3 x012, uint2 x34, uint3 x567)
        {
            if (Avx2.IsAvx2Supported)
            {
                this = Join.mm256_v3v2v3_epi32(x012, x34, x567);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Join.v3v2v3_epi32(x012, x34, x567, out v128 lo, out v128 hi);

                this = new uint8(lo, hi);
            }
            else
            {
                this = new uint8
                {
                    __x0 = new uint4(x012, x34.x),
                    __x4 = new uint4(x34.y, x567)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint3 x012, uint3 x345, uint2 x67)
        {
            if (Avx2.IsAvx2Supported)
            {
                this = Join.mm256_v3v3v2_epi32(x012, x345, x67);
            }
            else if (BurstArchitecture.IsSIMDSupported)
            {
                Join.v3v3v2_epi32(x012, x345, x67, out v128 lo, out v128 hi);

                this = new uint8(lo, hi);
            }
            else
            {
                this = new uint8
                {
                    __x0 = new uint4(x012, x345.x),
                    __x4 = new uint4(x345.yz, x67)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint4 x0123, uint2 x45, uint2 x67)
        {
            this = new uint8(x0123, new uint4(x45, x67));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint4 x2345, uint2 x67)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                Join.v2v4v2_epi32(x01, x2345, x67, out v128 lo, out v128 hi);

                this = new uint8(lo, hi);
            }
            else
            {
                this = new uint8
                {
                    __x0 = new uint4(x01, x2345.xy),
                    __x4 = new uint4(x2345.zw, x67)
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint2 x01, uint2 x23, uint4 x4567)
        {
            this = new uint8(new uint4(x01, x23), x4567);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint4 x0123, uint4 x4567)
        {
            if (Avx.IsAvxSupported)
            {
                this = Avx.mm256_set_m128i(x4567, x0123);
            }
            else
            {
                this = new uint8
                {
                    __x0 = x0123,
                    __x4 = x4567
                };
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(bool v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(bool8 v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(mask8x8 v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(mask16x8 v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(mask32x8 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(byte v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(byte8 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(sbyte v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(sbyte8 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(ushort v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(ushort8 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(short v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(short8 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(int v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(int8 v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(uint8 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(ulong v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(long v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(UInt128 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(Int128 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(quarter v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(quarter8 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(half v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(half8 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(float v)
        {
            this = (uint8)v;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(float8 v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(double v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(quadruple v)
        {
            this = (uint8)v;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint8(Unity.Mathematics.half v)
        {
            this = (uint8)v;
        }


        #region Shuffle
#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint4 v4_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castsi256_si128(this);
                }
                else
                {
                    return __x0;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(value), 0b0000_1111);
                }
                else
                {
                    this.__x0 = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint4 v4_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 1 * sizeof(uint));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    uint4 lo = this.__x0;
                    uint4 hi = this.__x4;

                    return Xse.alignr_epi8(lo, hi, 1 * sizeof(uint));
                }
                else
                {
                    return shuffle(__x0, __x4, ShuffleComponent.LeftY,
                                               ShuffleComponent.LeftZ,
                                               ShuffleComponent.LeftW,
                                               ShuffleComponent.RightX);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(value), 1), 0b0001_1110);
                }
                else
                {
                    this.__x0 = shuffle(__x0, value, ShuffleComponent.LeftX,
                                                     ShuffleComponent.RightX,
                                                     ShuffleComponent.RightY,
                                                     ShuffleComponent.RightZ);

                    this.__x4 = shuffle(__x4, value, ShuffleComponent.RightW,
                                                     ShuffleComponent.LeftY,
                                                     ShuffleComponent.LeftZ,
                                                     ShuffleComponent.LeftW);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint4 v4_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    uint4 lo = this.__x0;
                    uint4 hi = this.__x4;

                    return Xse.alignr_epi8(lo, hi, 2 * sizeof(uint));
                }
                else
                {
                    return shuffle(__x0, __x4, ShuffleComponent.LeftZ,
                                               ShuffleComponent.LeftW,
                                               ShuffleComponent.RightX,
                                               ShuffleComponent.RightY);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(value), Sse.SHUFFLE(0, 1, 0, 0)), 0b0011_1100);
                }
                else
                {
                    this.__x0 = shuffle(__x0, value, ShuffleComponent.LeftX,
                                                     ShuffleComponent.LeftY,
                                                     ShuffleComponent.RightX,
                                                     ShuffleComponent.RightY);

                    this.__x4 = shuffle(__x4, value, ShuffleComponent.RightZ,
                                                     ShuffleComponent.RightW,
                                                     ShuffleComponent.LeftZ,
                                                     ShuffleComponent.LeftW);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint4 v4_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(uint));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    uint4 lo = this.__x0;
                    uint4 hi = this.__x4;

                    return Xse.alignr_epi8(lo, hi, 3 * sizeof(uint));
                }
                else
                {
                    return shuffle(__x0, __x4, ShuffleComponent.LeftW,
                                               ShuffleComponent.RightX,
                                               ShuffleComponent.RightY,
                                               ShuffleComponent.RightZ);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(value), 3), 0b0111_1000);
                }
                else
                {
                    this.__x0 = shuffle(__x0, value, ShuffleComponent.LeftX,
                                                     ShuffleComponent.LeftY,
                                                     ShuffleComponent.LeftZ,
                                                     ShuffleComponent.RightX);

                    this.__x4 = shuffle(__x4, value, ShuffleComponent.RightY,
                                                     ShuffleComponent.RightZ,
                                                     ShuffleComponent.RightW,
                                                     ShuffleComponent.LeftW);
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint4 v4_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return __x4;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_inserti128_si256(this, value, 1);
                }
                else
                {
                    this.__x4 = value;
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 v3_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castsi256_si128(this);
                }
                else
                {
                    return __x0.xyz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(value), 0b0000_0111);
                }
                else
                {
                    this.__x0.xyz = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 v3_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(uint));
                }
                else
                {
                    return __x0.yzw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Xse.shuffle_epi32(value, Sse.SHUFFLE(2, 1, 0, 0))), 0b0000_1110);
                }
                else
                {
                    this.__x0.yzw = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 v3_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 2, 1)));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    uint4 lo = this.__x0;
                    uint4 hi = this.__x4;

                    return Xse.alignr_epi8(lo, hi, 2 * sizeof(uint));
                }
                else
                {
                    return new uint3(__x0.zw, __x4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(value), Sse.SHUFFLE(0, 1, 0, 0)), 0b0001_1100);
                }
                else
                {
                    this.__x0.zw = value.xy;
                    this.__x4.x  = value.z;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 v3_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(uint));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    uint4 lo = this.__x0;
                    uint4 hi = this.__x4;

                    return Xse.alignr_epi8(lo, hi, 3 * sizeof(uint));
                }
                else
                {
                    return new uint3(__x0.w, __x4.xy);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(value), 3), 0b0011_1000);
                }
                else
                {
                    this.__x0.w  = value.x;
                    this.__x4.xy = value.yz;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 v3_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return __x4.xyz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx2.mm256_permute4x64_epi64(Avx.mm256_castsi128_si256(value), Sse.SHUFFLE(1, 0, 0, 0)), 0b0111_0000);
                }
                else
                {
                    this.__x4.xyz = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint3 v3_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 1 * sizeof(uint));
                }
                else
                {
                    return __x4.yzw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(value), 5), 0b1110_0000);
                }
                else
                {
                    this.__x4.yzw = value;
                }
            }
        }


#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 v2_0
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Avx.mm256_castsi256_si128(this);
                }
                else
                {
                    return __x0.xy;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 0);
                }
                else
                {
                    this.__x0.xy = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 v2_1
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.bsrli_si128(Avx.mm256_castsi256_si128(this), sizeof(uint));
                }
                else
                {
                    return __x0.yz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, Avx.mm256_castsi128_si256(Xse.shuffle_epi32(value, Sse.SHUFFLE(0, 1, 0, 0))), 0b0000_0110);
                }
                else
                {
                    this.__x0.yz = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 v2_2
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx.IsAvxSupported)
                {
                    return Xse.bsrli_si128(Avx.mm256_castsi256_si128(this), 2 * sizeof(uint));
                }
                else
                {
                    return __x0.zw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 1);
                }
                else
                {
                    this.__x0.zw = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 v2_3
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.alignr_epi8(Avx.mm256_castsi256_si128(this), Avx2.mm256_extracti128_si256(this, 1), 3 * sizeof(uint));
                }
                else if (BurstArchitecture.IsTableLookupSupported)
                {
                    uint4 lo = this.__x0;
                    uint4 hi = this.__x4;

                    return Xse.alignr_epi8(lo, hi, 3 * sizeof(uint));
                }
                else
                {
                    return new uint2(__x0.w, __x4.x);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(value), 3), 0b0001_1000);
                }
                else
                {
                    this.__x0.w = value.x;
                    this.__x4.x = value.y;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 v2_4
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx2.mm256_extracti128_si256(this, 1);
                }
                else
                {
                    return __x4.xy;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 2);
                }
                else
                {
                    this.__x4.xy = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 v2_5
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Xse.bsrli_si128(Avx2.mm256_extracti128_si256(this, 1), 1 * sizeof(uint));
                }
                else
                {
                    return __x4.yz;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx2.IsAvx2Supported)
                {
                    this = Avx2.mm256_blend_epi32(this, vrol((uint8)Avx.mm256_castsi128_si256(value), 5), 0b0110_0000);
                }
                else
                {
                    this.__x4.yz = value;
                }
            }
        }

#if DEBUG
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
#endif
        public uint2 v2_6
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
                if (Avx2.IsAvx2Supported)
                {
                    return Avx.mm256_castsi256_si128(Avx2.mm256_permute4x64_epi64(this, Sse.SHUFFLE(0, 0, 0, 3)));
                }
                else
                {
                    return __x4.zw;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (Avx.IsAvxSupported)
                {
                    this = Avx.mm256_insert_epi64(this, *(long*)&value, 3);
                }
                else
                {
                    this.__x4.zw = value;
                }
            }
        }
        #endregion

        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator v256(uint8 input)
        {
            return new v256(input.__x0, input.__x4);
        }
        
        [SkipLocalsInit]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(v256 input)
        {
            return new uint8{ __x0 = input.Lo128, __x4 = input.Hi128 };
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(bool x) => math.tobyte(x);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(bool8 x) => (uint8)(mask32x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(mask8x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (uint8)(mask32x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(mask16x8 x)
        {
            if (BurstArchitecture.IsSIMDSupported)
            {
                return (uint8)(mask32x8)x;
            }
            else
            {
                return *(byte8*)&x;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(mask32x8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_neg_epi32(x);
            }
            else
            {
                return new uint8((uint4)x.v4_0, (uint4)x.v4_4);
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator bool8(uint8 x) => (mask32x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask8x8(uint8 x) => (mask32x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask16x8(uint8 x) => (mask32x8)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator mask32x8(uint8 x) => x != 0;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint8(byte x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(sbyte x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static /*implicit*/ explicit operator uint8(ushort x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(short x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(int x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(ulong x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(long x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(UInt128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(Int128 x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(quarter x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(half x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(float x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(double x) => (uint)x;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(quadruple x) => (uint)x;
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(Unity.Mathematics.half x) => (uint8)(half)x;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint8(uint input) => new uint8(input);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(int8 input) => *(uint8*)&input;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(half8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttph_epu32(input);
            }
            else
            {
                return new uint8((uint4)input.v4_0, (uint4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint8(float8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvttps_epu32(input);
            }
            else
            {
                return new uint8((uint4)input.__x0, (uint4)input.__x4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator half8(uint8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu32_ph(input, (half)float.PositiveInfinity);
            }
            else
            {
                return new half8((half4)input.v4_0, (half4)input.v4_4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float8(uint8 input)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cvtepu32_ps(input);
            }
            else
            {
                return new float8((float4)input.__x0, (float4)input.__x4);
            }
        }

        public uint this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
Assert.IsWithinArrayBounds(index, 8);

                if (constexpr.IS_CONST(index))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        return Xse.mm256_extract_epi32(this, (byte)index);
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (index < 4)
                        {
                            return Xse.extract_epi32(__x0, (byte)index);
                        }
                        else
                        {
                            return Xse.extract_epi32(__x4, (byte)(index - 4));
                        }
                    }
                }

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (uint8* ptr = &this)
                    {
                        return ((uint*)ptr)[index];
                    }
                }
                else
                {
                    return this.GetField<uint8, uint>(index);
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
Assert.IsWithinArrayBounds(index, 8);

                if (constexpr.IS_CONST(index))
                {
                    if (Avx2.IsAvx2Supported)
                    {
                        this = Xse.mm256_insert_epi32(this, value, (byte)index);

                        return;
                    }
                    else if (BurstArchitecture.IsSIMDSupported)
                    {
                        if (index < 4)
                        {
                            __x0 = Xse.insert_epi32(__x0, value, (byte)index);
                        }
                        else
                        {
                            __x4 = Xse.insert_epi32(__x4, value, (byte)(index - 4));
                        }

                        return;
                    }
                }

                if (BurstArchitecture.IsBurstCompiled)
                {
                    fixed (uint8* ptr = &this)
                    {
                        ((uint*)ptr)[index] = value;
                    }
                }
                else
                {
                    this.SetField(value, index);
                }
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator + (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_add_epi32(left, right);
            }
            else
            {
                return new uint8(left.__x0 + right.__x0, left.__x4 + right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator - (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_sub_epi32(left, right);
            }
            else
            {
                return new uint8(left.__x0 - right.__x0, left.__x4 - right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator * (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_mullo_epi32(left, right);
            }
            else
            {
                return new uint8(left.__x0 * right.__x0, left.__x4 * right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator / (uint8 left, uint8 right)
        {
VectorAssert.AreNotEqual<uint8, uint>(right, 0, 8);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_div_epu32(left, right);
            }
            else
            {
                return new uint8(left.__x0 / right.__x0, left.__x4 / right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator % (uint8 left, uint8 right)
        {
VectorAssert.AreNotEqual<uint8, uint>(right, 0, 8);

            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rem_epu32(left, right);
            }
            else
            {
                return new uint8(left.__x0 % right.__x0, left.__x4 % right.__x4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator * (uint left, uint8 right) => right * left;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator * (uint8 left, uint right)
        {
            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return new uint8((left.x0 * right), (left.x1 * right), (left.x2 * right), (left.x3 * right), (left.x4 * right), (left.x5 * right), (left.x6 * right), (left.x7 * right));
                }
            }

            return new uint8(left.v4_0 * right, left.v4_4 * right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator / (uint8 left, uint right)
        {
Assert.AreNotEqual(right, 0u);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constdiv_epu32(left, right);
                }
            }

            return new uint8(left.v4_0 / right, left.v4_4 / right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator % (uint8 left, uint right)
        {
Assert.AreNotEqual(right, 0u);

            if (Avx2.IsAvx2Supported)
            {
                if (constexpr.IS_CONST(right))
                {
                    return Xse.mm256_constrem_epu32(left, right);
                }
            }

            return new uint8(left.v4_0 % right, left.v4_4 % right);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator & (uint8 left, uint8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_and_ps(left, right);
            }
            else
            {
                return new uint8(left.__x0 & right.__x0, left.__x4 & right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator | (uint8 left, uint8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_or_ps(left, right);
            }
            else
            {
                return new uint8(left.__x0 | right.__x0, left.__x4 | right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator ^ (uint8 left, uint8 right)
        {
            if (Avx.IsAvxSupported)
            {
                return Avx.mm256_xor_ps(left, right);
            }
            else
            {
                return new uint8(left.__x0 ^ right.__x0, left.__x4 ^ right.__x4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator ++ (uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_inc_epi32(x);
            }
            else
            {
                return new uint8(x.__x0 + 1, x.__x4 + 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator -- (uint8 x)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_dec_epi32(x);
            }
            else
            {
                return new uint8(x.__x0 - 1, x.__x4 - 1);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator ~ (uint8 x)
        {
            if (Avx.IsAvxSupported)
            {
                return Xse.mm256_not_si256(x);
            }
            else
            {
                return new uint8(~x.__x0, ~x.__x4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator << (uint8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_slli_epi32(x, n);
            }
            else
            {
                return new uint8(x.__x0 << n, x.__x4 << n);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 operator >> (uint8 x, int n)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_srli_epi32(x, n);
            }
            else
            {
                return new uint8(x.__x0 >> n, x.__x4 >> n);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator == (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Avx2.mm256_cmpeq_epi32(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 == right.__x0, left.__x4 == right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator < (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmplt_epu32(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 < right.__x0, left.__x4 < right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator > (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmpgt_epu32(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 > right.__x0, left.__x4 > right.__x4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator != (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_not_si256(Avx2.mm256_cmpeq_epi32(left, right));
            }
            else
            {
                return new mask32x8(left.__x0 != right.__x0, left.__x4 != right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator <= (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmple_epu32(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 <= right.__x0, left.__x4 <= right.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static mask32x8 operator >= (uint8 left, uint8 right)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_cmpge_epu32(left, right);
            }
            else
            {
                return new mask32x8(left.__x0 >= right.__x0, left.__x4 >= right.__x4);
            }
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly bool Equals(uint8 other)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_alltrue_epi256<uint>(Avx2.mm256_cmpeq_epi32(this, other));
            }
            else
            {
                return this.__x0.Equals(other.__x0) & this.__x4.Equals(other.__x4);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly bool Equals(object obj) => obj is uint8 converted && this.Equals(converted);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override readonly int GetHashCode() => (int)math.hash(this);


        public override string ToString() => $"uint8({x0}, {x1}, {x2}, {x3},    {x4}, {x5}, {x6}, {x7})";
        public string ToString(string format, IFormatProvider formatProvider) => $"uint8({x0.ToString(format, formatProvider)}, {x1.ToString(format, formatProvider)}, {x2.ToString(format, formatProvider)}, {x3.ToString(format, formatProvider)},    {x4.ToString(format, formatProvider)}, {x5.ToString(format, formatProvider)}, {x6.ToString(format, formatProvider)}, {x7.ToString(format, formatProvider)})";
    }
}