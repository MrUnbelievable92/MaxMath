using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using DevTools;

namespace MaxMath
{
    unsafe public static class VectorAssert
    {
    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNonNegative<TVec, TScalar>(TVec vector, byte elements, NumericDataType dataType)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                if (dataType == NumericDataType.Integer)
                {
                    long final;
                    switch (sizeof(TScalar))
                    {
                        case 1: final = ((sbyte*)&vector)[i]; break;
                        case 2: final = ((short*)&vector)[i]; break;
                        case 4: final = ((int*)&vector)[i];   break;
                        case 8: final = ((long*)&vector)[i];  break;

                        default: throw Assert.Unreachable();
                    }

                    Assert.IsNonNegative(final);
                }
                else
                {
                    double final;
                    switch (sizeof(TScalar))
                    {
                        case 1: final = ((quarter*)&vector)[i]; break;
                        case 2: final = ((half*)&vector)[i];    break;
                        case 4: final = ((float*)&vector)[i];   break;
                        case 8: final = ((double*)&vector)[i];  break;

                        default: throw Assert.Unreachable();
                    }

                    Assert.IsNonNegative(final);
                }
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AreEqual<TVec, TScalar>(TVec vector, TScalar value, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.AreEqual(((TScalar*)&vector)[i], value);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AreNotEqual<TVec, TScalar>(TVec vector, TScalar value, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.AreNotEqual(((TScalar*)&vector)[i], value);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsGreater<TVec, TScalar>(TVec vector, TScalar value, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsGreater(((TScalar*)&vector)[i], value);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotGreater<TVec, TScalar>(TVec vector, TScalar value, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsNotGreater(((TScalar*)&vector)[i], value);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsSmaller<TVec, TScalar>(TVec vector, TScalar value, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsSmaller(((TScalar*)&vector)[i], value);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotSmaller<TVec, TScalar>(TVec vector, TScalar value, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsNotSmaller(((TScalar*)&vector)[i], value);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsBetween<TVec, TScalar>(TVec vector, TScalar min, TScalar max, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsBetween(((TScalar*)&vector)[i], min, max);
            }
#endif
        }


    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AreEqual<TVec, TScalar>(TVec x, TVec y, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.AreEqual(((TScalar*)&x)[i], ((TScalar*)&y)[i]);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AreNotEqual<TVec, TScalar>(TVec x, TVec y, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.AreNotEqual(((TScalar*)&x)[i], ((TScalar*)&y)[i]);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsGreater<TVec, TScalar>(TVec x, TVec y, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsGreater(((TScalar*)&x)[i], ((TScalar*)&y)[i]);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotGreater<TVec, TScalar>(TVec x, TVec y, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsNotGreater(((TScalar*)&x)[i], ((TScalar*)&y)[i]);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsSmaller<TVec, TScalar>(TVec x, TVec y, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsSmaller(((TScalar*)&x)[i], ((TScalar*)&y)[i]);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotSmaller<TVec, TScalar>(TVec x, TVec y, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsNotSmaller(((TScalar*)&x)[i], ((TScalar*)&y)[i]);
            }
#endif
        }

    	[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsBetween<TVec, TScalar>(TVec vector, TVec min, TVec max, byte elements)
            where TVec : unmanaged
            where TScalar : unmanaged, IEquatable<TScalar>, IComparable<TScalar>
        {
#if DEBUG
            for (int i = 0; i < elements; i++)
            {
                Assert.IsBetween(((TScalar*)&vector)[i], ((TScalar*)&min)[i], ((TScalar*)&max)[i]);
            }
#endif
        }
    }
}
