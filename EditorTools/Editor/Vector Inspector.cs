using UnityEditor;
using UnityEngine;

namespace MaxMath.EditorTools
{
    public abstract class VectorInspector : PropertyDrawer
    {
        protected const float Spacing = 2f;
        protected static float Line => EditorGUIUtility.singleLineHeight;
        protected static float Step => Line + Spacing;
        protected static float Indent => 12f;
        public abstract float Count { get; }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return property.isExpanded ? (Count + 1) * EditorGUIUtility.singleLineHeight + (Count - 1) * Spacing
                                       : EditorGUIUtility.singleLineHeight;
        }
        
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            property.isExpanded = EditorGUI.Foldout(new Rect(position.x + Indent, position.y, position.width, EditorGUIUtility.singleLineHeight),
                                                    property.isExpanded,
                                                    label,
                                                    true);
        }
    }

    
    [CustomPropertyDrawer(typeof(byte2))]
    public class byte2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            int packed = packedProp.intValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFu));
            int y = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 8) & 0xFFu));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit byte2");

                x = math.clamp(x, byte.MinValue, byte.MaxValue);
                y = math.clamp(y, byte.MinValue, byte.MaxValue);
    
                packed =
                     (x & 0xFF) |
                    ((y & 0xFF) << 8);
    
                packedProp.intValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(byte3))]
    public class byte3Drawer : VectorInspector
    {
        public override float Count => 3;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            int packed = packedProp.intValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 8) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit byte3");

                x0 = math.clamp(x0, byte.MinValue, byte.MaxValue);
                x1 = math.clamp(x1, byte.MinValue, byte.MaxValue);

                packed =
                     (x0 & 0xFF) |
                    ((x1 & 0xFF) << 8);

                packedProp.intValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x2");

            packed = packedProp.intValue;

            EditorGUI.BeginChangeCheck();

            int x2  = EditorGUI.DelayedIntField(r2,   "z", (int)(packed & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                packed = math.clamp(x2, byte.MinValue, byte.MaxValue);

                packedProp.intValue = packed & 0xFF;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(byte4))]
    public class byte4Drawer : VectorInspector
    {
        public override float Count => 4;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            int packed = packedProp.intValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFu));
            int y = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 8) & 0xFFu));
            int z = EditorGUI.DelayedIntField(r2, "z", (int)((packed >> 16) & 0xFFu));
            int w = EditorGUI.DelayedIntField(r3, "w", (int)((packed >> 24) & 0xFFu));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit byte4");

                x = math.clamp(x, byte.MinValue, byte.MaxValue);
                y = math.clamp(y, byte.MinValue, byte.MaxValue);
                z = math.clamp(z, byte.MinValue, byte.MaxValue);
                w = math.clamp(w, byte.MinValue, byte.MaxValue);
    
                packed =
                     (x & 0xFF) |
                    ((y & 0xFF) << 8) |
                    ((z & 0xFF) << 16) |
                    ((w & 0xFF) << 24);
    
                packedProp.intValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(byte8))]
    public class byte8Drawer : VectorInspector
    {
        public override float Count => 8;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            long packed = packedProp.longValue;

            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
            Rect r4 = new Rect(position.x + Indent, position.y + Step * 5, position.width, Line);
            Rect r5 = new Rect(position.x + Indent, position.y + Step * 6, position.width, Line);
            Rect r6 = new Rect(position.x + Indent, position.y + Step * 7, position.width, Line);
            Rect r7 = new Rect(position.x + Indent, position.y + Step * 8, position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 8) & 0xFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 16) & 0xFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 24) & 0xFFu));
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)((packed >> 32) & 0xFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 40) & 0xFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 48) & 0xFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit byte8");

                x0 = math.clamp(x0, byte.MinValue, byte.MaxValue);
                x1 = math.clamp(x1, byte.MinValue, byte.MaxValue);
                x2 = math.clamp(x2, byte.MinValue, byte.MaxValue);
                x3 = math.clamp(x3, byte.MinValue, byte.MaxValue);
                x4 = math.clamp(x4, byte.MinValue, byte.MaxValue);
                x5 = math.clamp(x5, byte.MinValue, byte.MaxValue);
                x6 = math.clamp(x6, byte.MinValue, byte.MaxValue);
                x7 = math.clamp(x7, byte.MinValue, byte.MaxValue);

                packed =
                     ((long)x0 & 0xFF) |
                    (((long)x1 & 0xFF) << 8) |
                    (((long)x2 & 0xFF) << 16) |
                    (((long)x3 & 0xFF) << 24) |
                    (((long)x4 & 0xFF) << 32) |
                    (((long)x5 & 0xFF) << 40) |
                    (((long)x6 & 0xFF) << 48) |
                    (((long)x7 & 0xFF) << 56);

                packedProp.longValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(byte16))]
    public class byte16Drawer : VectorInspector
    {
        public override float Count => 16;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            long packed = packedProp.longValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);
            Rect r8  = new Rect(position.x + Indent, position.y + Step * 9,  position.width, Line);
            Rect r9  = new Rect(position.x + Indent, position.y + Step * 10, position.width, Line);
            Rect r10 = new Rect(position.x + Indent, position.y + Step * 11, position.width, Line);
            Rect r11 = new Rect(position.x + Indent, position.y + Step * 12, position.width, Line);
            Rect r12 = new Rect(position.x + Indent, position.y + Step * 13, position.width, Line);
            Rect r13 = new Rect(position.x + Indent, position.y + Step * 14, position.width, Line);
            Rect r14 = new Rect(position.x + Indent, position.y + Step * 15, position.width, Line);
            Rect r15 = new Rect(position.x + Indent, position.y + Step * 16, position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 8) & 0xFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 16) & 0xFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 24) & 0xFFu));
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)((packed >> 32) & 0xFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 40) & 0xFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 48) & 0xFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit byte16");

                x0 = math.clamp(x0, byte.MinValue, byte.MaxValue);
                x1 = math.clamp(x1, byte.MinValue, byte.MaxValue);
                x2 = math.clamp(x2, byte.MinValue, byte.MaxValue);
                x3 = math.clamp(x3, byte.MinValue, byte.MaxValue);
                x4 = math.clamp(x4, byte.MinValue, byte.MaxValue);
                x5 = math.clamp(x5, byte.MinValue, byte.MaxValue);
                x6 = math.clamp(x6, byte.MinValue, byte.MaxValue);
                x7 = math.clamp(x7, byte.MinValue, byte.MaxValue);

                packed =
                     ((long)x0 & 0xFF) |
                    (((long)x1 & 0xFF) << 8) |
                    (((long)x2 & 0xFF) << 16) |
                    (((long)x3 & 0xFF) << 24) |
                    (((long)x4 & 0xFF) << 32) |
                    (((long)x5 & 0xFF) << 40) |
                    (((long)x6 & 0xFF) << 48) |
                    (((long)x7 & 0xFF) << 56);

                packedProp.longValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x8");

            packed = packedProp.longValue;

            EditorGUI.BeginChangeCheck();

            int x8  = EditorGUI.DelayedIntField(r8,   "x8", (int)(packed & 0xFFu));
            int x9  = EditorGUI.DelayedIntField(r9,   "x9", (int)((packed >> 8) & 0xFFu));
            int x10 = EditorGUI.DelayedIntField(r10, "x10", (int)((packed >> 16) & 0xFFu));
            int x11 = EditorGUI.DelayedIntField(r11, "x11", (int)((packed >> 24) & 0xFFu));
            int x12 = EditorGUI.DelayedIntField(r12, "x12", (int)((packed >> 32) & 0xFFu));
            int x13 = EditorGUI.DelayedIntField(r13, "x13", (int)((packed >> 40) & 0xFFu));
            int x14 = EditorGUI.DelayedIntField(r14, "x14", (int)((packed >> 48) & 0xFFu));
            int x15 = EditorGUI.DelayedIntField(r15, "x15", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x8  = math.clamp(x8,  byte.MinValue, byte.MaxValue);
                x9  = math.clamp(x9,  byte.MinValue, byte.MaxValue);
                x10 = math.clamp(x10, byte.MinValue, byte.MaxValue);
                x11 = math.clamp(x11, byte.MinValue, byte.MaxValue);
                x12 = math.clamp(x12, byte.MinValue, byte.MaxValue);
                x13 = math.clamp(x13, byte.MinValue, byte.MaxValue);
                x14 = math.clamp(x14, byte.MinValue, byte.MaxValue);
                x15 = math.clamp(x15, byte.MinValue, byte.MaxValue);

                packed =
                     ((long)x8  & 0xFF) |
                    (((long)x9  & 0xFF) << 8) |
                    (((long)x10 & 0xFF) << 16) |
                    (((long)x11 & 0xFF) << 24) |
                    (((long)x12 & 0xFF) << 32) |
                    (((long)x13 & 0xFF) << 40) |
                    (((long)x14 & 0xFF) << 48) |
                    (((long)x15 & 0xFF) << 56);

                packedProp.longValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(byte32))]
    public class byte32Drawer : VectorInspector
    {
        public override float Count => 32;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }
            SerializedProperty lo16 = property.FindPropertyRelative("__x0");
            SerializedProperty hi16 = property.FindPropertyRelative("__x16");
            SerializedProperty lo0 = lo16.FindPropertyRelative("__x0");
            SerializedProperty lo8 = lo16.FindPropertyRelative("__x8");
            SerializedProperty hi0 = hi16.FindPropertyRelative("__x0");
            SerializedProperty hi8 = hi16.FindPropertyRelative("__x8");

            EditorGUI.BeginProperty(position, label, property);

            long packed = lo0.longValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);
            Rect r8  = new Rect(position.x + Indent, position.y + Step * 9,  position.width, Line);
            Rect r9  = new Rect(position.x + Indent, position.y + Step * 10, position.width, Line);
            Rect r10 = new Rect(position.x + Indent, position.y + Step * 11, position.width, Line);
            Rect r11 = new Rect(position.x + Indent, position.y + Step * 12, position.width, Line);
            Rect r12 = new Rect(position.x + Indent, position.y + Step * 13, position.width, Line);
            Rect r13 = new Rect(position.x + Indent, position.y + Step * 14, position.width, Line);
            Rect r14 = new Rect(position.x + Indent, position.y + Step * 15, position.width, Line);
            Rect r15 = new Rect(position.x + Indent, position.y + Step * 16, position.width, Line);
            Rect r16 = new Rect(position.x + Indent, position.y + Step * 17, position.width, Line);
            Rect r17 = new Rect(position.x + Indent, position.y + Step * 18, position.width, Line);
            Rect r18 = new Rect(position.x + Indent, position.y + Step * 19, position.width, Line);
            Rect r19 = new Rect(position.x + Indent, position.y + Step * 20, position.width, Line);
            Rect r20 = new Rect(position.x + Indent, position.y + Step * 21, position.width, Line);
            Rect r21 = new Rect(position.x + Indent, position.y + Step * 22, position.width, Line);
            Rect r22 = new Rect(position.x + Indent, position.y + Step * 23, position.width, Line);
            Rect r23 = new Rect(position.x + Indent, position.y + Step * 24, position.width, Line);
            Rect r24 = new Rect(position.x + Indent, position.y + Step * 25, position.width, Line);
            Rect r25 = new Rect(position.x + Indent, position.y + Step * 26, position.width, Line);
            Rect r26 = new Rect(position.x + Indent, position.y + Step * 27, position.width, Line);
            Rect r27 = new Rect(position.x + Indent, position.y + Step * 28, position.width, Line);
            Rect r28 = new Rect(position.x + Indent, position.y + Step * 29, position.width, Line);
            Rect r29 = new Rect(position.x + Indent, position.y + Step * 30, position.width, Line);
            Rect r30 = new Rect(position.x + Indent, position.y + Step * 31, position.width, Line);
            Rect r31 = new Rect(position.x + Indent, position.y + Step * 32, position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 8) & 0xFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 16) & 0xFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 24) & 0xFFu));
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)((packed >> 32) & 0xFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 40) & 0xFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 48) & 0xFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit byte32");

                x0 = math.clamp(x0, byte.MinValue, byte.MaxValue);
                x1 = math.clamp(x1, byte.MinValue, byte.MaxValue);
                x2 = math.clamp(x2, byte.MinValue, byte.MaxValue);
                x3 = math.clamp(x3, byte.MinValue, byte.MaxValue);
                x4 = math.clamp(x4, byte.MinValue, byte.MaxValue);
                x5 = math.clamp(x5, byte.MinValue, byte.MaxValue);
                x6 = math.clamp(x6, byte.MinValue, byte.MaxValue);
                x7 = math.clamp(x7, byte.MinValue, byte.MaxValue);

                packed =
                     ((long)x0 & 0xFF) |
                    (((long)x1 & 0xFF) << 8) |
                    (((long)x2 & 0xFF) << 16) |
                    (((long)x3 & 0xFF) << 24) |
                    (((long)x4 & 0xFF) << 32) |
                    (((long)x5 & 0xFF) << 40) |
                    (((long)x6 & 0xFF) << 48) |
                    (((long)x7 & 0xFF) << 56);

                lo0.longValue = packed;
            }
            
            packed = lo8.longValue;

            EditorGUI.BeginChangeCheck();

            int x8  = EditorGUI.DelayedIntField(r8,  "x8", (int)(packed & 0xFFu));
            int x9  = EditorGUI.DelayedIntField(r9,  "x9", (int)((packed >> 8) & 0xFFu));
            int x10 = EditorGUI.DelayedIntField(r10, "x10", (int)((packed >> 16) & 0xFFu));
            int x11 = EditorGUI.DelayedIntField(r11, "x11", (int)((packed >> 24) & 0xFFu));
            int x12 = EditorGUI.DelayedIntField(r12, "x12", (int)((packed >> 32) & 0xFFu));
            int x13 = EditorGUI.DelayedIntField(r13, "x13", (int)((packed >> 40) & 0xFFu));
            int x14 = EditorGUI.DelayedIntField(r14, "x14", (int)((packed >> 48) & 0xFFu));
            int x15 = EditorGUI.DelayedIntField(r15, "x15", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x8  = math.clamp(x8,  byte.MinValue, byte.MaxValue);
                x9  = math.clamp(x9,  byte.MinValue, byte.MaxValue);
                x10 = math.clamp(x10, byte.MinValue, byte.MaxValue);
                x11 = math.clamp(x11, byte.MinValue, byte.MaxValue);
                x12 = math.clamp(x12, byte.MinValue, byte.MaxValue);
                x13 = math.clamp(x13, byte.MinValue, byte.MaxValue);
                x14 = math.clamp(x14, byte.MinValue, byte.MaxValue);
                x15 = math.clamp(x15, byte.MinValue, byte.MaxValue);

                packed =
                     ((long)x8  & 0xFF) |
                    (((long)x9  & 0xFF) << 8) |
                    (((long)x10 & 0xFF) << 16) |
                    (((long)x11 & 0xFF) << 24) |
                    (((long)x12 & 0xFF) << 32) |
                    (((long)x13 & 0xFF) << 40) |
                    (((long)x14 & 0xFF) << 48) |
                    (((long)x15 & 0xFF) << 56);

                lo8.longValue = packed;
            }

            EditorGUI.BeginChangeCheck();

            int x16 = EditorGUI.DelayedIntField(r16, "x16", (int)(packed & 0xFFu));
            int x17 = EditorGUI.DelayedIntField(r17, "x17", (int)((packed >> 8) & 0xFFu));
            int x18 = EditorGUI.DelayedIntField(r18, "x18", (int)((packed >> 16) & 0xFFu));
            int x19 = EditorGUI.DelayedIntField(r19, "x19", (int)((packed >> 24) & 0xFFu));
            int x20 = EditorGUI.DelayedIntField(r20, "x20", (int)((packed >> 32) & 0xFFu));
            int x21 = EditorGUI.DelayedIntField(r21, "x21", (int)((packed >> 40) & 0xFFu));
            int x22 = EditorGUI.DelayedIntField(r22, "x22", (int)((packed >> 48) & 0xFFu));
            int x23 = EditorGUI.DelayedIntField(r23, "x23", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x16 = math.clamp(x16, byte.MinValue, byte.MaxValue);
                x17 = math.clamp(x17, byte.MinValue, byte.MaxValue);
                x18 = math.clamp(x18, byte.MinValue, byte.MaxValue);
                x19 = math.clamp(x19, byte.MinValue, byte.MaxValue);
                x20 = math.clamp(x20, byte.MinValue, byte.MaxValue);
                x21 = math.clamp(x21, byte.MinValue, byte.MaxValue);
                x22 = math.clamp(x22, byte.MinValue, byte.MaxValue);
                x23 = math.clamp(x23, byte.MinValue, byte.MaxValue);

                packed =
                     ((long)x16 & 0xFF) |
                    (((long)x17 & 0xFF) << 8) |
                    (((long)x18 & 0xFF) << 16) |
                    (((long)x19 & 0xFF) << 24) |
                    (((long)x20 & 0xFF) << 32) |
                    (((long)x21 & 0xFF) << 40) |
                    (((long)x22 & 0xFF) << 48) |
                    (((long)x23 & 0xFF) << 56);

                hi0.longValue = packed;
            }
            
            packed = hi8.longValue;

            EditorGUI.BeginChangeCheck();

            int x24 = EditorGUI.DelayedIntField(r24, "x24", (int)(packed & 0xFFu));
            int x25 = EditorGUI.DelayedIntField(r25, "x25", (int)((packed >> 8) & 0xFFu));
            int x26 = EditorGUI.DelayedIntField(r26, "x26", (int)((packed >> 16) & 0xFFu));
            int x27 = EditorGUI.DelayedIntField(r27, "x27", (int)((packed >> 24) & 0xFFu));
            int x28 = EditorGUI.DelayedIntField(r28, "x28", (int)((packed >> 32) & 0xFFu));
            int x29 = EditorGUI.DelayedIntField(r29, "x29", (int)((packed >> 40) & 0xFFu));
            int x30 = EditorGUI.DelayedIntField(r30, "x30", (int)((packed >> 48) & 0xFFu));
            int x31 = EditorGUI.DelayedIntField(r31, "x31", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x24 = math.clamp(x24, byte.MinValue, byte.MaxValue);
                x25 = math.clamp(x25, byte.MinValue, byte.MaxValue);
                x26 = math.clamp(x26, byte.MinValue, byte.MaxValue);
                x27 = math.clamp(x27, byte.MinValue, byte.MaxValue);
                x28 = math.clamp(x28, byte.MinValue, byte.MaxValue);
                x29 = math.clamp(x29, byte.MinValue, byte.MaxValue);
                x30 = math.clamp(x30, byte.MinValue, byte.MaxValue);
                x31 = math.clamp(x31, byte.MinValue, byte.MaxValue);

                packed =
                     ((long)x24 & 0xFF) |
                    (((long)x25 & 0xFF) << 8) |
                    (((long)x26 & 0xFF) << 16) |
                    (((long)x27 & 0xFF) << 24) |
                    (((long)x28 & 0xFF) << 32) |
                    (((long)x29 & 0xFF) << 40) |
                    (((long)x30 & 0xFF) << 48) |
                    (((long)x31 & 0xFF) << 56);

                hi8.longValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    
    [CustomPropertyDrawer(typeof(sbyte2))]
    public class sbyte2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            int packed = packedProp.intValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFu));
            int y = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 8) & 0xFFu));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit sbyte2");

                x = math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
                y = math.clamp(y, sbyte.MinValue, sbyte.MaxValue);
    
                packed =
                     (x & 0xFF) |
                    ((y & 0xFF) << 8);
    
                packedProp.intValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(sbyte3))]
    public class sbyte3Drawer : VectorInspector
    {
        public override float Count => 3;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            int packed = packedProp.intValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 8) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit sbyte3");

                x0 = math.clamp(x0, sbyte.MinValue, sbyte.MaxValue);
                x1 = math.clamp(x1, sbyte.MinValue, sbyte.MaxValue);

                packed =
                     (x0 & 0xFF) |
                    ((x1 & 0xFF) << 8);

                packedProp.intValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x2");

            packed = packedProp.intValue;

            EditorGUI.BeginChangeCheck();

            int x2  = EditorGUI.DelayedIntField(r2,   "z", (int)(packed & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                packed = math.clamp(x2, sbyte.MinValue, sbyte.MaxValue);

                packedProp.intValue = x2 & 0xFF;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(sbyte4))]
    public class sbyte4Drawer : VectorInspector
    {
        public override float Count => 4;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            int packed = packedProp.intValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFu));
            int y = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 8) & 0xFFu));
            int z = EditorGUI.DelayedIntField(r2, "z", (int)((packed >> 16) & 0xFFu));
            int w = EditorGUI.DelayedIntField(r3, "w", (int)((packed >> 24) & 0xFFu));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit sbyte4");

                x = math.clamp(x, sbyte.MinValue, sbyte.MaxValue);
                y = math.clamp(y, sbyte.MinValue, sbyte.MaxValue);
                z = math.clamp(z, sbyte.MinValue, sbyte.MaxValue);
                w = math.clamp(w, sbyte.MinValue, sbyte.MaxValue);
    
                packed =
                     (x & 0xFF) |
                    ((y & 0xFF) << 8) |
                    ((z & 0xFF) << 16) |
                    ((w & 0xFF) << 24);
    
                packedProp.intValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(sbyte8))]
    public class sbyte8Drawer : VectorInspector
    {
        public override float Count => 8;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            long packed = packedProp.longValue;

            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
            Rect r4 = new Rect(position.x + Indent, position.y + Step * 5, position.width, Line);
            Rect r5 = new Rect(position.x + Indent, position.y + Step * 6, position.width, Line);
            Rect r6 = new Rect(position.x + Indent, position.y + Step * 7, position.width, Line);
            Rect r7 = new Rect(position.x + Indent, position.y + Step * 8, position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 8) & 0xFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 16) & 0xFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 24) & 0xFFu));
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)((packed >> 32) & 0xFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 40) & 0xFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 48) & 0xFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit sbyte8");

                x0 = math.clamp(x0, sbyte.MinValue, sbyte.MaxValue);
                x1 = math.clamp(x1, sbyte.MinValue, sbyte.MaxValue);
                x2 = math.clamp(x2, sbyte.MinValue, sbyte.MaxValue);
                x3 = math.clamp(x3, sbyte.MinValue, sbyte.MaxValue);
                x4 = math.clamp(x4, sbyte.MinValue, sbyte.MaxValue);
                x5 = math.clamp(x5, sbyte.MinValue, sbyte.MaxValue);
                x6 = math.clamp(x6, sbyte.MinValue, sbyte.MaxValue);
                x7 = math.clamp(x7, sbyte.MinValue, sbyte.MaxValue);

                packed =
                     ((long)x0 & 0xFF) |
                    (((long)x1 & 0xFF) << 8) |
                    (((long)x2 & 0xFF) << 16) |
                    (((long)x3 & 0xFF) << 24) |
                    (((long)x4 & 0xFF) << 32) |
                    (((long)x5 & 0xFF) << 40) |
                    (((long)x6 & 0xFF) << 48) |
                    (((long)x7 & 0xFF) << 56);

                packedProp.longValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(sbyte16))]
    public class sbyte16Drawer : VectorInspector
    {
        public override float Count => 16;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            long packed = packedProp.longValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);
            Rect r8  = new Rect(position.x + Indent, position.y + Step * 9,  position.width, Line);
            Rect r9  = new Rect(position.x + Indent, position.y + Step * 10, position.width, Line);
            Rect r10 = new Rect(position.x + Indent, position.y + Step * 11, position.width, Line);
            Rect r11 = new Rect(position.x + Indent, position.y + Step * 12, position.width, Line);
            Rect r12 = new Rect(position.x + Indent, position.y + Step * 13, position.width, Line);
            Rect r13 = new Rect(position.x + Indent, position.y + Step * 14, position.width, Line);
            Rect r14 = new Rect(position.x + Indent, position.y + Step * 15, position.width, Line);
            Rect r15 = new Rect(position.x + Indent, position.y + Step * 16, position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 8) & 0xFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 16) & 0xFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 24) & 0xFFu));
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)((packed >> 32) & 0xFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 40) & 0xFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 48) & 0xFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit sbyte16");

                x0 = math.clamp(x0, sbyte.MinValue, sbyte.MaxValue);
                x1 = math.clamp(x1, sbyte.MinValue, sbyte.MaxValue);
                x2 = math.clamp(x2, sbyte.MinValue, sbyte.MaxValue);
                x3 = math.clamp(x3, sbyte.MinValue, sbyte.MaxValue);
                x4 = math.clamp(x4, sbyte.MinValue, sbyte.MaxValue);
                x5 = math.clamp(x5, sbyte.MinValue, sbyte.MaxValue);
                x6 = math.clamp(x6, sbyte.MinValue, sbyte.MaxValue);
                x7 = math.clamp(x7, sbyte.MinValue, sbyte.MaxValue);

                packed =
                     ((long)x0 & 0xFF) |
                    (((long)x1 & 0xFF) << 8) |
                    (((long)x2 & 0xFF) << 16) |
                    (((long)x3 & 0xFF) << 24) |
                    (((long)x4 & 0xFF) << 32) |
                    (((long)x5 & 0xFF) << 40) |
                    (((long)x6 & 0xFF) << 48) |
                    (((long)x7 & 0xFF) << 56);

                packedProp.longValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x8");

            packed = packedProp.longValue;

            EditorGUI.BeginChangeCheck();

            int x8  = EditorGUI.DelayedIntField(r8,   "x8", (int)(packed & 0xFFu));
            int x9  = EditorGUI.DelayedIntField(r9,   "x9", (int)((packed >> 8) & 0xFFu));
            int x10 = EditorGUI.DelayedIntField(r10, "x10", (int)((packed >> 16) & 0xFFu));
            int x11 = EditorGUI.DelayedIntField(r11, "x11", (int)((packed >> 24) & 0xFFu));
            int x12 = EditorGUI.DelayedIntField(r12, "x12", (int)((packed >> 32) & 0xFFu));
            int x13 = EditorGUI.DelayedIntField(r13, "x13", (int)((packed >> 40) & 0xFFu));
            int x14 = EditorGUI.DelayedIntField(r14, "x14", (int)((packed >> 48) & 0xFFu));
            int x15 = EditorGUI.DelayedIntField(r15, "x15", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x8  = math.clamp(x8,  sbyte.MinValue, sbyte.MaxValue);
                x9  = math.clamp(x9,  sbyte.MinValue, sbyte.MaxValue);
                x10 = math.clamp(x10, sbyte.MinValue, sbyte.MaxValue);
                x11 = math.clamp(x11, sbyte.MinValue, sbyte.MaxValue);
                x12 = math.clamp(x12, sbyte.MinValue, sbyte.MaxValue);
                x13 = math.clamp(x13, sbyte.MinValue, sbyte.MaxValue);
                x14 = math.clamp(x14, sbyte.MinValue, sbyte.MaxValue);
                x15 = math.clamp(x15, sbyte.MinValue, sbyte.MaxValue);

                packed =
                     ((long)x8  & 0xFF) |
                    (((long)x9  & 0xFF) << 8) |
                    (((long)x10 & 0xFF) << 16) |
                    (((long)x11 & 0xFF) << 24) |
                    (((long)x12 & 0xFF) << 32) |
                    (((long)x13 & 0xFF) << 40) |
                    (((long)x14 & 0xFF) << 48) |
                    (((long)x15 & 0xFF) << 56);

                packedProp.longValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(sbyte32))]
    public class sbyte32Drawer : VectorInspector
    {
        public override float Count => 32;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }
            SerializedProperty lo16 = property.FindPropertyRelative("__x0");
            SerializedProperty hi16 = property.FindPropertyRelative("__x16");
            SerializedProperty lo0 = lo16.FindPropertyRelative("__x0");
            SerializedProperty lo8 = lo16.FindPropertyRelative("__x8");
            SerializedProperty hi0 = hi16.FindPropertyRelative("__x0");
            SerializedProperty hi8 = hi16.FindPropertyRelative("__x8");

            EditorGUI.BeginProperty(position, label, property);

            long packed = lo0.longValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);
            Rect r8  = new Rect(position.x + Indent, position.y + Step * 9,  position.width, Line);
            Rect r9  = new Rect(position.x + Indent, position.y + Step * 10, position.width, Line);
            Rect r10 = new Rect(position.x + Indent, position.y + Step * 11, position.width, Line);
            Rect r11 = new Rect(position.x + Indent, position.y + Step * 12, position.width, Line);
            Rect r12 = new Rect(position.x + Indent, position.y + Step * 13, position.width, Line);
            Rect r13 = new Rect(position.x + Indent, position.y + Step * 14, position.width, Line);
            Rect r14 = new Rect(position.x + Indent, position.y + Step * 15, position.width, Line);
            Rect r15 = new Rect(position.x + Indent, position.y + Step * 16, position.width, Line);
            Rect r16 = new Rect(position.x + Indent, position.y + Step * 17, position.width, Line);
            Rect r17 = new Rect(position.x + Indent, position.y + Step * 18, position.width, Line);
            Rect r18 = new Rect(position.x + Indent, position.y + Step * 19, position.width, Line);
            Rect r19 = new Rect(position.x + Indent, position.y + Step * 20, position.width, Line);
            Rect r20 = new Rect(position.x + Indent, position.y + Step * 21, position.width, Line);
            Rect r21 = new Rect(position.x + Indent, position.y + Step * 22, position.width, Line);
            Rect r22 = new Rect(position.x + Indent, position.y + Step * 23, position.width, Line);
            Rect r23 = new Rect(position.x + Indent, position.y + Step * 24, position.width, Line);
            Rect r24 = new Rect(position.x + Indent, position.y + Step * 25, position.width, Line);
            Rect r25 = new Rect(position.x + Indent, position.y + Step * 26, position.width, Line);
            Rect r26 = new Rect(position.x + Indent, position.y + Step * 27, position.width, Line);
            Rect r27 = new Rect(position.x + Indent, position.y + Step * 28, position.width, Line);
            Rect r28 = new Rect(position.x + Indent, position.y + Step * 29, position.width, Line);
            Rect r29 = new Rect(position.x + Indent, position.y + Step * 30, position.width, Line);
            Rect r30 = new Rect(position.x + Indent, position.y + Step * 31, position.width, Line);
            Rect r31 = new Rect(position.x + Indent, position.y + Step * 32, position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 8) & 0xFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 16) & 0xFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 24) & 0xFFu));
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)((packed >> 32) & 0xFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 40) & 0xFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 48) & 0xFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit sbyte32");

                x0 = math.clamp(x0, sbyte.MinValue, sbyte.MaxValue);
                x1 = math.clamp(x1, sbyte.MinValue, sbyte.MaxValue);
                x2 = math.clamp(x2, sbyte.MinValue, sbyte.MaxValue);
                x3 = math.clamp(x3, sbyte.MinValue, sbyte.MaxValue);
                x4 = math.clamp(x4, sbyte.MinValue, sbyte.MaxValue);
                x5 = math.clamp(x5, sbyte.MinValue, sbyte.MaxValue);
                x6 = math.clamp(x6, sbyte.MinValue, sbyte.MaxValue);
                x7 = math.clamp(x7, sbyte.MinValue, sbyte.MaxValue);

                packed =
                     ((long)x0 & 0xFF) |
                    (((long)x1 & 0xFF) << 8) |
                    (((long)x2 & 0xFF) << 16) |
                    (((long)x3 & 0xFF) << 24) |
                    (((long)x4 & 0xFF) << 32) |
                    (((long)x5 & 0xFF) << 40) |
                    (((long)x6 & 0xFF) << 48) |
                    (((long)x7 & 0xFF) << 56);

                lo0.longValue = packed;
            }
            
            packed = lo8.longValue;

            EditorGUI.BeginChangeCheck();

            int x8  = EditorGUI.DelayedIntField(r8,  "x8", (int)(packed & 0xFFu));
            int x9  = EditorGUI.DelayedIntField(r9,  "x9", (int)((packed >> 8) & 0xFFu));
            int x10 = EditorGUI.DelayedIntField(r10, "x10", (int)((packed >> 16) & 0xFFu));
            int x11 = EditorGUI.DelayedIntField(r11, "x11", (int)((packed >> 24) & 0xFFu));
            int x12 = EditorGUI.DelayedIntField(r12, "x12", (int)((packed >> 32) & 0xFFu));
            int x13 = EditorGUI.DelayedIntField(r13, "x13", (int)((packed >> 40) & 0xFFu));
            int x14 = EditorGUI.DelayedIntField(r14, "x14", (int)((packed >> 48) & 0xFFu));
            int x15 = EditorGUI.DelayedIntField(r15, "x15", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x8  = math.clamp(x8,  sbyte.MinValue, sbyte.MaxValue);
                x9  = math.clamp(x9,  sbyte.MinValue, sbyte.MaxValue);
                x10 = math.clamp(x10, sbyte.MinValue, sbyte.MaxValue);
                x11 = math.clamp(x11, sbyte.MinValue, sbyte.MaxValue);
                x12 = math.clamp(x12, sbyte.MinValue, sbyte.MaxValue);
                x13 = math.clamp(x13, sbyte.MinValue, sbyte.MaxValue);
                x14 = math.clamp(x14, sbyte.MinValue, sbyte.MaxValue);
                x15 = math.clamp(x15, sbyte.MinValue, sbyte.MaxValue);

                packed =
                     ((long)x8  & 0xFF) |
                    (((long)x9  & 0xFF) << 8) |
                    (((long)x10 & 0xFF) << 16) |
                    (((long)x11 & 0xFF) << 24) |
                    (((long)x12 & 0xFF) << 32) |
                    (((long)x13 & 0xFF) << 40) |
                    (((long)x14 & 0xFF) << 48) |
                    (((long)x15 & 0xFF) << 56);

                lo8.longValue = packed;
            }

            EditorGUI.BeginChangeCheck();

            int x16 = EditorGUI.DelayedIntField(r16, "x16", (int)(packed & 0xFFu));
            int x17 = EditorGUI.DelayedIntField(r17, "x17", (int)((packed >> 8) & 0xFFu));
            int x18 = EditorGUI.DelayedIntField(r18, "x18", (int)((packed >> 16) & 0xFFu));
            int x19 = EditorGUI.DelayedIntField(r19, "x19", (int)((packed >> 24) & 0xFFu));
            int x20 = EditorGUI.DelayedIntField(r20, "x20", (int)((packed >> 32) & 0xFFu));
            int x21 = EditorGUI.DelayedIntField(r21, "x21", (int)((packed >> 40) & 0xFFu));
            int x22 = EditorGUI.DelayedIntField(r22, "x22", (int)((packed >> 48) & 0xFFu));
            int x23 = EditorGUI.DelayedIntField(r23, "x23", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x16 = math.clamp(x16, sbyte.MinValue, sbyte.MaxValue);
                x17 = math.clamp(x17, sbyte.MinValue, sbyte.MaxValue);
                x18 = math.clamp(x18, sbyte.MinValue, sbyte.MaxValue);
                x19 = math.clamp(x19, sbyte.MinValue, sbyte.MaxValue);
                x20 = math.clamp(x20, sbyte.MinValue, sbyte.MaxValue);
                x21 = math.clamp(x21, sbyte.MinValue, sbyte.MaxValue);
                x22 = math.clamp(x22, sbyte.MinValue, sbyte.MaxValue);
                x23 = math.clamp(x23, sbyte.MinValue, sbyte.MaxValue);

                packed =
                     ((long)x16 & 0xFF) |
                    (((long)x17 & 0xFF) << 8) |
                    (((long)x18 & 0xFF) << 16) |
                    (((long)x19 & 0xFF) << 24) |
                    (((long)x20 & 0xFF) << 32) |
                    (((long)x21 & 0xFF) << 40) |
                    (((long)x22 & 0xFF) << 48) |
                    (((long)x23 & 0xFF) << 56);

                hi0.longValue = packed;
            }
            
            packed = hi8.longValue;

            EditorGUI.BeginChangeCheck();

            int x24 = EditorGUI.DelayedIntField(r24, "x24", (int)(packed & 0xFFu));
            int x25 = EditorGUI.DelayedIntField(r25, "x25", (int)((packed >> 8) & 0xFFu));
            int x26 = EditorGUI.DelayedIntField(r26, "x26", (int)((packed >> 16) & 0xFFu));
            int x27 = EditorGUI.DelayedIntField(r27, "x27", (int)((packed >> 24) & 0xFFu));
            int x28 = EditorGUI.DelayedIntField(r28, "x28", (int)((packed >> 32) & 0xFFu));
            int x29 = EditorGUI.DelayedIntField(r29, "x29", (int)((packed >> 40) & 0xFFu));
            int x30 = EditorGUI.DelayedIntField(r30, "x30", (int)((packed >> 48) & 0xFFu));
            int x31 = EditorGUI.DelayedIntField(r31, "x31", (int)((packed >> 56) & 0xFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x24 = math.clamp(x24, sbyte.MinValue, sbyte.MaxValue);
                x25 = math.clamp(x25, sbyte.MinValue, sbyte.MaxValue);
                x26 = math.clamp(x26, sbyte.MinValue, sbyte.MaxValue);
                x27 = math.clamp(x27, sbyte.MinValue, sbyte.MaxValue);
                x28 = math.clamp(x28, sbyte.MinValue, sbyte.MaxValue);
                x29 = math.clamp(x29, sbyte.MinValue, sbyte.MaxValue);
                x30 = math.clamp(x30, sbyte.MinValue, sbyte.MaxValue);
                x31 = math.clamp(x31, sbyte.MinValue, sbyte.MaxValue);

                packed =
                     ((long)x24 & 0xFF) |
                    (((long)x25 & 0xFF) << 8) |
                    (((long)x26 & 0xFF) << 16) |
                    (((long)x27 & 0xFF) << 24) |
                    (((long)x28 & 0xFF) << 32) |
                    (((long)x29 & 0xFF) << 40) |
                    (((long)x30 & 0xFF) << 48) |
                    (((long)x31 & 0xFF) << 56);

                hi8.longValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }
    

    [CustomPropertyDrawer(typeof(ushort2))]
    public class ushort2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            uint packed = packedProp.uintValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFFFu));
            int y = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 16) & 0xFFFFu));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit ushort2");

                x = math.clamp(x, ushort.MinValue, ushort.MaxValue);
                y = math.clamp(y, ushort.MinValue, ushort.MaxValue);
    
                packed = (uint)(
                     (x & 0xFFFF) |
                    ((y & 0xFFFF) << 16));
    
                packedProp.uintValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(ushort3))]
    public class ushort3Drawer : VectorInspector
    {
        public override float Count => 3;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            uint packed = packedProp.uintValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 16) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit ushort3");

                x0 = math.clamp(x0, ushort.MinValue, ushort.MaxValue);
                x1 = math.clamp(x1, ushort.MinValue, ushort.MaxValue);

                packed = (uint)(
                     (x0 & 0xFFFF) |
                    ((x1 & 0xFFFF) << 16));

                packedProp.uintValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x2");

            packed = packedProp.uintValue;

            EditorGUI.BeginChangeCheck();

            int x2  = EditorGUI.DelayedIntField(r2,   "z", (int)(packed & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                packed = (uint)math.clamp(x2, ushort.MinValue, ushort.MaxValue);

                packedProp.uintValue = (uint)x2 & 0xFFFF;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(ushort4))]
    public class ushort4Drawer : VectorInspector
    {
        public override float Count => 4;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            ulong packed = packedProp.ulongValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFFFu));
            int y = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 16) & 0xFFFFu));
            int z = EditorGUI.DelayedIntField(r2, "z", (int)((packed >> 32) & 0xFFFFu));
            int w = EditorGUI.DelayedIntField(r3, "w", (int)((packed >> 48) & 0xFFFFu));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit ushort4");

                x = math.clamp(x, ushort.MinValue, ushort.MaxValue);
                y = math.clamp(y, ushort.MinValue, ushort.MaxValue);
                z = math.clamp(z, ushort.MinValue, ushort.MaxValue);
                w = math.clamp(w, ushort.MinValue, ushort.MaxValue);
    
                packed =
                     ((ulong)x & 0xFFFF) |
                    (((ulong)y & 0xFFFF) << 16) |
                    (((ulong)z & 0xFFFF) << 32) |
                    (((ulong)w & 0xFFFF) << 48);
    
                packedProp.ulongValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(ushort8))]
    public class ushort8Drawer : VectorInspector
    {
        public override float Count => 8;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            ulong packed = packedProp.ulongValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 16) & 0xFFFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 32) & 0xFFFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit ushort16");

                x0 = math.clamp(x0, ushort.MinValue, ushort.MaxValue);
                x1 = math.clamp(x1, ushort.MinValue, ushort.MaxValue);
                x2 = math.clamp(x2, ushort.MinValue, ushort.MaxValue);
                x3 = math.clamp(x3, ushort.MinValue, ushort.MaxValue);

                packed =
                     ((ulong)x0 & 0xFFFF) |
                    (((ulong)x1 & 0xFFFF) << 16) |
                    (((ulong)x2 & 0xFFFF) << 32) |
                    (((ulong)x3 & 0xFFFF) << 48);

                packedProp.ulongValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x4");

            packed = packedProp.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)(packed & 0xFFFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 16) & 0xFFFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 32) & 0xFFFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x4 = math.clamp(x4, ushort.MinValue, ushort.MaxValue);
                x5 = math.clamp(x5, ushort.MinValue, ushort.MaxValue);
                x6 = math.clamp(x6, ushort.MinValue, ushort.MaxValue);
                x7 = math.clamp(x7, ushort.MinValue, ushort.MaxValue);

                packed =
                     ((ulong)x4 & 0xFFFF) |
                    (((ulong)x5 & 0xFFFF) << 16) |
                    (((ulong)x6 & 0xFFFF) << 32) |
                    (((ulong)x7 & 0xFFFF) << 48);

                packedProp.ulongValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(ushort16))]
    public class ushort16Drawer : VectorInspector
    {
        public override float Count => 16;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }
            SerializedProperty lo16 = property.FindPropertyRelative("__x0");
            SerializedProperty hi16 = property.FindPropertyRelative("__x8");
            SerializedProperty lo0 = lo16.FindPropertyRelative("__x0");
            SerializedProperty lo8 = lo16.FindPropertyRelative("__x4");
            SerializedProperty hi0 = hi16.FindPropertyRelative("__x0");
            SerializedProperty hi8 = hi16.FindPropertyRelative("__x4");

            EditorGUI.BeginProperty(position, label, property);

            ulong packed = lo0.ulongValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);
            Rect r8  = new Rect(position.x + Indent, position.y + Step * 9,  position.width, Line);
            Rect r9  = new Rect(position.x + Indent, position.y + Step * 10, position.width, Line);
            Rect r10 = new Rect(position.x + Indent, position.y + Step * 11, position.width, Line);
            Rect r11 = new Rect(position.x + Indent, position.y + Step * 12, position.width, Line);
            Rect r12 = new Rect(position.x + Indent, position.y + Step * 13, position.width, Line);
            Rect r13 = new Rect(position.x + Indent, position.y + Step * 14, position.width, Line);
            Rect r14 = new Rect(position.x + Indent, position.y + Step * 15, position.width, Line);
            Rect r15 = new Rect(position.x + Indent, position.y + Step * 16, position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 16) & 0xFFFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 32) & 0xFFFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit ushort32");

                x0 = math.clamp(x0, ushort.MinValue, ushort.MaxValue);
                x1 = math.clamp(x1, ushort.MinValue, ushort.MaxValue);
                x2 = math.clamp(x2, ushort.MinValue, ushort.MaxValue);
                x3 = math.clamp(x3, ushort.MinValue, ushort.MaxValue);

                packed =
                     ((ulong)x0 & 0xFFFF) |
                    (((ulong)x1 & 0xFFFF) << 16) |
                    (((ulong)x2 & 0xFFFF) << 32) |
                    (((ulong)x3 & 0xFFFF) << 48);

                lo0.ulongValue = packed;
            }
            
            packed = lo8.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)(packed & 0xFFFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 16) & 0xFFFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 32) & 0xFFFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x4 = math.clamp(x4, ushort.MinValue, ushort.MaxValue);
                x5 = math.clamp(x5, ushort.MinValue, ushort.MaxValue);
                x6 = math.clamp(x6, ushort.MinValue, ushort.MaxValue);
                x7 = math.clamp(x7, ushort.MinValue, ushort.MaxValue);

                packed =
                     ((ulong)x4 & 0xFFFF) |
                    (((ulong)x5 & 0xFFFF) << 16) |
                    (((ulong)x6 & 0xFFFF) << 32) |
                    (((ulong)x7 & 0xFFFF) << 48);

                lo8.ulongValue = packed;
            }
            
            packed = hi0.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            int x8  = EditorGUI.DelayedIntField(r8,  "x8", (int)(packed & 0xFFFFu));
            int x9  = EditorGUI.DelayedIntField(r9,  "x9", (int)((packed >> 16) & 0xFFFFu));
            int x10 = EditorGUI.DelayedIntField(r10, "x10", (int)((packed >> 32) & 0xFFFFu));
            int x11 = EditorGUI.DelayedIntField(r11, "x11", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x8  = math.clamp(x8,  ushort.MinValue, ushort.MaxValue);
                x9  = math.clamp(x9,  ushort.MinValue, ushort.MaxValue);
                x10 = math.clamp(x10, ushort.MinValue, ushort.MaxValue);
                x11 = math.clamp(x11, ushort.MinValue, ushort.MaxValue);
                
                packed =
                     ((ulong)x8  & 0xFFFF) |
                    (((ulong)x9  & 0xFFFF) << 16) |
                    (((ulong)x10 & 0xFFFF) << 32) |
                    (((ulong)x11 & 0xFFFF) << 48);

                hi0.ulongValue = packed;
            }
            
            packed = hi8.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            int x12 = EditorGUI.DelayedIntField(r12, "x12", (int)(packed & 0xFFFFu));
            int x13 = EditorGUI.DelayedIntField(r13, "x13", (int)((packed >> 16) & 0xFFFFu));
            int x14 = EditorGUI.DelayedIntField(r14, "x14", (int)((packed >> 32) & 0xFFFFu));
            int x15 = EditorGUI.DelayedIntField(r15, "x15", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x12 = math.clamp(x12, ushort.MinValue, ushort.MaxValue);
                x13 = math.clamp(x13, ushort.MinValue, ushort.MaxValue);
                x14 = math.clamp(x14, ushort.MinValue, ushort.MaxValue);
                x15 = math.clamp(x15, ushort.MinValue, ushort.MaxValue);
                
                packed =
                     ((ulong)x12 & 0xFFFF) |
                    (((ulong)x13 & 0xFFFF) << 16) |
                    (((ulong)x14 & 0xFFFF) << 32) |
                    (((ulong)x15 & 0xFFFF) << 48);

                hi8.ulongValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }
    

    [CustomPropertyDrawer(typeof(short2))]
    public class short2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            uint packed = packedProp.uintValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFFFu));
            int y = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 16) & 0xFFFFu));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit short2");

                x = math.clamp(x, short.MinValue, short.MaxValue);
                y = math.clamp(y, short.MinValue, short.MaxValue);
    
                packed = (uint)(
                     (x & 0xFFFF) |
                    ((y & 0xFFFF) << 16));
    
                packedProp.uintValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(short3))]
    public class short3Drawer : VectorInspector
    {
        public override float Count => 3;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            uint packed = packedProp.uintValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 16) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit short3");

                x0 = math.clamp(x0, short.MinValue, short.MaxValue);
                x1 = math.clamp(x1, short.MinValue, short.MaxValue);

                packed = (uint)(
                     (x0 & 0xFFFF) |
                    ((x1 & 0xFFFF) << 16));

                packedProp.uintValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x2");

            packed = packedProp.uintValue;

            EditorGUI.BeginChangeCheck();

            int x2  = EditorGUI.DelayedIntField(r2,   "z", (int)(packed & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                packed = (uint)math.clamp(x2, short.MinValue, short.MaxValue);

                packedProp.uintValue = (uint)x2 & 0xFFFF;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(short4))]
    public class short4Drawer : VectorInspector
    {
        public override float Count => 4;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            ulong packed = packedProp.ulongValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", (int)(packed & 0xFFFFu));
            int y = EditorGUI.DelayedIntField(r1, "y", (int)((packed >> 16) & 0xFFFFu));
            int z = EditorGUI.DelayedIntField(r2, "z", (int)((packed >> 32) & 0xFFFFu));
            int w = EditorGUI.DelayedIntField(r3, "w", (int)((packed >> 48) & 0xFFFFu));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit short4");

                x = math.clamp(x, short.MinValue, short.MaxValue);
                y = math.clamp(y, short.MinValue, short.MaxValue);
                z = math.clamp(z, short.MinValue, short.MaxValue);
                w = math.clamp(w, short.MinValue, short.MaxValue);
    
                packed =
                     ((ulong)x & 0xFFFF) |
                    (((ulong)y & 0xFFFF) << 16) |
                    (((ulong)z & 0xFFFF) << 32) |
                    (((ulong)w & 0xFFFF) << 48);
    
                packedProp.ulongValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(short8))]
    public class short8Drawer : VectorInspector
    {
        public override float Count => 8;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            ulong packed = packedProp.ulongValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 16) & 0xFFFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 32) & 0xFFFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit short16");

                x0 = math.clamp(x0, short.MinValue, short.MaxValue);
                x1 = math.clamp(x1, short.MinValue, short.MaxValue);
                x2 = math.clamp(x2, short.MinValue, short.MaxValue);
                x3 = math.clamp(x3, short.MinValue, short.MaxValue);

                packed =
                     ((ulong)x0 & 0xFFFF) |
                    (((ulong)x1 & 0xFFFF) << 16) |
                    (((ulong)x2 & 0xFFFF) << 32) |
                    (((ulong)x3 & 0xFFFF) << 48);

                packedProp.ulongValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x4");

            packed = packedProp.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)(packed & 0xFFFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 16) & 0xFFFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 32) & 0xFFFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x4 = math.clamp(x4, short.MinValue, short.MaxValue);
                x5 = math.clamp(x5, short.MinValue, short.MaxValue);
                x6 = math.clamp(x6, short.MinValue, short.MaxValue);
                x7 = math.clamp(x7, short.MinValue, short.MaxValue);

                packed =
                     ((ulong)x4 & 0xFFFF) |
                    (((ulong)x5 & 0xFFFF) << 16) |
                    (((ulong)x6 & 0xFFFF) << 32) |
                    (((ulong)x7 & 0xFFFF) << 48);

                packedProp.ulongValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(short16))]
    public class short16Drawer : VectorInspector
    {
        public override float Count => 16;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }
            SerializedProperty lo16 = property.FindPropertyRelative("__x0");
            SerializedProperty hi16 = property.FindPropertyRelative("__x8");
            SerializedProperty lo0 = lo16.FindPropertyRelative("__x0");
            SerializedProperty lo8 = lo16.FindPropertyRelative("__x4");
            SerializedProperty hi0 = hi16.FindPropertyRelative("__x0");
            SerializedProperty hi8 = hi16.FindPropertyRelative("__x4");

            EditorGUI.BeginProperty(position, label, property);

            ulong packed = lo0.ulongValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);
            Rect r8  = new Rect(position.x + Indent, position.y + Step * 9,  position.width, Line);
            Rect r9  = new Rect(position.x + Indent, position.y + Step * 10, position.width, Line);
            Rect r10 = new Rect(position.x + Indent, position.y + Step * 11, position.width, Line);
            Rect r11 = new Rect(position.x + Indent, position.y + Step * 12, position.width, Line);
            Rect r12 = new Rect(position.x + Indent, position.y + Step * 13, position.width, Line);
            Rect r13 = new Rect(position.x + Indent, position.y + Step * 14, position.width, Line);
            Rect r14 = new Rect(position.x + Indent, position.y + Step * 15, position.width, Line);
            Rect r15 = new Rect(position.x + Indent, position.y + Step * 16, position.width, Line);

            EditorGUI.BeginChangeCheck();

            int x0 = EditorGUI.DelayedIntField(r0, "x0", (int)(packed & 0xFFFFu));
            int x1 = EditorGUI.DelayedIntField(r1, "x1", (int)((packed >> 16) & 0xFFFFu));
            int x2 = EditorGUI.DelayedIntField(r2, "x2", (int)((packed >> 32) & 0xFFFFu));
            int x3 = EditorGUI.DelayedIntField(r3, "x3", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit short32");

                x0 = math.clamp(x0, short.MinValue, short.MaxValue);
                x1 = math.clamp(x1, short.MinValue, short.MaxValue);
                x2 = math.clamp(x2, short.MinValue, short.MaxValue);
                x3 = math.clamp(x3, short.MinValue, short.MaxValue);

                packed =
                     ((ulong)x0 & 0xFFFF) |
                    (((ulong)x1 & 0xFFFF) << 16) |
                    (((ulong)x2 & 0xFFFF) << 32) |
                    (((ulong)x3 & 0xFFFF) << 48);

                lo0.ulongValue = packed;
            }
            
            packed = lo8.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            int x4 = EditorGUI.DelayedIntField(r4, "x4", (int)(packed & 0xFFFFu));
            int x5 = EditorGUI.DelayedIntField(r5, "x5", (int)((packed >> 16) & 0xFFFFu));
            int x6 = EditorGUI.DelayedIntField(r6, "x6", (int)((packed >> 32) & 0xFFFFu));
            int x7 = EditorGUI.DelayedIntField(r7, "x7", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x4 = math.clamp(x4, short.MinValue, short.MaxValue);
                x5 = math.clamp(x5, short.MinValue, short.MaxValue);
                x6 = math.clamp(x6, short.MinValue, short.MaxValue);
                x7 = math.clamp(x7, short.MinValue, short.MaxValue);

                packed =
                     ((ulong)x4 & 0xFFFF) |
                    (((ulong)x5 & 0xFFFF) << 16) |
                    (((ulong)x6 & 0xFFFF) << 32) |
                    (((ulong)x7 & 0xFFFF) << 48);

                lo8.ulongValue = packed;
            }
            
            packed = hi0.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            int x8  = EditorGUI.DelayedIntField(r8,  "x8", (int)(packed & 0xFFFFu));
            int x9  = EditorGUI.DelayedIntField(r9,  "x9", (int)((packed >> 16) & 0xFFFFu));
            int x10 = EditorGUI.DelayedIntField(r10, "x10", (int)((packed >> 32) & 0xFFFFu));
            int x11 = EditorGUI.DelayedIntField(r11, "x11", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x8  = math.clamp(x8,  short.MinValue, short.MaxValue);
                x9  = math.clamp(x9,  short.MinValue, short.MaxValue);
                x10 = math.clamp(x10, short.MinValue, short.MaxValue);
                x11 = math.clamp(x11, short.MinValue, short.MaxValue);
                
                packed =
                     ((ulong)x8  & 0xFFFF) |
                    (((ulong)x9  & 0xFFFF) << 16) |
                    (((ulong)x10 & 0xFFFF) << 32) |
                    (((ulong)x11 & 0xFFFF) << 48);

                hi0.ulongValue = packed;
            }
            
            packed = hi8.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            int x12 = EditorGUI.DelayedIntField(r12, "x12", (int)(packed & 0xFFFFu));
            int x13 = EditorGUI.DelayedIntField(r13, "x13", (int)((packed >> 16) & 0xFFFFu));
            int x14 = EditorGUI.DelayedIntField(r14, "x14", (int)((packed >> 32) & 0xFFFFu));
            int x15 = EditorGUI.DelayedIntField(r15, "x15", (int)((packed >> 48) & 0xFFFFu));

            if (EditorGUI.EndChangeCheck())
            {
                x12 = math.clamp(x12, short.MinValue, short.MaxValue);
                x13 = math.clamp(x13, short.MinValue, short.MaxValue);
                x14 = math.clamp(x14, short.MinValue, short.MaxValue);
                x15 = math.clamp(x15, short.MinValue, short.MaxValue);
                
                packed =
                     ((ulong)x12 & 0xFFFF) |
                    (((ulong)x13 & 0xFFFF) << 16) |
                    (((ulong)x14 & 0xFFFF) << 32) |
                    (((ulong)x15 & 0xFFFF) << 48);

                hi8.ulongValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }
    

    [CustomPropertyDrawer(typeof(uint2))]
    public class uint2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("x");
            SerializedProperty yProp = packedProp.FindPropertyRelative("y");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            uint x = EditorGUIExtensions.DelayedField(r0, "x", xProp.uintValue);
            uint y = EditorGUIExtensions.DelayedField(r1, "y", yProp.uintValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit uint2");

                xProp.uintValue = x;
                yProp.uintValue = y;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(uint3))]
    public class uint3Drawer : VectorInspector
    {
        public override float Count => 3;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("x");
            SerializedProperty yProp = packedProp.FindPropertyRelative("y");
            SerializedProperty zProp = packedProp.FindPropertyRelative("z");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            uint x = EditorGUIExtensions.DelayedField(r0, "x", xProp.uintValue);
            uint y = EditorGUIExtensions.DelayedField(r1, "y", yProp.uintValue);
            uint z = EditorGUIExtensions.DelayedField(r2, "z", zProp.uintValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit uint3");

                xProp.uintValue = x;
                yProp.uintValue = y;
                zProp.uintValue = z;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(uint4))]
    public class uint4Drawer : VectorInspector
    {
        public override float Count => 4;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("x");
            SerializedProperty yProp = packedProp.FindPropertyRelative("y");
            SerializedProperty zProp = packedProp.FindPropertyRelative("z");
            SerializedProperty wProp = packedProp.FindPropertyRelative("w");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            uint x = EditorGUIExtensions.DelayedField(r0, "x", xProp.uintValue);
            uint y = EditorGUIExtensions.DelayedField(r1, "y", yProp.uintValue);
            uint z = EditorGUIExtensions.DelayedField(r2, "z", zProp.uintValue);
            uint w = EditorGUIExtensions.DelayedField(r3, "w", wProp.uintValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit uint4");

                xProp.uintValue = x;
                yProp.uintValue = y;
                zProp.uintValue = z;
                wProp.uintValue = w;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(uint8))]
    public class uint8Drawer : VectorInspector
    {
        public override float Count => 8;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty lo = property.FindPropertyRelative("__x0").FindPropertyRelative("__x0");
            SerializedProperty hi = property.FindPropertyRelative("__x4").FindPropertyRelative("__x0");
            SerializedProperty x0Prop = lo.FindPropertyRelative("x");
            SerializedProperty x1Prop = lo.FindPropertyRelative("y");
            SerializedProperty x2Prop = lo.FindPropertyRelative("z");
            SerializedProperty x3Prop = lo.FindPropertyRelative("w");
            SerializedProperty x4Prop = hi.FindPropertyRelative("x");
            SerializedProperty x5Prop = hi.FindPropertyRelative("y");
            SerializedProperty x6Prop = hi.FindPropertyRelative("z");
            SerializedProperty x7Prop = hi.FindPropertyRelative("w");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
            Rect r4 = new Rect(position.x + Indent, position.y + Step * 5, position.width, Line);
            Rect r5 = new Rect(position.x + Indent, position.y + Step * 6, position.width, Line);
            Rect r6 = new Rect(position.x + Indent, position.y + Step * 7, position.width, Line);
            Rect r7 = new Rect(position.x + Indent, position.y + Step * 8, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            uint x0 = EditorGUIExtensions.DelayedField(r0, "x0", x0Prop.uintValue);
            uint x1 = EditorGUIExtensions.DelayedField(r1, "x1", x1Prop.uintValue);
            uint x2 = EditorGUIExtensions.DelayedField(r2, "x2", x2Prop.uintValue);
            uint x3 = EditorGUIExtensions.DelayedField(r3, "x3", x3Prop.uintValue);
            uint x4 = EditorGUIExtensions.DelayedField(r4, "x4", x4Prop.uintValue);
            uint x5 = EditorGUIExtensions.DelayedField(r5, "x5", x5Prop.uintValue);
            uint x6 = EditorGUIExtensions.DelayedField(r6, "x6", x6Prop.uintValue);
            uint x7 = EditorGUIExtensions.DelayedField(r7, "x7", x7Prop.uintValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit uint8");

                x0Prop.uintValue = x0;
                x1Prop.uintValue = x1;
                x2Prop.uintValue = x2;
                x3Prop.uintValue = x3;
                x4Prop.uintValue = x4;
                x5Prop.uintValue = x5;
                x6Prop.uintValue = x6;
                x7Prop.uintValue = x7;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(int2))]
    public class int2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("x");
            SerializedProperty yProp = packedProp.FindPropertyRelative("y");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", xProp.intValue);
            int y = EditorGUI.DelayedIntField(r1, "y", yProp.intValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit int2");

                xProp.intValue = x;
                yProp.intValue = y;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(int3))]
    public class int3Drawer : VectorInspector
    {
        public override float Count => 3;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("x");
            SerializedProperty yProp = packedProp.FindPropertyRelative("y");
            SerializedProperty zProp = packedProp.FindPropertyRelative("z");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", xProp.intValue);
            int y = EditorGUI.DelayedIntField(r1, "y", yProp.intValue);
            int z = EditorGUI.DelayedIntField(r2, "z", zProp.intValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit int3");

                xProp.intValue = x;
                yProp.intValue = y;
                zProp.intValue = z;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(int4))]
    public class int4Drawer : VectorInspector
    {
        public override float Count => 4;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("x");
            SerializedProperty yProp = packedProp.FindPropertyRelative("y");
            SerializedProperty zProp = packedProp.FindPropertyRelative("z");
            SerializedProperty wProp = packedProp.FindPropertyRelative("w");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x = EditorGUI.DelayedIntField(r0, "x", xProp.intValue);
            int y = EditorGUI.DelayedIntField(r1, "y", yProp.intValue);
            int z = EditorGUI.DelayedIntField(r2, "z", zProp.intValue);
            int w = EditorGUI.DelayedIntField(r3, "w", wProp.intValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit int4");

                xProp.intValue = x;
                yProp.intValue = y;
                zProp.intValue = z;
                wProp.intValue = w;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(int8))]
    public class int8Drawer : VectorInspector
    {
        public override float Count => 8;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty lo = property.FindPropertyRelative("__x0").FindPropertyRelative("__x0");
            SerializedProperty hi = property.FindPropertyRelative("__x4").FindPropertyRelative("__x0");
            SerializedProperty x0Prop = lo.FindPropertyRelative("x");
            SerializedProperty x1Prop = lo.FindPropertyRelative("y");
            SerializedProperty x2Prop = lo.FindPropertyRelative("z");
            SerializedProperty x3Prop = lo.FindPropertyRelative("w");
            SerializedProperty x4Prop = hi.FindPropertyRelative("x");
            SerializedProperty x5Prop = hi.FindPropertyRelative("y");
            SerializedProperty x6Prop = hi.FindPropertyRelative("z");
            SerializedProperty x7Prop = hi.FindPropertyRelative("w");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
            Rect r4 = new Rect(position.x + Indent, position.y + Step * 5, position.width, Line);
            Rect r5 = new Rect(position.x + Indent, position.y + Step * 6, position.width, Line);
            Rect r6 = new Rect(position.x + Indent, position.y + Step * 7, position.width, Line);
            Rect r7 = new Rect(position.x + Indent, position.y + Step * 8, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            int x0 = EditorGUI.DelayedIntField(r0, "x0", x0Prop.intValue);
            int x1 = EditorGUI.DelayedIntField(r1, "x1", x1Prop.intValue);
            int x2 = EditorGUI.DelayedIntField(r2, "x2", x2Prop.intValue);
            int x3 = EditorGUI.DelayedIntField(r3, "x3", x3Prop.intValue);
            int x4 = EditorGUI.DelayedIntField(r4, "x4", x4Prop.intValue);
            int x5 = EditorGUI.DelayedIntField(r5, "x5", x5Prop.intValue);
            int x6 = EditorGUI.DelayedIntField(r6, "x6", x6Prop.intValue);
            int x7 = EditorGUI.DelayedIntField(r7, "x7", x7Prop.intValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit int8");

                x0Prop.intValue = x0;
                x1Prop.intValue = x1;
                x2Prop.intValue = x2;
                x3Prop.intValue = x3;
                x4Prop.intValue = x4;
                x5Prop.intValue = x5;
                x6Prop.intValue = x6;
                x7Prop.intValue = x7;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    

    [CustomPropertyDrawer(typeof(ulong2))]
    public class ulong2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty xProp = property.FindPropertyRelative("__x0");
            SerializedProperty yProp = property.FindPropertyRelative("__x1");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            ulong x = EditorGUIExtensions.DelayedField(r0, "x", xProp.ulongValue);
            ulong y = EditorGUIExtensions.DelayedField(r1, "y", yProp.ulongValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit ulong2");

                xProp.ulongValue = x;
                yProp.ulongValue = y;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(ulong3))]
    public class ulong3Drawer : VectorInspector
    {
        public override float Count => 3;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("__x0");
            SerializedProperty yProp = packedProp.FindPropertyRelative("__x1");
            SerializedProperty zProp = property.FindPropertyRelative("__x2");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            ulong x = EditorGUIExtensions.DelayedField(r0, "x", xProp.ulongValue);
            ulong y = EditorGUIExtensions.DelayedField(r1, "y", yProp.ulongValue);
            ulong z = EditorGUIExtensions.DelayedField(r2, "z", zProp.ulongValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit ulong3");

                xProp.ulongValue = x;
                yProp.ulongValue = y;
                zProp.ulongValue = z;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(ulong4))]
    public class ulong4Drawer : VectorInspector
    {
        public override float Count => 4;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }
            
            SerializedProperty lo = property.FindPropertyRelative("__x0");
            SerializedProperty hi = property.FindPropertyRelative("__x2");
            SerializedProperty xProp = lo.FindPropertyRelative("__x0");
            SerializedProperty yProp = lo.FindPropertyRelative("__x1");
            SerializedProperty zProp = hi.FindPropertyRelative("__x0");
            SerializedProperty wProp = hi.FindPropertyRelative("__x1");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            ulong x = EditorGUIExtensions.DelayedField(r0, "x", xProp.ulongValue);
            ulong y = EditorGUIExtensions.DelayedField(r1, "y", yProp.ulongValue);
            ulong z = EditorGUIExtensions.DelayedField(r2, "z", zProp.ulongValue);
            ulong w = EditorGUIExtensions.DelayedField(r3, "w", wProp.ulongValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit ulong4");

                xProp.ulongValue = x;
                yProp.ulongValue = y;
                zProp.ulongValue = z;
                wProp.ulongValue = w;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    

    [CustomPropertyDrawer(typeof(long2))]
    public class long2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty xProp = property.FindPropertyRelative("__x0");
            SerializedProperty yProp = property.FindPropertyRelative("__x1");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            long x = EditorGUIExtensions.DelayedField(r0, "x", xProp.longValue);
            long y = EditorGUIExtensions.DelayedField(r1, "y", yProp.longValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit long2");

                xProp.longValue = x;
                yProp.longValue = y;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(long3))]
    public class long3Drawer : VectorInspector
    {
        public override float Count => 3;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("__x0");
            SerializedProperty yProp = packedProp.FindPropertyRelative("__x1");
            SerializedProperty zProp = property.FindPropertyRelative("__x2");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            long x = EditorGUIExtensions.DelayedField(r0, "x", xProp.longValue);
            long y = EditorGUIExtensions.DelayedField(r1, "y", yProp.longValue);
            long z = EditorGUIExtensions.DelayedField(r2, "z", zProp.longValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit long3");

                xProp.longValue = x;
                yProp.longValue = y;
                zProp.longValue = z;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(long4))]
    public class long4Drawer : VectorInspector
    {
        public override float Count => 4;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }
            
            SerializedProperty lo = property.FindPropertyRelative("__x0");
            SerializedProperty hi = property.FindPropertyRelative("__x2");
            SerializedProperty xProp = lo.FindPropertyRelative("__x0");
            SerializedProperty yProp = lo.FindPropertyRelative("__x1");
            SerializedProperty zProp = hi.FindPropertyRelative("__x0");
            SerializedProperty wProp = hi.FindPropertyRelative("__x1");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            long x = EditorGUIExtensions.DelayedField(r0, "x", xProp.longValue);
            long y = EditorGUIExtensions.DelayedField(r1, "y", yProp.longValue);
            long z = EditorGUIExtensions.DelayedField(r2, "z", zProp.longValue);
            long w = EditorGUIExtensions.DelayedField(r3, "w", wProp.longValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit long4");

                xProp.longValue = x;
                yProp.longValue = y;
                zProp.longValue = z;
                wProp.longValue = w;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }

    
    [CustomPropertyDrawer(typeof(quarter2))]
    public class quarter2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            int packed = packedProp.intValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            quarter x = EditorGUIExtensions.DelayedField(r0, "x", math.asquarter((byte)(packed & 0xFFu)));
            quarter y = EditorGUIExtensions.DelayedField(r1, "y", math.asquarter((byte)((packed >> 8) & 0xFFu)));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit quarter2");

                packed =
                     (math.asbyte(x) & 0xFF) |
                    ((math.asbyte(y) & 0xFF) << 8);
    
                packedProp.intValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(quarter3))]
    public class quarter3Drawer : VectorInspector
    {
        public override float Count => 3;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            int packed = packedProp.intValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);

            EditorGUI.BeginChangeCheck();

            quarter x0 = EditorGUIExtensions.DelayedField(r0, "x", math.asquarter((byte)(packed & 0xFFu)));
            quarter x1 = EditorGUIExtensions.DelayedField(r1, "y", math.asquarter((byte)((packed >> 8) & 0xFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit quarter3");

                packed =
                     (math.asbyte(x0) & 0xFF) |
                    ((math.asbyte(x1) & 0xFF) << 8);

                packedProp.intValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x2");

            packed = packedProp.intValue;

            EditorGUI.BeginChangeCheck();

            quarter x2  = EditorGUIExtensions.DelayedField(r2,   "z", math.asquarter((byte)(packed & 0xFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packedProp.intValue = math.asbyte(x2) & 0xFF;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(quarter4))]
    public class quarter4Drawer : VectorInspector
    {
        public override float Count => 4;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            int packed = packedProp.intValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            quarter x = EditorGUIExtensions.DelayedField(r0, "x", math.asquarter((byte)(packed & 0xFFu)));
            quarter y = EditorGUIExtensions.DelayedField(r1, "y", math.asquarter((byte)((packed >> 8) & 0xFFu)));
            quarter z = EditorGUIExtensions.DelayedField(r2, "z", math.asquarter((byte)((packed >> 16) & 0xFFu)));
            quarter w = EditorGUIExtensions.DelayedField(r3, "w", math.asquarter((byte)((packed >> 24) & 0xFFu)));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit quarter4");

                packed =
                     (math.asbyte(x) & 0xFF) |
                    ((math.asbyte(y) & 0xFF) << 8) |
                    ((math.asbyte(z) & 0xFF) << 16) |
                    ((math.asbyte(w) & 0xFF) << 24);
    
                packedProp.intValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(quarter8))]
    public class quarter8Drawer : VectorInspector
    {
        public override float Count => 8;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            long packed = packedProp.longValue;

            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
            Rect r4 = new Rect(position.x + Indent, position.y + Step * 5, position.width, Line);
            Rect r5 = new Rect(position.x + Indent, position.y + Step * 6, position.width, Line);
            Rect r6 = new Rect(position.x + Indent, position.y + Step * 7, position.width, Line);
            Rect r7 = new Rect(position.x + Indent, position.y + Step * 8, position.width, Line);

            EditorGUI.BeginChangeCheck();

            quarter x0 = EditorGUIExtensions.DelayedField(r0, "x0", math.asquarter((byte)(packed & 0xFFu)));
            quarter x1 = EditorGUIExtensions.DelayedField(r1, "x1", math.asquarter((byte)((packed >> 8) & 0xFFu)));
            quarter x2 = EditorGUIExtensions.DelayedField(r2, "x2", math.asquarter((byte)((packed >> 16) & 0xFFu)));
            quarter x3 = EditorGUIExtensions.DelayedField(r3, "x3", math.asquarter((byte)((packed >> 24) & 0xFFu)));
            quarter x4 = EditorGUIExtensions.DelayedField(r4, "x4", math.asquarter((byte)((packed >> 32) & 0xFFu)));
            quarter x5 = EditorGUIExtensions.DelayedField(r5, "x5", math.asquarter((byte)((packed >> 40) & 0xFFu)));
            quarter x6 = EditorGUIExtensions.DelayedField(r6, "x6", math.asquarter((byte)((packed >> 48) & 0xFFu)));
            quarter x7 = EditorGUIExtensions.DelayedField(r7, "x7", math.asquarter((byte)((packed >> 56) & 0xFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit quarter8");

                packed =
                     ((long)math.asbyte(x0) & 0xFF) |
                    (((long)math.asbyte(x1) & 0xFF) << 8) |
                    (((long)math.asbyte(x2) & 0xFF) << 16) |
                    (((long)math.asbyte(x3) & 0xFF) << 24) |
                    (((long)math.asbyte(x4) & 0xFF) << 32) |
                    (((long)math.asbyte(x5) & 0xFF) << 40) |
                    (((long)math.asbyte(x6) & 0xFF) << 48) |
                    (((long)math.asbyte(x7) & 0xFF) << 56);

                packedProp.longValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(quarter16))]
    public class quarter16Drawer : VectorInspector
    {
        public override float Count => 16;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            long packed = packedProp.longValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);
            Rect r8  = new Rect(position.x + Indent, position.y + Step * 9,  position.width, Line);
            Rect r9  = new Rect(position.x + Indent, position.y + Step * 10, position.width, Line);
            Rect r10 = new Rect(position.x + Indent, position.y + Step * 11, position.width, Line);
            Rect r11 = new Rect(position.x + Indent, position.y + Step * 12, position.width, Line);
            Rect r12 = new Rect(position.x + Indent, position.y + Step * 13, position.width, Line);
            Rect r13 = new Rect(position.x + Indent, position.y + Step * 14, position.width, Line);
            Rect r14 = new Rect(position.x + Indent, position.y + Step * 15, position.width, Line);
            Rect r15 = new Rect(position.x + Indent, position.y + Step * 16, position.width, Line);

            EditorGUI.BeginChangeCheck();

            quarter x0 = EditorGUIExtensions.DelayedField(r0, "x0", math.asquarter((byte)(packed & 0xFFu)));
            quarter x1 = EditorGUIExtensions.DelayedField(r1, "x1", math.asquarter((byte)((packed >> 8) & 0xFFu)));
            quarter x2 = EditorGUIExtensions.DelayedField(r2, "x2", math.asquarter((byte)((packed >> 16) & 0xFFu)));
            quarter x3 = EditorGUIExtensions.DelayedField(r3, "x3", math.asquarter((byte)((packed >> 24) & 0xFFu)));
            quarter x4 = EditorGUIExtensions.DelayedField(r4, "x4", math.asquarter((byte)((packed >> 32) & 0xFFu)));
            quarter x5 = EditorGUIExtensions.DelayedField(r5, "x5", math.asquarter((byte)((packed >> 40) & 0xFFu)));
            quarter x6 = EditorGUIExtensions.DelayedField(r6, "x6", math.asquarter((byte)((packed >> 48) & 0xFFu)));
            quarter x7 = EditorGUIExtensions.DelayedField(r7, "x7", math.asquarter((byte)((packed >> 56) & 0xFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit quarter16");

                packed =
                     ((long)math.asbyte(x0) & 0xFF) |
                    (((long)math.asbyte(x1) & 0xFF) << 8) |
                    (((long)math.asbyte(x2) & 0xFF) << 16) |
                    (((long)math.asbyte(x3) & 0xFF) << 24) |
                    (((long)math.asbyte(x4) & 0xFF) << 32) |
                    (((long)math.asbyte(x5) & 0xFF) << 40) |
                    (((long)math.asbyte(x6) & 0xFF) << 48) |
                    (((long)math.asbyte(x7) & 0xFF) << 56);

                packedProp.longValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x8");

            packed = packedProp.longValue;

            EditorGUI.BeginChangeCheck();

            quarter x8  = EditorGUIExtensions.DelayedField(r8,   "x8", math.asquarter((byte)(packed & 0xFFu)));
            quarter x9  = EditorGUIExtensions.DelayedField(r9,   "x9", math.asquarter((byte)((packed >> 8) & 0xFFu)));
            quarter x10 = EditorGUIExtensions.DelayedField(r10, "x10", math.asquarter((byte)((packed >> 16) & 0xFFu)));
            quarter x11 = EditorGUIExtensions.DelayedField(r11, "x11", math.asquarter((byte)((packed >> 24) & 0xFFu)));
            quarter x12 = EditorGUIExtensions.DelayedField(r12, "x12", math.asquarter((byte)((packed >> 32) & 0xFFu)));
            quarter x13 = EditorGUIExtensions.DelayedField(r13, "x13", math.asquarter((byte)((packed >> 40) & 0xFFu)));
            quarter x14 = EditorGUIExtensions.DelayedField(r14, "x14", math.asquarter((byte)((packed >> 48) & 0xFFu)));
            quarter x15 = EditorGUIExtensions.DelayedField(r15, "x15", math.asquarter((byte)((packed >> 56) & 0xFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packed =
                     ((long)math.asbyte(x8)  & 0xFF) |
                    (((long)math.asbyte(x9)  & 0xFF) << 8) |
                    (((long)math.asbyte(x10) & 0xFF) << 16) |
                    (((long)math.asbyte(x11) & 0xFF) << 24) |
                    (((long)math.asbyte(x12) & 0xFF) << 32) |
                    (((long)math.asbyte(x13) & 0xFF) << 40) |
                    (((long)math.asbyte(x14) & 0xFF) << 48) |
                    (((long)math.asbyte(x15) & 0xFF) << 56);

                packedProp.longValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(quarter32))]
    public class quarter32Drawer : VectorInspector
    {
        public override float Count => 32;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }
            SerializedProperty lo16 = property.FindPropertyRelative("__x0");
            SerializedProperty hi16 = property.FindPropertyRelative("__x16");
            SerializedProperty lo0 = lo16.FindPropertyRelative("__x0");
            SerializedProperty lo8 = lo16.FindPropertyRelative("__x8");
            SerializedProperty hi0 = hi16.FindPropertyRelative("__x0");
            SerializedProperty hi8 = hi16.FindPropertyRelative("__x8");

            EditorGUI.BeginProperty(position, label, property);

            long packed = lo0.longValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);
            Rect r8  = new Rect(position.x + Indent, position.y + Step * 9,  position.width, Line);
            Rect r9  = new Rect(position.x + Indent, position.y + Step * 10, position.width, Line);
            Rect r10 = new Rect(position.x + Indent, position.y + Step * 11, position.width, Line);
            Rect r11 = new Rect(position.x + Indent, position.y + Step * 12, position.width, Line);
            Rect r12 = new Rect(position.x + Indent, position.y + Step * 13, position.width, Line);
            Rect r13 = new Rect(position.x + Indent, position.y + Step * 14, position.width, Line);
            Rect r14 = new Rect(position.x + Indent, position.y + Step * 15, position.width, Line);
            Rect r15 = new Rect(position.x + Indent, position.y + Step * 16, position.width, Line);
            Rect r16 = new Rect(position.x + Indent, position.y + Step * 17, position.width, Line);
            Rect r17 = new Rect(position.x + Indent, position.y + Step * 18, position.width, Line);
            Rect r18 = new Rect(position.x + Indent, position.y + Step * 19, position.width, Line);
            Rect r19 = new Rect(position.x + Indent, position.y + Step * 20, position.width, Line);
            Rect r20 = new Rect(position.x + Indent, position.y + Step * 21, position.width, Line);
            Rect r21 = new Rect(position.x + Indent, position.y + Step * 22, position.width, Line);
            Rect r22 = new Rect(position.x + Indent, position.y + Step * 23, position.width, Line);
            Rect r23 = new Rect(position.x + Indent, position.y + Step * 24, position.width, Line);
            Rect r24 = new Rect(position.x + Indent, position.y + Step * 25, position.width, Line);
            Rect r25 = new Rect(position.x + Indent, position.y + Step * 26, position.width, Line);
            Rect r26 = new Rect(position.x + Indent, position.y + Step * 27, position.width, Line);
            Rect r27 = new Rect(position.x + Indent, position.y + Step * 28, position.width, Line);
            Rect r28 = new Rect(position.x + Indent, position.y + Step * 29, position.width, Line);
            Rect r29 = new Rect(position.x + Indent, position.y + Step * 30, position.width, Line);
            Rect r30 = new Rect(position.x + Indent, position.y + Step * 31, position.width, Line);
            Rect r31 = new Rect(position.x + Indent, position.y + Step * 32, position.width, Line);

            EditorGUI.BeginChangeCheck();

            quarter x0 = EditorGUIExtensions.DelayedField(r0, "x0", math.asquarter((byte)(packed & 0xFFu)));
            quarter x1 = EditorGUIExtensions.DelayedField(r1, "x1", math.asquarter((byte)((packed >> 8) & 0xFFu)));
            quarter x2 = EditorGUIExtensions.DelayedField(r2, "x2", math.asquarter((byte)((packed >> 16) & 0xFFu)));
            quarter x3 = EditorGUIExtensions.DelayedField(r3, "x3", math.asquarter((byte)((packed >> 24) & 0xFFu)));
            quarter x4 = EditorGUIExtensions.DelayedField(r4, "x4", math.asquarter((byte)((packed >> 32) & 0xFFu)));
            quarter x5 = EditorGUIExtensions.DelayedField(r5, "x5", math.asquarter((byte)((packed >> 40) & 0xFFu)));
            quarter x6 = EditorGUIExtensions.DelayedField(r6, "x6", math.asquarter((byte)((packed >> 48) & 0xFFu)));
            quarter x7 = EditorGUIExtensions.DelayedField(r7, "x7", math.asquarter((byte)((packed >> 56) & 0xFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit quarter32");

                packed =
                     ((long)math.asbyte(x0) & 0xFF) |
                    (((long)math.asbyte(x1) & 0xFF) << 8) |
                    (((long)math.asbyte(x2) & 0xFF) << 16) |
                    (((long)math.asbyte(x3) & 0xFF) << 24) |
                    (((long)math.asbyte(x4) & 0xFF) << 32) |
                    (((long)math.asbyte(x5) & 0xFF) << 40) |
                    (((long)math.asbyte(x6) & 0xFF) << 48) |
                    (((long)math.asbyte(x7) & 0xFF) << 56);

                lo0.longValue = packed;
            }
            
            packed = lo8.longValue;

            EditorGUI.BeginChangeCheck();

            quarter x8  = EditorGUIExtensions.DelayedField(r8,  "x8",  math.asquarter((byte)(packed & 0xFFu)));
            quarter x9  = EditorGUIExtensions.DelayedField(r9,  "x9",  math.asquarter((byte)((packed >> 8) & 0xFFu)));
            quarter x10 = EditorGUIExtensions.DelayedField(r10, "x10", math.asquarter((byte)((packed >> 16) & 0xFFu)));
            quarter x11 = EditorGUIExtensions.DelayedField(r11, "x11", math.asquarter((byte)((packed >> 24) & 0xFFu)));
            quarter x12 = EditorGUIExtensions.DelayedField(r12, "x12", math.asquarter((byte)((packed >> 32) & 0xFFu)));
            quarter x13 = EditorGUIExtensions.DelayedField(r13, "x13", math.asquarter((byte)((packed >> 40) & 0xFFu)));
            quarter x14 = EditorGUIExtensions.DelayedField(r14, "x14", math.asquarter((byte)((packed >> 48) & 0xFFu)));
            quarter x15 = EditorGUIExtensions.DelayedField(r15, "x15", math.asquarter((byte)((packed >> 56) & 0xFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packed =
                     ((long)math.asbyte(x8)  & 0xFF) |
                    (((long)math.asbyte(x9)  & 0xFF) << 8) |
                    (((long)math.asbyte(x10) & 0xFF) << 16) |
                    (((long)math.asbyte(x11) & 0xFF) << 24) |
                    (((long)math.asbyte(x12) & 0xFF) << 32) |
                    (((long)math.asbyte(x13) & 0xFF) << 40) |
                    (((long)math.asbyte(x14) & 0xFF) << 48) |
                    (((long)math.asbyte(x15) & 0xFF) << 56);

                lo8.longValue = packed;
            }

            EditorGUI.BeginChangeCheck();

            quarter x16 = EditorGUIExtensions.DelayedField(r16, "x16", math.asquarter((byte)(packed & 0xFFu)));
            quarter x17 = EditorGUIExtensions.DelayedField(r17, "x17", math.asquarter((byte)((packed >> 8) & 0xFFu)));
            quarter x18 = EditorGUIExtensions.DelayedField(r18, "x18", math.asquarter((byte)((packed >> 16) & 0xFFu)));
            quarter x19 = EditorGUIExtensions.DelayedField(r19, "x19", math.asquarter((byte)((packed >> 24) & 0xFFu)));
            quarter x20 = EditorGUIExtensions.DelayedField(r20, "x20", math.asquarter((byte)((packed >> 32) & 0xFFu)));
            quarter x21 = EditorGUIExtensions.DelayedField(r21, "x21", math.asquarter((byte)((packed >> 40) & 0xFFu)));
            quarter x22 = EditorGUIExtensions.DelayedField(r22, "x22", math.asquarter((byte)((packed >> 48) & 0xFFu)));
            quarter x23 = EditorGUIExtensions.DelayedField(r23, "x23", math.asquarter((byte)((packed >> 56) & 0xFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packed =
                     ((long)math.asbyte(x16) & 0xFF) |
                    (((long)math.asbyte(x17) & 0xFF) << 8) |
                    (((long)math.asbyte(x18) & 0xFF) << 16) |
                    (((long)math.asbyte(x19) & 0xFF) << 24) |
                    (((long)math.asbyte(x20) & 0xFF) << 32) |
                    (((long)math.asbyte(x21) & 0xFF) << 40) |
                    (((long)math.asbyte(x22) & 0xFF) << 48) |
                    (((long)math.asbyte(x23) & 0xFF) << 56);

                hi0.longValue = packed;
            }
            
            packed = hi8.longValue;

            EditorGUI.BeginChangeCheck();

            quarter x24 = EditorGUIExtensions.DelayedField(r24, "x24", math.asquarter((byte)(packed & 0xFFu)));
            quarter x25 = EditorGUIExtensions.DelayedField(r25, "x25", math.asquarter((byte)((packed >> 8) & 0xFFu)));
            quarter x26 = EditorGUIExtensions.DelayedField(r26, "x26", math.asquarter((byte)((packed >> 16) & 0xFFu)));
            quarter x27 = EditorGUIExtensions.DelayedField(r27, "x27", math.asquarter((byte)((packed >> 24) & 0xFFu)));
            quarter x28 = EditorGUIExtensions.DelayedField(r28, "x28", math.asquarter((byte)((packed >> 32) & 0xFFu)));
            quarter x29 = EditorGUIExtensions.DelayedField(r29, "x29", math.asquarter((byte)((packed >> 40) & 0xFFu)));
            quarter x30 = EditorGUIExtensions.DelayedField(r30, "x30", math.asquarter((byte)((packed >> 48) & 0xFFu)));
            quarter x31 = EditorGUIExtensions.DelayedField(r31, "x31", math.asquarter((byte)((packed >> 56) & 0xFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packed =
                     ((long)math.asbyte(x24) & 0xFF) |
                    (((long)math.asbyte(x25) & 0xFF) << 8) |
                    (((long)math.asbyte(x26) & 0xFF) << 16) |
                    (((long)math.asbyte(x27) & 0xFF) << 24) |
                    (((long)math.asbyte(x28) & 0xFF) << 32) |
                    (((long)math.asbyte(x29) & 0xFF) << 40) |
                    (((long)math.asbyte(x30) & 0xFF) << 48) |
                    (((long)math.asbyte(x31) & 0xFF) << 56);

                hi8.longValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }
    

    [CustomPropertyDrawer(typeof(half2))]
    public class half2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            uint packed = packedProp.uintValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            half x = EditorGUIExtensions.DelayedField(r0, "x", math.ashalf((ushort)(packed & 0xFFFFu)));
            half y = EditorGUIExtensions.DelayedField(r1, "y", math.ashalf((ushort)((packed >> 16) & 0xFFFFu)));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit half2");

                packed = (uint)(
                     (math.asushort(x) & 0xFFFF) |
                    ((math.asushort(y) & 0xFFFF) << 16));
    
                packedProp.uintValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(half3))]
    public class half3Drawer : VectorInspector
    {
        public override float Count => 3;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            uint packed = packedProp.uintValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);

            EditorGUI.BeginChangeCheck();

            half x0 = EditorGUIExtensions.DelayedField(r0, "x", math.ashalf((ushort)(packed & 0xFFFFu)));
            half x1 = EditorGUIExtensions.DelayedField(r1, "y", math.ashalf((ushort)((packed >> 16) & 0xFFFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit half3");

                packed = (uint)(
                     (math.asushort(x0) & 0xFFFF) |
                    ((math.asushort(x1) & 0xFFFF) << 16));

                packedProp.uintValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x2");

            packed = packedProp.uintValue;

            EditorGUI.BeginChangeCheck();

            half x2  = EditorGUIExtensions.DelayedField(r2,   "z", math.ashalf((ushort)(packed & 0xFFFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packedProp.uintValue = (uint)math.asushort(x2) & 0xFFFF;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(half4))]
    public class half4Drawer : VectorInspector
    {
        public override float Count => 4;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
    
            EditorGUI.BeginProperty(position, label, property);
    
            ulong packed = packedProp.ulongValue;
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            half x = EditorGUIExtensions.DelayedField(r0, "x", math.ashalf((ushort)(packed & 0xFFFFu)));
            half y = EditorGUIExtensions.DelayedField(r1, "y", math.ashalf((ushort)((packed >> 16) & 0xFFFFu)));
            half z = EditorGUIExtensions.DelayedField(r2, "z", math.ashalf((ushort)((packed >> 32) & 0xFFFFu)));
            half w = EditorGUIExtensions.DelayedField(r3, "w", math.ashalf((ushort)((packed >> 48) & 0xFFFFu)));
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit half4");

                packed =
                     ((ulong)math.asushort(x) & 0xFFFF) |
                    (((ulong)math.asushort(y) & 0xFFFF) << 16) |
                    (((ulong)math.asushort(z) & 0xFFFF) << 32) |
                    (((ulong)math.asushort(w) & 0xFFFF) << 48);
    
                packedProp.ulongValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(half8))]
    public class half8Drawer : VectorInspector
    {
        public override float Count => 8;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");

            EditorGUI.BeginProperty(position, label, property);

            ulong packed = packedProp.ulongValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);

            EditorGUI.BeginChangeCheck();

            half x0 = EditorGUIExtensions.DelayedField(r0, "x0", math.ashalf((ushort)(packed & 0xFFFFu)));
            half x1 = EditorGUIExtensions.DelayedField(r1, "x1", math.ashalf((ushort)((packed >> 16) & 0xFFFFu)));
            half x2 = EditorGUIExtensions.DelayedField(r2, "x2", math.ashalf((ushort)((packed >> 32) & 0xFFFFu)));
            half x3 = EditorGUIExtensions.DelayedField(r3, "x3", math.ashalf((ushort)((packed >> 48) & 0xFFFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit half16");

                packed =
                     ((ulong)math.asushort(x0) & 0xFFFF) |
                    (((ulong)math.asushort(x1) & 0xFFFF) << 16) |
                    (((ulong)math.asushort(x2) & 0xFFFF) << 32) |
                    (((ulong)math.asushort(x3) & 0xFFFF) << 48);

                packedProp.ulongValue = packed;
            }

            packedProp = property.FindPropertyRelative("__x4");

            packed = packedProp.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            half x4 = EditorGUIExtensions.DelayedField(r4, "x4", math.ashalf((ushort)(packed & 0xFFFFu)));
            half x5 = EditorGUIExtensions.DelayedField(r5, "x5", math.ashalf((ushort)((packed >> 16) & 0xFFFFu)));
            half x6 = EditorGUIExtensions.DelayedField(r6, "x6", math.ashalf((ushort)((packed >> 32) & 0xFFFFu)));
            half x7 = EditorGUIExtensions.DelayedField(r7, "x7", math.ashalf((ushort)((packed >> 48) & 0xFFFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packed =
                     ((ulong)math.asushort(x4) & 0xFFFF) |
                    (((ulong)math.asushort(x5) & 0xFFFF) << 16) |
                    (((ulong)math.asushort(x6) & 0xFFFF) << 32) |
                    (((ulong)math.asushort(x7) & 0xFFFF) << 48);

                packedProp.ulongValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(half16))]
    public class half16Drawer : VectorInspector
    {
        public override float Count => 16;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            
            if (!property.isExpanded)
            {
                return;
            }
            SerializedProperty lo16 = property.FindPropertyRelative("__x0");
            SerializedProperty hi16 = property.FindPropertyRelative("__x8");
            SerializedProperty lo0 = lo16.FindPropertyRelative("__x0");
            SerializedProperty lo8 = lo16.FindPropertyRelative("__x4");
            SerializedProperty hi0 = hi16.FindPropertyRelative("__x0");
            SerializedProperty hi8 = hi16.FindPropertyRelative("__x4");

            EditorGUI.BeginProperty(position, label, property);

            ulong packed = lo0.ulongValue;

            Rect r0  = new Rect(position.x + Indent, position.y + Step * 1,  position.width, Line);
            Rect r1  = new Rect(position.x + Indent, position.y + Step * 2,  position.width, Line);
            Rect r2  = new Rect(position.x + Indent, position.y + Step * 3,  position.width, Line);
            Rect r3  = new Rect(position.x + Indent, position.y + Step * 4,  position.width, Line);
            Rect r4  = new Rect(position.x + Indent, position.y + Step * 5,  position.width, Line);
            Rect r5  = new Rect(position.x + Indent, position.y + Step * 6,  position.width, Line);
            Rect r6  = new Rect(position.x + Indent, position.y + Step * 7,  position.width, Line);
            Rect r7  = new Rect(position.x + Indent, position.y + Step * 8,  position.width, Line);
            Rect r8  = new Rect(position.x + Indent, position.y + Step * 9,  position.width, Line);
            Rect r9  = new Rect(position.x + Indent, position.y + Step * 10, position.width, Line);
            Rect r10 = new Rect(position.x + Indent, position.y + Step * 11, position.width, Line);
            Rect r11 = new Rect(position.x + Indent, position.y + Step * 12, position.width, Line);
            Rect r12 = new Rect(position.x + Indent, position.y + Step * 13, position.width, Line);
            Rect r13 = new Rect(position.x + Indent, position.y + Step * 14, position.width, Line);
            Rect r14 = new Rect(position.x + Indent, position.y + Step * 15, position.width, Line);
            Rect r15 = new Rect(position.x + Indent, position.y + Step * 16, position.width, Line);

            EditorGUI.BeginChangeCheck();

            half x0 = EditorGUIExtensions.DelayedField(r0, "x0", math.ashalf((ushort)(packed & 0xFFFFu)));
            half x1 = EditorGUIExtensions.DelayedField(r1, "x1", math.ashalf((ushort)((packed >> 16) & 0xFFFFu)));
            half x2 = EditorGUIExtensions.DelayedField(r2, "x2", math.ashalf((ushort)((packed >> 32) & 0xFFFFu)));
            half x3 = EditorGUIExtensions.DelayedField(r3, "x3", math.ashalf((ushort)((packed >> 48) & 0xFFFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit half32");

                packed =
                     ((ulong)math.asushort(x0) & 0xFFFF) |
                    (((ulong)math.asushort(x1) & 0xFFFF) << 16) |
                    (((ulong)math.asushort(x2) & 0xFFFF) << 32) |
                    (((ulong)math.asushort(x3) & 0xFFFF) << 48);

                lo0.ulongValue = packed;
            }
            
            packed = lo8.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            half x4 = EditorGUIExtensions.DelayedField(r4, "x4", math.ashalf((ushort)(packed & 0xFFFFu)));
            half x5 = EditorGUIExtensions.DelayedField(r5, "x5", math.ashalf((ushort)((packed >> 16) & 0xFFFFu)));
            half x6 = EditorGUIExtensions.DelayedField(r6, "x6", math.ashalf((ushort)((packed >> 32) & 0xFFFFu)));
            half x7 = EditorGUIExtensions.DelayedField(r7, "x7", math.ashalf((ushort)((packed >> 48) & 0xFFFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packed =
                     ((ulong)math.asushort(x4) & 0xFFFF) |
                    (((ulong)math.asushort(x5) & 0xFFFF) << 16) |
                    (((ulong)math.asushort(x6) & 0xFFFF) << 32) |
                    (((ulong)math.asushort(x7) & 0xFFFF) << 48);

                lo8.ulongValue = packed;
            }
            
            packed = hi0.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            half x8  = EditorGUIExtensions.DelayedField(r8,  "x8",  math.ashalf((ushort)(packed & 0xFFFFu)));
            half x9  = EditorGUIExtensions.DelayedField(r9,  "x9",  math.ashalf((ushort)((packed >> 16) & 0xFFFFu)));
            half x10 = EditorGUIExtensions.DelayedField(r10, "x10", math.ashalf((ushort)((packed >> 32) & 0xFFFFu)));
            half x11 = EditorGUIExtensions.DelayedField(r11, "x11", math.ashalf((ushort)((packed >> 48) & 0xFFFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packed =
                     ((ulong)math.asushort(x8)  & 0xFFFF) |
                    (((ulong)math.asushort(x9)  & 0xFFFF) << 16) |
                    (((ulong)math.asushort(x10) & 0xFFFF) << 32) |
                    (((ulong)math.asushort(x11) & 0xFFFF) << 48);

                hi0.ulongValue = packed;
            }
            
            packed = hi8.ulongValue;

            EditorGUI.BeginChangeCheck();
            
            half x12 = EditorGUIExtensions.DelayedField(r12, "x12", math.ashalf((ushort)(packed & 0xFFFFu)));
            half x13 = EditorGUIExtensions.DelayedField(r13, "x13", math.ashalf((ushort)((packed >> 16) & 0xFFFFu)));
            half x14 = EditorGUIExtensions.DelayedField(r14, "x14", math.ashalf((ushort)((packed >> 32) & 0xFFFFu)));
            half x15 = EditorGUIExtensions.DelayedField(r15, "x15", math.ashalf((ushort)((packed >> 48) & 0xFFFFu)));

            if (EditorGUI.EndChangeCheck())
            {
                packed =
                     ((ulong)math.asushort(x12) & 0xFFFF) |
                    (((ulong)math.asushort(x13) & 0xFFFF) << 16) |
                    (((ulong)math.asushort(x14) & 0xFFFF) << 32) |
                    (((ulong)math.asushort(x15) & 0xFFFF) << 48);

                hi8.ulongValue = packed;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }

            EditorGUI.EndProperty();
        }
    }

    [CustomPropertyDrawer(typeof(float2))]
    public class float2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("x");
            SerializedProperty yProp = packedProp.FindPropertyRelative("y");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            float x = EditorGUI.DelayedFloatField(r0, "x", xProp.floatValue);
            float y = EditorGUI.DelayedFloatField(r1, "y", yProp.floatValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit float2");

                xProp.floatValue = x;
                yProp.floatValue = y;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(float3))]
    public class float3Drawer : VectorInspector
    {
        public override float Count => 3;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("x");
            SerializedProperty yProp = packedProp.FindPropertyRelative("y");
            SerializedProperty zProp = packedProp.FindPropertyRelative("z");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            float x = EditorGUI.DelayedFloatField(r0, "x", xProp.floatValue);
            float y = EditorGUI.DelayedFloatField(r1, "y", yProp.floatValue);
            float z = EditorGUI.DelayedFloatField(r2, "z", zProp.floatValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit float3");

                xProp.floatValue = x;
                yProp.floatValue = y;
                zProp.floatValue = z;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(float4))]
    public class float4Drawer : VectorInspector
    {
        public override float Count => 4;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("x");
            SerializedProperty yProp = packedProp.FindPropertyRelative("y");
            SerializedProperty zProp = packedProp.FindPropertyRelative("z");
            SerializedProperty wProp = packedProp.FindPropertyRelative("w");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            float x = EditorGUI.DelayedFloatField(r0, "x", xProp.floatValue);
            float y = EditorGUI.DelayedFloatField(r1, "y", yProp.floatValue);
            float z = EditorGUI.DelayedFloatField(r2, "z", zProp.floatValue);
            float w = EditorGUI.DelayedFloatField(r3, "w", wProp.floatValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit float4");

                xProp.floatValue = x;
                yProp.floatValue = y;
                zProp.floatValue = z;
                wProp.floatValue = w;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(float8))]
    public class float8Drawer : VectorInspector
    {
        public override float Count => 8;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty lo = property.FindPropertyRelative("__x0").FindPropertyRelative("__x0");
            SerializedProperty hi = property.FindPropertyRelative("__x4").FindPropertyRelative("__x0");
            SerializedProperty x0Prop = lo.FindPropertyRelative("x");
            SerializedProperty x1Prop = lo.FindPropertyRelative("y");
            SerializedProperty x2Prop = lo.FindPropertyRelative("z");
            SerializedProperty x3Prop = lo.FindPropertyRelative("w");
            SerializedProperty x4Prop = hi.FindPropertyRelative("x");
            SerializedProperty x5Prop = hi.FindPropertyRelative("y");
            SerializedProperty x6Prop = hi.FindPropertyRelative("z");
            SerializedProperty x7Prop = hi.FindPropertyRelative("w");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
            Rect r4 = new Rect(position.x + Indent, position.y + Step * 5, position.width, Line);
            Rect r5 = new Rect(position.x + Indent, position.y + Step * 6, position.width, Line);
            Rect r6 = new Rect(position.x + Indent, position.y + Step * 7, position.width, Line);
            Rect r7 = new Rect(position.x + Indent, position.y + Step * 8, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            float x0 = EditorGUI.DelayedFloatField(r0, "x0", x0Prop.floatValue);
            float x1 = EditorGUI.DelayedFloatField(r1, "x1", x1Prop.floatValue);
            float x2 = EditorGUI.DelayedFloatField(r2, "x2", x2Prop.floatValue);
            float x3 = EditorGUI.DelayedFloatField(r3, "x3", x3Prop.floatValue);
            float x4 = EditorGUI.DelayedFloatField(r4, "x4", x4Prop.floatValue);
            float x5 = EditorGUI.DelayedFloatField(r5, "x5", x5Prop.floatValue);
            float x6 = EditorGUI.DelayedFloatField(r6, "x6", x6Prop.floatValue);
            float x7 = EditorGUI.DelayedFloatField(r7, "x7", x7Prop.floatValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit float8");

                x0Prop.floatValue = x0;
                x1Prop.floatValue = x1;
                x2Prop.floatValue = x2;
                x3Prop.floatValue = x3;
                x4Prop.floatValue = x4;
                x5Prop.floatValue = x5;
                x6Prop.floatValue = x6;
                x7Prop.floatValue = x7;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    

    [CustomPropertyDrawer(typeof(double2))]
    public class double2Drawer : VectorInspector
    {
        public override float Count => 2;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty xProp = property.FindPropertyRelative("__x0");
            SerializedProperty yProp = property.FindPropertyRelative("__x1");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            double x = EditorGUI.DelayedDoubleField(r0, "x", xProp.doubleValue);
            double y = EditorGUI.DelayedDoubleField(r1, "y", yProp.doubleValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit double2");

                xProp.doubleValue = x;
                yProp.doubleValue = y;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(double3))]
    public class double3Drawer : VectorInspector
    {
        public override float Count => 3;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }

            SerializedProperty packedProp = property.FindPropertyRelative("__x0");
            SerializedProperty xProp = packedProp.FindPropertyRelative("__x0");
            SerializedProperty yProp = packedProp.FindPropertyRelative("__x1");
            SerializedProperty zProp = property.FindPropertyRelative("__x2");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            double x = EditorGUI.DelayedDoubleField(r0, "x", xProp.doubleValue);
            double y = EditorGUI.DelayedDoubleField(r1, "y", yProp.doubleValue);
            double z = EditorGUI.DelayedDoubleField(r2, "z", zProp.doubleValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit double3");

                xProp.doubleValue = x;
                yProp.doubleValue = y;
                zProp.doubleValue = z;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
    
    [CustomPropertyDrawer(typeof(double4))]
    public class double4Drawer : VectorInspector
    {
        public override float Count => 4;
    
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label); 
            
            if (!property.isExpanded)
            {
                return;
            }
            
            SerializedProperty lo = property.FindPropertyRelative("__x0");
            SerializedProperty hi = property.FindPropertyRelative("__x2");
            SerializedProperty xProp = lo.FindPropertyRelative("__x0");
            SerializedProperty yProp = lo.FindPropertyRelative("__x1");
            SerializedProperty zProp = hi.FindPropertyRelative("__x0");
            SerializedProperty wProp = hi.FindPropertyRelative("__x1");
    
            EditorGUI.BeginProperty(position, label, property);
    
            Rect r0 = new Rect(position.x + Indent, position.y + Step * 1, position.width, Line);
            Rect r1 = new Rect(position.x + Indent, position.y + Step * 2, position.width, Line);
            Rect r2 = new Rect(position.x + Indent, position.y + Step * 3, position.width, Line);
            Rect r3 = new Rect(position.x + Indent, position.y + Step * 4, position.width, Line);
    
            EditorGUI.BeginChangeCheck();
    
            double x = EditorGUI.DelayedDoubleField(r0, "x", xProp.doubleValue);
            double y = EditorGUI.DelayedDoubleField(r1, "y", yProp.doubleValue);
            double z = EditorGUI.DelayedDoubleField(r2, "z", zProp.doubleValue);
            double w = EditorGUI.DelayedDoubleField(r3, "w", wProp.doubleValue);
    
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(property.serializedObject.targetObject, "Edit double4");

                xProp.doubleValue = x;
                yProp.doubleValue = y;
                zProp.doubleValue = z;
                wProp.doubleValue = w;
                
                EditorUtility.SetDirty(property.serializedObject.targetObject);
            }
    
            EditorGUI.EndProperty();
        }
    }
}
