using Reshyl.GUI;
using System.Collections.Generic;
using UnityEditor;

namespace ReshylEditor.GUI
{
    public abstract class PaletteEditor : Editor
    {
        protected SerializedProperty definitionProp;
        protected SerializedProperty listProp;

        /// <summary>
        /// Override to provide implemention of finding properties.
        /// </summary>
        protected abstract void OnEnable();

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(definitionProp);

            if (definitionProp.objectReferenceValue != null)
            {
                var paletteDefinition = (PaletteDefinition)definitionProp.objectReferenceValue;
                SynchronizeLists(paletteDefinition);

                EditorGUILayout.PropertyField(listProp, true);
            }
            else
            {
                EditorGUILayout.HelpBox("Must create and assign a Palette Definition first!", MessageType.Info);
            }

            serializedObject.ApplyModifiedProperties();
        }

        protected virtual void SynchronizeLists(PaletteDefinition definition)
        {
            if (definition.keys == null)
                definition.keys = new List<string>();

            // Ensure the keys list and colors list have the same length
            while (listProp.arraySize < definition.keys.Count)
                listProp.InsertArrayElementAtIndex(listProp.arraySize);
            while (listProp.arraySize > definition.keys.Count)
                listProp.DeleteArrayElementAtIndex(listProp.arraySize - 1);

            // Set the key of each ColorInfo to the corresponding key from the keys list
            for (int i = 0; i < listProp.arraySize; i++)
            {
                var listElement = listProp.GetArrayElementAtIndex(i);
                var keyProp = listElement.FindPropertyRelative("key");

                if (i < definition.keys.Count)
                    keyProp.stringValue = definition.keys[i];
                else
                    keyProp.stringValue = "";
            }
        }
    }
}
