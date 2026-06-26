using UnityEngine;
using UnityEditor;

namespace MaxMath.EditorTools
{
    public class GenericInspector<T> : PropertyDrawer
        where T : unmanaged
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            object target = property.serializedObject.targetObject;
            T current = (T)fieldInfo.GetValue(target);

            EditorGUI.BeginChangeCheck();
            T edited = EditorGUIExtensions.DelayedField<T>(position, label, current);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject((Object)target, "Edit " + typeof(T).Name.ToString());
                fieldInfo.SetValue(target, edited);
                EditorUtility.SetDirty((Object)target);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(quarter))]
    public class quarterInspector : GenericInspector<quarter>
    {

    }

    [CustomPropertyDrawer(typeof(half))]
    public class halfInspector : GenericInspector<half>
    {

    }

    [CustomPropertyDrawer(typeof(quadruple))]
    public class quadrupleInspector : GenericInspector<quadruple>
    {

    }

    [CustomPropertyDrawer(typeof(UInt128))]
    public class UInt128Inspector : GenericInspector<UInt128>
    {

    }

    [CustomPropertyDrawer(typeof(Int128))]
    public class Int128Inspector : GenericInspector<Int128>
    {

    }
}
