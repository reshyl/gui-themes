using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedImage))]
    public class ThemedImageEditor : Editor
    {
        private ThemedImage themedImage;

        private SerializedProperty spritePaletteProp;
        private SerializedProperty spriteKeyProp;

        private void OnEnable()
        {
            themedImage = (ThemedImage)target;

            spritePaletteProp = serializedObject.FindProperty("spritePalette");
            spriteKeyProp = serializedObject.FindProperty("spriteKey");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(spritePaletteProp);

            if (spritePaletteProp.objectReferenceValue == null)
            {
                serializedObject.ApplyModifiedProperties();
                return;
            }

            var palette = (SpritePalette)spritePaletteProp.objectReferenceValue;
            var options = palette.Definition.Keys;

            if (spriteKeyProp.stringValue == string.Empty)
                spriteKeyProp.stringValue = options[0];
            else if (!options.Contains(spriteKeyProp.stringValue))
                spriteKeyProp.stringValue = options[0];

            var selectedIndex = options.IndexOf(spriteKeyProp.stringValue);

            selectedIndex = EditorGUILayout.Popup("Sprite", selectedIndex, options.ToArray());
            spriteKeyProp.stringValue = options[selectedIndex];

            serializedObject.ApplyModifiedProperties();

            themedImage.UpdateElement();
        }
    }
}
