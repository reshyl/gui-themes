using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedGraphic))]
    public class ThemedGraphicEditor : Editor
    {
        private ThemedGraphic themedGraphic;

        private SerializedProperty colorPaletteProp;
        private SerializedProperty colorKeyProp;
        private SerializedProperty overrideAlphaProp;
        private SerializedProperty alphaProp;

        private void OnEnable()
        {
            themedGraphic = (ThemedGraphic)target;

            colorPaletteProp = serializedObject.FindProperty("colorPalette");
            colorKeyProp = serializedObject.FindProperty("colorKey");
            overrideAlphaProp = serializedObject.FindProperty("overrideAlpha");
            alphaProp = serializedObject.FindProperty("alpha");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(colorPaletteProp);

            if (colorPaletteProp.objectReferenceValue == null)
            {
                serializedObject.ApplyModifiedProperties();
                return;
            }

            var palette = (ColorPalette)colorPaletteProp.objectReferenceValue;
            var options = palette.definition.keys;

            if (colorKeyProp.stringValue == string.Empty)
                colorKeyProp.stringValue = options[0];
            else if (!options.Contains(colorKeyProp.stringValue))
                colorKeyProp.stringValue = options[0];

            var selectedIndex = options.IndexOf(colorKeyProp.stringValue);

            selectedIndex = EditorGUILayout.Popup("Color", selectedIndex, options.ToArray());
            colorKeyProp.stringValue = options[selectedIndex];

            EditorGUILayout.PropertyField(overrideAlphaProp);

            if (overrideAlphaProp.boolValue)
                EditorGUILayout.PropertyField(alphaProp);

            serializedObject.ApplyModifiedProperties();
            themedGraphic.UpdateElement();
        }
    }
}
