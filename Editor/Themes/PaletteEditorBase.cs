using Reshyl.GUI;
using UnityEditor;
using UnityEngine;

namespace ReshylEditor.GUI
{
    public class PaletteEditorBase : Editor
    {
        protected SerializedProperty idProp;
        protected SerializedProperty definitionProp;
        protected SerializedProperty elementsProp;

        protected virtual string ElementsHeader => "Elements";

        protected virtual void OnEnable()
        {
            idProp = serializedObject.FindProperty("id");
            definitionProp = serializedObject.FindProperty("definition");
            elementsProp = serializedObject.FindProperty("elements");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(idProp);
            EditorGUILayout.PropertyField(definitionProp);

            var definition = (PaletteDefinition)definitionProp.objectReferenceValue;

            if (definition != null && definition.Keys != null)
            {
                // Ensure the keys list and colors list have the same length
                while (elementsProp.arraySize < definition.Keys.Count)
                    elementsProp.InsertArrayElementAtIndex(elementsProp.arraySize);
                while (elementsProp.arraySize > definition.Keys.Count)
                    elementsProp.DeleteArrayElementAtIndex(elementsProp.arraySize - 1);

                GUILayout.Space(5f);

                DrawElementsCollection(definition);
            }
            else
            {
                EditorGUILayout.HelpBox("Must create and assign a Palette Definition first!", MessageType.Info);
            }

            serializedObject.ApplyModifiedProperties();
        }

        protected virtual void DrawElementsCollection(PaletteDefinition definition)
        {
            var headerStyle = new GUIStyle(EditorStyles.boldLabel);
            headerStyle.fontSize = 14;

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField(ElementsHeader, headerStyle);
            EditorGUI.indentLevel++;

            for (int i = 0; i < elementsProp.arraySize; i++)
            {
                var label = new GUIContent(definition.Keys[i]);
                EditorGUILayout.PropertyField(elementsProp.GetArrayElementAtIndex(i), label);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }
    }
}
