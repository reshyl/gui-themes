using UnityEditor;
using UnityEngine;

namespace ReshylEditor.GUI
{
    public abstract class ElementInfoDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var keyProp = property.FindPropertyRelative("key");
            var valueProp = GetValueProp(property);

            Rect keyRect = new Rect(position.x, position.y, position.width * 0.4f, position.height);
            Rect valueRect = new Rect(position.x + position.width * 0.42f, position.y, position.width * 0.58f, position.height);

            UnityEngine.GUI.enabled = false;
            EditorGUI.PropertyField(keyRect, keyProp, GUIContent.none);
            UnityEngine.GUI.enabled = true;

            EditorGUI.PropertyField(valueRect, valueProp, GUIContent.none);

            EditorGUI.EndProperty();
        }

        protected abstract SerializedProperty GetValueProp(SerializedProperty parentProp);
    }
}
