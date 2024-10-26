using System;
using System.Runtime.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Mathematics;

namespace MaxMath
{
    // extension
    unsafe public partial struct Divider<T>
        where T : unmanaged, IEquatable<T>, IFormattable
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private readonly void AssertValidShuffle(byte elements)
        {
            switch (elements)
            {
                case 4:
                {
                    switch (sizeof(T))
                    {
                        case 4 * sizeof(byte):      AssertOperationMatchesInitialization(sizeof(byte),   4, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        case 4 * sizeof(ushort):    AssertOperationMatchesInitialization(sizeof(ushort), 4, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        case 4 * sizeof(uint):      AssertOperationMatchesInitialization(sizeof(uint),   4, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        case 4 * sizeof(ulong):     AssertOperationMatchesInitialization(sizeof(ulong),  4, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        default:                    throw new InvalidOperationException();
                    }
                }
                case 3:
                {
                    switch (sizeof(T))
                    {
                        case 3 * sizeof(byte):      AssertOperationMatchesInitialization(sizeof(byte),   3, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        case 3 * sizeof(ushort):    AssertOperationMatchesInitialization(sizeof(ushort), 3, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        case 3 * sizeof(uint):      AssertOperationMatchesInitialization(sizeof(uint),   3, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        case 3 * sizeof(ulong):     AssertOperationMatchesInitialization(sizeof(ulong),  3, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        default:                    throw new InvalidOperationException();
                    }
                }
                case 2:
                {
                    switch (sizeof(T))
                    {
                        case 2 * sizeof(byte):      AssertOperationMatchesInitialization(sizeof(byte),   2, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        case 2 * sizeof(ushort):    AssertOperationMatchesInitialization(sizeof(ushort), 2, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        case 2 * sizeof(uint):      AssertOperationMatchesInitialization(sizeof(uint),   2, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        case 2 * sizeof(ulong):     AssertOperationMatchesInitialization(sizeof(ulong),  2, columnCount: 1, Signedness.Undefined, NumericDataType.Integer);   return;
                        default:                    throw new InvalidOperationException();
                    }
                }
                default: throw new InvalidOperationException();
            }
        }

        
        public readonly Divider<T> xxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;
                result._promises |= PROMISE_SAME_VALUE;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxyy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxyz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxyw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxzy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxzz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxzw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxwy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxwz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xxww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xxww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xxww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xxww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xxww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xxww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xxww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xxww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xxww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xxww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xxww;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xxww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xxww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyyy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyyz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyyw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyzy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyzz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xywx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xywx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xywx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xywx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xywx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xywx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xywx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xywx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xywx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xywx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xywx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xywx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xywx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xywy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xywy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xywy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xywy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xywy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xywy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xywy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xywy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xywy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xywy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xywy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xywy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xywy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> xywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xywz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xywz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xywz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xywz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xywz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xywz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xywz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xywz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xywz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xywz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xywz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xywz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xywz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).xywz.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).xywz.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).xywz.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).xywz.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).xywz.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).xywz.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).xywz.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).xywz.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).xywz.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).xywz.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).xywz.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = x;
                        *((UInt128*)&bigM + 1) = y;
                        *((UInt128*)&bigM + 2) = w;
                        *((UInt128*)&bigM + 3) = z;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).xywz.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).xywz.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xyww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xyww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xyww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xyww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xyww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xyww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xyww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xyww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xyww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xyww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xyww;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xyww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xyww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzyy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzyz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> xzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzyw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).xzyw.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).xzyw.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).xzyw.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).xzyw.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).xzyw.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).xzyw.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).xzyw.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).xzyw.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).xzyw.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).xzyw.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).xzyw.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = x;
                        *((UInt128*)&bigM + 1) = z;
                        *((UInt128*)&bigM + 2) = y;
                        *((UInt128*)&bigM + 3) = w;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).xzyw.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).xzyw.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzzy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzzz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzzw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> xzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzwy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).xwyz.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).xwyz.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).xwyz.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).xwyz.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).xwyz.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).xwyz.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).xwyz.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).xwyz.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).xwyz.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).xwyz.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).xwyz.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = x;
                        *((UInt128*)&bigM + 1) = w;
                        *((UInt128*)&bigM + 2) = y;
                        *((UInt128*)&bigM + 3) = z;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).xwyz.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).xwyz.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzwz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xzww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xzww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xzww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xzww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xzww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xzww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xzww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xzww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xzww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xzww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xzww;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xzww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xzww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwyy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> xwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwyz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).xzwy.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).xzwy.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).xzwy.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).xzwy.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).xzwy.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).xzwy.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).xzwy.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).xzwy.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).xzwy.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).xzwy.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).xzwy.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = x;
                        *((UInt128*)&bigM + 1) = z;
                        *((UInt128*)&bigM + 2) = w;
                        *((UInt128*)&bigM + 3) = y;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).xzwy.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).xzwy.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwyw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> xwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwzy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).xwzy.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).xwzy.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).xwzy.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).xwzy.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).xwzy.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).xwzy.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).xwzy.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).xwzy.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).xwzy.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).xwzy.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).xwzy.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = x;
                        *((UInt128*)&bigM + 1) = w;
                        *((UInt128*)&bigM + 2) = z;
                        *((UInt128*)&bigM + 3) = y;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).xwzy.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).xwzy.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwzz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwzw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwwy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwwz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).xwww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).xwww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).xwww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).xwww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).xwww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).xwww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).xwww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).xwww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).xwww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).xwww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).xwww;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).xwww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).xwww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxyy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxyz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxyw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxzy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxzz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> yxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxzw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).yxzw.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).yxzw.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).yxzw.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).yxzw.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).yxzw.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).yxzw.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).yxzw.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).yxzw.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).yxzw.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).yxzw.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).yxzw.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = y;
                        *((UInt128*)&bigM + 1) = x;
                        *((UInt128*)&bigM + 2) = z;
                        *((UInt128*)&bigM + 3) = w;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).yxzw.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).yxzw.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxwy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> yxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxwz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).yxwz.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).yxwz.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).yxwz.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).yxwz.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).yxwz.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).yxwz.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).yxwz.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).yxwz.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).yxwz.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).yxwz.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).yxwz.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = y;
                        *((UInt128*)&bigM + 1) = x;
                        *((UInt128*)&bigM + 2) = w;
                        *((UInt128*)&bigM + 3) = z;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).yxwz.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).yxwz.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yxww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yxww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yxww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yxww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yxww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yxww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yxww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yxww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yxww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yxww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yxww;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yxww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yxww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;
                result._promises |= PROMISE_SAME_VALUE;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyyw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyzz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyzw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yywx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yywx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yywx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yywx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yywx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yywx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yywx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yywx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yywx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yywx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yywx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yywx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yywx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yywy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yywy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yywy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yywy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yywy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yywy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yywy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yywy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yywy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yywy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yywy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yywy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yywy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yywz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yywz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yywz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yywz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yywz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yywz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yywz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yywz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yywz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yywz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yywz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yywz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yywz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yyww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yyww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yyww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yyww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yyww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yyww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yyww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yyww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yyww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yyww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yyww;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yyww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yyww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> yzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).zxyw.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).zxyw.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).zxyw.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).zxyw.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).zxyw.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).zxyw.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).zxyw.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).zxyw.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).zxyw.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).zxyw.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).zxyw.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = z;
                        *((UInt128*)&bigM + 1) = x;
                        *((UInt128*)&bigM + 2) = y;
                        *((UInt128*)&bigM + 3) = w;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).zxyw.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).zxyw.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzyw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzzz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzzw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> yzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).wxyz.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).wxyz.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).wxyz.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).wxyz.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).wxyz.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).wxyz.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).wxyz.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).wxyz.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).wxyz.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).wxyz.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).wxyz.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = w;
                        *((UInt128*)&bigM + 1) = x;
                        *((UInt128*)&bigM + 2) = y;
                        *((UInt128*)&bigM + 3) = z;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).wxyz.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).wxyz.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzwy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzwz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).yzww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).yzww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).yzww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).yzww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).yzww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).yzww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).yzww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).yzww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).yzww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).yzww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).yzww;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).yzww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).yzww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> ywxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).zxwy.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).zxwy.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).zxwy.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).zxwy.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).zxwy.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).zxwy.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).zxwy.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).zxwy.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).zxwy.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).zxwy.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).zxwy.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = z;
                        *((UInt128*)&bigM + 1) = x;
                        *((UInt128*)&bigM + 2) = w;
                        *((UInt128*)&bigM + 3) = y;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).zxwy.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).zxwy.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywyw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> ywzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).wxzy.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).wxzy.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).wxzy.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).wxzy.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).wxzy.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).wxzy.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).wxzy.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).wxzy.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).wxzy.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).wxzy.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).wxzy.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = w;
                        *((UInt128*)&bigM + 1) = x;
                        *((UInt128*)&bigM + 2) = z;
                        *((UInt128*)&bigM + 3) = y;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).wxzy.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).wxzy.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywzz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywzw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywwy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywwz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> ywww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).ywww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).ywww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).ywww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).ywww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).ywww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).ywww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).ywww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).ywww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).ywww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).ywww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).ywww;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).ywww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).ywww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxyy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxyz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> zxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxyw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).yzxw.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).yzxw.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).yzxw.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).yzxw.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).yzxw.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).yzxw.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).yzxw.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).yzxw.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).yzxw.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).yzxw.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).yzxw.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = y;
                        *((UInt128*)&bigM + 1) = z;
                        *((UInt128*)&bigM + 2) = x;
                        *((UInt128*)&bigM + 3) = w;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).yzxw.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).yzxw.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxzy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxzz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxzw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> zxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxwy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).ywxz.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).ywxz.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).ywxz.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).ywxz.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).ywxz.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).ywxz.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).ywxz.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).ywxz.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).ywxz.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).ywxz.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).ywxz.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = y;
                        *((UInt128*)&bigM + 1) = w;
                        *((UInt128*)&bigM + 2) = x;
                        *((UInt128*)&bigM + 3) = z;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).ywxz.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).ywxz.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxwz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zxww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zxww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zxww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zxww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zxww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zxww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zxww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zxww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zxww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zxww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zxww;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zxww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zxww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> zyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).zyxw.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).zyxw.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).zyxw.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).zyxw.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).zyxw.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).zyxw.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).zyxw.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).zyxw.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).zyxw.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).zyxw.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).zyxw.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = z;
                        *((UInt128*)&bigM + 1) = y;
                        *((UInt128*)&bigM + 2) = x;
                        *((UInt128*)&bigM + 3) = w;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).zyxw.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).zyxw.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyyw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyzz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyzw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> zywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zywx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zywx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zywx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zywx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zywx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zywx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zywx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zywx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zywx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zywx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zywx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zywx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zywx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).wyxz.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).wyxz.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).wyxz.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).wyxz.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).wyxz.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).wyxz.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).wyxz.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).wyxz.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).wyxz.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).wyxz.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).wyxz.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = w;
                        *((UInt128*)&bigM + 1) = y;
                        *((UInt128*)&bigM + 2) = x;
                        *((UInt128*)&bigM + 3) = z;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).wyxz.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).wyxz.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zywy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zywy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zywy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zywy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zywy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zywy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zywy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zywy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zywy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zywy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zywy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zywy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zywy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zywz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zywz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zywz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zywz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zywz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zywz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zywz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zywz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zywz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zywz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zywz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zywz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zywz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zyww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zyww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zyww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zyww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zyww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zyww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zyww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zyww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zyww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zyww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zyww;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zyww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zyww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException(); 
                    }
                }
            }
        }
        public readonly Divider<T> zzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzyw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;
                result._promises |= PROMISE_SAME_VALUE;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzzz;

                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzzw;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzwy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzwz;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zzww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zzww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zzww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zzww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zzww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zzww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zzww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zzww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zzww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zzww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zzww;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zzww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zzww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> zwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).zwxy.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).zwxy.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).zwxy.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).zwxy.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).zwxy.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).zwxy.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).zwxy.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).zwxy.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).zwxy.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).zwxy.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).zwxy.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = z;
                        *((UInt128*)&bigM + 1) = w;
                        *((UInt128*)&bigM + 2) = x;
                        *((UInt128*)&bigM + 3) = y;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).zwxy.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).zwxy.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> zwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).wzxy.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).wzxy.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).wzxy.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).wzxy.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).wzxy.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).wzxy.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).wzxy.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).wzxy.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).wzxy.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).wzxy.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).wzxy.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = w;
                        *((UInt128*)&bigM + 1) = z;
                        *((UInt128*)&bigM + 2) = x;
                        *((UInt128*)&bigM + 3) = y;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).wzxy.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).wzxy.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwyw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwzz;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwzw;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwwy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwwz;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).zwww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).zwww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).zwww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).zwww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).zwww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).zwww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).zwww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).zwww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).zwww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).zwww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).zwww;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).zwww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).zwww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxyy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> wxyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxyz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).yzwx.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).yzwx.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).yzwx.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).yzwx.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).yzwx.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).yzwx.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).yzwx.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).yzwx.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).yzwx.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).yzwx.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).yzwx.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = y;
                        *((UInt128*)&bigM + 1) = z;
                        *((UInt128*)&bigM + 2) = w;
                        *((UInt128*)&bigM + 3) = x;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).yzwx.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).yzwx.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxyw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> wxzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxzy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).ywzx.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).ywzx.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).ywzx.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).ywzx.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).ywzx.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).ywzx.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).ywzx.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).ywzx.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).ywzx.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).ywzx.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).ywzx.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = y;
                        *((UInt128*)&bigM + 1) = w;
                        *((UInt128*)&bigM + 2) = z;
                        *((UInt128*)&bigM + 3) = x;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).ywzx.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).ywzx.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxzz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxzw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxwy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxwz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wxww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wxww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wxww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wxww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wxww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wxww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wxww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wxww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wxww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wxww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wxww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wxww;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wxww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wxww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> wyxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).zywx.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).zywx.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).zywx.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).zywx.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).zywx.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).zywx.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).zywx.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).zywx.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).zywx.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).zywx.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).zywx.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = z;
                        *((UInt128*)&bigM + 1) = y;
                        *((UInt128*)&bigM + 2) = w;
                        *((UInt128*)&bigM + 3) = x;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).zywx.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).zywx.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyyw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> wyzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).wyzx.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).wyzx.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).wyzx.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).wyzx.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).wyzx.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).wyzx.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).wyzx.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).wyzx.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).wyzx.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).wyzx.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).wyzx.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = w;
                        *((UInt128*)&bigM + 1) = y;
                        *((UInt128*)&bigM + 2) = z;
                        *((UInt128*)&bigM + 3) = x;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).wyzx.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).wyzx.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyzz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyzw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wywx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wywx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wywx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wywx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wywx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wywx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wywx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wywx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wywx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wywx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wywx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wywx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wywx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wywx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wywy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wywy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wywy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wywy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wywy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wywy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wywy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wywy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wywy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wywy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wywy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wywy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wywy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wywy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wywz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wywz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wywz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wywz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wywz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wywz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wywz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wywz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wywz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wywz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wywz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wywz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wywz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wywz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wyww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wyww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wyww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wyww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wyww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wyww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wyww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wyww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wyww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wyww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wyww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wyww;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wyww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wyww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> wzxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).zwyx.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).zwyx.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).zwyx.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).zwyx.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).zwyx.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).zwyx.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).zwyx.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).zwyx.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).zwyx.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).zwyx.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).zwyx.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = z;
                        *((UInt128*)&bigM + 1) = w;
                        *((UInt128*)&bigM + 2) = y;
                        *((UInt128*)&bigM + 3) = x;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).zwyx.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).zwyx.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> wzyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(4);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        _divisor = (*(byte4*)&value._divisor).wzyx.Reinterpret<byte4, T>();

                        _bigM    = (*(ushort4*)&value._bigM).wzyx.Reinterpret<ushort4, BigM>();

                        return;
                    }
                    case 4 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort4*)&value._divisor).wzyx.Reinterpret<ushort4, T>();

                        _bigM             = (*(uint4*)&value._bigM).wzyx.Reinterpret<uint4, BigM>();
                        _mulShift._mul    = (*(ushort4*)&value._mulShift._mul   ).wzyx.Reinterpret<ushort4, T>();
                        _mulShift._shift  = (*(ushort4*)&value._mulShift._shift).wzyx.Reinterpret<ushort4, T>();

                        return;
					}
                    case 4 * sizeof(uint):
                    {
                        _divisor          = (*(uint4*)&value._divisor).wzyx.Reinterpret<uint4, T>();

                        _bigM             = (*(ulong4*)&value._bigM).wzyx.Reinterpret<ulong4, BigM>();
                        _mulShift._mul    = (*(uint4*)&value._mulShift._mul   ).wzyx.Reinterpret<uint4, T>();
                        _mulShift._shift  = (*(uint4*)&value._mulShift._shift).wzyx.Reinterpret<uint4, T>();

                        return;
                    }
                    case 4 * sizeof(ulong):
                    {
                        _divisor = (*(ulong4*)&value._divisor).wzyx.Reinterpret<ulong4, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        UInt128 w = *((UInt128*)&value._bigM + 3);
                        *((UInt128*)&bigM + 0) = w;
                        *((UInt128*)&bigM + 1) = z;
                        *((UInt128*)&bigM + 2) = y;
                        *((UInt128*)&bigM + 3) = x;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong4*)&value._mulShift._mul   ).wzyx.Reinterpret<ulong4, T>();
                        _mulShift._shift  = (*(ulong4*)&value._mulShift._shift).wzyx.Reinterpret<ulong4, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzyw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzzz;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzzw;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzwy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzwz;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wzww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wzww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wzww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wzww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wzww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wzww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wzww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wzww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wzww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wzww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wzww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wzww;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wzww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wzww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwxx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwxx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwxx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwxx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwxx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwxx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwxx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwxx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwxx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwxx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwxx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwxy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwxy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwxy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwxy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwxy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwxy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwxy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwxy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwxy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwxy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwxy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwxz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwxz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwxz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwxz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwxz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwxz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwxz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwxz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwxz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwxz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwxz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwxw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwxw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwxw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwxw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwxw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwxw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwxw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwxw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwxw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwxw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwxw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwxw;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwxw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwxw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwyx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwyx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwyx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwyx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwyx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwyx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwyx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwyx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwyx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwyx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwyx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwyy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwyy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwyy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwyy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwyy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwyy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwyy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwyy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwyy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwyy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwyy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwyz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwyz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwyz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwyz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwyz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwyz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwyz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwyz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwyz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwyz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwyz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwyw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwyw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwyw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwyw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwyw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwyw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwyw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwyw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwyw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwyw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwyw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwyw;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwyw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwyw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwzx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwzx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwzx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwzx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwzx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwzx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwzx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwzx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwzx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwzx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwzx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwzy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwzy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwzy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwzy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwzy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwzy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwzy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwzy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwzy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwzy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwzy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwzz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwzz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwzz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwzz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwzz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwzz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwzz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwzz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwzz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwzz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwzz;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwzz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwzw
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwzw;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwzw;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwzw;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwzw;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwzw;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwzw;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwzw;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwzw;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwzw;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwzw;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwzw;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwzw;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwzw;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwwx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwwx;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwwx;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwwx;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwwx;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwwx;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwwx;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwwx;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwwx;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwwx;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwwx;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwwx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = x;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwwx;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwwx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwwy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwwy;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwwy;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwwy;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwwy;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwwy;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwwy;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwwy;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwwy;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwwy;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwwy;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwwy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = y;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwwy;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwwy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwwz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwwz;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwwz;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwwz;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwwz;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwwz;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwwz;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwwz;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwwz;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwwz;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwwz;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwwz;

                        UInt128 z = *((UInt128*)&result._bigM + 2);
                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = z;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwwz;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwwz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> wwww
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(4);

                Divider<T> result = this;
                result._promises |= PROMISE_SAME_VALUE;

                switch (sizeof(T))
                {
                    case 4 * sizeof(byte):
                    {
                        *(byte4*)&result._divisor = (*(byte4*)&result._divisor).wwww;

                        *(ushort4*)&result._bigM  = (*(ushort4*)&result._bigM).wwww;

                        return result;
                    }
                    case 4 * sizeof(ushort):
                    {
                        *(ushort4*)&result._divisor          = (*(ushort4*)&result._divisor).wwww;

                        *(uint4*)&result._bigM               = (*(uint4*)&result._bigM).wwww;
                        *(ushort4*)&result._mulShift._mul    = (*(ushort4*)&result._mulShift._mul).wwww;
                        *(ushort4*)&result._mulShift._shift  = (*(ushort4*)&result._mulShift._shift).wwww;

                        return result;
					}
                    case 4 * sizeof(uint):
                    {
                        *(uint4*)&result._divisor          = (*(uint4*)&result._divisor).wwww;

                        *(ulong4*)&result._bigM            = (*(ulong4*)&result._bigM).wwww;
                        *(uint4*)&result._mulShift._mul    = (*(uint4*)&result._mulShift._mul).wwww;
                        *(uint4*)&result._mulShift._shift  = (*(uint4*)&result._mulShift._shift).wwww;

                        return result;
                    }
                    case 4 * sizeof(ulong):
                    {
                        *(ulong4*)&result._divisor          = (*(ulong4*)&result._divisor).wwww;

                        UInt128 w = *((UInt128*)&result._bigM + 3);

                        *((UInt128*)&result._bigM + 0)      = w;
                        *((UInt128*)&result._bigM + 1)      = w;
                        *((UInt128*)&result._bigM + 2)      = w;
                        *((UInt128*)&result._bigM + 3)      = w;
                        *(ulong4*)&result._mulShift._mul    = (*(ulong4*)&result._mulShift._mul).wwww;
                        *(ulong4*)&result._mulShift._shift  = (*(ulong4*)&result._mulShift._shift).wwww;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }


        public readonly Divider<T> xxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;
                result._promises |= PROMISE_SAME_VALUE;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).xxx;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).xxx;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).xxx;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).xxx;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).xxx;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).xxx;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).xxx;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).xxx;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).xxx;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).xxx;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).xxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).xxx;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).xxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).xxy;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).xxy;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).xxy;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).xxy;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).xxy;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).xxy;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).xxy;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).xxy;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).xxy;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).xxy;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).xxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).xxy;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).xxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).xxz;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).xxz;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).xxz;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).xxz;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).xxz;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).xxz;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).xxz;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).xxz;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).xxz;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).xxz;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).xxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).xxz;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).xxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).xyx;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).xyx;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).xyx;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).xyx;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).xyx;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).xyx;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).xyx;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).xyx;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).xyx;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).xyx;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).xyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).xyx;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).xyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).xyy;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).xyy;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).xyy;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).xyy;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).xyy;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).xyy;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).xyy;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).xyy;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).xyy;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).xyy;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).xyy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).xyy;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).xyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).xzx;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).xzx;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).xzx;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).xzx;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).xzx;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).xzx;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).xzx;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).xzx;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).xzx;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).xzx;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).xzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).xzx;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).xzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> xzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).xzy;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).xzy;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).xzy;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).xzy;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).xzy;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).xzy;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).xzy;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).xzy;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).xzy;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).xzy;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).xzy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).xzy;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).xzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(3);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        _divisor = (*(byte3*)&value._divisor).xzy.Reinterpret<byte3, T>();

                        _bigM    = (*(ushort3*)&value._bigM).xzy.Reinterpret<ushort3, BigM>();

                        return;
                    }
                    case 3 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort3*)&value._divisor).xzy.Reinterpret<ushort3, T>();

                        _bigM             = (*(uint3*)&value._bigM).xzy.Reinterpret<uint3, BigM>();
                        _mulShift._mul    = (*(ushort3*)&value._mulShift._mul   ).xzy.Reinterpret<ushort3, T>();
                        _mulShift._shift  = (*(ushort3*)&value._mulShift._shift).xzy.Reinterpret<ushort3, T>();

                        return;
					}
                    case 3 * sizeof(uint):
                    {
                        _divisor          = (*(uint3*)&value._divisor).xzy.Reinterpret<uint3, T>();

                        _bigM             = (*(ulong3*)&value._bigM).xzy.Reinterpret<ulong3, BigM>();
                        _mulShift._mul    = (*(uint3*)&value._mulShift._mul   ).xzy.Reinterpret<uint3, T>();
                        _mulShift._shift  = (*(uint3*)&value._mulShift._shift).xzy.Reinterpret<uint3, T>();

                        return;
                    }
                    case 3 * sizeof(ulong):
                    {
                        _divisor = (*(ulong3*)&value._divisor).xzy.Reinterpret<ulong3, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        *((UInt128*)&bigM + 0) = x;
                        *((UInt128*)&bigM + 1) = z;
                        *((UInt128*)&bigM + 2) = y;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong3*)&value._mulShift._mul   ).xzy.Reinterpret<ulong3, T>();
                        _mulShift._shift  = (*(ulong3*)&value._mulShift._shift).xzy.Reinterpret<ulong3, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> xzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).xzz;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).xzz;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).xzz;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).xzz;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).xzz;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).xzz;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).xzz;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).xzz;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).xzz;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).xzz;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).xzz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).xzz;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).xzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).yxx;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).yxx;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).yxx;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).yxx;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).yxx;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).yxx;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).yxx;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).yxx;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).yxx;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).yxx;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).yxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).yxx;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).yxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).yxy;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).yxy;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).yxy;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).yxy;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).yxy;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).yxy;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).yxy;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).yxy;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).yxy;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).yxy;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).yxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).yxy;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).yxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> yxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).yxz;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).yxz;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).yxz;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).yxz;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).yxz;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).yxz;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).yxz;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).yxz;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).yxz;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).yxz;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).yxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).yxz;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).yxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(3);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        _divisor = (*(byte3*)&value._divisor).yxz.Reinterpret<byte3, T>();

                        _bigM    = (*(ushort3*)&value._bigM).yxz.Reinterpret<ushort3, BigM>();

                        return;
                    }
                    case 3 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort3*)&value._divisor).yxz.Reinterpret<ushort3, T>();

                        _bigM             = (*(uint3*)&value._bigM).yxz.Reinterpret<uint3, BigM>();
                        _mulShift._mul    = (*(ushort3*)&value._mulShift._mul   ).yxz.Reinterpret<ushort3, T>();
                        _mulShift._shift  = (*(ushort3*)&value._mulShift._shift).yxz.Reinterpret<ushort3, T>();

                        return;
					}
                    case 3 * sizeof(uint):
                    {
                        _divisor          = (*(uint3*)&value._divisor).yxz.Reinterpret<uint3, T>();

                        _bigM             = (*(ulong3*)&value._bigM).yxz.Reinterpret<ulong3, BigM>();
                        _mulShift._mul    = (*(uint3*)&value._mulShift._mul   ).yxz.Reinterpret<uint3, T>();
                        _mulShift._shift  = (*(uint3*)&value._mulShift._shift).yxz.Reinterpret<uint3, T>();

                        return;
                    }
                    case 3 * sizeof(ulong):
                    {
                        _divisor = (*(ulong3*)&value._divisor).yxz.Reinterpret<ulong3, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        *((UInt128*)&bigM + 0) = y;
                        *((UInt128*)&bigM + 1) = x;
                        *((UInt128*)&bigM + 2) = z;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong3*)&value._mulShift._mul   ).yxz.Reinterpret<ulong3, T>();
                        _mulShift._shift  = (*(ulong3*)&value._mulShift._shift).yxz.Reinterpret<ulong3, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).yyx;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).yyx;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).yyx;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).yyx;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).yyx;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).yyx;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).yyx;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).yyx;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).yyx;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).yyx;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).yyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).yyx;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).yyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;
                result._promises |= PROMISE_SAME_VALUE;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).yyy;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).yyy;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).yyy;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).yyy;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).yyy;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).yyy;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).yyy;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).yyy;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).yyy;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).yyy;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).yyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).yyy;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).yyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).yyz;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).yyz;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).yyz;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).yyz;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).yyz;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).yyz;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).yyz;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).yyz;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).yyz;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).yyz;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).yyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).yyz;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).yyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> yzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).yzx;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).yzx;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).yzx;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).yzx;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).yzx;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).yzx;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).yzx;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).yzx;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).yzx;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).yzx;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).yzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).yzx;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).yzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(3);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        _divisor = (*(byte3*)&value._divisor).zxy.Reinterpret<byte3, T>();

                        _bigM    = (*(ushort3*)&value._bigM).zxy.Reinterpret<ushort3, BigM>();

                        return;
                    }
                    case 3 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort3*)&value._divisor).zxy.Reinterpret<ushort3, T>();

                        _bigM             = (*(uint3*)&value._bigM).zxy.Reinterpret<uint3, BigM>();
                        _mulShift._mul    = (*(ushort3*)&value._mulShift._mul   ).zxy.Reinterpret<ushort3, T>();
                        _mulShift._shift  = (*(ushort3*)&value._mulShift._shift).zxy.Reinterpret<ushort3, T>();

                        return;
					}
                    case 3 * sizeof(uint):
                    {
                        _divisor          = (*(uint3*)&value._divisor).zxy.Reinterpret<uint3, T>();

                        _bigM             = (*(ulong3*)&value._bigM).zxy.Reinterpret<ulong3, BigM>();
                        _mulShift._mul    = (*(uint3*)&value._mulShift._mul   ).zxy.Reinterpret<uint3, T>();
                        _mulShift._shift  = (*(uint3*)&value._mulShift._shift).zxy.Reinterpret<uint3, T>();

                        return;
                    }
                    case 3 * sizeof(ulong):
                    {
                        _divisor = (*(ulong3*)&value._divisor).zxy.Reinterpret<ulong3, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        *((UInt128*)&bigM + 0) = z;
                        *((UInt128*)&bigM + 1) = x;
                        *((UInt128*)&bigM + 2) = y;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong3*)&value._mulShift._mul   ).zxy.Reinterpret<ulong3, T>();
                        _mulShift._shift  = (*(ulong3*)&value._mulShift._shift).zxy.Reinterpret<ulong3, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).yzy;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).yzy;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).yzy;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).yzy;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).yzy;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).yzy;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).yzy;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).yzy;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).yzy;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).yzy;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).yzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).yzy;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).yzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).yzz;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).yzz;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).yzz;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).yzz;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).yzz;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).yzz;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).yzz;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).yzz;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).yzz;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).yzz;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).yzz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).yzz;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).yzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).zxx;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).zxx;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).zxx;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).zxx;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).zxx;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).zxx;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).zxx;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).zxx;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).zxx;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).zxx;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).zxx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).zxx;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).zxx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> zxy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).zxy;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).zxy;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).zxy;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).zxy;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).zxy;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).zxy;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).zxy;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).zxy;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).zxy;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).zxy;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).zxy;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).zxy;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).zxy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(3);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        _divisor = (*(byte3*)&value._divisor).yzx.Reinterpret<byte3, T>();

                        _bigM    = (*(ushort3*)&value._bigM).yzx.Reinterpret<ushort3, BigM>();

                        return;
                    }
                    case 3 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort3*)&value._divisor).yzx.Reinterpret<ushort3, T>();

                        _bigM             = (*(uint3*)&value._bigM).yzx.Reinterpret<uint3, BigM>();
                        _mulShift._mul    = (*(ushort3*)&value._mulShift._mul   ).yzx.Reinterpret<ushort3, T>();
                        _mulShift._shift  = (*(ushort3*)&value._mulShift._shift).yzx.Reinterpret<ushort3, T>();

                        return;
					}
                    case 3 * sizeof(uint):
                    {
                        _divisor          = (*(uint3*)&value._divisor).yzx.Reinterpret<uint3, T>();

                        _bigM             = (*(ulong3*)&value._bigM).yzx.Reinterpret<ulong3, BigM>();
                        _mulShift._mul    = (*(uint3*)&value._mulShift._mul   ).yzx.Reinterpret<uint3, T>();
                        _mulShift._shift  = (*(uint3*)&value._mulShift._shift).yzx.Reinterpret<uint3, T>();

                        return;
                    }
                    case 3 * sizeof(ulong):
                    {
                        _divisor = (*(ulong3*)&value._divisor).yzx.Reinterpret<ulong3, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        *((UInt128*)&bigM + 0) = y;
                        *((UInt128*)&bigM + 1) = z;
                        *((UInt128*)&bigM + 2) = x;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong3*)&value._mulShift._mul   ).yzx.Reinterpret<ulong3, T>();
                        _mulShift._shift  = (*(ulong3*)&value._mulShift._shift).yzx.Reinterpret<ulong3, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zxz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).zxz;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).zxz;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).zxz;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).zxz;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).zxz;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).zxz;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).zxz;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).zxz;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).zxz;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).zxz;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).zxz;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).zxz;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).zxz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> zyx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).zyx;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).zyx;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).zyx;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).zyx;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).zyx;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).zyx;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).zyx;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).zyx;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).zyx;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).zyx;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).zyx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).zyx;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).zyx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(3);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        _divisor = (*(byte3*)&value._divisor).zyx.Reinterpret<byte3, T>();

                        _bigM    = (*(ushort3*)&value._bigM).zyx.Reinterpret<ushort3, BigM>();

                        return;
                    }
                    case 3 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort3*)&value._divisor).zyx.Reinterpret<ushort3, T>();

                        _bigM             = (*(uint3*)&value._bigM).zyx.Reinterpret<uint3, BigM>();
                        _mulShift._mul    = (*(ushort3*)&value._mulShift._mul   ).zyx.Reinterpret<ushort3, T>();
                        _mulShift._shift  = (*(ushort3*)&value._mulShift._shift).zyx.Reinterpret<ushort3, T>();

                        return;
					}
                    case 3 * sizeof(uint):
                    {
                        _divisor          = (*(uint3*)&value._divisor).zyx.Reinterpret<uint3, T>();

                        _bigM             = (*(ulong3*)&value._bigM).zyx.Reinterpret<ulong3, BigM>();
                        _mulShift._mul    = (*(uint3*)&value._mulShift._mul   ).zyx.Reinterpret<uint3, T>();
                        _mulShift._shift  = (*(uint3*)&value._mulShift._shift).zyx.Reinterpret<uint3, T>();

                        return;
                    }
                    case 3 * sizeof(ulong):
                    {
                        _divisor = (*(ulong3*)&value._divisor).zyx.Reinterpret<ulong3, T>();

                        BigM bigM;
                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);
                        UInt128 z = *((UInt128*)&value._bigM + 2);
                        *((UInt128*)&bigM + 0) = z;
                        *((UInt128*)&bigM + 1) = y;
                        *((UInt128*)&bigM + 2) = x;
                        _bigM      = bigM;

                        _mulShift._mul    = (*(ulong3*)&value._mulShift._mul   ).zyx.Reinterpret<ulong3, T>();
                        _mulShift._shift  = (*(ulong3*)&value._mulShift._shift).zyx.Reinterpret<ulong3, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).zyy;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).zyy;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).zyy;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).zyy;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).zyy;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).zyy;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).zyy;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).zyy;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).zyy;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).zyy;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).zyy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).zyy;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).zyy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zyz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).zyz;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).zyz;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).zyz;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).zyz;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).zyz;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).zyz;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).zyz;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).zyz;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).zyz;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).zyz;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).zyz;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).zyz;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).zyz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).zzx;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).zzx;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).zzx;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).zzx;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).zzx;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).zzx;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).zzx;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).zzx;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).zzx;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).zzx;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).zzx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = x;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).zzx;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).zzx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).zzy;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).zzy;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).zzy;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).zzy;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).zzy;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).zzy;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).zzy;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).zzy;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).zzy;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).zzy;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).zzy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);
                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = y;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).zzy;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).zzy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> zzz
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(3);

                Divider<T> result = this;
                result._promises |= PROMISE_SAME_VALUE;

                switch (sizeof(T))
                {
                    case 3 * sizeof(byte):
                    {
                        *(byte3*)&result._divisor = (*(byte3*)&result._divisor).zzz;

                        *(ushort3*)&result._bigM  = (*(ushort3*)&result._bigM).zzz;

                        return result;
                    }
                    case 3 * sizeof(ushort):
                    {
                        *(ushort3*)&result._divisor          = (*(ushort3*)&result._divisor).zzz;

                        *(uint3*)&result._bigM               = (*(uint3*)&result._bigM).zzz;
                        *(ushort3*)&result._mulShift._mul    = (*(ushort3*)&result._mulShift._mul).zzz;
                        *(ushort3*)&result._mulShift._shift  = (*(ushort3*)&result._mulShift._shift).zzz;

                        return result;
					}
                    case 3 * sizeof(uint):
                    {
                        *(uint3*)&result._divisor          = (*(uint3*)&result._divisor).zzz;

                        *(ulong3*)&result._bigM            = (*(ulong3*)&result._bigM).zzz;
                        *(uint3*)&result._mulShift._mul    = (*(uint3*)&result._mulShift._mul).zzz;
                        *(uint3*)&result._mulShift._shift  = (*(uint3*)&result._mulShift._shift).zzz;

                        return result;
                    }
                    case 3 * sizeof(ulong):
                    {
                        *(ulong3*)&result._divisor          = (*(ulong3*)&result._divisor).zzz;

                        UInt128 z = *((UInt128*)&result._bigM + 2);

                        *((UInt128*)&result._bigM + 0)      = z;
                        *((UInt128*)&result._bigM + 1)      = z;
                        *((UInt128*)&result._bigM + 2)      = z;
                        *(ulong3*)&result._mulShift._mul    = (*(ulong3*)&result._mulShift._mul).zzz;
                        *(ulong3*)&result._mulShift._shift  = (*(ulong3*)&result._mulShift._shift).zzz;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }


        public readonly Divider<T> xx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(2);

                Divider<T> result = this;
                result._promises |= PROMISE_SAME_VALUE;

                switch (sizeof(T))
                {
                    case 2 * sizeof(byte):
                    {
                        *(byte2*)&result._divisor = (*(byte2*)&result._divisor).xx;

                        *(ushort2*)&result._bigM  = (*(ushort2*)&result._bigM).xx;

                        return result;
                    }
                    case 2 * sizeof(ushort):
                    {
                        *(ushort2*)&result._divisor          = (*(ushort2*)&result._divisor).xx;

                        *(uint2*)&result._bigM               = (*(uint2*)&result._bigM).xx;
                        *(ushort2*)&result._mulShift._mul    = (*(ushort2*)&result._mulShift._mul).xx;
                        *(ushort2*)&result._mulShift._shift  = (*(ushort2*)&result._mulShift._shift).xx;

                        return result;
					}
                    case 2 * sizeof(uint):
                    {
                        *(uint2*)&result._divisor          = (*(uint2*)&result._divisor).xx;

                        *(ulong2*)&result._bigM            = (*(ulong2*)&result._bigM).xx;
                        *(uint2*)&result._mulShift._mul    = (*(uint2*)&result._mulShift._mul).xx;
                        *(uint2*)&result._mulShift._shift  = (*(uint2*)&result._mulShift._shift).xx;

                        return result;
                    }
                    case 2 * sizeof(ulong):
                    {
                        *(ulong2*)&result._divisor          = (*(ulong2*)&result._divisor).xx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);

                        *((UInt128*)&result._bigM + 0)      = x;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *(ulong2*)&result._mulShift._mul    = (*(ulong2*)&result._mulShift._mul).xx;
                        *(ulong2*)&result._mulShift._shift  = (*(ulong2*)&result._mulShift._shift).xx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public          Divider<T> yx
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            readonly get
            {
AssertValidShuffle(2);

                Divider<T> result = this;

                switch (sizeof(T))
                {
                    case 2 * sizeof(byte):
                    {
                        *(byte2*)&result._divisor = (*(byte2*)&result._divisor).yx;

                        *(ushort2*)&result._bigM  = (*(ushort2*)&result._bigM).yx;

                        return result;
                    }
                    case 2 * sizeof(ushort):
                    {
                        *(ushort2*)&result._divisor          = (*(ushort2*)&result._divisor).yx;

                        *(uint2*)&result._bigM               = (*(uint2*)&result._bigM).yx;
                        *(ushort2*)&result._mulShift._mul    = (*(ushort2*)&result._mulShift._mul).yx;
                        *(ushort2*)&result._mulShift._shift  = (*(ushort2*)&result._mulShift._shift).yx;

                        return result;
					}
                    case 2 * sizeof(uint):
                    {
                        *(uint2*)&result._divisor          = (*(uint2*)&result._divisor).yx;

                        *(ulong2*)&result._bigM            = (*(ulong2*)&result._bigM).yx;
                        *(uint2*)&result._mulShift._mul    = (*(uint2*)&result._mulShift._mul).yx;
                        *(uint2*)&result._mulShift._shift  = (*(uint2*)&result._mulShift._shift).yx;

                        return result;
                    }
                    case 2 * sizeof(ulong):
                    {
                        *(ulong2*)&result._divisor          = (*(ulong2*)&result._divisor).yx;

                        UInt128 x = *((UInt128*)&result._bigM + 0);
                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = x;
                        *(ulong2*)&result._mulShift._mul    = (*(ulong2*)&result._mulShift._mul).yx;
                        *(ulong2*)&result._mulShift._shift  = (*(ulong2*)&result._mulShift._shift).yx;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
AssertValidShuffle(2);

                _promises = value._promises;

                switch (sizeof(T))
                {
                    case 2 * sizeof(byte):
                    {
                        _divisor = (*(byte2*)&value._divisor).yx.Reinterpret<byte2, T>();

                        _bigM    = (*(ushort2*)&value._bigM).yx.Reinterpret<ushort2, BigM>();

                        return;
                    }
                    case 2 * sizeof(ushort):
                    {
                        _divisor          = (*(ushort2*)&value._divisor).yx.Reinterpret<ushort2, T>();

                        _bigM             = (*(uint2*)&value._bigM).yx.Reinterpret<uint2, BigM>();
                        _mulShift._mul    = (*(ushort2*)&value._mulShift._mul   ).yx.Reinterpret<ushort2, T>();
                        _mulShift._shift  = (*(ushort2*)&value._mulShift._shift).yx.Reinterpret<ushort2, T>();

                        return;
					}
                    case 2 * sizeof(uint):
                    {
                        _divisor          = (*(uint2*)&value._divisor).yx.Reinterpret<uint2, T>();

                        _bigM             = (*(ulong2*)&value._bigM).yx.Reinterpret<ulong2, BigM>();
                        _mulShift._mul    = (*(uint2*)&value._mulShift._mul   ).yx.Reinterpret<uint2, T>();
                        _mulShift._shift  = (*(uint2*)&value._mulShift._shift).yx.Reinterpret<uint2, T>();

                        return;
                    }
                    case 2 * sizeof(ulong):
                    {
                        _divisor = (*(ulong2*)&value._divisor).yx.Reinterpret<ulong2, T>();

                        UInt128 x = *((UInt128*)&value._bigM + 0);
                        UInt128 y = *((UInt128*)&value._bigM + 1);

                        _bigM._mulLo      = y.Reinterpret<UInt128, T>();
                        _bigM._mulHi      = x.Reinterpret<UInt128, T>();
                        _mulShift._mul    = (*(ulong2*)&value._mulShift._mul   ).yx.Reinterpret<ulong2, T>();
                        _mulShift._shift  = (*(ulong2*)&value._mulShift._shift).yx.Reinterpret<ulong2, T>();

                        return;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
        public readonly Divider<T> yy
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
AssertValidShuffle(2);

                Divider<T> result = this;
                result._promises |= PROMISE_SAME_VALUE;

                switch (sizeof(T))
                {
                    case 2 * sizeof(byte):
                    {
                        *(byte2*)&result._divisor = (*(byte2*)&result._divisor).yy;

                        *(ushort2*)&result._bigM  = (*(ushort2*)&result._bigM).yy;

                        return result;
                    }
                    case 2 * sizeof(ushort):
                    {
                        *(ushort2*)&result._divisor          = (*(ushort2*)&result._divisor).yy;

                        *(uint2*)&result._bigM               = (*(uint2*)&result._bigM).yy;
                        *(ushort2*)&result._mulShift._mul    = (*(ushort2*)&result._mulShift._mul).yy;
                        *(ushort2*)&result._mulShift._shift  = (*(ushort2*)&result._mulShift._shift).yy;

                        return result;
					}
                    case 2 * sizeof(uint):
                    {
                        *(uint2*)&result._divisor          = (*(uint2*)&result._divisor).yy;

                        *(ulong2*)&result._bigM            = (*(ulong2*)&result._bigM).yy;
                        *(uint2*)&result._mulShift._mul    = (*(uint2*)&result._mulShift._mul).yy;
                        *(uint2*)&result._mulShift._shift  = (*(uint2*)&result._mulShift._shift).yy;

                        return result;
                    }
                    case 2 * sizeof(ulong):
                    {
                        *(ulong2*)&result._divisor          = (*(ulong2*)&result._divisor).yy;

                        UInt128 y = *((UInt128*)&result._bigM + 1);

                        *((UInt128*)&result._bigM + 0)      = y;
                        *((UInt128*)&result._bigM + 1)      = y;
                        *(ulong2*)&result._mulShift._mul    = (*(ulong2*)&result._mulShift._mul).yy;
                        *(ulong2*)&result._mulShift._shift  = (*(ulong2*)&result._mulShift._shift).yy;

                        return result;
                    }
                    default:
                    {
                    	throw new InvalidOperationException();
                    }
                }
            }
        }
	}
}
