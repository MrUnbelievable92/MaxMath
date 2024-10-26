using System;
using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace MaxMath
{
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        #region byte2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x, Divider<byte> y)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte2(x._divisor, y._divisor).Reinterpret<byte2, T>();
            _bigM = new ushort2(*(ushort*)&x._bigM, *(ushort*)&y._bigM).Reinterpret<ushort2, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x._promises & y._promises);
        }
        #endregion

        #region byte3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x, Divider<byte> y, Divider<byte> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte3(x._divisor, y._divisor, z._divisor).Reinterpret<byte3, T>();
            _bigM = new ushort3(*(ushort*)&x._bigM, *(ushort*)&y._bigM, *(ushort*)&z._bigM).Reinterpret<ushort3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x._promises & y._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte2> xy, Divider<byte> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte3(xy._divisor, z._divisor).Reinterpret<byte3, T>();
            _bigM = new ushort3(*(ushort2*)&xy._bigM, *(ushort*)&z._bigM).Reinterpret<ushort3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (xy._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x, Divider<byte2> yz)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte3(x._divisor, yz._divisor).Reinterpret<byte3, T>();
            _bigM = new ushort3(*(ushort*)&x._bigM, *(ushort2*)&yz._bigM).Reinterpret<ushort3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x._promises & yz._promises);
        }
        #endregion

        #region byte4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x, Divider<byte> y, Divider<byte> z, Divider<byte> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte4(x._divisor, y._divisor, z._divisor, w._divisor).Reinterpret<byte4, T>();
            _bigM = new ushort4(*(ushort*)&x._bigM, *(ushort*)&y._bigM, *(ushort*)&z._bigM, *(ushort*)&w._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x._promises & y._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte2> xy, Divider<byte> z, Divider<byte> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte4(xy._divisor, z._divisor, w._divisor).Reinterpret<byte4, T>();
            _bigM = new ushort4(*(ushort2*)&xy._bigM, *(ushort*)&z._bigM, *(ushort*)&w._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (xy._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x, Divider<byte2> yz, Divider<byte> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte4(x._divisor, yz._divisor, w._divisor).Reinterpret<byte4, T>();
            _bigM = new ushort4(*(ushort*)&x._bigM, *(ushort2*)&yz._bigM, *(ushort*)&w._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x._promises & yz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x, Divider<byte> y, Divider<byte2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte4(x._divisor, y._divisor, zw._divisor).Reinterpret<byte4, T>();
            _bigM = new ushort4(*(ushort*)&x._bigM, *(ushort*)&y._bigM, *(ushort2*)&zw._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x._promises & y._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte2> xy, Divider<byte2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte4(xy._divisor, zw._divisor).Reinterpret<byte4, T>();
            _bigM = new ushort4(*(ushort2*)&xy._bigM, *(ushort2*)&zw._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (xy._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte3> xyz, Divider<byte> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte4(xyz._divisor, w._divisor).Reinterpret<byte4, T>();
            _bigM = new ushort4(*(ushort3*)&xyz._bigM, *(ushort*)&w._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (xyz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x, Divider<byte3> yzw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte4(x._divisor, yzw._divisor).Reinterpret<byte4, T>();
            _bigM = new ushort4(*(ushort*)&x._bigM, *(ushort3*)&yzw._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x._promises & yzw._promises);
        }
        #endregion

        #region byte8
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x0, Divider<byte> x1, Divider<byte> x2, Divider<byte> x3, Divider<byte> x4, Divider<byte> x5, Divider<byte> x6, Divider<byte> x7)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte8(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor).Reinterpret<byte8, T>();
            _bigM = new ushort8(*(ushort*)&x0._bigM, *(ushort*)&x1._bigM, *(ushort*)&x2._bigM, *(ushort*)&x3._bigM, *(ushort*)&x4._bigM, *(ushort*)&x5._bigM, *(ushort*)&x6._bigM, *(ushort*)&x7._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte2> x01, Divider<byte2> x23, Divider<byte2> x45, Divider<byte2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte8(x01._divisor, x23._divisor, x45._divisor, x67._divisor).Reinterpret<byte8, T>();
            _bigM = new ushort8(*(ushort2*)&x01._bigM, *(ushort2*)&x23._bigM, *(ushort2*)&x45._bigM, *(ushort2*)&x67._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x01._promises & x23._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte2> x01, Divider<byte3> x234, Divider<byte3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte8(x01._divisor, x234._divisor, x567._divisor).Reinterpret<byte8, T>();
            _bigM = new ushort8(*(ushort2*)&x01._bigM, *(ushort3*)&x234._bigM, *(ushort3*)&x567._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x01._promises & x234._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte3> x012, Divider<byte2> x34, Divider<byte3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte8(x012._divisor, x34._divisor, x567._divisor).Reinterpret<byte8, T>();
            _bigM = new ushort8(*(ushort3*)&x012._bigM, *(ushort2*)&x34._bigM, *(ushort3*)&x567._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x012._promises & x34._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte3> x012, Divider<byte3> x345, Divider<byte2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte8(x012._divisor, x345._divisor, x67._divisor).Reinterpret<byte8, T>();
            _bigM = new ushort8(*(ushort3*)&x012._bigM, *(ushort3*)&x345._bigM, *(ushort2*)&x67._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x012._promises & x345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte4> x0123, Divider<byte2> x45, Divider<byte2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte8(x0123._divisor, x45._divisor, x67._divisor).Reinterpret<byte8, T>();
            _bigM = new ushort8(*(ushort4*)&x0123._bigM, *(ushort2*)&x45._bigM, *(ushort2*)&x67._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0123._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte2> x01, Divider<byte4> x2345, Divider<byte2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte8(x01._divisor, x2345._divisor, x67._divisor).Reinterpret<byte8, T>();
            _bigM = new ushort8(*(ushort2*)&x01._bigM, *(ushort4*)&x2345._bigM, *(ushort2*)&x67._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x01._promises & x2345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte2> x01, Divider<byte2> x23, Divider<byte4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte8(x01._divisor, x23._divisor, x4567._divisor).Reinterpret<byte8, T>();
            _bigM = new ushort8(*(ushort2*)&x01._bigM, *(ushort2*)&x23._bigM, *(ushort4*)&x4567._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x01._promises & x23._promises & x4567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte4> x0123, Divider<byte4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte8(x0123._divisor, x4567._divisor).Reinterpret<byte8, T>();
            _bigM = new ushort8(*(ushort4*)&x0123._bigM, *(ushort4*)&x4567._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0123._promises & x4567._promises);
        }
        #endregion

        #region byte16
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x0, Divider<byte> x1, Divider<byte> x2, Divider<byte> x3, Divider<byte> x4, Divider<byte> x5, Divider<byte> x6, Divider<byte> x7, Divider<byte> x8, Divider<byte> x9, Divider<byte> x10, Divider<byte> x11, Divider<byte> x12, Divider<byte> x13, Divider<byte> x14, Divider<byte> x15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor, x8._divisor, x9._divisor, x10._divisor, x11._divisor, x12._divisor, x13._divisor, x14._divisor, x15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort*)&x0._bigM, *(ushort*)&x1._bigM, *(ushort*)&x2._bigM, *(ushort*)&x3._bigM, *(ushort*)&x4._bigM, *(ushort*)&x5._bigM, *(ushort*)&x6._bigM, *(ushort*)&x7._bigM, *(ushort*)&x8._bigM, *(ushort*)&x9._bigM, *(ushort*)&x10._bigM, *(ushort*)&x11._bigM, *(ushort*)&x12._bigM, *(ushort*)&x13._bigM, *(ushort*)&x14._bigM, *(ushort*)&x15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises & x8._promises & x9._promises & x10._promises & x11._promises & x12._promises & x13._promises & x14._promises & x15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte2> x01, Divider<byte2> x23, Divider<byte2> x45, Divider<byte2> x67, Divider<byte2> x89, Divider<byte2> x10_11, Divider<byte2> x12_13, Divider<byte2> x14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x01._divisor, x23._divisor, x45._divisor, x67._divisor, x89._divisor, x10_11._divisor, x12_13._divisor, x14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort2*)&x01._bigM, *(ushort2*)&x23._bigM, *(ushort2*)&x45._bigM, *(ushort2*)&x67._bigM, *(ushort2*)&x89._bigM, *(ushort2*)&x10_11._bigM, *(ushort2*)&x12_13._bigM, *(ushort2*)&x14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x01._promises & x23._promises & x45._promises & x67._promises & x89._promises & x10_11._promises & x12_13._promises & x14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte4> x0123, Divider<byte4> x4567, Divider<byte4> x8_9_10_11, Divider<byte4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x0123._divisor, x4567._divisor, x8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort4*)&x0123._bigM, *(ushort4*)&x4567._bigM, *(ushort4*)&x8_9_10_11._bigM, *(ushort4*)&x12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0123._promises & x4567._promises & x8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte4> x0123, Divider<byte3> x456, Divider<byte3> x789, Divider<byte3> x10_11_12, Divider<byte3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x0123._divisor, x456._divisor, x789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort4*)&x0123._bigM, *(ushort3*)&x456._bigM, *(ushort3*)&x789._bigM, *(ushort3*)&x10_11_12._bigM, *(ushort3*)&x13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0123._promises & x456._promises & x789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte3> x012, Divider<byte4> x3456, Divider<byte3> x789, Divider<byte3> x10_11_12, Divider<byte3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x012._divisor, x3456._divisor, x789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort3*)&x012._bigM, *(ushort4*)&x3456._bigM, *(ushort3*)&x789._bigM, *(ushort3*)&x10_11_12._bigM, *(ushort3*)&x13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x012._promises & x3456._promises & x789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte3> x012, Divider<byte3> x345, Divider<byte4> x6789, Divider<byte3> x10_11_12, Divider<byte3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x012._divisor, x345._divisor, x6789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort3*)&x012._bigM, *(ushort3*)&x345._bigM, *(ushort4*)&x6789._bigM, *(ushort3*)&x10_11_12._bigM, *(ushort3*)&x13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x012._promises & x345._promises & x6789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte3> x012, Divider<byte3> x345, Divider<byte3> x678, Divider<byte4> x9_10_11_12, Divider<byte3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x012._divisor, x345._divisor, x678._divisor, x9_10_11_12._divisor, x13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort3*)&x012._bigM, *(ushort3*)&x345._bigM, *(ushort3*)&x678._bigM, *(ushort4*)&x9_10_11_12._bigM, *(ushort3*)&x13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x012._promises & x345._promises & x678._promises & x9_10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte3> x012, Divider<byte3> x345, Divider<byte3> x678, Divider<byte3> x9_10_11, Divider<byte4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x012._divisor, x345._divisor, x678._divisor, x9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort3*)&x012._bigM, *(ushort3*)&x345._bigM, *(ushort3*)&x678._bigM, *(ushort3*)&x9_10_11._bigM, *(ushort4*)&x12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x012._promises & x345._promises & x678._promises & x9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte8> x01234567, Divider<byte4> x8_9_10_11, Divider<byte4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x01234567._divisor, x8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort8*)&x01234567._bigM, *(ushort4*)&x8_9_10_11._bigM, *(ushort4*)&x12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x01234567._promises & x8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte4> x0123, Divider<byte8> x4_5_6_7_8_9_10_11, Divider<byte4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x0123._divisor, x4_5_6_7_8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort4*)&x0123._bigM, *(ushort8*)&x4_5_6_7_8_9_10_11._bigM, *(ushort4*)&x12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0123._promises & x4_5_6_7_8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte4> x0123, Divider<byte4> x4567, Divider<byte8> x8_9_10_11_12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x0123._divisor, x4567._divisor, x8_9_10_11_12_13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort4*)&x0123._bigM, *(ushort4*)&x4567._bigM, *(ushort8*)&x8_9_10_11_12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0123._promises & x4567._promises & x8_9_10_11_12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte8> x01234567, Divider<byte8> x8_9_10_11_12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte16(x01234567._divisor, x8_9_10_11_12_13_14_15._divisor).Reinterpret<byte16, T>();
            _bigM = new ushort16(*(ushort8*)&x01234567._bigM, *(ushort8*)&x8_9_10_11_12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x01234567._promises & x8_9_10_11_12_13_14_15._promises);
        }
        #endregion

        #region byte32
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte> x0, Divider<byte> x1, Divider<byte> x2, Divider<byte> x3, Divider<byte> x4, Divider<byte> x5, Divider<byte> x6, Divider<byte> x7, Divider<byte> x8, Divider<byte> x9, Divider<byte> x10, Divider<byte> x11, Divider<byte> x12, Divider<byte> x13, Divider<byte> x14, Divider<byte> x15, Divider<byte> x16, Divider<byte> x17, Divider<byte> x18, Divider<byte> x19, Divider<byte> x20, Divider<byte> x21, Divider<byte> x22, Divider<byte> x23, Divider<byte> x24, Divider<byte> x25, Divider<byte> x26, Divider<byte> x27, Divider<byte> x28, Divider<byte> x29, Divider<byte> x30, Divider<byte> x31)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte32(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor, x8._divisor, x9._divisor, x10._divisor, x11._divisor, x12._divisor, x13._divisor, x14._divisor, x15._divisor, x16._divisor, x17._divisor, x18._divisor, x19._divisor, x20._divisor, x21._divisor, x22._divisor, x23._divisor, x24._divisor, x25._divisor, x26._divisor, x27._divisor, x28._divisor, x29._divisor, x30._divisor, x31._divisor).Reinterpret<byte32, T>();
            _bigM._mulLo = new ushort16(*(ushort*)&x0._bigM, *(ushort*)&x1._bigM, *(ushort*)&x2._bigM, *(ushort*)&x3._bigM, *(ushort*)&x4._bigM, *(ushort*)&x5._bigM, *(ushort*)&x6._bigM, *(ushort*)&x7._bigM, *(ushort*)&x8._bigM, *(ushort*)&x9._bigM, *(ushort*)&x10._bigM, *(ushort*)&x11._bigM, *(ushort*)&x12._bigM, *(ushort*)&x13._bigM, *(ushort*)&x14._bigM, *(ushort*)&x15._bigM).Reinterpret<ushort16, T>();
            _bigM._mulHi = new ushort16(*(ushort*)&x16._bigM, *(ushort*)&x17._bigM, *(ushort*)&x18._bigM, *(ushort*)&x19._bigM, *(ushort*)&x20._bigM, *(ushort*)&x21._bigM, *(ushort*)&x22._bigM, *(ushort*)&x23._bigM, *(ushort*)&x24._bigM, *(ushort*)&x25._bigM, *(ushort*)&x26._bigM, *(ushort*)&x27._bigM, *(ushort*)&x28._bigM, *(ushort*)&x29._bigM, *(ushort*)&x30._bigM, *(ushort*)&x31._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises & x8._promises & x9._promises & x10._promises & x11._promises & x12._promises & x13._promises & x14._promises & x15._promises & x16._promises & x17._promises & x18._promises & x19._promises & x20._promises & x21._promises & x22._promises & x23._promises & x24._promises & x25._promises & x26._promises & x27._promises & x28._promises & x29._promises & x30._promises & x31._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte4> x0_3, Divider<byte4> x4_7, Divider<byte4> x8_11, Divider<byte4> x12_15, Divider<byte4> x16_19, Divider<byte4> x20_23, Divider<byte4> x24_27, Divider<byte4> x28_31)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte32(x0_3._divisor, x4_7._divisor, x8_11._divisor, x12_15._divisor, x16_19._divisor, x20_23._divisor, x24_27._divisor, x28_31._divisor).Reinterpret<byte32, T>();
            _bigM._mulLo = new ushort16(*(ushort4*)&x0_3._bigM, *(ushort4*)&x4_7._bigM, *(ushort4*)&x8_11._bigM, *(ushort4*)&x12_15._bigM).Reinterpret<ushort16, T>();
            _bigM._mulHi = new ushort16(*(ushort4*)&x16_19._bigM, *(ushort4*)&x20_23._bigM, *(ushort4*)&x24_27._bigM, *(ushort4*)&x28_31._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (x0_3._promises & x4_7._promises & x8_11._promises & x12_15._promises & x16_19._promises & x20_23._promises & x24_27._promises & x28_31._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte8> v8_0, Divider<byte8> v8_8, Divider<byte8> v8_16, Divider<byte8> v8_24)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte32(v8_0._divisor, v8_8._divisor, v8_16._divisor, v8_24._divisor).Reinterpret<byte32, T>();
            _bigM._mulLo = new ushort16(*(ushort8*)&v8_0._bigM, *(ushort8*)&v8_8._bigM).Reinterpret<ushort16, T>();
            _bigM._mulHi = new ushort16(*(ushort8*)&v8_16._bigM, *(ushort8*)&v8_24._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (v8_0._promises & v8_8._promises & v8_16._promises & v8_24._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte16> v16_0, Divider<byte8> v8_16, Divider<byte8> v8_24)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte32(v16_0._divisor, v8_16._divisor, v8_24._divisor).Reinterpret<byte32, T>();
            _bigM._mulLo = v16_0._bigM.Reinterpret<Divider<byte16>.BigM, T>();
            _bigM._mulHi = new ushort16(*(ushort8*)&v8_16._bigM, *(ushort8*)&v8_24._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (v16_0._promises & v8_16._promises & v8_24._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte8> v8_0, Divider<byte16> v16_8, Divider<byte8> v8_24)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte32(v8_0._divisor, v16_8._divisor, v8_24._divisor).Reinterpret<byte32, T>();
            _bigM._mulLo = new ushort16(*(ushort8*)&v8_0._bigM, *(ushort8*)&v16_8._bigM._mulLo).Reinterpret<ushort16, T>();
            _bigM._mulHi = new ushort16(*(ushort8*)&v16_8._bigM._mulHi, *(ushort8*)&v8_24._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (v8_0._promises & v16_8._promises & v8_24._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte8> v8_0, Divider<byte8> v8_8, Divider<byte16> v16_16)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte32(v8_0._divisor, v8_8._divisor, v16_16._divisor).Reinterpret<byte32, T>();
            _bigM._mulLo = new ushort16(*(ushort8*)&v8_0._bigM, *(ushort8*)&v8_8._bigM).Reinterpret<ushort16, T>();
            _bigM._mulHi = v16_16._bigM.Reinterpret<Divider<byte16>.BigM, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (v8_0._promises & v8_8._promises & v16_16._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<byte16> v16_0, Divider<byte16> v16_16)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(byte), 32, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new byte32(v16_0._divisor, v16_16._divisor).Reinterpret<byte32, T>();
            _bigM._mulLo = v16_0._bigM.Reinterpret<Divider<byte16>.BigM, T>();
            _bigM._mulHi = v16_16._bigM.Reinterpret<Divider<byte16>.BigM, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(byte)) | (v16_0._promises & v16_16._promises);
        }
        #endregion


        #region ushort2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort> x, Divider<ushort> y)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort2(x._divisor, y._divisor).Reinterpret<ushort2, T>();
            _mulShift._mul = new ushort2(x._mulShift._mul, y._mulShift._mul).Reinterpret<ushort2, T>();
            _mulShift._shift = new ushort2(x._mulShift._shift, y._mulShift._shift).Reinterpret<ushort2, T>();
            _bigM = new uint2(*(uint*)&x._bigM, *(uint*)&y._bigM).Reinterpret<uint2, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x._promises & y._promises);
        }
        #endregion

        #region ushort3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort> x, Divider<ushort> y, Divider<ushort> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort3(x._divisor, y._divisor, z._divisor).Reinterpret<ushort3, T>();
            _mulShift._mul = new ushort3(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul).Reinterpret<ushort3, T>();
            _mulShift._shift = new ushort3(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift).Reinterpret<ushort3, T>();
            _bigM = new uint3(*(uint*)&x._bigM, *(uint*)&y._bigM, *(uint*)&z._bigM).Reinterpret<uint3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x._promises & y._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort2> xy, Divider<ushort> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort3(xy._divisor, z._divisor).Reinterpret<ushort3, T>();
            _mulShift._mul = new ushort3(xy._mulShift._mul, z._mulShift._mul).Reinterpret<ushort3, T>();
            _mulShift._shift = new ushort3(xy._mulShift._shift, z._mulShift._shift).Reinterpret<ushort3, T>();
            _bigM = new uint3(*(uint2*)&xy._bigM, *(uint*)&z._bigM).Reinterpret<uint3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (xy._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort> x, Divider<ushort2> yz)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort3(x._divisor, yz._divisor).Reinterpret<ushort3, T>();
            _mulShift._mul = new ushort3(x._mulShift._mul, yz._mulShift._mul).Reinterpret<ushort3, T>();
            _mulShift._shift = new ushort3(x._mulShift._shift, yz._mulShift._shift).Reinterpret<ushort3, T>();
            _bigM = new uint3(*(uint*)&x._bigM, *(uint2*)&yz._bigM).Reinterpret<uint3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x._promises & yz._promises);
        }
        #endregion

        #region ushort4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort> x, Divider<ushort> y, Divider<ushort> z, Divider<ushort> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort4(x._divisor, y._divisor, z._divisor, w._divisor).Reinterpret<ushort4, T>();
            _mulShift._mul = new ushort4(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<ushort4, T>();
            _mulShift._shift = new ushort4(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<ushort4, T>();
            _bigM = new uint4(*(uint*)&x._bigM, *(uint*)&y._bigM, *(uint*)&z._bigM, *(uint*)&w._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x._promises & y._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort2> xy, Divider<ushort> z, Divider<ushort> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort4(xy._divisor, z._divisor, w._divisor).Reinterpret<ushort4, T>();
            _mulShift._mul = new ushort4(xy._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<ushort4, T>();
            _mulShift._shift = new ushort4(xy._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<ushort4, T>();
            _bigM = new uint4(*(uint2*)&xy._bigM, *(uint*)&z._bigM, *(uint*)&w._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (xy._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort> x, Divider<ushort2> yz, Divider<ushort> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort4(x._divisor, yz._divisor, w._divisor).Reinterpret<ushort4, T>();
            _mulShift._mul = new ushort4(x._mulShift._mul, yz._mulShift._mul, w._mulShift._mul).Reinterpret<ushort4, T>();
            _mulShift._shift = new ushort4(x._mulShift._shift, yz._mulShift._shift, w._mulShift._shift).Reinterpret<ushort4, T>();
            _bigM = new uint4(*(uint*)&x._bigM, *(uint2*)&yz._bigM, *(uint*)&w._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x._promises & yz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort> x, Divider<ushort> y, Divider<ushort2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort4(x._divisor, y._divisor, zw._divisor).Reinterpret<ushort4, T>();
            _mulShift._mul = new ushort4(x._mulShift._mul, y._mulShift._mul, zw._mulShift._mul).Reinterpret<ushort4, T>();
            _mulShift._shift = new ushort4(x._mulShift._shift, y._mulShift._shift, zw._mulShift._shift).Reinterpret<ushort4, T>();
            _bigM = new uint4(*(uint*)&x._bigM, *(uint*)&y._bigM, *(uint2*)&zw._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x._promises & y._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort2> xy, Divider<ushort2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort4(xy._divisor, zw._divisor).Reinterpret<ushort4, T>();
            _mulShift._mul = new ushort4(xy._mulShift._mul, zw._mulShift._mul).Reinterpret<ushort4, T>();
            _mulShift._shift = new ushort4(xy._mulShift._shift, zw._mulShift._shift).Reinterpret<ushort4, T>();
            _bigM = new uint4(*(uint2*)&xy._bigM, *(uint2*)&zw._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (xy._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort3> xyz, Divider<ushort> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort4(xyz._divisor, w._divisor).Reinterpret<ushort4, T>();
            _mulShift._mul = new ushort4(xyz._mulShift._mul, w._mulShift._mul).Reinterpret<ushort4, T>();
            _mulShift._shift = new ushort4(xyz._mulShift._shift, w._mulShift._shift).Reinterpret<ushort4, T>();
            _bigM = new uint4(*(uint3*)&xyz._bigM, *(uint*)&w._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (xyz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort> x, Divider<ushort3> yzw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort4(x._divisor, yzw._divisor).Reinterpret<ushort4, T>();
            _mulShift._mul = new ushort4(x._mulShift._mul, yzw._mulShift._mul).Reinterpret<ushort4, T>();
            _mulShift._shift = new ushort4(x._mulShift._shift, yzw._mulShift._shift).Reinterpret<ushort4, T>();
            _bigM = new uint4(*(uint*)&x._bigM, *(uint3*)&yzw._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x._promises & yzw._promises);
        }
        #endregion

        #region ushort8
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort> x0, Divider<ushort> x1, Divider<ushort> x2, Divider<ushort> x3, Divider<ushort> x4, Divider<ushort> x5, Divider<ushort> x6, Divider<ushort> x7)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort8(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor).Reinterpret<ushort8, T>();
            _mulShift._mul = new ushort8(x0._mulShift._mul, x1._mulShift._mul, x2._mulShift._mul, x3._mulShift._mul, x4._mulShift._mul, x5._mulShift._mul, x6._mulShift._mul, x7._mulShift._mul).Reinterpret<ushort8, T>();
            _mulShift._shift = new ushort8(x0._mulShift._shift, x1._mulShift._shift, x2._mulShift._shift, x3._mulShift._shift, x4._mulShift._shift, x5._mulShift._shift, x6._mulShift._shift, x7._mulShift._shift).Reinterpret<ushort8, T>();
            _bigM = new uint8(*(uint*)&x0._bigM, *(uint*)&x1._bigM, *(uint*)&x2._bigM, *(uint*)&x3._bigM, *(uint*)&x4._bigM, *(uint*)&x5._bigM, *(uint*)&x6._bigM, *(uint*)&x7._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort2> x01, Divider<ushort2> x23, Divider<ushort2> x45, Divider<ushort2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort8(x01._divisor, x23._divisor, x45._divisor, x67._divisor).Reinterpret<ushort8, T>();
            _mulShift._mul = new ushort8(x01._mulShift._mul, x23._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul).Reinterpret<ushort8, T>();
            _mulShift._shift = new ushort8(x01._mulShift._shift, x23._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift).Reinterpret<ushort8, T>();
            _bigM = new uint8(*(uint2*)&x01._bigM, *(uint2*)&x23._bigM, *(uint2*)&x45._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x01._promises & x23._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort2> x01, Divider<ushort3> x234, Divider<ushort3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort8(x01._divisor, x234._divisor, x567._divisor).Reinterpret<ushort8, T>();
            _mulShift._mul = new ushort8(x01._mulShift._mul, x234._mulShift._mul, x567._mulShift._mul).Reinterpret<ushort8, T>();
            _mulShift._shift = new ushort8(x01._mulShift._shift, x234._mulShift._shift, x567._mulShift._shift).Reinterpret<ushort8, T>();
            _bigM = new uint8(*(uint2*)&x01._bigM, *(uint3*)&x234._bigM, *(uint3*)&x567._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x01._promises & x234._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort3> x012, Divider<ushort2> x34, Divider<ushort3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort8(x012._divisor, x34._divisor, x567._divisor).Reinterpret<ushort8, T>();
            _mulShift._mul = new ushort8(x012._mulShift._mul, x34._mulShift._mul, x567._mulShift._mul).Reinterpret<ushort8, T>();
            _mulShift._shift = new ushort8(x012._mulShift._shift, x34._mulShift._shift, x567._mulShift._shift).Reinterpret<ushort8, T>();
            _bigM = new uint8(*(uint3*)&x012._bigM, *(uint2*)&x34._bigM, *(uint3*)&x567._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x012._promises & x34._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort3> x012, Divider<ushort3> x345, Divider<ushort2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort8(x012._divisor, x345._divisor, x67._divisor).Reinterpret<ushort8, T>();
            _mulShift._mul = new ushort8(x012._mulShift._mul, x345._mulShift._mul, x67._mulShift._mul).Reinterpret<ushort8, T>();
            _mulShift._shift = new ushort8(x012._mulShift._shift, x345._mulShift._shift, x67._mulShift._shift).Reinterpret<ushort8, T>();
            _bigM = new uint8(*(uint3*)&x012._bigM, *(uint3*)&x345._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x012._promises & x345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort4> x0123, Divider<ushort2> x45, Divider<ushort2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort8(x0123._divisor, x45._divisor, x67._divisor).Reinterpret<ushort8, T>();
            _mulShift._mul = new ushort8(x0123._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul).Reinterpret<ushort8, T>();
            _mulShift._shift = new ushort8(x0123._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift).Reinterpret<ushort8, T>();
            _bigM = new uint8(*(uint4*)&x0123._bigM, *(uint2*)&x45._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x0123._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort2> x01, Divider<ushort4> x2345, Divider<ushort2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort8(x01._divisor, x2345._divisor, x67._divisor).Reinterpret<ushort8, T>();
            _mulShift._mul = new ushort8(x01._mulShift._mul, x2345._mulShift._mul, x67._mulShift._mul).Reinterpret<ushort8, T>();
            _mulShift._shift = new ushort8(x01._mulShift._shift, x2345._mulShift._shift, x67._mulShift._shift).Reinterpret<ushort8, T>();
            _bigM = new uint8(*(uint2*)&x01._bigM, *(uint4*)&x2345._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x01._promises & x2345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort2> x01, Divider<ushort2> x23, Divider<ushort4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort8(x01._divisor, x23._divisor, x4567._divisor).Reinterpret<ushort8, T>();
            _mulShift._mul = new ushort8(x01._mulShift._mul, x23._mulShift._mul, x4567._mulShift._mul).Reinterpret<ushort8, T>();
            _mulShift._shift = new ushort8(x01._mulShift._shift, x23._mulShift._shift, x4567._mulShift._shift).Reinterpret<ushort8, T>();
            _bigM = new uint8(*(uint2*)&x01._bigM, *(uint2*)&x23._bigM, *(uint4*)&x4567._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x01._promises & x23._promises & x4567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort4> x0123, Divider<ushort4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort8(x0123._divisor, x4567._divisor).Reinterpret<ushort8, T>();
            _mulShift._mul = new ushort8(x0123._mulShift._mul, x4567._mulShift._mul).Reinterpret<ushort8, T>();
            _mulShift._shift = new ushort8(x0123._mulShift._shift, x4567._mulShift._shift).Reinterpret<ushort8, T>();
            _bigM = new uint8(*(uint4*)&x0123._bigM, *(uint4*)&x4567._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x0123._promises & x4567._promises);
        }
        #endregion

        #region ushort16
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort> x0, Divider<ushort> x1, Divider<ushort> x2, Divider<ushort> x3, Divider<ushort> x4, Divider<ushort> x5, Divider<ushort> x6, Divider<ushort> x7, Divider<ushort> x8, Divider<ushort> x9, Divider<ushort> x10, Divider<ushort> x11, Divider<ushort> x12, Divider<ushort> x13, Divider<ushort> x14, Divider<ushort> x15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor, x8._divisor, x9._divisor, x10._divisor, x11._divisor, x12._divisor, x13._divisor, x14._divisor, x15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x0._mulShift._mul, x1._mulShift._mul, x2._mulShift._mul, x3._mulShift._mul, x4._mulShift._mul, x5._mulShift._mul, x6._mulShift._mul, x7._mulShift._mul, x8._mulShift._mul, x9._mulShift._mul, x10._mulShift._mul, x11._mulShift._mul, x12._mulShift._mul, x13._mulShift._mul, x14._mulShift._mul, x15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x0._mulShift._shift, x1._mulShift._shift, x2._mulShift._shift, x3._mulShift._shift, x4._mulShift._shift, x5._mulShift._shift, x6._mulShift._shift, x7._mulShift._shift, x8._mulShift._shift, x9._mulShift._shift, x10._mulShift._shift, x11._mulShift._shift, x12._mulShift._shift, x13._mulShift._shift, x14._mulShift._shift, x15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(*(uint*)&x0._bigM, *(uint*)&x1._bigM, *(uint*)&x2._bigM, *(uint*)&x3._bigM, *(uint*)&x4._bigM, *(uint*)&x5._bigM, *(uint*)&x6._bigM, *(uint*)&x7._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(*(uint*)&x8._bigM, *(uint*)&x9._bigM, *(uint*)&x10._bigM, *(uint*)&x11._bigM, *(uint*)&x12._bigM, *(uint*)&x13._bigM, *(uint*)&x14._bigM, *(uint*)&x15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises & x8._promises & x9._promises & x10._promises & x11._promises & x12._promises & x13._promises & x14._promises & x15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort2> x01, Divider<ushort2> x23, Divider<ushort2> x45, Divider<ushort2> x67, Divider<ushort2> x89, Divider<ushort2> x10_11, Divider<ushort2> x12_13, Divider<ushort2> x14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x01._divisor, x23._divisor, x45._divisor, x67._divisor, x89._divisor, x10_11._divisor, x12_13._divisor, x14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x01._mulShift._mul, x23._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul, x89._mulShift._mul, x10_11._mulShift._mul, x12_13._mulShift._mul, x14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x01._mulShift._shift, x23._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift, x89._mulShift._shift, x10_11._mulShift._shift, x12_13._mulShift._shift, x14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(*(uint2*)&x01._bigM, *(uint2*)&x23._bigM, *(uint2*)&x45._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(*(uint2*)&x89._bigM, *(uint2*)&x10_11._bigM, *(uint2*)&x12_13._bigM, *(uint2*)&x14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x01._promises & x23._promises & x45._promises & x67._promises & x89._promises & x10_11._promises & x12_13._promises & x14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort4> x0123, Divider<ushort4> x4567, Divider<ushort4> x8_9_10_11, Divider<ushort4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x0123._divisor, x4567._divisor, x8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x0123._mulShift._mul, x4567._mulShift._mul, x8_9_10_11._mulShift._mul, x12_13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x0123._mulShift._shift, x4567._mulShift._shift, x8_9_10_11._mulShift._shift, x12_13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(*(uint4*)&x0123._bigM, *(uint4*)&x4567._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(*(uint4*)&x8_9_10_11._bigM, *(uint4*)&x12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x0123._promises & x4567._promises & x8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort4> x0123, Divider<ushort3> x456, Divider<ushort3> x789, Divider<ushort3> x10_11_12, Divider<ushort3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x0123._divisor, x456._divisor, x789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x0123._mulShift._mul, x456._mulShift._mul, x789._mulShift._mul, x10_11_12._mulShift._mul, x13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x0123._mulShift._shift, x456._mulShift._shift, x789._mulShift._shift, x10_11_12._mulShift._shift, x13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(*(uint4*)&x0123._bigM, new uint4(*(uint3*)&x456._bigM, (*(uint3*)&x789._bigM).x)).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8((*(uint3*)&x789._bigM).yz, *(uint3*)&x10_11_12._bigM, *(uint3*)&x13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x0123._promises & x456._promises & x789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort3> x012, Divider<ushort4> x3456, Divider<ushort3> x789, Divider<ushort3> x10_11_12, Divider<ushort3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x012._divisor, x3456._divisor, x789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x012._mulShift._mul, x3456._mulShift._mul, x789._mulShift._mul, x10_11_12._mulShift._mul, x13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x012._mulShift._shift, x3456._mulShift._shift, x789._mulShift._shift, x10_11_12._mulShift._shift, x13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(new uint4(*(uint3*)&x012._bigM, (*(uint4*)&x3456._bigM).x), new uint4((*(uint4*)&x3456._bigM).yzw, (*(uint3*)&x789._bigM).x)).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8((*(uint3*)&x789._bigM).yz, *(uint3*)&x10_11_12._bigM, *(uint3*)&x13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x012._promises & x3456._promises & x789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort3> x012, Divider<ushort3> x345, Divider<ushort4> x6789, Divider<ushort3> x10_11_12, Divider<ushort3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x012._divisor, x345._divisor, x6789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x012._mulShift._mul, x345._mulShift._mul, x6789._mulShift._mul, x10_11_12._mulShift._mul, x13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x012._mulShift._shift, x345._mulShift._shift, x6789._mulShift._shift, x10_11_12._mulShift._shift, x13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(*(uint3*)&x012._bigM, *(uint3*)&x345._bigM, (*(uint4*)&x6789._bigM).xy).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8((*(uint4*)&x6789._bigM).zw, *(uint3*)&x10_11_12._bigM, *(uint3*)&x13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x012._promises & x345._promises & x6789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort3> x012, Divider<ushort3> x345, Divider<ushort3> x678, Divider<ushort4> x9_10_11_12, Divider<ushort3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x012._divisor, x345._divisor, x678._divisor, x9_10_11_12._divisor, x13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x012._mulShift._mul, x345._mulShift._mul, x678._mulShift._mul, x9_10_11_12._mulShift._mul, x13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x012._mulShift._shift, x345._mulShift._shift, x678._mulShift._shift, x9_10_11_12._mulShift._shift, x13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(*(uint3*)&x012._bigM, *(uint3*)&x345._bigM, (*(uint3*)&x678._bigM).xy).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(new uint4((*(uint3*)&x678._bigM).z, (*(uint4*)&x9_10_11_12._bigM).xyz), new uint4((*(uint4*)&x9_10_11_12._bigM).w, *(uint3*)&x13_14_15._bigM)).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x012._promises & x345._promises & x678._promises & x9_10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort3> x012, Divider<ushort3> x345, Divider<ushort3> x678, Divider<ushort3> x9_10_11, Divider<ushort4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x012._divisor, x345._divisor, x678._divisor, x9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x012._mulShift._mul, x345._mulShift._mul, x678._mulShift._mul, x9_10_11._mulShift._mul, x12_13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x012._mulShift._shift, x345._mulShift._shift, x678._mulShift._shift, x9_10_11._mulShift._shift, x12_13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(*(uint3*)&x012._bigM, *(uint3*)&x345._bigM, (*(uint3*)&x678._bigM).xy).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(new uint4((*(uint3*)&x678._bigM).z, *(uint3*)&x9_10_11._bigM), *(uint4*)&x12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x012._promises & x345._promises & x678._promises & x9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort8> x01234567, Divider<ushort4> x8_9_10_11, Divider<ushort4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x01234567._divisor, x8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x01234567._mulShift._mul, x8_9_10_11._mulShift._mul, x12_13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x01234567._mulShift._shift, x8_9_10_11._mulShift._shift, x12_13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = (*(uint8*)&x01234567._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(*(uint4*)&x8_9_10_11._bigM, *(uint4*)&x12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x01234567._promises & x8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort4> x0123, Divider<ushort8> x4_5_6_7_8_9_10_11, Divider<ushort4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x0123._divisor, x4_5_6_7_8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x0123._mulShift._mul, x4_5_6_7_8_9_10_11._mulShift._mul, x12_13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x0123._mulShift._shift, x4_5_6_7_8_9_10_11._mulShift._shift, x12_13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(*(uint4*)&x0123._bigM, (*(uint8*)&x4_5_6_7_8_9_10_11._bigM).v4_0).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8((*(uint8*)&x4_5_6_7_8_9_10_11._bigM).v4_4, *(uint4*)&x12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x0123._promises & x4_5_6_7_8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort4> x0123, Divider<ushort4> x4567, Divider<ushort8> x8_9_10_11_12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x0123._divisor, x4567._divisor, x8_9_10_11_12_13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x0123._mulShift._mul, x4567._mulShift._mul, x8_9_10_11_12_13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x0123._mulShift._shift, x4567._mulShift._shift, x8_9_10_11_12_13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = new uint8(*(uint4*)&x0123._bigM, *(uint4*)&x4567._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = (*(uint8*)&x8_9_10_11_12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x0123._promises & x4567._promises & x8_9_10_11_12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ushort8> x01234567, Divider<ushort8> x8_9_10_11_12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ushort), 16, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ushort16(x01234567._divisor, x8_9_10_11_12_13_14_15._divisor).Reinterpret<ushort16, T>();
            _mulShift._mul = new ushort16(x01234567._mulShift._mul, x8_9_10_11_12_13_14_15._mulShift._mul).Reinterpret<ushort16, T>();
            _mulShift._shift = new ushort16(x01234567._mulShift._shift, x8_9_10_11_12_13_14_15._mulShift._shift).Reinterpret<ushort16, T>();
            _bigM._mulLo = (*(uint8*)&x01234567._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = (*(uint8*)&x8_9_10_11_12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ushort)) | (x01234567._promises & x8_9_10_11_12_13_14_15._promises);
        }
        #endregion


        #region uint2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint> x, Divider<uint> y)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint2(x._divisor, y._divisor).Reinterpret<uint2, T>();
            _mulShift._mul = new uint2(x._mulShift._mul, y._mulShift._mul).Reinterpret<uint2, T>();
            _mulShift._shift = new uint2(x._mulShift._shift, y._mulShift._shift).Reinterpret<uint2, T>();
            _bigM = new ulong2(*(ulong*)&x._bigM, *(ulong*)&y._bigM).Reinterpret<ulong2, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x._promises & y._promises);
        }
        #endregion

        #region uint3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint> x, Divider<uint> y, Divider<uint> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint3(x._divisor, y._divisor, z._divisor).Reinterpret<uint3, T>();
            _mulShift._mul = new uint3(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul).Reinterpret<uint3, T>();
            _mulShift._shift = new uint3(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift).Reinterpret<uint3, T>();
            _bigM = new ulong3(*(ulong*)&x._bigM, *(ulong*)&y._bigM, *(ulong*)&z._bigM).Reinterpret<ulong3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x._promises & y._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint2> xy, Divider<uint> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint3(xy._divisor, z._divisor).Reinterpret<uint3, T>();
            _mulShift._mul = new uint3(xy._mulShift._mul, z._mulShift._mul).Reinterpret<uint3, T>();
            _mulShift._shift = new uint3(xy._mulShift._shift, z._mulShift._shift).Reinterpret<uint3, T>();
            _bigM = new ulong3(*(ulong2*)&xy._bigM, *(ulong*)&z._bigM).Reinterpret<ulong3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (xy._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint> x, Divider<uint2> yz)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint3(x._divisor, yz._divisor).Reinterpret<uint3, T>();
            _mulShift._mul = new uint3(x._mulShift._mul, yz._mulShift._mul).Reinterpret<uint3, T>();
            _mulShift._shift = new uint3(x._mulShift._shift, yz._mulShift._shift).Reinterpret<uint3, T>();
            _bigM = new ulong3(*(ulong*)&x._bigM, *(ulong2*)&yz._bigM).Reinterpret<ulong3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x._promises & yz._promises);
        }
        #endregion

        #region uint4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint> x, Divider<uint> y, Divider<uint> z, Divider<uint> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint4(x._divisor, y._divisor, z._divisor, w._divisor).Reinterpret<uint4, T>();
            _mulShift._mul = new uint4(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<uint4, T>();
            _mulShift._shift = new uint4(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<uint4, T>();
            _bigM = new ulong4(*(ulong*)&x._bigM, *(ulong*)&y._bigM, *(ulong*)&z._bigM, *(ulong*)&w._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x._promises & y._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint2> xy, Divider<uint> z, Divider<uint> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint4(xy._divisor, z._divisor, w._divisor).Reinterpret<uint4, T>();
            _mulShift._mul = new uint4(xy._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<uint4, T>();
            _mulShift._shift = new uint4(xy._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<uint4, T>();
            _bigM = new ulong4(*(ulong2*)&xy._bigM, *(ulong*)&z._bigM, *(ulong*)&w._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (xy._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint> x, Divider<uint2> yz, Divider<uint> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint4(x._divisor, yz._divisor, w._divisor).Reinterpret<uint4, T>();
            _mulShift._mul = new uint4(x._mulShift._mul, yz._mulShift._mul, w._mulShift._mul).Reinterpret<uint4, T>();
            _mulShift._shift = new uint4(x._mulShift._shift, yz._mulShift._shift, w._mulShift._shift).Reinterpret<uint4, T>();
            _bigM = new ulong4(*(ulong*)&x._bigM, *(ulong2*)&yz._bigM, *(ulong*)&w._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x._promises & yz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint> x, Divider<uint> y, Divider<uint2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint4(x._divisor, y._divisor, zw._divisor).Reinterpret<uint4, T>();
            _mulShift._mul = new uint4(x._mulShift._mul, y._mulShift._mul, zw._mulShift._mul).Reinterpret<uint4, T>();
            _mulShift._shift = new uint4(x._mulShift._shift, y._mulShift._shift, zw._mulShift._shift).Reinterpret<uint4, T>();
            _bigM = new ulong4(*(ulong*)&x._bigM, *(ulong*)&y._bigM, *(ulong2*)&zw._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x._promises & y._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint2> xy, Divider<uint2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint4(xy._divisor, zw._divisor).Reinterpret<uint4, T>();
            _mulShift._mul = new uint4(xy._mulShift._mul, zw._mulShift._mul).Reinterpret<uint4, T>();
            _mulShift._shift = new uint4(xy._mulShift._shift, zw._mulShift._shift).Reinterpret<uint4, T>();
            _bigM = new ulong4(*(ulong2*)&xy._bigM, *(ulong2*)&zw._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (xy._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint3> xyz, Divider<uint> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint4(xyz._divisor, w._divisor).Reinterpret<uint4, T>();
            _mulShift._mul = new uint4(xyz._mulShift._mul, w._mulShift._mul).Reinterpret<uint4, T>();
            _mulShift._shift = new uint4(xyz._mulShift._shift, w._mulShift._shift).Reinterpret<uint4, T>();
            _bigM = new ulong4(*(ulong3*)&xyz._bigM, *(ulong*)&w._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (xyz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint> x, Divider<uint3> yzw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint4(x._divisor, yzw._divisor).Reinterpret<uint4, T>();
            _mulShift._mul = new uint4(x._mulShift._mul, yzw._mulShift._mul).Reinterpret<uint4, T>();
            _mulShift._shift = new uint4(x._mulShift._shift, yzw._mulShift._shift).Reinterpret<uint4, T>();
            _bigM = new ulong4(*(ulong*)&x._bigM, *(ulong3*)&yzw._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x._promises & yzw._promises);
        }
        #endregion

        #region uint8
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint> x0, Divider<uint> x1, Divider<uint> x2, Divider<uint> x3, Divider<uint> x4, Divider<uint> x5, Divider<uint> x6, Divider<uint> x7)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint8(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor).Reinterpret<uint8, T>();
            _mulShift._mul = new uint8(x0._mulShift._mul, x1._mulShift._mul, x2._mulShift._mul, x3._mulShift._mul, x4._mulShift._mul, x5._mulShift._mul, x6._mulShift._mul, x7._mulShift._mul).Reinterpret<uint8, T>();
            _mulShift._shift = new uint8(x0._mulShift._shift, x1._mulShift._shift, x2._mulShift._shift, x3._mulShift._shift, x4._mulShift._shift, x5._mulShift._shift, x6._mulShift._shift, x7._mulShift._shift).Reinterpret<uint8, T>();
            _bigM._mulLo = new ulong4(*(ulong*)&x0._bigM, *(ulong*)&x1._bigM, *(ulong*)&x2._bigM, *(ulong*)&x3._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4(*(ulong*)&x4._bigM, *(ulong*)&x5._bigM, *(ulong*)&x6._bigM, *(ulong*)&x7._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint2> x01, Divider<uint2> x23, Divider<uint2> x45, Divider<uint2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint8(x01._divisor, x23._divisor, x45._divisor, x67._divisor).Reinterpret<uint8, T>();
            _mulShift._mul = new uint8(x01._mulShift._mul, x23._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul).Reinterpret<uint8, T>();
            _mulShift._shift = new uint8(x01._mulShift._shift, x23._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift).Reinterpret<uint8, T>();
            _bigM._mulLo = new ulong4(*(ulong2*)&x01._bigM, *(ulong2*)&x23._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4(*(ulong2*)&x45._bigM, *(ulong2*)&x67._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x01._promises & x23._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint2> x01, Divider<uint3> x234, Divider<uint3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint8(x01._divisor, x234._divisor, x567._divisor).Reinterpret<uint8, T>();
            _mulShift._mul = new uint8(x01._mulShift._mul, x234._mulShift._mul, x567._mulShift._mul).Reinterpret<uint8, T>();
            _mulShift._shift = new uint8(x01._mulShift._shift, x234._mulShift._shift, x567._mulShift._shift).Reinterpret<uint8, T>();
            _bigM._mulLo = new ulong4(*(ulong2*)&x01._bigM, (*(ulong3*)&x234._bigM).xy).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4((*(ulong3*)&x234._bigM).z, *(ulong3*)&x567._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x01._promises & x234._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint3> x012, Divider<uint2> x34, Divider<uint3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint8(x012._divisor, x34._divisor, x567._divisor).Reinterpret<uint8, T>();
            _mulShift._mul = new uint8(x012._mulShift._mul, x34._mulShift._mul, x567._mulShift._mul).Reinterpret<uint8, T>();
            _mulShift._shift = new uint8(x012._mulShift._shift, x34._mulShift._shift, x567._mulShift._shift).Reinterpret<uint8, T>();
            _bigM._mulLo = new ulong4(*(ulong3*)&x012._bigM, (*(ulong2*)&x34._bigM).x).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4((*(ulong2*)&x34._bigM).y, *(ulong3*)&x567._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x012._promises & x34._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint3> x012, Divider<uint3> x345, Divider<uint2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint8(x012._divisor, x345._divisor, x67._divisor).Reinterpret<uint8, T>();
            _mulShift._mul = new uint8(x012._mulShift._mul, x345._mulShift._mul, x67._mulShift._mul).Reinterpret<uint8, T>();
            _mulShift._shift = new uint8(x012._mulShift._shift, x345._mulShift._shift, x67._mulShift._shift).Reinterpret<uint8, T>();
            _bigM._mulLo = new ulong4(*(ulong3*)&x012._bigM, (*(ulong3*)&x345._bigM).x).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4((*(ulong3*)&x345._bigM).yx, *(ulong2*)&x67._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x012._promises & x345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint4> x0123, Divider<uint2> x45, Divider<uint2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint8(x0123._divisor, x45._divisor, x67._divisor).Reinterpret<uint8, T>();
            _mulShift._mul = new uint8(x0123._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul).Reinterpret<uint8, T>();
            _mulShift._shift = new uint8(x0123._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift).Reinterpret<uint8, T>();
            _bigM._mulLo = (*(ulong4*)&x0123._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4(*(ulong2*)&x45._bigM, *(ulong2*)&x67._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x0123._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint2> x01, Divider<uint4> x2345, Divider<uint2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint8(x01._divisor, x2345._divisor, x67._divisor).Reinterpret<uint8, T>();
            _mulShift._mul = new uint8(x01._mulShift._mul, x2345._mulShift._mul, x67._mulShift._mul).Reinterpret<uint8, T>();
            _mulShift._shift = new uint8(x01._mulShift._shift, x2345._mulShift._shift, x67._mulShift._shift).Reinterpret<uint8, T>();
            _bigM._mulLo = new ulong4(*(ulong2*)&x01._bigM, (*(ulong4*)&x2345._bigM).xy).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4((*(ulong4*)&x2345._bigM).yz, *(ulong2*)&x67._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x01._promises & x2345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint2> x01, Divider<uint2> x23, Divider<uint4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint8(x01._divisor, x23._divisor, x4567._divisor).Reinterpret<uint8, T>();
            _mulShift._mul = new uint8(x01._mulShift._mul, x23._mulShift._mul, x4567._mulShift._mul).Reinterpret<uint8, T>();
            _mulShift._shift = new uint8(x01._mulShift._shift, x23._mulShift._shift, x4567._mulShift._shift).Reinterpret<uint8, T>();
            _bigM._mulLo = new ulong4(*(ulong2*)&x01._bigM, *(ulong2*)&x23._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = (*(ulong4*)&x4567._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x01._promises & x23._promises & x4567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<uint4> x0123, Divider<uint4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(uint), 8, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new uint8(x0123._divisor, x4567._divisor).Reinterpret<uint8, T>();
            _mulShift._mul = new uint8(x0123._mulShift._mul, x4567._mulShift._mul).Reinterpret<uint8, T>();
            _mulShift._shift = new uint8(x0123._mulShift._shift, x4567._mulShift._shift).Reinterpret<uint8, T>();
            _bigM._mulLo = (*(ulong4*)&x0123._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = (*(ulong4*)&x4567._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(uint)) | (x0123._promises & x4567._promises);
        }
        #endregion


        #region ulong2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong> x, Divider<ulong> y)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 2, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong2(x._divisor, y._divisor).Reinterpret<ulong2, T>();
            _mulShift._mul = new ulong2(x._mulShift._mul, y._mulShift._mul).Reinterpret<ulong2, T>();
            _mulShift._shift = new ulong2(x._mulShift._shift, y._mulShift._shift).Reinterpret<ulong2, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(*(UInt128*)&y._bigM, 1);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (x._promises & y._promises);
        }
        #endregion

        #region ulong3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong> x, Divider<ulong> y, Divider<ulong> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong3(x._divisor, y._divisor, z._divisor).Reinterpret<ulong3, T>();
            _mulShift._mul = new ulong3(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul).Reinterpret<ulong3, T>();
            _mulShift._shift = new ulong3(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift).Reinterpret<ulong3, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(*(UInt128*)&y._bigM, 1);
            _bigM.SetField(*(UInt128*)&z._bigM, 2);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (x._promises & y._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong2> xy, Divider<ulong> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong3(xy._divisor, z._divisor).Reinterpret<ulong3, T>();
            _mulShift._mul = new ulong3(xy._mulShift._mul, z._mulShift._mul).Reinterpret<ulong3, T>();
            _mulShift._shift = new ulong3(xy._mulShift._shift, z._mulShift._shift).Reinterpret<ulong3, T>();
            _bigM.SetField(xy.GetField<Divider<ulong2>, UInt128>(0), 0);
            _bigM.SetField(xy.GetField<Divider<ulong2>, UInt128>(1), 1);
            _bigM.SetField(*(UInt128*)&z._bigM, 1);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (xy._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong> x, Divider<ulong2> yz)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 3, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong3(x._divisor, yz._divisor).Reinterpret<ulong3, T>();
            _mulShift._mul = new ulong3(x._mulShift._mul, yz._mulShift._mul).Reinterpret<ulong3, T>();
            _mulShift._shift = new ulong3(x._mulShift._shift, yz._mulShift._shift).Reinterpret<ulong3, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(yz.GetField<Divider<ulong2>, UInt128>(0), 1);
            _bigM.SetField(yz.GetField<Divider<ulong2>, UInt128>(1), 2);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (x._promises & yz._promises);
        }
        #endregion

        #region ulong4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong> x, Divider<ulong> y, Divider<ulong> z, Divider<ulong> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong4(x._divisor, y._divisor, z._divisor, w._divisor).Reinterpret<ulong4, T>();
            _mulShift._mul = new ulong4(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<ulong4, T>();
            _mulShift._shift = new ulong4(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<ulong4, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(*(UInt128*)&y._bigM, 1);
            _bigM.SetField(*(UInt128*)&z._bigM, 2);
            _bigM.SetField(*(UInt128*)&w._bigM, 3);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (x._promises & y._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong2> xy, Divider<ulong> z, Divider<ulong> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong4(xy._divisor, z._divisor, w._divisor).Reinterpret<ulong4, T>();
            _mulShift._mul = new ulong4(xy._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<ulong4, T>();
            _mulShift._shift = new ulong4(xy._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<ulong4, T>();
            _bigM.SetField(xy.GetField<Divider<ulong2>, UInt128>(1), 0);
            _bigM.SetField(xy.GetField<Divider<ulong2>, UInt128>(1), 1);
            _bigM.SetField(*(UInt128*)&z._bigM, 2);
            _bigM.SetField(*(UInt128*)&w._bigM, 3);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (xy._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong> x, Divider<ulong2> yz, Divider<ulong> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong4(x._divisor, yz._divisor, w._divisor).Reinterpret<ulong4, T>();
            _mulShift._mul = new ulong4(x._mulShift._mul, yz._mulShift._mul, w._mulShift._mul).Reinterpret<ulong4, T>();
            _mulShift._shift = new ulong4(x._mulShift._shift, yz._mulShift._shift, w._mulShift._shift).Reinterpret<ulong4, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(yz.GetField<Divider<ulong2>, UInt128>(1), 1);
            _bigM.SetField(yz.GetField<Divider<ulong2>, UInt128>(1), 2);
            _bigM.SetField(*(UInt128*)&w._bigM, 3);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (x._promises & yz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong> x, Divider<ulong> y, Divider<ulong2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong4(x._divisor, y._divisor, zw._divisor).Reinterpret<ulong4, T>();
            _mulShift._mul = new ulong4(x._mulShift._mul, y._mulShift._mul, zw._mulShift._mul).Reinterpret<ulong4, T>();
            _mulShift._shift = new ulong4(x._mulShift._shift, y._mulShift._shift, zw._mulShift._shift).Reinterpret<ulong4, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(*(UInt128*)&y._bigM, 1);
            _bigM.SetField(zw.GetField<Divider<ulong2>, UInt128>(0), 2);
            _bigM.SetField(zw.GetField<Divider<ulong2>, UInt128>(1), 3);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (x._promises & y._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong2> xy, Divider<ulong2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong4(xy._divisor, zw._divisor).Reinterpret<ulong4, T>();
            _mulShift._mul = new ulong4(xy._mulShift._mul, zw._mulShift._mul).Reinterpret<ulong4, T>();
            _mulShift._shift = new ulong4(xy._mulShift._shift, zw._mulShift._shift).Reinterpret<ulong4, T>();
            _bigM.SetField(xy.GetField<Divider<ulong2>, UInt128>(0), 0);
            _bigM.SetField(xy.GetField<Divider<ulong2>, UInt128>(1), 1);
            _bigM.SetField(zw.GetField<Divider<ulong2>, UInt128>(0), 2);
            _bigM.SetField(zw.GetField<Divider<ulong2>, UInt128>(1), 3);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (xy._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong3> xyz, Divider<ulong> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong4(xyz._divisor, w._divisor).Reinterpret<ulong4, T>();
            _mulShift._mul = new ulong4(xyz._mulShift._mul, w._mulShift._mul).Reinterpret<ulong4, T>();
            _mulShift._shift = new ulong4(xyz._mulShift._shift, w._mulShift._shift).Reinterpret<ulong4, T>();
            _bigM.SetField(xyz.GetField<Divider<ulong3>, UInt128>(0), 0);
            _bigM.SetField(xyz.GetField<Divider<ulong3>, UInt128>(1), 1);
            _bigM.SetField(xyz.GetField<Divider<ulong3>, UInt128>(2), 2);
            _bigM.SetField(*(UInt128*)&w._bigM, 3);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (xyz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<ulong> x, Divider<ulong3> yzw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(ulong), 4, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer);
#endif
            _divisor = new ulong4(x._divisor, yzw._divisor).Reinterpret<ulong4, T>();
            _mulShift._mul = new ulong4(x._mulShift._mul, yzw._mulShift._mul).Reinterpret<ulong4, T>();
            _mulShift._shift = new ulong4(x._mulShift._shift, yzw._mulShift._shift).Reinterpret<ulong4, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(yzw.GetField<Divider<ulong3>, UInt128>(0), 1);
            _bigM.SetField(yzw.GetField<Divider<ulong3>, UInt128>(1), 2);
            _bigM.SetField(yzw.GetField<Divider<ulong3>, UInt128>(2), 3);
            _promises = new DividerPromise(_divisor, Signedness.Unsigned, sizeof(ulong)) | (x._promises & yzw._promises);
        }
        #endregion


        #region sbyte2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x, Divider<sbyte> y)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte2(x._divisor, y._divisor).Reinterpret<sbyte2, T>();
            _bigM = new ushort2(*(ushort*)&x._bigM, *(ushort*)&y._bigM).Reinterpret<ushort2, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x._promises & y._promises);
        }
        #endregion

        #region sbyte3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x, Divider<sbyte> y, Divider<sbyte> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte3(x._divisor, y._divisor, z._divisor).Reinterpret<sbyte3, T>();
            _bigM = new ushort3(*(ushort*)&x._bigM, *(ushort*)&y._bigM, *(ushort*)&z._bigM).Reinterpret<ushort3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x._promises & y._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte2> xy, Divider<sbyte> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte3(xy._divisor, z._divisor).Reinterpret<sbyte3, T>();
            _bigM = new ushort3(*(ushort2*)&xy._bigM, *(ushort*)&z._bigM).Reinterpret<ushort3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (xy._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x, Divider<sbyte2> yz)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte3(x._divisor, yz._divisor).Reinterpret<sbyte3, T>();
            _bigM = new ushort3(*(ushort*)&x._bigM, *(ushort2*)&yz._bigM).Reinterpret<ushort3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x._promises & yz._promises);
        }
        #endregion

        #region sbyte4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x, Divider<sbyte> y, Divider<sbyte> z, Divider<sbyte> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte4(x._divisor, y._divisor, z._divisor, w._divisor).Reinterpret<sbyte4, T>();
            _bigM = new ushort4(*(ushort*)&x._bigM, *(ushort*)&y._bigM, *(ushort*)&z._bigM, *(ushort*)&w._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x._promises & y._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte2> xy, Divider<sbyte> z, Divider<sbyte> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte4(xy._divisor, z._divisor, w._divisor).Reinterpret<sbyte4, T>();
            _bigM = new ushort4(*(ushort2*)&xy._bigM, *(ushort*)&z._bigM, *(ushort*)&w._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (xy._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x, Divider<sbyte2> yz, Divider<sbyte> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte4(x._divisor, yz._divisor, w._divisor).Reinterpret<sbyte4, T>();
            _bigM = new ushort4(*(ushort*)&x._bigM, *(ushort2*)&yz._bigM, *(ushort*)&w._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x._promises & yz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x, Divider<sbyte> y, Divider<sbyte2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte4(x._divisor, y._divisor, zw._divisor).Reinterpret<sbyte4, T>();
            _bigM = new ushort4(*(ushort*)&x._bigM, *(ushort*)&y._bigM, *(ushort2*)&zw._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x._promises & y._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte2> xy, Divider<sbyte2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte4(xy._divisor, zw._divisor).Reinterpret<sbyte4, T>();
            _bigM = new ushort4(*(ushort2*)&xy._bigM, *(ushort2*)&zw._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (xy._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte3> xyz, Divider<sbyte> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte4(xyz._divisor, w._divisor).Reinterpret<sbyte4, T>();
            _bigM = new ushort4(*(ushort3*)&xyz._bigM, *(ushort*)&w._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (xyz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x, Divider<sbyte3> yzw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte4(x._divisor, yzw._divisor).Reinterpret<sbyte4, T>();
            _bigM = new ushort4(*(ushort*)&x._bigM, *(ushort3*)&yzw._bigM).Reinterpret<ushort4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x._promises & yzw._promises);
        }
        #endregion

        #region sbyte8
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x0, Divider<sbyte> x1, Divider<sbyte> x2, Divider<sbyte> x3, Divider<sbyte> x4, Divider<sbyte> x5, Divider<sbyte> x6, Divider<sbyte> x7)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte8(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor).Reinterpret<sbyte8, T>();
            _bigM = new ushort8(*(ushort*)&x0._bigM, *(ushort*)&x1._bigM, *(ushort*)&x2._bigM, *(ushort*)&x3._bigM, *(ushort*)&x4._bigM, *(ushort*)&x5._bigM, *(ushort*)&x6._bigM, *(ushort*)&x7._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte2> x01, Divider<sbyte2> x23, Divider<sbyte2> x45, Divider<sbyte2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte8(x01._divisor, x23._divisor, x45._divisor, x67._divisor).Reinterpret<sbyte8, T>();
            _bigM = new ushort8(*(ushort2*)&x01._bigM, *(ushort2*)&x23._bigM, *(ushort2*)&x45._bigM, *(ushort2*)&x67._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x01._promises & x23._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte2> x01, Divider<sbyte3> x234, Divider<sbyte3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte8(x01._divisor, x234._divisor, x567._divisor).Reinterpret<sbyte8, T>();
            _bigM = new ushort8(*(ushort2*)&x01._bigM, *(ushort3*)&x234._bigM, *(ushort3*)&x567._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x01._promises & x234._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte3> x012, Divider<sbyte2> x34, Divider<sbyte3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte8(x012._divisor, x34._divisor, x567._divisor).Reinterpret<sbyte8, T>();
            _bigM = new ushort8(*(ushort3*)&x012._bigM, *(ushort2*)&x34._bigM, *(ushort3*)&x567._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x012._promises & x34._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte3> x012, Divider<sbyte3> x345, Divider<sbyte2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte8(x012._divisor, x345._divisor, x67._divisor).Reinterpret<sbyte8, T>();
            _bigM = new ushort8(*(ushort3*)&x012._bigM, *(ushort3*)&x345._bigM, *(ushort2*)&x67._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x012._promises & x345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte4> x0123, Divider<sbyte2> x45, Divider<sbyte2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte8(x0123._divisor, x45._divisor, x67._divisor).Reinterpret<sbyte8, T>();
            _bigM = new ushort8(*(ushort4*)&x0123._bigM, *(ushort2*)&x45._bigM, *(ushort2*)&x67._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0123._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte2> x01, Divider<sbyte4> x2345, Divider<sbyte2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte8(x01._divisor, x2345._divisor, x67._divisor).Reinterpret<sbyte8, T>();
            _bigM = new ushort8(*(ushort2*)&x01._bigM, *(ushort4*)&x2345._bigM, *(ushort2*)&x67._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x01._promises & x2345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte2> x01, Divider<sbyte2> x23, Divider<sbyte4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte8(x01._divisor, x23._divisor, x4567._divisor).Reinterpret<sbyte8, T>();
            _bigM = new ushort8(*(ushort2*)&x01._bigM, *(ushort2*)&x23._bigM, *(ushort4*)&x4567._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x01._promises & x23._promises & x4567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte4> x0123, Divider<sbyte4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte8(x0123._divisor, x4567._divisor).Reinterpret<sbyte8, T>();
            _bigM = new ushort8(*(ushort4*)&x0123._bigM, *(ushort4*)&x4567._bigM).Reinterpret<ushort8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0123._promises & x4567._promises);
        }
        #endregion

        #region sbyte16
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x0, Divider<sbyte> x1, Divider<sbyte> x2, Divider<sbyte> x3, Divider<sbyte> x4, Divider<sbyte> x5, Divider<sbyte> x6, Divider<sbyte> x7, Divider<sbyte> x8, Divider<sbyte> x9, Divider<sbyte> x10, Divider<sbyte> x11, Divider<sbyte> x12, Divider<sbyte> x13, Divider<sbyte> x14, Divider<sbyte> x15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor, x8._divisor, x9._divisor, x10._divisor, x11._divisor, x12._divisor, x13._divisor, x14._divisor, x15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort*)&x0._bigM, *(ushort*)&x1._bigM, *(ushort*)&x2._bigM, *(ushort*)&x3._bigM, *(ushort*)&x4._bigM, *(ushort*)&x5._bigM, *(ushort*)&x6._bigM, *(ushort*)&x7._bigM, *(ushort*)&x8._bigM, *(ushort*)&x9._bigM, *(ushort*)&x10._bigM, *(ushort*)&x11._bigM, *(ushort*)&x12._bigM, *(ushort*)&x13._bigM, *(ushort*)&x14._bigM, *(ushort*)&x15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises & x8._promises & x9._promises & x10._promises & x11._promises & x12._promises & x13._promises & x14._promises & x15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte2> x01, Divider<sbyte2> x23, Divider<sbyte2> x45, Divider<sbyte2> x67, Divider<sbyte2> x89, Divider<sbyte2> x10_11, Divider<sbyte2> x12_13, Divider<sbyte2> x14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x01._divisor, x23._divisor, x45._divisor, x67._divisor, x89._divisor, x10_11._divisor, x12_13._divisor, x14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort2*)&x01._bigM, *(ushort2*)&x23._bigM, *(ushort2*)&x45._bigM, *(ushort2*)&x67._bigM, *(ushort2*)&x89._bigM, *(ushort2*)&x10_11._bigM, *(ushort2*)&x12_13._bigM, *(ushort2*)&x14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x01._promises & x23._promises & x45._promises & x67._promises & x89._promises & x10_11._promises & x12_13._promises & x14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte4> x0123, Divider<sbyte4> x4567, Divider<sbyte4> x8_9_10_11, Divider<sbyte4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x0123._divisor, x4567._divisor, x8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort4*)&x0123._bigM, *(ushort4*)&x4567._bigM, *(ushort4*)&x8_9_10_11._bigM, *(ushort4*)&x12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0123._promises & x4567._promises & x8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte4> x0123, Divider<sbyte3> x456, Divider<sbyte3> x789, Divider<sbyte3> x10_11_12, Divider<sbyte3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x0123._divisor, x456._divisor, x789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort4*)&x0123._bigM, *(ushort3*)&x456._bigM, *(ushort3*)&x789._bigM, *(ushort3*)&x10_11_12._bigM, *(ushort3*)&x13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0123._promises & x456._promises & x789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte3> x012, Divider<sbyte4> x3456, Divider<sbyte3> x789, Divider<sbyte3> x10_11_12, Divider<sbyte3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x012._divisor, x3456._divisor, x789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort3*)&x012._bigM, *(ushort4*)&x3456._bigM, *(ushort3*)&x789._bigM, *(ushort3*)&x10_11_12._bigM, *(ushort3*)&x13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x012._promises & x3456._promises & x789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte3> x012, Divider<sbyte3> x345, Divider<sbyte4> x6789, Divider<sbyte3> x10_11_12, Divider<sbyte3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x012._divisor, x345._divisor, x6789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort3*)&x012._bigM, *(ushort3*)&x345._bigM, *(ushort4*)&x6789._bigM, *(ushort3*)&x10_11_12._bigM, *(ushort3*)&x13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x012._promises & x345._promises & x6789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte3> x012, Divider<sbyte3> x345, Divider<sbyte3> x678, Divider<sbyte4> x9_10_11_12, Divider<sbyte3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x012._divisor, x345._divisor, x678._divisor, x9_10_11_12._divisor, x13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort3*)&x012._bigM, *(ushort3*)&x345._bigM, *(ushort3*)&x678._bigM, *(ushort4*)&x9_10_11_12._bigM, *(ushort3*)&x13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x012._promises & x345._promises & x678._promises & x9_10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte3> x012, Divider<sbyte3> x345, Divider<sbyte3> x678, Divider<sbyte3> x9_10_11, Divider<sbyte4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x012._divisor, x345._divisor, x678._divisor, x9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort3*)&x012._bigM, *(ushort3*)&x345._bigM, *(ushort3*)&x678._bigM, *(ushort3*)&x9_10_11._bigM, *(ushort4*)&x12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x012._promises & x345._promises & x678._promises & x9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte8> x01234567, Divider<sbyte4> x8_9_10_11, Divider<sbyte4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x01234567._divisor, x8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort8*)&x01234567._bigM, *(ushort4*)&x8_9_10_11._bigM, *(ushort4*)&x12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x01234567._promises & x8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte4> x0123, Divider<sbyte8> x4_5_6_7_8_9_10_11, Divider<sbyte4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x0123._divisor, x4_5_6_7_8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort4*)&x0123._bigM, *(ushort8*)&x4_5_6_7_8_9_10_11._bigM, *(ushort4*)&x12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0123._promises & x4_5_6_7_8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte4> x0123, Divider<sbyte4> x4567, Divider<sbyte8> x8_9_10_11_12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x0123._divisor, x4567._divisor, x8_9_10_11_12_13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort4*)&x0123._bigM, *(ushort4*)&x4567._bigM, *(ushort8*)&x8_9_10_11_12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0123._promises & x4567._promises & x8_9_10_11_12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte8> x01234567, Divider<sbyte8> x8_9_10_11_12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte16(x01234567._divisor, x8_9_10_11_12_13_14_15._divisor).Reinterpret<sbyte16, T>();
            _bigM = new ushort16(*(ushort8*)&x01234567._bigM, *(ushort8*)&x8_9_10_11_12_13_14_15._bigM).Reinterpret<ushort16, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x01234567._promises & x8_9_10_11_12_13_14_15._promises);
        }
        #endregion

        #region sbyte32
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte> x0, Divider<sbyte> x1, Divider<sbyte> x2, Divider<sbyte> x3, Divider<sbyte> x4, Divider<sbyte> x5, Divider<sbyte> x6, Divider<sbyte> x7, Divider<sbyte> x8, Divider<sbyte> x9, Divider<sbyte> x10, Divider<sbyte> x11, Divider<sbyte> x12, Divider<sbyte> x13, Divider<sbyte> x14, Divider<sbyte> x15, Divider<sbyte> x16, Divider<sbyte> x17, Divider<sbyte> x18, Divider<sbyte> x19, Divider<sbyte> x20, Divider<sbyte> x21, Divider<sbyte> x22, Divider<sbyte> x23, Divider<sbyte> x24, Divider<sbyte> x25, Divider<sbyte> x26, Divider<sbyte> x27, Divider<sbyte> x28, Divider<sbyte> x29, Divider<sbyte> x30, Divider<sbyte> x31)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte32(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor, x8._divisor, x9._divisor, x10._divisor, x11._divisor, x12._divisor, x13._divisor, x14._divisor, x15._divisor, x16._divisor, x17._divisor, x18._divisor, x19._divisor, x20._divisor, x21._divisor, x22._divisor, x23._divisor, x24._divisor, x25._divisor, x26._divisor, x27._divisor, x28._divisor, x29._divisor, x30._divisor, x31._divisor).Reinterpret<sbyte32, T>();
            _bigM._mulLo = new ushort16(*(ushort*)&x0._bigM, *(ushort*)&x1._bigM, *(ushort*)&x2._bigM, *(ushort*)&x3._bigM, *(ushort*)&x4._bigM, *(ushort*)&x5._bigM, *(ushort*)&x6._bigM, *(ushort*)&x7._bigM, *(ushort*)&x8._bigM, *(ushort*)&x9._bigM, *(ushort*)&x10._bigM, *(ushort*)&x11._bigM, *(ushort*)&x12._bigM, *(ushort*)&x13._bigM, *(ushort*)&x14._bigM, *(ushort*)&x15._bigM).Reinterpret<ushort16, T>();
            _bigM._mulHi = new ushort16(*(ushort*)&x16._bigM, *(ushort*)&x17._bigM, *(ushort*)&x18._bigM, *(ushort*)&x19._bigM, *(ushort*)&x20._bigM, *(ushort*)&x21._bigM, *(ushort*)&x22._bigM, *(ushort*)&x23._bigM, *(ushort*)&x24._bigM, *(ushort*)&x25._bigM, *(ushort*)&x26._bigM, *(ushort*)&x27._bigM, *(ushort*)&x28._bigM, *(ushort*)&x29._bigM, *(ushort*)&x30._bigM, *(ushort*)&x31._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises & x8._promises & x9._promises & x10._promises & x11._promises & x12._promises & x13._promises & x14._promises & x15._promises & x16._promises & x17._promises & x18._promises & x19._promises & x20._promises & x21._promises & x22._promises & x23._promises & x24._promises & x25._promises & x26._promises & x27._promises & x28._promises & x29._promises & x30._promises & x31._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte4> x0_3, Divider<sbyte4> x4_7, Divider<sbyte4> x8_11, Divider<sbyte4> x12_15, Divider<sbyte4> x16_19, Divider<sbyte4> x20_23, Divider<sbyte4> x24_27, Divider<sbyte4> x28_31)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte32(x0_3._divisor, x4_7._divisor, x8_11._divisor, x12_15._divisor, x16_19._divisor, x20_23._divisor, x24_27._divisor, x28_31._divisor).Reinterpret<sbyte32, T>();
            _bigM._mulLo = new ushort16(*(ushort4*)&x0_3._bigM, *(ushort4*)&x4_7._bigM, *(ushort4*)&x8_11._bigM, *(ushort4*)&x12_15._bigM).Reinterpret<ushort16, T>();
            _bigM._mulHi = new ushort16(*(ushort4*)&x16_19._bigM, *(ushort4*)&x20_23._bigM, *(ushort4*)&x24_27._bigM, *(ushort4*)&x28_31._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (x0_3._promises & x4_7._promises & x8_11._promises & x12_15._promises & x16_19._promises & x20_23._promises & x24_27._promises & x28_31._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte8> v8_0, Divider<sbyte8> v8_8, Divider<sbyte8> v8_16, Divider<sbyte8> v8_24)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte32(v8_0._divisor, v8_8._divisor, v8_16._divisor, v8_24._divisor).Reinterpret<sbyte32, T>();
            _bigM._mulLo = new ushort16(*(ushort8*)&v8_0._bigM, *(ushort8*)&v8_8._bigM).Reinterpret<ushort16, T>();
            _bigM._mulHi = new ushort16(*(ushort8*)&v8_16._bigM, *(ushort8*)&v8_24._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (v8_0._promises & v8_8._promises & v8_16._promises & v8_24._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte16> v16_0, Divider<sbyte8> v8_16, Divider<sbyte8> v8_24)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte32(v16_0._divisor, v8_16._divisor, v8_24._divisor).Reinterpret<sbyte32, T>();
            _bigM._mulLo = v16_0._bigM.Reinterpret<Divider<sbyte16>.BigM, T>();
            _bigM._mulHi = new ushort16(*(ushort8*)&v8_16._bigM, *(ushort8*)&v8_24._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (v16_0._promises & v8_16._promises & v8_24._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte8> v8_0, Divider<sbyte16> v16_8, Divider<sbyte8> v8_24)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte32(v8_0._divisor, v16_8._divisor, v8_24._divisor).Reinterpret<sbyte32, T>();
            _bigM._mulLo = new ushort16(*(ushort8*)&v8_0._bigM, *(ushort8*)&v16_8._bigM._mulLo).Reinterpret<ushort16, T>();
            _bigM._mulHi = new ushort16(*(ushort8*)&v16_8._bigM._mulHi, *(ushort8*)&v8_24._bigM).Reinterpret<ushort16, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (v8_0._promises & v16_8._promises & v8_24._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte8> v8_0, Divider<sbyte8> v8_8, Divider<sbyte16> v16_16)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte32(v8_0._divisor, v8_8._divisor, v16_16._divisor).Reinterpret<sbyte32, T>();
            _bigM._mulLo = new ushort16(*(ushort8*)&v8_0._bigM, *(ushort8*)&v8_8._bigM).Reinterpret<ushort16, T>();
            _bigM._mulHi = v16_16._bigM.Reinterpret<Divider<sbyte16>.BigM, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (v8_0._promises & v8_8._promises & v16_16._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<sbyte16> v16_0, Divider<sbyte16> v16_16)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(sbyte), 32, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new sbyte32(v16_0._divisor, v16_16._divisor).Reinterpret<sbyte32, T>();
            _bigM._mulLo = v16_0._bigM.Reinterpret<Divider<sbyte16>.BigM, T>();
            _bigM._mulHi = v16_16._bigM.Reinterpret<Divider<sbyte16>.BigM, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(sbyte)) | (v16_0._promises & v16_16._promises);
        }
        #endregion


        #region short2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short> x, Divider<short> y)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short2(x._divisor, y._divisor).Reinterpret<short2, T>();
            _mulShift._mul = new short2(x._mulShift._mul, y._mulShift._mul).Reinterpret<short2, T>();
            _mulShift._shift = new short2(x._mulShift._shift, y._mulShift._shift).Reinterpret<short2, T>();
            _bigM = new uint2(*(uint*)&x._bigM, *(uint*)&y._bigM).Reinterpret<uint2, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x._promises & y._promises);
        }
        #endregion

        #region short3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short> x, Divider<short> y, Divider<short> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short3(x._divisor, y._divisor, z._divisor).Reinterpret<short3, T>();
            _mulShift._mul = new short3(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul).Reinterpret<short3, T>();
            _mulShift._shift = new short3(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift).Reinterpret<short3, T>();
            _bigM = new uint3(*(uint*)&x._bigM, *(uint*)&y._bigM, *(uint*)&z._bigM).Reinterpret<uint3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x._promises & y._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short2> xy, Divider<short> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short3(xy._divisor, z._divisor).Reinterpret<short3, T>();
            _mulShift._mul = new short3(xy._mulShift._mul, z._mulShift._mul).Reinterpret<short3, T>();
            _mulShift._shift = new short3(xy._mulShift._shift, z._mulShift._shift).Reinterpret<short3, T>();
            _bigM = new uint3(*(uint2*)&xy._bigM, *(uint*)&z._bigM).Reinterpret<uint3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (xy._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short> x, Divider<short2> yz)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short3(x._divisor, yz._divisor).Reinterpret<short3, T>();
            _mulShift._mul = new short3(x._mulShift._mul, yz._mulShift._mul).Reinterpret<short3, T>();
            _mulShift._shift = new short3(x._mulShift._shift, yz._mulShift._shift).Reinterpret<short3, T>();
            _bigM = new uint3(*(uint*)&x._bigM, *(uint2*)&yz._bigM).Reinterpret<uint3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x._promises & yz._promises);
        }
        #endregion

        #region short4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short> x, Divider<short> y, Divider<short> z, Divider<short> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short4(x._divisor, y._divisor, z._divisor, w._divisor).Reinterpret<short4, T>();
            _mulShift._mul = new short4(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<short4, T>();
            _mulShift._shift = new short4(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<short4, T>();
            _bigM = new uint4(*(uint*)&x._bigM, *(uint*)&y._bigM, *(uint*)&z._bigM, *(uint*)&w._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x._promises & y._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short2> xy, Divider<short> z, Divider<short> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short4(xy._divisor, z._divisor, w._divisor).Reinterpret<short4, T>();
            _mulShift._mul = new short4(xy._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<short4, T>();
            _mulShift._shift = new short4(xy._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<short4, T>();
            _bigM = new uint4(*(uint2*)&xy._bigM, *(uint*)&z._bigM, *(uint*)&w._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (xy._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short> x, Divider<short2> yz, Divider<short> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short4(x._divisor, yz._divisor, w._divisor).Reinterpret<short4, T>();
            _mulShift._mul = new short4(x._mulShift._mul, yz._mulShift._mul, w._mulShift._mul).Reinterpret<short4, T>();
            _mulShift._shift = new short4(x._mulShift._shift, yz._mulShift._shift, w._mulShift._shift).Reinterpret<short4, T>();
            _bigM = new uint4(*(uint*)&x._bigM, *(uint2*)&yz._bigM, *(uint*)&w._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x._promises & yz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short> x, Divider<short> y, Divider<short2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short4(x._divisor, y._divisor, zw._divisor).Reinterpret<short4, T>();
            _mulShift._mul = new short4(x._mulShift._mul, y._mulShift._mul, zw._mulShift._mul).Reinterpret<short4, T>();
            _mulShift._shift = new short4(x._mulShift._shift, y._mulShift._shift, zw._mulShift._shift).Reinterpret<short4, T>();
            _bigM = new uint4(*(uint*)&x._bigM, *(uint*)&y._bigM, *(uint2*)&zw._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x._promises & y._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short2> xy, Divider<short2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short4(xy._divisor, zw._divisor).Reinterpret<short4, T>();
            _mulShift._mul = new short4(xy._mulShift._mul, zw._mulShift._mul).Reinterpret<short4, T>();
            _mulShift._shift = new short4(xy._mulShift._shift, zw._mulShift._shift).Reinterpret<short4, T>();
            _bigM = new uint4(*(uint2*)&xy._bigM, *(uint2*)&zw._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (xy._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short3> xyz, Divider<short> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short4(xyz._divisor, w._divisor).Reinterpret<short4, T>();
            _mulShift._mul = new short4(xyz._mulShift._mul, w._mulShift._mul).Reinterpret<short4, T>();
            _mulShift._shift = new short4(xyz._mulShift._shift, w._mulShift._shift).Reinterpret<short4, T>();
            _bigM = new uint4(*(uint3*)&xyz._bigM, *(uint*)&w._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (xyz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short> x, Divider<short3> yzw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short4(x._divisor, yzw._divisor).Reinterpret<short4, T>();
            _mulShift._mul = new short4(x._mulShift._mul, yzw._mulShift._mul).Reinterpret<short4, T>();
            _mulShift._shift = new short4(x._mulShift._shift, yzw._mulShift._shift).Reinterpret<short4, T>();
            _bigM = new uint4(*(uint*)&x._bigM, *(uint3*)&yzw._bigM).Reinterpret<uint4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x._promises & yzw._promises);
        }
        #endregion

        #region short8
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short> x0, Divider<short> x1, Divider<short> x2, Divider<short> x3, Divider<short> x4, Divider<short> x5, Divider<short> x6, Divider<short> x7)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short8(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor).Reinterpret<short8, T>();
            _mulShift._mul = new short8(x0._mulShift._mul, x1._mulShift._mul, x2._mulShift._mul, x3._mulShift._mul, x4._mulShift._mul, x5._mulShift._mul, x6._mulShift._mul, x7._mulShift._mul).Reinterpret<short8, T>();
            _mulShift._shift = new short8(x0._mulShift._shift, x1._mulShift._shift, x2._mulShift._shift, x3._mulShift._shift, x4._mulShift._shift, x5._mulShift._shift, x6._mulShift._shift, x7._mulShift._shift).Reinterpret<short8, T>();
            _bigM = new uint8(*(uint*)&x0._bigM, *(uint*)&x1._bigM, *(uint*)&x2._bigM, *(uint*)&x3._bigM, *(uint*)&x4._bigM, *(uint*)&x5._bigM, *(uint*)&x6._bigM, *(uint*)&x7._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short2> x01, Divider<short2> x23, Divider<short2> x45, Divider<short2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short8(x01._divisor, x23._divisor, x45._divisor, x67._divisor).Reinterpret<short8, T>();
            _mulShift._mul = new short8(x01._mulShift._mul, x23._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul).Reinterpret<short8, T>();
            _mulShift._shift = new short8(x01._mulShift._shift, x23._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift).Reinterpret<short8, T>();
            _bigM = new uint8(*(uint2*)&x01._bigM, *(uint2*)&x23._bigM, *(uint2*)&x45._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x01._promises & x23._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short2> x01, Divider<short3> x234, Divider<short3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short8(x01._divisor, x234._divisor, x567._divisor).Reinterpret<short8, T>();
            _mulShift._mul = new short8(x01._mulShift._mul, x234._mulShift._mul, x567._mulShift._mul).Reinterpret<short8, T>();
            _mulShift._shift = new short8(x01._mulShift._shift, x234._mulShift._shift, x567._mulShift._shift).Reinterpret<short8, T>();
            _bigM = new uint8(*(uint2*)&x01._bigM, *(uint3*)&x234._bigM, *(uint3*)&x567._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x01._promises & x234._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short3> x012, Divider<short2> x34, Divider<short3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short8(x012._divisor, x34._divisor, x567._divisor).Reinterpret<short8, T>();
            _mulShift._mul = new short8(x012._mulShift._mul, x34._mulShift._mul, x567._mulShift._mul).Reinterpret<short8, T>();
            _mulShift._shift = new short8(x012._mulShift._shift, x34._mulShift._shift, x567._mulShift._shift).Reinterpret<short8, T>();
            _bigM = new uint8(*(uint3*)&x012._bigM, *(uint2*)&x34._bigM, *(uint3*)&x567._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x012._promises & x34._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short3> x012, Divider<short3> x345, Divider<short2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short8(x012._divisor, x345._divisor, x67._divisor).Reinterpret<short8, T>();
            _mulShift._mul = new short8(x012._mulShift._mul, x345._mulShift._mul, x67._mulShift._mul).Reinterpret<short8, T>();
            _mulShift._shift = new short8(x012._mulShift._shift, x345._mulShift._shift, x67._mulShift._shift).Reinterpret<short8, T>();
            _bigM = new uint8(*(uint3*)&x012._bigM, *(uint3*)&x345._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x012._promises & x345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short4> x0123, Divider<short2> x45, Divider<short2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short8(x0123._divisor, x45._divisor, x67._divisor).Reinterpret<short8, T>();
            _mulShift._mul = new short8(x0123._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul).Reinterpret<short8, T>();
            _mulShift._shift = new short8(x0123._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift).Reinterpret<short8, T>();
            _bigM = new uint8(*(uint4*)&x0123._bigM, *(uint2*)&x45._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x0123._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short2> x01, Divider<short4> x2345, Divider<short2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short8(x01._divisor, x2345._divisor, x67._divisor).Reinterpret<short8, T>();
            _mulShift._mul = new short8(x01._mulShift._mul, x2345._mulShift._mul, x67._mulShift._mul).Reinterpret<short8, T>();
            _mulShift._shift = new short8(x01._mulShift._shift, x2345._mulShift._shift, x67._mulShift._shift).Reinterpret<short8, T>();
            _bigM = new uint8(*(uint2*)&x01._bigM, *(uint4*)&x2345._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x01._promises & x2345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short2> x01, Divider<short2> x23, Divider<short4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short8(x01._divisor, x23._divisor, x4567._divisor).Reinterpret<short8, T>();
            _mulShift._mul = new short8(x01._mulShift._mul, x23._mulShift._mul, x4567._mulShift._mul).Reinterpret<short8, T>();
            _mulShift._shift = new short8(x01._mulShift._shift, x23._mulShift._shift, x4567._mulShift._shift).Reinterpret<short8, T>();
            _bigM = new uint8(*(uint2*)&x01._bigM, *(uint2*)&x23._bigM, *(uint4*)&x4567._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x01._promises & x23._promises & x4567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short4> x0123, Divider<short4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short8(x0123._divisor, x4567._divisor).Reinterpret<short8, T>();
            _mulShift._mul = new short8(x0123._mulShift._mul, x4567._mulShift._mul).Reinterpret<short8, T>();
            _mulShift._shift = new short8(x0123._mulShift._shift, x4567._mulShift._shift).Reinterpret<short8, T>();
            _bigM = new uint8(*(uint4*)&x0123._bigM, *(uint4*)&x4567._bigM).Reinterpret<uint8, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x0123._promises & x4567._promises);
        }
        #endregion

        #region short16
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short> x0, Divider<short> x1, Divider<short> x2, Divider<short> x3, Divider<short> x4, Divider<short> x5, Divider<short> x6, Divider<short> x7, Divider<short> x8, Divider<short> x9, Divider<short> x10, Divider<short> x11, Divider<short> x12, Divider<short> x13, Divider<short> x14, Divider<short> x15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor, x8._divisor, x9._divisor, x10._divisor, x11._divisor, x12._divisor, x13._divisor, x14._divisor, x15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x0._mulShift._mul, x1._mulShift._mul, x2._mulShift._mul, x3._mulShift._mul, x4._mulShift._mul, x5._mulShift._mul, x6._mulShift._mul, x7._mulShift._mul, x8._mulShift._mul, x9._mulShift._mul, x10._mulShift._mul, x11._mulShift._mul, x12._mulShift._mul, x13._mulShift._mul, x14._mulShift._mul, x15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x0._mulShift._shift, x1._mulShift._shift, x2._mulShift._shift, x3._mulShift._shift, x4._mulShift._shift, x5._mulShift._shift, x6._mulShift._shift, x7._mulShift._shift, x8._mulShift._shift, x9._mulShift._shift, x10._mulShift._shift, x11._mulShift._shift, x12._mulShift._shift, x13._mulShift._shift, x14._mulShift._shift, x15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(*(uint*)&x0._bigM, *(uint*)&x1._bigM, *(uint*)&x2._bigM, *(uint*)&x3._bigM, *(uint*)&x4._bigM, *(uint*)&x5._bigM, *(uint*)&x6._bigM, *(uint*)&x7._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(*(uint*)&x8._bigM, *(uint*)&x9._bigM, *(uint*)&x10._bigM, *(uint*)&x11._bigM, *(uint*)&x12._bigM, *(uint*)&x13._bigM, *(uint*)&x14._bigM, *(uint*)&x15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises & x8._promises & x9._promises & x10._promises & x11._promises & x12._promises & x13._promises & x14._promises & x15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short2> x01, Divider<short2> x23, Divider<short2> x45, Divider<short2> x67, Divider<short2> x89, Divider<short2> x10_11, Divider<short2> x12_13, Divider<short2> x14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x01._divisor, x23._divisor, x45._divisor, x67._divisor, x89._divisor, x10_11._divisor, x12_13._divisor, x14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x01._mulShift._mul, x23._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul, x89._mulShift._mul, x10_11._mulShift._mul, x12_13._mulShift._mul, x14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x01._mulShift._shift, x23._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift, x89._mulShift._shift, x10_11._mulShift._shift, x12_13._mulShift._shift, x14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(*(uint2*)&x01._bigM, *(uint2*)&x23._bigM, *(uint2*)&x45._bigM, *(uint2*)&x67._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(*(uint2*)&x89._bigM, *(uint2*)&x10_11._bigM, *(uint2*)&x12_13._bigM, *(uint2*)&x14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x01._promises & x23._promises & x45._promises & x67._promises & x89._promises & x10_11._promises & x12_13._promises & x14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short4> x0123, Divider<short4> x4567, Divider<short4> x8_9_10_11, Divider<short4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x0123._divisor, x4567._divisor, x8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x0123._mulShift._mul, x4567._mulShift._mul, x8_9_10_11._mulShift._mul, x12_13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x0123._mulShift._shift, x4567._mulShift._shift, x8_9_10_11._mulShift._shift, x12_13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(*(uint4*)&x0123._bigM, *(uint4*)&x4567._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(*(uint4*)&x8_9_10_11._bigM, *(uint4*)&x12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x0123._promises & x4567._promises & x8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short4> x0123, Divider<short3> x456, Divider<short3> x789, Divider<short3> x10_11_12, Divider<short3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x0123._divisor, x456._divisor, x789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x0123._mulShift._mul, x456._mulShift._mul, x789._mulShift._mul, x10_11_12._mulShift._mul, x13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x0123._mulShift._shift, x456._mulShift._shift, x789._mulShift._shift, x10_11_12._mulShift._shift, x13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(*(uint4*)&x0123._bigM, new uint4(*(uint3*)&x456._bigM, (*(uint3*)&x789._bigM).x)).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8((*(uint3*)&x789._bigM).yz, *(uint3*)&x10_11_12._bigM, *(uint3*)&x13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x0123._promises & x456._promises & x789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short3> x012, Divider<short4> x3456, Divider<short3> x789, Divider<short3> x10_11_12, Divider<short3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x012._divisor, x3456._divisor, x789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x012._mulShift._mul, x3456._mulShift._mul, x789._mulShift._mul, x10_11_12._mulShift._mul, x13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x012._mulShift._shift, x3456._mulShift._shift, x789._mulShift._shift, x10_11_12._mulShift._shift, x13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(new uint4(*(uint3*)&x012._bigM, (*(uint4*)&x3456._bigM).x), new uint4((*(uint4*)&x3456._bigM).yzw, (*(uint3*)&x789._bigM).x)).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8((*(uint3*)&x789._bigM).yz, *(uint3*)&x10_11_12._bigM, *(uint3*)&x13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x012._promises & x3456._promises & x789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short3> x012, Divider<short3> x345, Divider<short4> x6789, Divider<short3> x10_11_12, Divider<short3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x012._divisor, x345._divisor, x6789._divisor, x10_11_12._divisor, x13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x012._mulShift._mul, x345._mulShift._mul, x6789._mulShift._mul, x10_11_12._mulShift._mul, x13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x012._mulShift._shift, x345._mulShift._shift, x6789._mulShift._shift, x10_11_12._mulShift._shift, x13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(*(uint3*)&x012._bigM, *(uint3*)&x345._bigM, (*(uint4*)&x6789._bigM).xy).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8((*(uint4*)&x6789._bigM).zw, *(uint3*)&x10_11_12._bigM, *(uint3*)&x13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x012._promises & x345._promises & x6789._promises & x10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short3> x012, Divider<short3> x345, Divider<short3> x678, Divider<short4> x9_10_11_12, Divider<short3> x13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x012._divisor, x345._divisor, x678._divisor, x9_10_11_12._divisor, x13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x012._mulShift._mul, x345._mulShift._mul, x678._mulShift._mul, x9_10_11_12._mulShift._mul, x13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x012._mulShift._shift, x345._mulShift._shift, x678._mulShift._shift, x9_10_11_12._mulShift._shift, x13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(*(uint3*)&x012._bigM, *(uint3*)&x345._bigM, (*(uint3*)&x678._bigM).xy).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(new uint4((*(uint3*)&x678._bigM).z, (*(uint4*)&x9_10_11_12._bigM).xyz), new uint4((*(uint4*)&x9_10_11_12._bigM).w, *(uint3*)&x13_14_15._bigM)).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x012._promises & x345._promises & x678._promises & x9_10_11_12._promises & x13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short3> x012, Divider<short3> x345, Divider<short3> x678, Divider<short3> x9_10_11, Divider<short4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x012._divisor, x345._divisor, x678._divisor, x9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x012._mulShift._mul, x345._mulShift._mul, x678._mulShift._mul, x9_10_11._mulShift._mul, x12_13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x012._mulShift._shift, x345._mulShift._shift, x678._mulShift._shift, x9_10_11._mulShift._shift, x12_13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(*(uint3*)&x012._bigM, *(uint3*)&x345._bigM, (*(uint3*)&x678._bigM).xy).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(new uint4((*(uint3*)&x678._bigM).z, *(uint3*)&x9_10_11._bigM), *(uint4*)&x12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x012._promises & x345._promises & x678._promises & x9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short8> x01234567, Divider<short4> x8_9_10_11, Divider<short4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x01234567._divisor, x8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x01234567._mulShift._mul, x8_9_10_11._mulShift._mul, x12_13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x01234567._mulShift._shift, x8_9_10_11._mulShift._shift, x12_13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = (*(uint8*)&x01234567._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8(*(uint4*)&x8_9_10_11._bigM, *(uint4*)&x12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x01234567._promises & x8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short4> x0123, Divider<short8> x4_5_6_7_8_9_10_11, Divider<short4> x12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x0123._divisor, x4_5_6_7_8_9_10_11._divisor, x12_13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x0123._mulShift._mul, x4_5_6_7_8_9_10_11._mulShift._mul, x12_13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x0123._mulShift._shift, x4_5_6_7_8_9_10_11._mulShift._shift, x12_13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(*(uint4*)&x0123._bigM, (*(uint8*)&x4_5_6_7_8_9_10_11._bigM).v4_0).Reinterpret<uint8, T>();
            _bigM._mulHi = new uint8((*(uint8*)&x4_5_6_7_8_9_10_11._bigM).v4_4, *(uint4*)&x12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x0123._promises & x4_5_6_7_8_9_10_11._promises & x12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short4> x0123, Divider<short4> x4567, Divider<short8> x8_9_10_11_12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x0123._divisor, x4567._divisor, x8_9_10_11_12_13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x0123._mulShift._mul, x4567._mulShift._mul, x8_9_10_11_12_13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x0123._mulShift._shift, x4567._mulShift._shift, x8_9_10_11_12_13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = new uint8(*(uint4*)&x0123._bigM, *(uint4*)&x4567._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = (*(uint8*)&x8_9_10_11_12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x0123._promises & x4567._promises & x8_9_10_11_12_13_14_15._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<short8> x01234567, Divider<short8> x8_9_10_11_12_13_14_15)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(short), 16, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new short16(x01234567._divisor, x8_9_10_11_12_13_14_15._divisor).Reinterpret<short16, T>();
            _mulShift._mul = new short16(x01234567._mulShift._mul, x8_9_10_11_12_13_14_15._mulShift._mul).Reinterpret<short16, T>();
            _mulShift._shift = new short16(x01234567._mulShift._shift, x8_9_10_11_12_13_14_15._mulShift._shift).Reinterpret<short16, T>();
            _bigM._mulLo = (*(uint8*)&x01234567._bigM).Reinterpret<uint8, T>();
            _bigM._mulHi = (*(uint8*)&x8_9_10_11_12_13_14_15._bigM).Reinterpret<uint8, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(short)) | (x01234567._promises & x8_9_10_11_12_13_14_15._promises);
        }
        #endregion


        #region int2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int> x, Divider<int> y)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int2(x._divisor, y._divisor).Reinterpret<int2, T>();
            _mulShift._mul = new int2(x._mulShift._mul, y._mulShift._mul).Reinterpret<int2, T>();
            _mulShift._shift = new int2(x._mulShift._shift, y._mulShift._shift).Reinterpret<int2, T>();
            _bigM = new ulong2(*(ulong*)&x._bigM, *(ulong*)&y._bigM).Reinterpret<ulong2, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x._promises & y._promises);
        }
        #endregion

        #region int3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int> x, Divider<int> y, Divider<int> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int3(x._divisor, y._divisor, z._divisor).Reinterpret<int3, T>();
            _mulShift._mul = new int3(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul).Reinterpret<int3, T>();
            _mulShift._shift = new int3(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift).Reinterpret<int3, T>();
            _bigM = new ulong3(*(ulong*)&x._bigM, *(ulong*)&y._bigM, *(ulong*)&z._bigM).Reinterpret<ulong3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x._promises & y._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int2> xy, Divider<int> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int3(xy._divisor, z._divisor).Reinterpret<int3, T>();
            _mulShift._mul = new int3(xy._mulShift._mul, z._mulShift._mul).Reinterpret<int3, T>();
            _mulShift._shift = new int3(xy._mulShift._shift, z._mulShift._shift).Reinterpret<int3, T>();
            _bigM = new ulong3(*(ulong2*)&xy._bigM, *(ulong*)&z._bigM).Reinterpret<ulong3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (xy._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int> x, Divider<int2> yz)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int3(x._divisor, yz._divisor).Reinterpret<int3, T>();
            _mulShift._mul = new int3(x._mulShift._mul, yz._mulShift._mul).Reinterpret<int3, T>();
            _mulShift._shift = new int3(x._mulShift._shift, yz._mulShift._shift).Reinterpret<int3, T>();
            _bigM = new ulong3(*(ulong*)&x._bigM, *(ulong2*)&yz._bigM).Reinterpret<ulong3, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x._promises & yz._promises);
        }
        #endregion

        #region int4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int> x, Divider<int> y, Divider<int> z, Divider<int> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int4(x._divisor, y._divisor, z._divisor, w._divisor).Reinterpret<int4, T>();
            _mulShift._mul = new int4(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<int4, T>();
            _mulShift._shift = new int4(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<int4, T>();
            _bigM = new ulong4(*(ulong*)&x._bigM, *(ulong*)&y._bigM, *(ulong*)&z._bigM, *(ulong*)&w._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x._promises & y._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int2> xy, Divider<int> z, Divider<int> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int4(xy._divisor, z._divisor, w._divisor).Reinterpret<int4, T>();
            _mulShift._mul = new int4(xy._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<int4, T>();
            _mulShift._shift = new int4(xy._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<int4, T>();
            _bigM = new ulong4(*(ulong2*)&xy._bigM, *(ulong*)&z._bigM, *(ulong*)&w._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (xy._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int> x, Divider<int2> yz, Divider<int> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int4(x._divisor, yz._divisor, w._divisor).Reinterpret<int4, T>();
            _mulShift._mul = new int4(x._mulShift._mul, yz._mulShift._mul, w._mulShift._mul).Reinterpret<int4, T>();
            _mulShift._shift = new int4(x._mulShift._shift, yz._mulShift._shift, w._mulShift._shift).Reinterpret<int4, T>();
            _bigM = new ulong4(*(ulong*)&x._bigM, *(ulong2*)&yz._bigM, *(ulong*)&w._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x._promises & yz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int> x, Divider<int> y, Divider<int2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int4(x._divisor, y._divisor, zw._divisor).Reinterpret<int4, T>();
            _mulShift._mul = new int4(x._mulShift._mul, y._mulShift._mul, zw._mulShift._mul).Reinterpret<int4, T>();
            _mulShift._shift = new int4(x._mulShift._shift, y._mulShift._shift, zw._mulShift._shift).Reinterpret<int4, T>();
            _bigM = new ulong4(*(ulong*)&x._bigM, *(ulong*)&y._bigM, *(ulong2*)&zw._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x._promises & y._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int2> xy, Divider<int2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int4(xy._divisor, zw._divisor).Reinterpret<int4, T>();
            _mulShift._mul = new int4(xy._mulShift._mul, zw._mulShift._mul).Reinterpret<int4, T>();
            _mulShift._shift = new int4(xy._mulShift._shift, zw._mulShift._shift).Reinterpret<int4, T>();
            _bigM = new ulong4(*(ulong2*)&xy._bigM, *(ulong2*)&zw._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (xy._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int3> xyz, Divider<int> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int4(xyz._divisor, w._divisor).Reinterpret<int4, T>();
            _mulShift._mul = new int4(xyz._mulShift._mul, w._mulShift._mul).Reinterpret<int4, T>();
            _mulShift._shift = new int4(xyz._mulShift._shift, w._mulShift._shift).Reinterpret<int4, T>();
            _bigM = new ulong4(*(ulong3*)&xyz._bigM, *(ulong*)&w._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (xyz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int> x, Divider<int3> yzw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int4(x._divisor, yzw._divisor).Reinterpret<int4, T>();
            _mulShift._mul = new int4(x._mulShift._mul, yzw._mulShift._mul).Reinterpret<int4, T>();
            _mulShift._shift = new int4(x._mulShift._shift, yzw._mulShift._shift).Reinterpret<int4, T>();
            _bigM = new ulong4(*(ulong*)&x._bigM, *(ulong3*)&yzw._bigM).Reinterpret<ulong4, BigM>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x._promises & yzw._promises);
        }
        #endregion

        #region int8
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int> x0, Divider<int> x1, Divider<int> x2, Divider<int> x3, Divider<int> x4, Divider<int> x5, Divider<int> x6, Divider<int> x7)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int8(x0._divisor, x1._divisor, x2._divisor, x3._divisor, x4._divisor, x5._divisor, x6._divisor, x7._divisor).Reinterpret<int8, T>();
            _mulShift._mul = new int8(x0._mulShift._mul, x1._mulShift._mul, x2._mulShift._mul, x3._mulShift._mul, x4._mulShift._mul, x5._mulShift._mul, x6._mulShift._mul, x7._mulShift._mul).Reinterpret<int8, T>();
            _mulShift._shift = new int8(x0._mulShift._shift, x1._mulShift._shift, x2._mulShift._shift, x3._mulShift._shift, x4._mulShift._shift, x5._mulShift._shift, x6._mulShift._shift, x7._mulShift._shift).Reinterpret<int8, T>();
            _bigM._mulLo = new ulong4(*(ulong*)&x0._bigM, *(ulong*)&x1._bigM, *(ulong*)&x2._bigM, *(ulong*)&x3._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4(*(ulong*)&x4._bigM, *(ulong*)&x5._bigM, *(ulong*)&x6._bigM, *(ulong*)&x7._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x0._promises & x1._promises & x2._promises & x3._promises & x4._promises & x5._promises & x6._promises & x7._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int2> x01, Divider<int2> x23, Divider<int2> x45, Divider<int2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int8(x01._divisor, x23._divisor, x45._divisor, x67._divisor).Reinterpret<int8, T>();
            _mulShift._mul = new int8(x01._mulShift._mul, x23._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul).Reinterpret<int8, T>();
            _mulShift._shift = new int8(x01._mulShift._shift, x23._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift).Reinterpret<int8, T>();
            _bigM._mulLo = new ulong4(*(ulong2*)&x01._bigM, *(ulong2*)&x23._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4(*(ulong2*)&x45._bigM, *(ulong2*)&x67._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x01._promises & x23._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int2> x01, Divider<int3> x234, Divider<int3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int8(x01._divisor, x234._divisor, x567._divisor).Reinterpret<int8, T>();
            _mulShift._mul = new int8(x01._mulShift._mul, x234._mulShift._mul, x567._mulShift._mul).Reinterpret<int8, T>();
            _mulShift._shift = new int8(x01._mulShift._shift, x234._mulShift._shift, x567._mulShift._shift).Reinterpret<int8, T>();
            _bigM._mulLo = new ulong4(*(ulong2*)&x01._bigM, (*(ulong3*)&x234._bigM).xy).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4((*(ulong3*)&x234._bigM).z, *(ulong3*)&x567._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x01._promises & x234._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int3> x012, Divider<int2> x34, Divider<int3> x567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int8(x012._divisor, x34._divisor, x567._divisor).Reinterpret<int8, T>();
            _mulShift._mul = new int8(x012._mulShift._mul, x34._mulShift._mul, x567._mulShift._mul).Reinterpret<int8, T>();
            _mulShift._shift = new int8(x012._mulShift._shift, x34._mulShift._shift, x567._mulShift._shift).Reinterpret<int8, T>();
            _bigM._mulLo = new ulong4(*(ulong3*)&x012._bigM, (*(ulong2*)&x34._bigM).x).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4((*(ulong2*)&x34._bigM).y, *(ulong3*)&x567._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x012._promises & x34._promises & x567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int3> x012, Divider<int3> x345, Divider<int2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int8(x012._divisor, x345._divisor, x67._divisor).Reinterpret<int8, T>();
            _mulShift._mul = new int8(x012._mulShift._mul, x345._mulShift._mul, x67._mulShift._mul).Reinterpret<int8, T>();
            _mulShift._shift = new int8(x012._mulShift._shift, x345._mulShift._shift, x67._mulShift._shift).Reinterpret<int8, T>();
            _bigM._mulLo = new ulong4(*(ulong3*)&x012._bigM, (*(ulong3*)&x345._bigM).x).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4((*(ulong3*)&x345._bigM).yx, *(ulong2*)&x67._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x012._promises & x345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int4> x0123, Divider<int2> x45, Divider<int2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int8(x0123._divisor, x45._divisor, x67._divisor).Reinterpret<int8, T>();
            _mulShift._mul = new int8(x0123._mulShift._mul, x45._mulShift._mul, x67._mulShift._mul).Reinterpret<int8, T>();
            _mulShift._shift = new int8(x0123._mulShift._shift, x45._mulShift._shift, x67._mulShift._shift).Reinterpret<int8, T>();
            _bigM._mulLo = (*(ulong4*)&x0123._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4(*(ulong2*)&x45._bigM, *(ulong2*)&x67._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x0123._promises & x45._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int2> x01, Divider<int4> x2345, Divider<int2> x67)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int8(x01._divisor, x2345._divisor, x67._divisor).Reinterpret<int8, T>();
            _mulShift._mul = new int8(x01._mulShift._mul, x2345._mulShift._mul, x67._mulShift._mul).Reinterpret<int8, T>();
            _mulShift._shift = new int8(x01._mulShift._shift, x2345._mulShift._shift, x67._mulShift._shift).Reinterpret<int8, T>();
            _bigM._mulLo = new ulong4(*(ulong2*)&x01._bigM, (*(ulong4*)&x2345._bigM).xy).Reinterpret<ulong4, T>();
            _bigM._mulHi = new ulong4((*(ulong4*)&x2345._bigM).yz, *(ulong2*)&x67._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x01._promises & x2345._promises & x67._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int2> x01, Divider<int2> x23, Divider<int4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int8(x01._divisor, x23._divisor, x4567._divisor).Reinterpret<int8, T>();
            _mulShift._mul = new int8(x01._mulShift._mul, x23._mulShift._mul, x4567._mulShift._mul).Reinterpret<int8, T>();
            _mulShift._shift = new int8(x01._mulShift._shift, x23._mulShift._shift, x4567._mulShift._shift).Reinterpret<int8, T>();
            _bigM._mulLo = new ulong4(*(ulong2*)&x01._bigM, *(ulong2*)&x23._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = (*(ulong4*)&x4567._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x01._promises & x23._promises & x4567._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<int4> x0123, Divider<int4> x4567)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(int), 8, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new int8(x0123._divisor, x4567._divisor).Reinterpret<int8, T>();
            _mulShift._mul = new int8(x0123._mulShift._mul, x4567._mulShift._mul).Reinterpret<int8, T>();
            _mulShift._shift = new int8(x0123._mulShift._shift, x4567._mulShift._shift).Reinterpret<int8, T>();
            _bigM._mulLo = (*(ulong4*)&x0123._bigM).Reinterpret<ulong4, T>();
            _bigM._mulHi = (*(ulong4*)&x4567._bigM).Reinterpret<ulong4, T>();
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(int)) | (x0123._promises & x4567._promises);
        }
        #endregion


        #region long2
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long> x, Divider<long> y)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 2, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long2(x._divisor, y._divisor).Reinterpret<long2, T>();
            _mulShift._mul = new long2(x._mulShift._mul, y._mulShift._mul).Reinterpret<long2, T>();
            _mulShift._shift = new long2(x._mulShift._shift, y._mulShift._shift).Reinterpret<long2, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(*(UInt128*)&y._bigM, 1);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (x._promises & y._promises);
        }
        #endregion

        #region long3
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long> x, Divider<long> y, Divider<long> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long3(x._divisor, y._divisor, z._divisor).Reinterpret<long3, T>();
            _mulShift._mul = new long3(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul).Reinterpret<long3, T>();
            _mulShift._shift = new long3(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift).Reinterpret<long3, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(*(UInt128*)&y._bigM, 1);
            _bigM.SetField(*(UInt128*)&z._bigM, 2);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (x._promises & y._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long2> xy, Divider<long> z)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long3(xy._divisor, z._divisor).Reinterpret<long3, T>();
            _mulShift._mul = new long3(xy._mulShift._mul, z._mulShift._mul).Reinterpret<long3, T>();
            _mulShift._shift = new long3(xy._mulShift._shift, z._mulShift._shift).Reinterpret<long3, T>();
            _bigM.SetField(xy.GetField<Divider<long2>, UInt128>(0), 0);
            _bigM.SetField(xy.GetField<Divider<long2>, UInt128>(1), 1);
            _bigM.SetField(*(UInt128*)&z._bigM, 1);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (xy._promises & z._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long> x, Divider<long2> yz)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 3, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long3(x._divisor, yz._divisor).Reinterpret<long3, T>();
            _mulShift._mul = new long3(x._mulShift._mul, yz._mulShift._mul).Reinterpret<long3, T>();
            _mulShift._shift = new long3(x._mulShift._shift, yz._mulShift._shift).Reinterpret<long3, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(yz.GetField<Divider<long2>, UInt128>(0), 1);
            _bigM.SetField(yz.GetField<Divider<long2>, UInt128>(1), 2);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (x._promises & yz._promises);
        }
        #endregion

        #region long4
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long> x, Divider<long> y, Divider<long> z, Divider<long> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long4(x._divisor, y._divisor, z._divisor, w._divisor).Reinterpret<long4, T>();
            _mulShift._mul = new long4(x._mulShift._mul, y._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<long4, T>();
            _mulShift._shift = new long4(x._mulShift._shift, y._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<long4, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(*(UInt128*)&y._bigM, 1);
            _bigM.SetField(*(UInt128*)&z._bigM, 2);
            _bigM.SetField(*(UInt128*)&w._bigM, 3);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (x._promises & y._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long2> xy, Divider<long> z, Divider<long> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long4(xy._divisor, z._divisor, w._divisor).Reinterpret<long4, T>();
            _mulShift._mul = new long4(xy._mulShift._mul, z._mulShift._mul, w._mulShift._mul).Reinterpret<long4, T>();
            _mulShift._shift = new long4(xy._mulShift._shift, z._mulShift._shift, w._mulShift._shift).Reinterpret<long4, T>();
            _bigM.SetField(xy.GetField<Divider<long2>, UInt128>(1), 0);
            _bigM.SetField(xy.GetField<Divider<long2>, UInt128>(1), 1);
            _bigM.SetField(*(UInt128*)&z._bigM, 2);
            _bigM.SetField(*(UInt128*)&w._bigM, 3);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (xy._promises & z._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long> x, Divider<long2> yz, Divider<long> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long4(x._divisor, yz._divisor, w._divisor).Reinterpret<long4, T>();
            _mulShift._mul = new long4(x._mulShift._mul, yz._mulShift._mul, w._mulShift._mul).Reinterpret<long4, T>();
            _mulShift._shift = new long4(x._mulShift._shift, yz._mulShift._shift, w._mulShift._shift).Reinterpret<long4, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(yz.GetField<Divider<long2>, UInt128>(1), 1);
            _bigM.SetField(yz.GetField<Divider<long2>, UInt128>(1), 2);
            _bigM.SetField(*(UInt128*)&w._bigM, 3);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (x._promises & yz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long> x, Divider<long> y, Divider<long2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long4(x._divisor, y._divisor, zw._divisor).Reinterpret<long4, T>();
            _mulShift._mul = new long4(x._mulShift._mul, y._mulShift._mul, zw._mulShift._mul).Reinterpret<long4, T>();
            _mulShift._shift = new long4(x._mulShift._shift, y._mulShift._shift, zw._mulShift._shift).Reinterpret<long4, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(*(UInt128*)&y._bigM, 1);
            _bigM.SetField(zw.GetField<Divider<long2>, UInt128>(0), 2);
            _bigM.SetField(zw.GetField<Divider<long2>, UInt128>(1), 3);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (x._promises & y._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long2> xy, Divider<long2> zw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long4(xy._divisor, zw._divisor).Reinterpret<long4, T>();
            _mulShift._mul = new long4(xy._mulShift._mul, zw._mulShift._mul).Reinterpret<long4, T>();
            _mulShift._shift = new long4(xy._mulShift._shift, zw._mulShift._shift).Reinterpret<long4, T>();
            _bigM.SetField(xy.GetField<Divider<long2>, UInt128>(0), 0);
            _bigM.SetField(xy.GetField<Divider<long2>, UInt128>(1), 1);
            _bigM.SetField(zw.GetField<Divider<long2>, UInt128>(0), 2);
            _bigM.SetField(zw.GetField<Divider<long2>, UInt128>(1), 3);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (xy._promises & zw._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long3> xyz, Divider<long> w)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long4(xyz._divisor, w._divisor).Reinterpret<long4, T>();
            _mulShift._mul = new long4(xyz._mulShift._mul, w._mulShift._mul).Reinterpret<long4, T>();
            _mulShift._shift = new long4(xyz._mulShift._shift, w._mulShift._shift).Reinterpret<long4, T>();
            _bigM.SetField(xyz.GetField<Divider<long3>, UInt128>(0), 0);
            _bigM.SetField(xyz.GetField<Divider<long3>, UInt128>(1), 1);
            _bigM.SetField(xyz.GetField<Divider<long3>, UInt128>(2), 2);
            _bigM.SetField(*(UInt128*)&w._bigM, 3);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (xyz._promises & w._promises);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Divider(Divider<long> x, Divider<long3> yzw)
        {
            this = Uninitialized<Divider<T>>.Create();
#if DEBUG
_typeInfo = new TypeInfo(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
AssertOperationMatchesInitialization(sizeof(long), 4, columnCount: 1, Signedness.Signed, NumericDataType.Integer);
#endif
            _divisor = new long4(x._divisor, yzw._divisor).Reinterpret<long4, T>();
            _mulShift._mul = new long4(x._mulShift._mul, yzw._mulShift._mul).Reinterpret<long4, T>();
            _mulShift._shift = new long4(x._mulShift._shift, yzw._mulShift._shift).Reinterpret<long4, T>();
            _bigM.SetField(*(UInt128*)&x._bigM, 0);
            _bigM.SetField(yzw.GetField<Divider<long3>, UInt128>(0), 1);
            _bigM.SetField(yzw.GetField<Divider<long3>, UInt128>(1), 2);
            _bigM.SetField(yzw.GetField<Divider<long3>, UInt128>(2), 3);
            _promises = new DividerPromise(_divisor, Signedness.Signed, sizeof(long)) | (x._promises & yzw._promises);
        }
        #endregion
    }
}
