namespace MaxMath
{
    internal interface IVector
    {
        Signedness Signedness { get; }
        NumericDataType DataType { get; }
        uint Elements { get; }
    }

    internal interface IMatrix<T>
        where T : IVector
    {
        uint Elements { get; }
    }
}
