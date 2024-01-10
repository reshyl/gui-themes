using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedText))]
    public class ThemedTextEditor : Editor
    {
        private ThemedText themedText;

        private SerializedProperty paletteProp;
        private SerializedProperty keyProp;
        private SerializedProperty ignoreColorProp;

        private void OnEnable()
        {
            themedText = (ThemedText)target;

            paletteProp = serializedObject.FindProperty("palette");
            keyProp = serializedObject.FindProperty("textKey");
            ignoreColorProp = serializedObject.FindProperty("ignoreColor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(paletteProp);

            if (paletteProp.objectReferenceValue == null)
            {
                serializedObject.ApplyModifiedProperties();
                return;
            }

            var palette = (TextPalette)paletteProp.objectReferenceValue;
            var options = palette.definition.keys;

            if (keyProp.stringValue == string.Empty)
                keyProp.stringValue = options[0];
            else if (!options.Contains(keyProp.stringValue))
                keyProp.stringValue = options[0];

            var selectedIndex = options.IndexOf(keyProp.stringValue);

            selectedIndex = EditorGUILayout.Popup("Text", selectedIndex, options.ToArray());
            keyProp.stringValue = options[selectedIndex];

            EditorGUILayout.PropertyField(ignoreColorProp);

            serializedObject.ApplyModifiedProperties();

            themedText.UpdateElement();
        }
    }
}
