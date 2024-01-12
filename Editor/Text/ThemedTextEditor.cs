using Reshyl.GUI.Themes;
using UnityEditor;

namespace ReshylEditor.GUI.Themes
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

            EditorGUI.BeginChangeCheck();

            DrawKeyPopup(out var palette);

            if (palette == null)
            {
                if (EditorGUI.EndChangeCheck())
                    serializedObject.ApplyModifiedProperties();

                return;
            }

            EditorGUILayout.PropertyField(ignoreColorProp);

            serializedObject.ApplyModifiedProperties();

            if (EditorGUI.EndChangeCheck())
                themedComponent.UpdateElement(palette);
        }
    }
}
