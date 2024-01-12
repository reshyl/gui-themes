using Reshyl.GUI;
using UnityEditor;
using UnityEngine;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedText))]
    public class ThemedTextEditor : ThemedComponentEditorBase<TextPalette>
    {
        private SerializedProperty ignoreColorProp;

        protected override string KeyLabel => "Text";

        protected override void OnEnable()
        {
            base.OnEnable();

            ignoreColorProp = serializedObject.FindProperty("ignoreColor");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var palette = GetPalette();

            if (palette == null)
            {
                UnityEngine.GUI.enabled = false;
                EditorGUILayout.PropertyField(keyProp, new GUIContent(KeyLabel));
                UnityEngine.GUI.enabled = true;

                return;
            }

            DrawKeyPopup(palette);
            EditorGUILayout.PropertyField(ignoreColorProp);

            serializedObject.ApplyModifiedProperties();

            themedComponent.UpdateElement(palette);
        }
    }
}
