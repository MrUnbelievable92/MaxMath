#if DEBUG
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Burst.Intrinsics;
using DevTools;

using static Unity.Mathematics.math;
using static MaxMath.maxmath;

namespace MaxMath
{
    [StructLayout(LayoutKind.Sequential, Size = 5)]
    unsafe internal readonly struct TypeInfo : IEquatable<TypeInfo>
    {
        internal readonly Signedness _sign;
        internal readonly byte _elementSize;
        internal readonly byte _elementCount;
        internal readonly byte _columnCount;
        internal readonly NumericDataType _dataType;

        internal TypeInfo(byte elementSize, byte elementCount, byte columnCount, Signedness sign, NumericDataType numericType)
        {
            _elementSize = elementSize;
            _elementCount = elementCount;
            _columnCount = columnCount;
            _sign = sign;
            _dataType = numericType;
        }


        public readonly bool IsScalar => _elementCount == 1;
        public readonly bool IsVector => !IsScalar & _columnCount == 1;
        public readonly bool IsMatrix => _columnCount != 1;

        public readonly bool IsV128 => !IsScalar & !IsV256;
        public readonly bool IsV256 => !IsScalar & (_elementCount * _elementSize > sizeof(v128));

        public readonly string GetFieldName(int element)
        {
            if (IsVector)
            {
                switch (_elementCount)
                {
                    case 2:
                    case 3:
                    case 4:
                    {
                        switch (element)
                        {
                            case 0: return "x";
                            case 1: return "y";
                            case 2: return "z";
                            case 3: return "w";
                            default: throw Assert.Unreachable();
                        }
                    }
                    default:
                    {
                        return 'x' + element.ToString(); 
                    }
                }
            }
            else if (IsMatrix)
            {
                return 'c' + element.ToString();
            }
            else
            {
                throw Assert.Unreachable();
            }
        }

        public readonly bool Equals(TypeInfo other)
        {
            return this._sign == other._sign
                && this._elementSize == other._elementSize
                && this._elementCount == other._elementCount
                && this._columnCount == other._columnCount
                && this._dataType == other._dataType;
        }

        public override readonly bool Equals(object other)
        {
            return this.Equals((TypeInfo)other);
        }

        public override readonly int GetHashCode()
        {
            return (byte)_sign
                 | (byte)(_elementSize    << (floorlog2(3)))
                 | (byte)(_elementCount   << (floorlog2(3) + floorlog2(16)))
                 | (byte)(_columnCount    << (floorlog2(3) + floorlog2(16) + floorlog2(32)))
                 | (byte)((byte)_dataType << (floorlog2(3) + floorlog2(16) + floorlog2(32) + floorlog2(4)));
        }

        public override readonly string ToString()
        {
            if (_dataType == NumericDataType.Undefined)
            {
                throw new ArgumentException("Datatype is undefined");
            }

            string type = string.Empty;
            
            if (_dataType == NumericDataType.Boolean)
            {
                type = "bool";
            }

            else
            {
                if (_dataType == NumericDataType.Integer)
                {
                    if (_elementSize == 1 && _sign == Signedness.Signed)
                    {
                        type += "s";
                    }
                    else if (_elementSize != 1 && _sign == Signedness.Unsigned)
                    {
                        type += _elementSize == sizeof(UInt128) ? "U" : "u";
                    }
                }

                switch (_elementSize)
                {
                    case 1:  type += (_dataType == NumericDataType.Integer) ? "byte"   : "quarter";     break;
                    case 2:  type += (_dataType == NumericDataType.Integer) ? "short"  : "half";        break;
                    case 4:  type += (_dataType == NumericDataType.Integer) ? "int"    : "float";       break;
                    case 8:  type += (_dataType == NumericDataType.Integer) ? "long"   : "double";      break;
                    case 16: type += (_dataType == NumericDataType.Integer) ? "Int128" : "quadruple";   break;

                    default: throw new ArgumentException($"Datatype with size { _elementSize } is undefined");
                }
            }

            if (_elementCount != 1)
            {
                type += _elementCount.ToString();
            }

            if (_columnCount != 1)
            {
                type += 'x' + _columnCount.ToString();
            }

            return type;
        }


        public static TypeInfo[] AllScalarTypes => new TypeInfo[]
        {
            new TypeInfo(sizeof(bool),          1, columnCount: 1, Signedness.Unsigned, NumericDataType.Boolean),

            new TypeInfo(sizeof(byte),          1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer),
            new TypeInfo(sizeof(ushort),        1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer),
            new TypeInfo(sizeof(uint),          1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer),
            new TypeInfo(sizeof(ulong),         1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer),
            new TypeInfo((byte)sizeof(UInt128), 1, columnCount: 1, Signedness.Unsigned, NumericDataType.Integer),

            new TypeInfo(sizeof(sbyte),         1, columnCount: 1, Signedness.Signed, NumericDataType.Integer),
            new TypeInfo(sizeof(short),         1, columnCount: 1, Signedness.Signed, NumericDataType.Integer),
            new TypeInfo(sizeof(int),           1, columnCount: 1, Signedness.Signed, NumericDataType.Integer),
            new TypeInfo(sizeof(long),          1, columnCount: 1, Signedness.Signed, NumericDataType.Integer),
            new TypeInfo((byte)sizeof(Int128),  1, columnCount: 1, Signedness.Signed, NumericDataType.Integer),

            new TypeInfo((byte)sizeof(quarter), 1, columnCount: 1, Signedness.Signed, NumericDataType.FloatingPoint),
            new TypeInfo((byte)sizeof(half),    1, columnCount: 1, Signedness.Signed, NumericDataType.FloatingPoint),
            new TypeInfo(sizeof(float),         1, columnCount: 1, Signedness.Signed, NumericDataType.FloatingPoint),
            new TypeInfo(sizeof(double),        1, columnCount: 1, Signedness.Signed, NumericDataType.FloatingPoint)
        };

        public static TypeInfo[] AllVectorTypes
        {
            get
            {
                const int MAX_VECTOR_LENGTH_BYTES = 32;

                List<TypeInfo> types = new List<TypeInfo>();

                foreach (TypeInfo type in AllScalarTypes)
                {
                    if (type._elementSize > 8) continue;
                    
                    int i = 2;
                    while (i <= 4)
                    {
                        types.Add(new TypeInfo(type._elementSize, (byte)i, columnCount: 1, type._sign, type._dataType));
                        i++;
                    }
                    
                    i = 8;
                    while (i * type._elementSize <= MAX_VECTOR_LENGTH_BYTES)
                    {
                        types.Add(new TypeInfo(type._elementSize, (byte)i, columnCount: 1, type._sign, type._dataType));
                        i *= 2;

                        if (type._dataType == NumericDataType.FloatingPoint)
                        {
                            break;
                        }
                    }
                }

                return types.ToArray();
            }
        }

        public static TypeInfo[] AllMatrixTypes
        {
            get
            {
                List<TypeInfo> types = new List<TypeInfo>();

                foreach (TypeInfo type in AllVectorTypes)
                {
                    if (type._dataType == NumericDataType.FloatingPoint
                     && (type._elementSize == sizeof(quarter) 
                      || type._elementSize == sizeof(half)))
                    {
                        continue;
                    }
                    
                    if (type._elementSize > 8) continue;
                    if (type._elementCount > 4) continue;

                    int i = 2;
                    while (i <= 4)
                    {
                        types.Add(new TypeInfo(type._elementSize, type._elementCount, columnCount: (byte)i, type._sign, type._dataType));
                        i++;
                    }
                }

                return types.ToArray();
            }
        }
    }
}
#endif
