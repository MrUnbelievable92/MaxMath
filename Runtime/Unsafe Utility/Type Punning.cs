using System.Runtime.CompilerServices;
using DevTools;
using MaxMath.Intrinsics;

namespace MaxMath
{
    unsafe public static class UnsafeExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TTo Reinterpret<TFrom, TTo>(this TFrom value)
            where TFrom : unmanaged
            where TTo   : unmanaged
        {
Assert.AreEqual(sizeof(TFrom), sizeof(TTo));

            return *(TTo*)&value;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TField GetField<TStruct, TField>(this TStruct container, int index, int stepSizeInBytes = 0)
            where TStruct : unmanaged
            where TField  : unmanaged
        {
            stepSizeInBytes = stepSizeInBytes != 0 ? stepSizeInBytes : sizeof(TField);

Assert.IsNotGreater((1 + index) * stepSizeInBytes, sizeof(TStruct));

            return *(TField*)((byte*)&container + (stepSizeInBytes * index));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetField<TStruct, TField>(ref this TStruct container, TField value, int index, int stepSizeInBytes = 0)
            where TStruct : unmanaged
            where TField  : unmanaged
        {
            stepSizeInBytes = stepSizeInBytes != 0 ? stepSizeInBytes : sizeof(TField);

Assert.IsNotGreater((1 + index) * stepSizeInBytes, sizeof(TStruct));

            if (BurstArchitecture.IsBurstCompiled)
            {
                fixed (TStruct* ptr = &container)
                {
                    *(TField*)((byte*)ptr + (stepSizeInBytes * index)) = value;
                }
            }
            else
            {
                TStruct containing = container;
                *(TField*)((byte*)&containing + (stepSizeInBytes * index)) = value;
                container = containing;
            }
        }
    }
}
