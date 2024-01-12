using Reshyl.GUI;
using UnityEditor;
using UnityEngine;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedImage))]
    public class ThemedImageEditor : ThemedComponentEditorBase<SpritePalette>
    {
        protected override string KeyLabel => "Sprite";

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
