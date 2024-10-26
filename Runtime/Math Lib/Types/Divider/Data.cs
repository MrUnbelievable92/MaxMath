//#define TESTING

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace MaxMath
{
    /// <summary>
    /// <para>  Performs fast integer division- and modulo operations as well as divisibility checks. </para>
    /// <para>  A <see cref="Divider{T}"/> initialized with a scalar value can perform operations on scalar values of the same exact type or a vector of integers of any size, provided it is a vector of integers of the same exact type. </para>
    /// <para>  A <see cref="Divider{T}"/> initialized with a vector can perform operations on scalar values of the same exact integer type or a vector of integers of the same size and same exact integer type. </para>
    /// <para>  For valid <see cref="Promise"/> arguments, please refer to: <see cref="PROMISE_NOT_MIN_VALUE"/>, <see cref="PROMISE_NOT_ONE"/>, <see cref="PROMISE_POW2"/>, <see cref="PROMISE_NOT_POW2"/>, <see cref="PROMISE_POSITIVE"/>, <see cref="PROMISE_NEGATIVE"/>, <see cref="PROMISE_SAME_VALUE"/>, <see cref="PROMISE_LZCNT_NOT_0"/></para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [DebuggerTypeProxy(typeof(Divider<>.DebuggerProxy))]
    unsafe public partial struct Divider<T> : IEquatable<T>, IEquatable<Divider<T>>, IFormattable
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        internal sealed class DebuggerProxy
        {
            public T Divisor;

            public DebuggerProxy(Divider<T> d)
            {
                Divisor = d.Divisor;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct BigM
        {
            internal T _mulLo;
            internal T _mulHi;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        internal struct MulShift
        {
            internal T _mul;
            internal T _shift;
        }


        internal T _divisor;
        internal BigM _bigM;
        internal MulShift _mulShift;
        internal DividerPromise _promises;
#if DEBUG
        internal TypeInfo _typeInfo;
#endif
        public readonly T Divisor => _divisor;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal Divider(T divisor, Promise promises, Signedness sign, byte elementSize)
        {
            this = Uninitialized<Divider<T>>.Create();
            _divisor = divisor;
            _promises = promises | new DividerPromise(divisor, sign, elementSize);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly bool DivideByScalar<U>()
            where U : unmanaged
        {
            return _promises.SameValue || sizeof(T) != sizeof(U);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal readonly void AssertOperationMatchesInitialization(int argumentSize, int argumentElements, int columnCount, Signedness argumentSign, NumericDataType argumentDatatype)
        {
#if DEBUG
            if  (_typeInfo._dataType     != argumentDatatype
             ||  _typeInfo._elementSize  != argumentSize
             || (_typeInfo._sign         != argumentSign     && argumentSign != Signedness.Undefined)
             || (_typeInfo._elementCount != argumentElements && (argumentElements != 1 && _typeInfo._elementCount != 1)))
            {
            #pragma warning disable IDE0071 // Burst compilation error (string interpolation of custom types)
                throw new InvalidOperationException($"Attempted to perform a '{ new TypeInfo((byte)argumentSize, (byte)argumentElements, (byte)columnCount, argumentSign, argumentDatatype).ToString() }' operation using a '{ nameof(Divider<T>) }' instance which was initialized for performing '{ _typeInfo.ToString() }' operations.");
            #pragma warning restore IDE0071
            }
#endif
        }

        public override readonly int GetHashCode()
        {
            return Divisor.GetHashCode();
        }

        public readonly bool Equals(Divider<T> other)
        {
            return this.Divisor.Equals(other.Divisor)
        #if TESTING
                && this._bigM._mulLo.Equals(other._bigM._mulLo)
                && this._bigM._mulHi.Equals(other._bigM._mulHi)
                && this._mulShift._mul.Equals(other._mulShift._mul)
                && this._mulShift._shift.Equals(other._mulShift._shift)
                && this._typeInfo.Equals(other._typeInfo)
                && ((Promise)this._promises).Equals((Promise)other._promises)
        #endif
            ;
        }
        public readonly bool Equals(T other)
        {
            return this.Divisor.Equals(other);
        }
        public override readonly bool Equals(object other)
        {
            return (other is T cvtDivisor          && Divisor.Equals(cvtDivisor))
                || (other is Divider<T> cvtDivider && this.Equals(cvtDivider));
        }

        public override readonly string ToString()
        {
            return ToString(null, null);
        }
        public readonly string ToString(string format)
        {
            return ToString(format, null);
        }
        public readonly string ToString(IFormatProvider formatProvider)
        {
            return ToString(null, formatProvider);
        }
        public readonly string ToString(string format, IFormatProvider formatProvider)
        {
        #if TESTING
            return $"DIVISOR: {Divisor}, BIGM: ({_bigM._mulLo}, {_bigM._mulHi}), MULSHIFT: ({_mulShift._mul}, {_mulShift._shift}), PROMISES: {(byte)(Promise)_promises}, TYPEINFO: {_typeInfo}";
        #else
            return Divisor.ToString(format, formatProvider);
        #endif
        }
    }
}
