using Reshyl.GUI;
using UnityEditor;
using UnityEngine;

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

            var palette = GetPalette();

            if (palette == null)
            {
                UnityEngine.GUI.enabled = false;
                EditorGUILayout.PropertyField(keyProp, new GUIContent(KeyLabel));
                UnityEngine.GUI.enabled = true;

                return;
            }
            
            DrawKeyPopup(palette);
            EditorGUILayout.PropertyField(overrideAlphaProp);

            if (overrideAlphaProp.boolValue)
                EditorGUILayout.PropertyField(alphaProp);

            serializedObject.ApplyModifiedProperties();

            themedComponent.UpdateElement(palette);
        }
    }
}
