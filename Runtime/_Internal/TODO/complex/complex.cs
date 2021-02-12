using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Burst.Intrinsics;

namespace MaxMath
{
    [StructLayout(LayoutKind.Sequential, Size = 8)]
    unsafe internal struct complex //: IComparable, IComparable<complex>, IConvertible, IEquatable<complex>, IFormattable
    { 
        [NoAlias] public float real;
        [NoAlias] public float imaginary;


        public bool IsReal
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return maxmath.approx(imaginary, 0f);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                imaginary = math.select(imaginary, 0f, value);
            }
        }

        public bool IsPurelyImaginary
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return maxmath.approx(real, 0f);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                real = math.select(real, 0f, value);
            }
        }


        public override readonly string ToString()
        {
            return $"{ math.abs(real) } + { math.abs(imaginary) }i";
        }
    }
}