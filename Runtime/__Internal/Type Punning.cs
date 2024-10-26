using System.Runtime.CompilerServices;
using DevTools;

namespace MaxMath
{
    unsafe internal static partial class Utility
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TTo Reinterpret<TFrom, TTo>(this TFrom value)
            where TFrom : unmanaged
            where TTo   : unmanaged
        {
Assert.AreEqual(sizeof(TFrom), sizeof(TTo));

            return *(TTo*)&value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static TField GetField<TStruct, TField>(this TStruct container, int index, int stepSizeInBytes = 0)
            where TStruct : unmanaged
            where TField  : unmanaged
        {
            stepSizeInBytes = stepSizeInBytes != 0 ? stepSizeInBytes : sizeof(TField);

Assert.IsNotGreater((1 + index) * stepSizeInBytes, sizeof(TStruct));

            TStruct containing = container;
            return *(TField*)((byte*)&containing + (stepSizeInBytes * index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void SetField<TStruct, TField>(ref this TStruct container, TField value, int index, int stepSizeInBytes = 0)
            where TStruct : unmanaged
            where TField  : unmanaged
        {
            stepSizeInBytes = stepSizeInBytes != 0 ? stepSizeInBytes : sizeof(TField);

Assert.IsNotGreater((1 + index) * stepSizeInBytes, sizeof(TStruct));

            TStruct containing = container;
            *(TField*)((byte*)&containing + (stepSizeInBytes * index)) = value;
            container = containing;
        }
    }
}
