using Reshyl.GUI;
using UnityEditor;
using UnityEngine;

namespace ReshylEditor.GUI
{
    [CustomPropertyDrawer(typeof(ColorInfo))]
    public class ColorInfoDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            //if (label.text.Contains("Element "))
            //    label.text = label.text.Replace("Element ", "Color ");

            //position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), GUIContent.none);

            var keyProp = property.FindPropertyRelative("key");
            var colorProp = property.FindPropertyRelative("color");

            
            Rect keyRect = new Rect(position.x, position.y, position.width * 0.4f, position.height);
            Rect colorRect = new Rect(position.x + position.width * 0.42f, position.y, position.width * 0.58f, position.height);

            UnityEngine.GUI.enabled = false;
            EditorGUI.PropertyField(keyRect, keyProp, GUIContent.none);
            UnityEngine.GUI.enabled = true;

            EditorGUI.PropertyField(colorRect, colorProp, GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}
