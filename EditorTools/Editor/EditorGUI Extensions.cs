using UnityEditor;
using UnityEngine;

namespace MaxMath.EditorTools
{
    internal static class EditorGUIExtensions
    {
        unsafe private static T DelayedFieldBase<T>(string text, T value)
            where T: unmanaged
        {
            if (typeof(T) == typeof(quarter)
             && quarter.TryParse(text, out quarter parsedquarter))
            {
                return *(T*)&parsedquarter;
            }
            if (typeof(T) == typeof(half)
             && half.TryParse(text, out half parsedhalf))
            {
                return *(T*)&parsedhalf;
            }
            if (typeof(T) == typeof(quadruple)
             && quadruple.TryParse(text, out quadruple parsedquadruple))
            {
                return *(T*)&parsedquadruple;
            }
            if (typeof(T) == typeof(uint)
             && uint.TryParse(text, out uint parseduint))
            {
                return *(T*)&parseduint;
            }
            if (typeof(T) == typeof(ulong)
             && ulong.TryParse(text, out ulong parsedulong))
            {
                return *(T*)&parsedulong;
            }
            if (typeof(T) == typeof(long)
             && long.TryParse(text, out long parsedlong))
            {
                return *(T*)&parsedlong;
            }
            if (typeof(T) == typeof(UInt128)
             && UInt128.TryParse(text, out UInt128 parsedUInt128))
            {
                return *(T*)&parsedUInt128;
            }
            if (typeof(T) == typeof(Int128)
             && Int128.TryParse(text, out Int128 parsedInt128))
            {
                return *(T*)&parsedInt128;
            }
        
            return value;
        }

        unsafe public static T DelayedField<T>(Rect position, string label, T value)
            where T: unmanaged
        {
            return DelayedFieldBase(EditorGUI.DelayedTextField(position, label, value.ToString()), value);
        }

        unsafe public static T DelayedField<T>(Rect position, GUIContent label, T value)
            where T: unmanaged
        {
            return DelayedFieldBase(EditorGUI.DelayedTextField(position, label, value.ToString()), value);
        }
    }
}
