using Reshyl.GUI;
using UnityEditor;
using UnityEngine;

namespace ReshylEditor.GUI
{
    [CustomPropertyDrawer(typeof(SpriteInfo))]
    public class SpriteInfoDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            var keyProp = property.FindPropertyRelative("key");
            var spriteProp = property.FindPropertyRelative("sprite");

            Rect keyRect = new Rect(position.x, position.y, position.width * 0.4f, position.height);
            Rect spriteRect = new Rect(position.x + position.width * 0.42f, position.y, position.width * 0.58f, position.height);

            UnityEngine.GUI.enabled = false;
            EditorGUI.PropertyField(keyRect, keyProp, GUIContent.none);
            UnityEngine.GUI.enabled = true;

            EditorGUI.PropertyField(spriteRect, spriteProp, GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}
