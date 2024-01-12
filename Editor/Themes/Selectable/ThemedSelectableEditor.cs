using Reshyl.GUI;
using UnityEditor;
using UnityEngine;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedSelectable))]
    public class ThemedSelectableEditor : ThemedComponentEditorBase<SelectablePalette>
    {
        protected override string KeyLabel => "Selectable";

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

            serializedObject.ApplyModifiedProperties();

            themedComponent.UpdateElement(palette);
        }
    }
}
