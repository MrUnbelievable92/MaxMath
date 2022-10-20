using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using MaxMath.Intrinsics;

using static Unity.Burst.Intrinsics.X86;


namespace MaxMath
{
    namespace Intrinsics
    {
        unsafe public static partial class Xse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rorv_epi8(v128 a, v128 b, bool promise = false, byte elements = 16)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        v128 a32 = Sse4_1.cvtepu8_epi32(a);
                        v128 b32 = Sse4_1.cvtepu8_epi32(b);
    
                        if (!promise)
                        {
                            b32 = Sse2.and_si128(b32, Sse2.set1_epi32(7));
                        }
    
                        v128 inv = Sse2.and_si128(neg_epi32(b32), Sse2.set1_epi32(7));
    
                        return Xse.cvtepi32_epi8(Sse2.or_si128(Avx2.srlv_epi32(a32, b32), Avx2.sllv_epi32(a32, inv)));
                    }
                    else if (elements <= 8)
                    {
                        v256 a32 = Avx2.mm256_cvtepu8_epi32(a);
                        v256 b32 = Avx2.mm256_cvtepu8_epi32(b);
                        
                        if (!promise)
                        {
                            b32 = Avx2.mm256_and_si256(b32, Avx.mm256_set1_epi32(7));
                        }
                        
                        v256 inv = Avx2.mm256_and_si256(mm256_neg_epi32(b32), Avx.mm256_set1_epi32(7));
    
                        return Xse.mm256_cvtepi32_epi8(Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a32, b32), Avx2.mm256_sllv_epi32(a32, inv)));
                    }
                }
                
                if (Sse2.IsSse2Supported)
                {
                    if (!promise)
                    {
                        b = Sse2.and_si128(b, Sse2.set1_epi8(7));
                    }
                    
                    v128 inv = Sse2.and_si128(neg_epi8(b), Sse2.set1_epi8(7));
    
                    return Sse2.or_si128(srlv_epi8(a, b, elements), sllv_epi8(a, inv, elements));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rorv_epi8(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, Avx.mm256_set1_epi8(7));
                    }
                    
                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi8(b), Avx.mm256_set1_epi8(7));
    
                    return Avx2.mm256_or_si256(mm256_srlv_epi8(a, b), mm256_sllv_epi8(a, inv));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rorv_epi16(v128 a, v128 b, bool promise = false, byte elements = 8)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        v128 a32 = Sse4_1.cvtepu16_epi32(a);
                        v128 b32 = Sse4_1.cvtepu16_epi32(b);
                        
                        if (!promise)
                        {
                            b32 = Sse2.and_si128(b32, Sse2.set1_epi32(15));
                        }
                        
                        v128 inv = Sse2.and_si128(neg_epi32(b32), Sse2.set1_epi32(15));
    
                        return Xse.cvtepi32_epi16(Sse2.or_si128(Avx2.srlv_epi32(a32, b32), Avx2.sllv_epi32(a32, inv)), elements);
                    }
                    else if (elements <= 8)
                    {
                        v256 a32 = Avx2.mm256_cvtepu16_epi32(a);
                        v256 b32 = Avx2.mm256_cvtepu16_epi32(b);
                        
                        if (!promise)
                        {
                            b32 = Avx2.mm256_and_si256(b32, Avx.mm256_set1_epi32(15));
                        }
                        
                        v256 inv = Avx2.mm256_and_si256(mm256_neg_epi32(b32), Avx.mm256_set1_epi32(15));
    
                        return Xse.mm256_cvtepi32_epi16(Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a32, b32), Avx2.mm256_sllv_epi32(a32, inv)));
                    }
                }
                
                if (Sse2.IsSse2Supported)
                {
                    if (!promise)
                    {
                        b = Sse2.and_si128(b, Sse2.set1_epi16(15));
                    }
                    
                    v128 inv = Sse2.and_si128(neg_epi16(b), Sse2.set1_epi16(15));
    
                    return Sse2.or_si128(srlv_epi16(a, b, elements), sllv_epi16(a, inv, elements));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rorv_epi16(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, Avx.mm256_set1_epi16(15));
                    }
                    
                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi16(b), Avx.mm256_set1_epi16(15));
    
                    return Avx2.mm256_or_si256(mm256_srlv_epi16(a, b), mm256_sllv_epi16(a, inv));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rorv_epi32(v128 a, v128 b, bool promise = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (!promise)
                    {
                        b = Sse2.and_si128(b, Sse2.set1_epi32(31));
                    }
                    
                    v128 inv = Sse2.and_si128(neg_epi32(b), Sse2.set1_epi32(31));
    
                    return Sse2.or_si128(srlv_epi32(a, b, elements), sllv_epi32(a, inv, elements));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rorv_epi32(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, Avx.mm256_set1_epi32(31));
                    }
                    
                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi32(b), Avx.mm256_set1_epi32(31));
    
                    return Avx2.mm256_or_si256(Avx2.mm256_srlv_epi32(a, b), Avx2.mm256_sllv_epi32(a, inv));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rorv_epi64(v128 a, v128 b, bool promise = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (!promise)
                    {
                        b = Sse2.and_si128(b, Sse2.set1_epi64x(63));
                    }
                    
                    v128 inv = Sse2.and_si128(neg_epi64(b), Sse2.set1_epi64x(63));
    
                    return Sse2.or_si128(srlv_epi64(a, b), sllv_epi64(a, inv));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rorv_epi64(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, Avx.mm256_set1_epi64x(63));
                    }
                    
                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi64(b), Avx.mm256_set1_epi64x(63));
    
                    return Avx2.mm256_or_si256(Avx2.mm256_srlv_epi64(a, b), Avx2.mm256_sllv_epi64(a, inv));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rolv_epi8(v128 a, v128 b, bool promise = false, byte elements = 16)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        v128 a32 = Sse4_1.cvtepu8_epi32(a);
                        v128 b32 = Sse4_1.cvtepu8_epi32(b);
                        
                        if (!promise)
                        {
                            b32 = Sse2.and_si128(b32, Sse2.set1_epi32(7));
                        }
                        
                        v128 inv = Sse2.and_si128(neg_epi32(b32), Sse2.set1_epi32(7));
    
                        return Xse.cvtepi32_epi8(Sse2.or_si128(Avx2.sllv_epi32(a32, b32), Avx2.srlv_epi32(a32, inv)));
                    }
                    else if (elements <= 8)
                    {
                        v256 a32 = Avx2.mm256_cvtepu8_epi32(a);
                        v256 b32 = Avx2.mm256_cvtepu8_epi32(b);
                        
                        if (!promise)
                        {
                            b32 = Avx2.mm256_and_si256(b32, Avx.mm256_set1_epi32(7));
                        }
                        
                        v256 inv = Avx2.mm256_and_si256(mm256_neg_epi32(b32), Avx.mm256_set1_epi32(7));
    
                        return Xse.mm256_cvtepi32_epi8(Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a32, b32), Avx2.mm256_srlv_epi32(a32, inv)));
                    }
                }
                
                if (Sse2.IsSse2Supported)
                {
                    if (!promise)
                    {
                        b = Sse2.and_si128(b, Sse2.set1_epi8(7));
                    }
                    
                    v128 inv = Sse2.and_si128(neg_epi8(b), Sse2.set1_epi8(7));
    
                    return Sse2.or_si128(sllv_epi8(a, b, elements), srlv_epi8(a, inv, elements));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rolv_epi8(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, Avx.mm256_set1_epi8(7));
                    }
                    
                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi8(b), Avx.mm256_set1_epi8(7));
    
                    return Avx2.mm256_or_si256(mm256_sllv_epi8(a, b), mm256_srlv_epi8(a, inv));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rolv_epi16(v128 a, v128 b, bool promise = false, byte elements = 8)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (elements <= 4)
                    {
                        v128 a32 = Sse4_1.cvtepu16_epi32(a);
                        v128 b32 = Sse4_1.cvtepu16_epi32(b);
                        
                        if (!promise)
                        {
                            b32 = Sse2.and_si128(b32, Sse2.set1_epi32(15));
                        }
                        
                        v128 inv = Sse2.and_si128(neg_epi32(b32), Sse2.set1_epi32(15));
    
                        return Xse.cvtepi32_epi16(Sse2.or_si128(Avx2.sllv_epi32(a32, b32), Avx2.srlv_epi32(a32, inv)), elements);
                    }
                    else if (elements <= 8)
                    {
                        v256 a32 = Avx2.mm256_cvtepu16_epi32(a);
                        v256 b32 = Avx2.mm256_cvtepu16_epi32(b);
    
                        b32 = Avx2.mm256_and_si256(b32, Avx.mm256_set1_epi32(15));
                        v256 inv = Avx2.mm256_and_si256(mm256_neg_epi32(b32), Avx.mm256_set1_epi32(15));
    
                        return Xse.mm256_cvtepi32_epi16(Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a32, b32), Avx2.mm256_srlv_epi32(a32, inv)));
                    }
                }
                
                if (Sse2.IsSse2Supported)
                {
                    if (!promise)
                    {
                        b = Sse2.and_si128(b, Sse2.set1_epi16(15));
                    }
                    
                    v128 inv = Sse2.and_si128(neg_epi16(b), Sse2.set1_epi16(15));
    
                    return Sse2.or_si128(sllv_epi16(a, b, elements), srlv_epi16(a, inv, elements));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rolv_epi16(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, Avx.mm256_set1_epi16(15));
                    }
                    
                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi16(b), Avx.mm256_set1_epi16(15));
    
                    return Avx2.mm256_or_si256(mm256_sllv_epi16(a, b), mm256_srlv_epi16(a, inv));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rolv_epi32(v128 a, v128 b, bool promise = false, byte elements = 4)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (!promise)
                    {
                        b = Sse2.and_si128(b, Sse2.set1_epi32(31));
                    }
                    
                    v128 inv = Sse2.and_si128(neg_epi32(b), Sse2.set1_epi32(31));
    
                    return Sse2.or_si128(sllv_epi32(a, b, elements), srlv_epi32(a, inv, elements));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rolv_epi32(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, Avx.mm256_set1_epi32(31));
                    }
                    
                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi32(b), Avx.mm256_set1_epi32(31));
    
                    return Avx2.mm256_or_si256(Avx2.mm256_sllv_epi32(a, b), Avx2.mm256_srlv_epi32(a, inv));
                }
                else throw new IllegalInstructionException();
            }
    
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v128 rolv_epi64(v128 a, v128 b, bool promise = false)
            {
                if (Sse2.IsSse2Supported)
                {
                    if (!promise)
                    {
                        b = Sse2.and_si128(b, Sse2.set1_epi64x(63));
                    }
                    
                    v128 inv = Sse2.and_si128(neg_epi64(b), Sse2.set1_epi64x(63));
    
                    return Sse2.or_si128(sllv_epi64(a, b), srlv_epi64(a, inv));
                }
                else throw new IllegalInstructionException();
            }
    
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static v256 mm256_rolv_epi64(v256 a, v256 b, bool promise = false)
            {
                if (Avx2.IsAvx2Supported)
                {
                    if (!promise)
                    {
                        b = Avx2.mm256_and_si256(b, Avx.mm256_set1_epi64x(63));
                    }
                    
                    v256 inv = Avx2.mm256_and_si256(mm256_neg_epi64(b), Avx.mm256_set1_epi64x(63));
    
                    return Avx2.mm256_or_si256(Avx2.mm256_sllv_epi64(a, b), Avx2.mm256_srlv_epi64(a, inv));
                }
                else throw new IllegalInstructionException();
            }
        }
    }


    unsafe public static partial class maxmath
    {
        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 ror(sbyte2 x, sbyte2 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new sbyte2(ror(x.x, n.x), ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 ror(sbyte3 x, sbyte3 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new sbyte3(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 ror(sbyte4 x, sbyte4 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new sbyte4(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z), ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 ror(sbyte8 x, sbyte8 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new sbyte8(ror(x.x0, n.x0), ror(x.x1, n.x1), ror(x.x2, n.x2), ror(x.x3, n.x3), ror(x.x4, n.x4), ror(x.x5, n.x5), ror(x.x6, n.x6), ror(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte16"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 ror(sbyte16 x, sbyte16 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 16);
            }
            else
            {
                return new sbyte16(ror(x.v8_0, n.v8_0), ror(x.v8_8, n.v8_8));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte32"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 ror(sbyte32 x, sbyte32 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi8(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte32(ror(x.v16_0, n.v16_0), ror(x.v16_16, n.v16_16));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 ror(byte2 x, byte2 n, Promise inRange = Promise.Nothing)
        {
            return (byte2)ror((sbyte2)x, (sbyte2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 ror(byte3 x, byte3 n, Promise inRange = Promise.Nothing)
        {
            return (byte3)ror((sbyte3)x, (sbyte3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 ror(byte4 x, byte4 n, Promise inRange = Promise.Nothing)
        {
            return (byte4)ror((sbyte4)x, (sbyte4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 ror(byte8 x, byte8 n, Promise inRange = Promise.Nothing)
        {
            return (byte8)ror((sbyte8)x, (sbyte8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte16"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 ror(byte16 x, byte16 n, Promise inRange = Promise.Nothing)
        {
            return (byte16)ror((sbyte16)x, (sbyte16)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte32"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 ror(byte32 x, byte32 n, Promise inRange = Promise.Nothing)
        {
            return (byte32)ror((sbyte32)x, (sbyte32)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 ror(short2 x, short2 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new short2(ror(x.x, n.x), ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 ror(short3 x, short3 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new short3(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 ror(short4 x, short4 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new short4(ror(x.x, n.x), ror(x.y, n.y), ror(x.z, n.z), ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 ror(short8 x, short8 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new short8(ror(x.x0, n.x0), ror(x.x1, n.x1), ror(x.x2, n.x2), ror(x.x3, n.x3), ror(x.x4, n.x4), ror(x.x5, n.x5), ror(x.x6, n.x6), ror(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short16"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 ror(short16 x, short16 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi16(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short16(ror(x.v8_0, n.v8_0), ror(x.v8_8, n.v8_8));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 ror(ushort2 x, ushort2 n, Promise inRange = Promise.Nothing)
        {
            return (ushort2)ror((short2)x, (short2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 ror(ushort3 x, ushort3 n, Promise inRange = Promise.Nothing)
        {
            return (ushort3)ror((short3)x, (short3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 ror(ushort4 x, ushort4 n, Promise inRange = Promise.Nothing)
        {
            return (ushort4)ror((short4)x, (short4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 ror(ushort8 x, ushort8 n, Promise inRange = Promise.Nothing)
        {
            return (ushort8)ror((short8)x, (short8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort16"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 ror(ushort16 x, ushort16 n, Promise inRange = Promise.Nothing)
        {
            return (ushort16)ror((short16)x, (short16)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ror(int2 x, int2 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToInt2(Xse.rorv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), inRange.Promises(Promise.NoOverflow), 2));
            }
            else
            {
                return new int2(math.ror(x.x, n.x), math.ror(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ror(int3 x, int3 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToInt3(Xse.rorv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), inRange.Promises(Promise.NoOverflow), 3));
            }
            else
            {
                return new int3(math.ror(x.x, n.x), math.ror(x.y, n.y), math.ror(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ror(int4 x, int4 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return RegisterConversion.ToInt4(Xse.rorv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), inRange.Promises(Promise.NoOverflow), 4));
            }
            else
            {
                return new int4(math.ror(x.x, n.x), math.ror(x.y, n.y), math.ror(x.z, n.z), math.ror(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.int8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 ror(int8 x, int8 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi32(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int8(math.ror(x.x0, n.x0), math.ror(x.x1, n.x1), math.ror(x.x2, n.x2), math.ror(x.x3, n.x3), math.ror(x.x4, n.x4), math.ror(x.x5, n.x5), math.ror(x.x6, n.x6), math.ror(x.x7, n.x7));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, uint2 n, Promise inRange = Promise.Nothing)
        {
            return (uint2)ror((int2)x, (int2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, uint3 n, Promise inRange = Promise.Nothing)
        {
            return (uint3)ror((int3)x, (int3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, uint4 n, Promise inRange = Promise.Nothing)
        {
            return (uint4)ror((int4)x, (int4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.uint8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, uint8 n, Promise inRange = Promise.Nothing)
        {
            return (uint8)ror((int8)x, (int8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ror(uint2 x, int2 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (uint2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ror(uint3 x, int3 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (uint3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ror(uint4 x, int4 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (uint4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.uint8"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 ror(uint8 x, int8 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (uint8)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.long2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 ror(long2 x, long2 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rorv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long2(math.ror(x.x, (int)n.x), math.ror(x.y, (int)n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.long3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 ror(long3 x, long3 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long3(math.ror(x.x, (int)n.x), math.ror(x.y, (int)n.y), math.ror(x.z, (int)n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.long4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 ror(long4 x, long4 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rorv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long4(math.ror(x.x, (int)n.x), math.ror(x.y, (int)n.y), math.ror(x.z, (int)n.z), math.ror(x.w, (int)n.w));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, ulong2 n, Promise inRange = Promise.Nothing)
        {
            return (ulong2)ror((long2)x, (long2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, ulong3 n, Promise inRange = Promise.Nothing)
        {
            return (ulong3)ror((long3)x, (long3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, ulong4 n, Promise inRange = Promise.Nothing)
        {
            return (ulong4)ror((long4)x, (long4)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong2"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 ror(ulong2 x, long2 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (ulong2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong3"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 ror(ulong3 x, long3 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (ulong3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong4"/> right by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 ror(ulong4 x, long4 n, Promise inRange = Promise.Nothing)
        {
            return ror(x, (ulong4)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte2 rol(sbyte2 x, sbyte2 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new sbyte2(rol(x.x, n.x), rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte3 rol(sbyte3 x, sbyte3 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new sbyte3(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte4 rol(sbyte4 x, sbyte4 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new sbyte4(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z), rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte8 rol(sbyte8 x, sbyte8 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new sbyte8(rol(x.x0, n.x0), rol(x.x1, n.x1), rol(x.x2, n.x2), rol(x.x3, n.x3), rol(x.x4, n.x4), rol(x.x5, n.x5), rol(x.x6, n.x6), rol(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte16"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte16 rol(sbyte16 x, sbyte16 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow), 16);
            }
            else
            {
                return new sbyte16(rol(x.v8_0, n.v8_0), rol(x.v8_8, n.v8_8));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.sbyte32"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte32 rol(sbyte32 x, sbyte32 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi8(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new sbyte32(rol(x.v8_0, n.v8_0), rol(x.v8_8, n.v8_8), rol(x.v8_16, n.v8_16), rol(x.v8_24, n.v8_24));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte2 rol(byte2 x, byte2 n, Promise inRange = Promise.Nothing)
        {
            return (byte2)rol((sbyte2)x, (sbyte2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte3 rol(byte3 x, byte3 n, Promise inRange = Promise.Nothing)
        {
            return (byte3)rol((sbyte3)x, (sbyte3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte4 rol(byte4 x, byte4 n, Promise inRange = Promise.Nothing)
        {
            return (byte4)rol((sbyte4)x, (sbyte4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte8 rol(byte8 x, byte8 n, Promise inRange = Promise.Nothing)
        {
            return (byte8)rol((sbyte8)x, (sbyte8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte16"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte16 rol(byte16 x, byte16 n, Promise inRange = Promise.Nothing)
        {
            return (byte16)rol((sbyte16)x, (sbyte16)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.byte32"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 7.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte32 rol(byte32 x, byte32 n, Promise inRange = Promise.Nothing)
        {
            return (byte32)rol((sbyte32)x, (sbyte32)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short2 rol(short2 x, short2 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 2);
            }
            else
            {
                return new short2(rol(x.x, n.x), rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short3 rol(short3 x, short3 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 3);
            }
            else
            {
                return new short3(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short4 rol(short4 x, short4 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 4);
            }
            else
            {
                return new short4(rol(x.x, n.x), rol(x.y, n.y), rol(x.z, n.z), rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short8 rol(short8 x, short8 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow), 8);
            }
            else
            {
                return new short8(rol(x.x0, n.x0), rol(x.x1, n.x1), rol(x.x2, n.x2), rol(x.x3, n.x3), rol(x.x4, n.x4), rol(x.x5, n.x5), rol(x.x6, n.x6), rol(x.x7, n.x7));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.short16"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static short16 rol(short16 x, short16 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi16(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new short16(rol(x.v8_0, n.v8_0), rol(x.v8_8, n.v8_8));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort2 rol(ushort2 x, ushort2 n, Promise inRange = Promise.Nothing)
        {
            return (ushort2)rol((short2)x, (short2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort3 rol(ushort3 x, ushort3 n, Promise inRange = Promise.Nothing)
        {
            return (ushort3)rol((short3)x, (short3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort4 rol(ushort4 x, ushort4 n, Promise inRange = Promise.Nothing)
        {
            return (ushort4)rol((short4)x, (short4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort8 rol(ushort8 x, ushort8 n, Promise inRange = Promise.Nothing)
        {
            return (ushort8)rol((short8)x, (short8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ushort16"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 15.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ushort16 rol(ushort16 x, ushort16 n, Promise inRange = Promise.Nothing)
        {
            return (ushort16)rol((short16)x, (short16)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 rol(int2 x, int2 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt2(Xse.rolv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), inRange.Promises(Promise.NoOverflow), 2));
            }
            else
            {
                return new int2(math.rol(x.x, n.x), math.rol(x.y, n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 rol(int3 x, int3 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt3(Xse.rolv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), inRange.Promises(Promise.NoOverflow), 3));
            }
            else
            {
                return new int3(math.rol(x.x, n.x), math.rol(x.y, n.y), math.rol(x.z, n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="int4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 rol(int4 x, int4 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return RegisterConversion.ToInt4(Xse.rolv_epi32(RegisterConversion.ToV128(x), RegisterConversion.ToV128(n), inRange.Promises(Promise.NoOverflow), 4));
            }
            else
            {
                return new int4(math.rol(x.x, n.x), math.rol(x.y, n.y), math.rol(x.z, n.z), math.rol(x.w, n.w));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of an <see cref="MaxMath.int8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int8 rol(int8 x, int8 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi32(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new int8(math.rol(x.x0, n.x0), math.rol(x.x1, n.x1), math.rol(x.x2, n.x2), math.rol(x.x3, n.x3), math.rol(x.x4, n.x4), math.rol(x.x5, n.x5), math.rol(x.x6, n.x6), math.rol(x.x7, n.x7));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 rol(uint2 x, uint2 n, Promise inRange = Promise.Nothing)
        {
            return (uint2)rol((int2)x, (int2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 rol(uint3 x, uint3 n, Promise inRange = Promise.Nothing)
        {
            return (uint3)rol((int3)x, (int3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 rol(uint4 x, uint4 n, Promise inRange = Promise.Nothing)
        {
            return (uint4)rol((int4)x, (int4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.uint8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, uint8 n, Promise inRange = Promise.Nothing)
        {
            return (uint8)rol((int8)x, (int8)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 rol(uint2 x, int2 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (uint2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 rol(uint3 x, int3 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (uint3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="uint4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 rol(uint4 x, int4 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (uint4)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.uint8"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 31.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint8 rol(uint8 x, int8 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (uint8)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.long2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long2 rol(long2 x, long2 n, Promise inRange = Promise.Nothing)
        {
            if (Sse2.IsSse2Supported)
            {
                return Xse.rolv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long2(math.rol(x.x, (int)n.x), math.rol(x.y, (int)n.y));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.long3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long3 rol(long3 x, long3 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long3(math.rol(x.x, (int)n.x), math.rol(x.y, (int)n.y), math.rol(x.z, (int)n.z));
            }
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.long4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long4 rol(long4 x, long4 n, Promise inRange = Promise.Nothing)
        {
            if (Avx2.IsAvx2Supported)
            {
                return Xse.mm256_rolv_epi64(x, n, inRange.Promises(Promise.NoOverflow));
            }
            else
            {
                return new long4(math.rol(x.x, (int)n.x), math.rol(x.y, (int)n.y), math.rol(x.z, (int)n.z), math.rol(x.w, (int)n.w));
            }
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, ulong2 n, Promise inRange = Promise.Nothing)
        {
            return (ulong2)rol((long2)x, (long2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, ulong3 n, Promise inRange = Promise.Nothing)
        {
            return (ulong3)rol((long3)x, (long3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, ulong4 n, Promise inRange = Promise.Nothing)
        {
            return (ulong4)rol((long4)x, (long4)n, inRange);
        }


        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong2"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong2 rol(ulong2 x, long2 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (ulong2)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong3"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong3 rol(ulong3 x, long3 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (ulong3)n, inRange);
        }

        /// <summary>       Returns the result of rotating the components' bits of a <see cref="MaxMath.ulong4"/> left by a number of bits specified in the corresponing component in <paramref name="n"/>.      </summary>
        /// <remarks>       A <see cref="Promise"/> '<paramref name="inRange"/>' with its <see cref="Promise.NoOverflow"/> flag set expects any <paramref name="n"/> value to be between 0 and 63.      </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ulong4 rol(ulong4 x, long4 n, Promise inRange = Promise.Nothing)
        {
            return rol(x, (ulong4)n, inRange);
        }
    }
}