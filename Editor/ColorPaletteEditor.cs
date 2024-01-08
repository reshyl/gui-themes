using Reshyl.GUI;
using System.Collections.Generic;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ColorPalette))]
    public class ColorPaletteEditor : Editor
    {
        private SerializedProperty definitionProp;
        private SerializedProperty colorsProp;

        private void OnEnable()
        {
            definitionProp = serializedObject.FindProperty("definition");
            colorsProp = serializedObject.FindProperty("colors");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(definitionProp);

            if (definitionProp.objectReferenceValue != null)
            {
                var paletteDefinition = (PaletteDefinition)definitionProp.objectReferenceValue;
                SynchronizeLists(paletteDefinition);

                EditorGUILayout.PropertyField(colorsProp, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Must create and assign a Palette Definition first!", MessageType.Info);
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void SynchronizeLists(PaletteDefinition paletteDefinition)
        {
            if (paletteDefinition.keys == null)
            {
                paletteDefinition.keys = new List<string>();
            }

            // Ensure the keys list and colors list have the same length
            while (colorsProp.arraySize < paletteDefinition.keys.Count)
            {
                colorsProp.InsertArrayElementAtIndex(colorsProp.arraySize);
            }
            while (colorsProp.arraySize > paletteDefinition.keys.Count)
            {
                colorsProp.DeleteArrayElementAtIndex(colorsProp.arraySize - 1);
            }

            // Set the key of each ColorInfo to the corresponding key from the keys list
            for (int i = 0; i < colorsProp.arraySize; i++)
            {
                SerializedProperty colorElement = colorsProp.GetArrayElementAtIndex(i);
                SerializedProperty keyProp = colorElement.FindPropertyRelative("key");

                if (i < paletteDefinition.keys.Count)
                {
                    keyProp.stringValue = paletteDefinition.keys[i];
                }
                else
                {
                    keyProp.stringValue = "";
                }
            }
        }
    }
}
