using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedGraphic))]
    public class ThemedGraphicEditor : ThemedComponentEditorBase<ColorPalette>
    {
        private SerializedProperty overrideAlphaProp;
        private SerializedProperty alphaProp;

        protected override string KeyLabel => "Color";

        protected override void OnEnable()
        {
            base.OnEnable();

            overrideAlphaProp = serializedObject.FindProperty("overrideAlpha");
            alphaProp = serializedObject.FindProperty("alpha");
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

            EditorGUILayout.PropertyField(overrideAlphaProp);

            if (overrideAlphaProp.boolValue)
                EditorGUILayout.PropertyField(alphaProp);

            serializedObject.ApplyModifiedProperties();

            if (EditorGUI.EndChangeCheck())
                themedComponent.UpdateElement(palette);
        }
    }
}
