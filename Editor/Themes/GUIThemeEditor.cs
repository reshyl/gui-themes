using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(GUITheme))]
    public class GUIThemeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var guiTheme = (GUITheme)target;

            EditorGUI.BeginChangeCheck();

            var theme = guiTheme.GetCurrentTheme();
            theme = (Theme)EditorGUILayout.ObjectField("Theme", theme, typeof(Theme), false);

            if (EditorGUI.EndChangeCheck())
                guiTheme.UpdateTheme(theme);
        }
    }
}
