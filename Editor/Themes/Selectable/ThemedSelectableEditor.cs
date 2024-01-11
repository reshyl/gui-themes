using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedSelectable))]
    public class ThemedSelectableEditor : Editor
    {
        private ThemedSelectable themedSelectable;

        private SerializedProperty paletteProp;
        private SerializedProperty keyProp;

        private void OnEnable()
        {
            themedSelectable = (ThemedSelectable)target;

            paletteProp = serializedObject.FindProperty("palette");
            keyProp = serializedObject.FindProperty("selectableKey");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(paletteProp);

            if (paletteProp.objectReferenceValue == null)
            {
                serializedObject.ApplyModifiedProperties();
                return;
            }

            var palette = (SelectablePalette)paletteProp.objectReferenceValue;
            var options = palette.Definition.Keys;

            if (keyProp.stringValue == string.Empty)
                keyProp.stringValue = options[0];
            else if (!options.Contains(keyProp.stringValue))
                keyProp.stringValue = options[0];

            var selectedIndex = options.IndexOf(keyProp.stringValue);

            selectedIndex = EditorGUILayout.Popup("Selectable", selectedIndex, options.ToArray());
            keyProp.stringValue = options[selectedIndex];

            serializedObject.ApplyModifiedProperties();

            themedSelectable.UpdateElement();
        }
    }
}
