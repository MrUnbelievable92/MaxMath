//#define TESTING

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

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
        public Divider(T divisor, Promise promises = Promise.Nothing)
        {
            if      (typeof(T) == typeof(sbyte))    this = ctor_sbyte(*(sbyte*)&divisor, promises);
            else if (typeof(T) == typeof(sbyte2))   this = ctor_sbyte2(*(sbyte2*)&divisor, promises);
            else if (typeof(T) == typeof(sbyte3))   this = ctor_sbyte3(*(sbyte3*)&divisor, promises);
            else if (typeof(T) == typeof(sbyte4))   this = ctor_sbyte4(*(sbyte4*)&divisor, promises);
            else if (typeof(T) == typeof(sbyte8))   this = ctor_sbyte8(*(sbyte8*)&divisor, promises);
            else if (typeof(T) == typeof(sbyte16))  this = ctor_sbyte16(*(sbyte16*)&divisor, promises);
            else if (typeof(T) == typeof(sbyte32))  this = ctor_sbyte32(*(sbyte32*)&divisor, promises);

            else if (typeof(T) == typeof(byte))     this = ctor_byte(*(byte*)&divisor, promises);
            else if (typeof(T) == typeof(byte2))    this = ctor_byte2(*(byte2*)&divisor, promises);
            else if (typeof(T) == typeof(byte3))    this = ctor_byte3(*(byte3*)&divisor, promises);
            else if (typeof(T) == typeof(byte4))    this = ctor_byte4(*(byte4*)&divisor, promises);
            else if (typeof(T) == typeof(byte8))    this = ctor_byte8(*(byte8*)&divisor, promises);
            else if (typeof(T) == typeof(byte16))   this = ctor_byte16(*(byte16*)&divisor, promises);
            else if (typeof(T) == typeof(byte32))   this = ctor_byte32(*(byte32*)&divisor, promises);

            else if (typeof(T) == typeof(short))    this = ctor_short(*(short*)&divisor, promises);
            else if (typeof(T) == typeof(short2))   this = ctor_short2(*(short2*)&divisor, promises);
            else if (typeof(T) == typeof(short3))   this = ctor_short3(*(short3*)&divisor, promises);
            else if (typeof(T) == typeof(short4))   this = ctor_short4(*(short4*)&divisor, promises);
            else if (typeof(T) == typeof(short8))   this = ctor_short8(*(short8*)&divisor, promises);
            else if (typeof(T) == typeof(short16))  this = ctor_short16(*(short16*)&divisor, promises);

            else if (typeof(T) == typeof(ushort))   this = ctor_ushort(*(ushort*)&divisor, promises);
            else if (typeof(T) == typeof(ushort2))  this = ctor_ushort2(*(ushort2*)&divisor, promises);
            else if (typeof(T) == typeof(ushort3))  this = ctor_ushort3(*(ushort3*)&divisor, promises);
            else if (typeof(T) == typeof(ushort4))  this = ctor_ushort4(*(ushort4*)&divisor, promises);
            else if (typeof(T) == typeof(ushort8))  this = ctor_ushort8(*(ushort8*)&divisor, promises);
            else if (typeof(T) == typeof(ushort16)) this = ctor_ushort16(*(ushort16*)&divisor, promises);

            else if (typeof(T) == typeof(int))      this = ctor_int(*(int*)&divisor, promises);
            else if (typeof(T) == typeof(int2))     this = ctor_int2(*(int2*)&divisor, promises);
            else if (typeof(T) == typeof(int3))     this = ctor_int3(*(int3*)&divisor, promises);
            else if (typeof(T) == typeof(int4))     this = ctor_int4(*(int4*)&divisor, promises);
            else if (typeof(T) == typeof(int8))     this = ctor_int8(*(int8*)&divisor, promises);

            else if (typeof(T) == typeof(uint))     this = ctor_uint(*(uint*)&divisor, promises);
            else if (typeof(T) == typeof(uint2))    this = ctor_uint2(*(uint2*)&divisor, promises);
            else if (typeof(T) == typeof(uint3))    this = ctor_uint3(*(uint3*)&divisor, promises);
            else if (typeof(T) == typeof(uint4))    this = ctor_uint4(*(uint4*)&divisor, promises);
            else if (typeof(T) == typeof(uint8))    this = ctor_uint8(*(uint8*)&divisor, promises);

            else if (typeof(T) == typeof(long))     this = ctor_long(*(long*)&divisor, promises);
            else if (typeof(T) == typeof(long2))    this = ctor_long2(*(long2*)&divisor, promises);
            else if (typeof(T) == typeof(long3))    this = ctor_long3(*(long3*)&divisor, promises);
            else if (typeof(T) == typeof(long4))    this = ctor_long4(*(long4*)&divisor, promises);

            else if (typeof(T) == typeof(ulong))    this = ctor_ulong(*(ulong*)&divisor, promises);
            else if (typeof(T) == typeof(ulong2))   this = ctor_ulong2(*(ulong2*)&divisor, promises);
            else if (typeof(T) == typeof(ulong3))   this = ctor_ulong3(*(ulong3*)&divisor, promises);
            else if (typeof(T) == typeof(ulong4))   this = ctor_ulong4(*(ulong4*)&divisor, promises);

            else if (typeof(T) == typeof(Int128))   this = ctor_Int128(*(Int128*)&divisor, promises);

            else if (typeof(T) == typeof(UInt128))  this = ctor_UInt128(*(UInt128*)&divisor, promises);

            else throw new TypeInitializationException($"{typeof(Divider<T>)}", null);
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
