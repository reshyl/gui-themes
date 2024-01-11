using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    public abstract class ThemedComponentEditorBase<T> : Editor
        where T : PaletteBase
    {
        protected SerializedProperty keyProp;
        protected ThemedComponent<T> themedComponent;
        protected GUITheme parentTheme;

        protected virtual string KeyLabel => "Key";

        protected virtual void OnEnable()
        {
            keyProp = serializedObject.FindProperty("elementKey");
            themedComponent = (ThemedComponent<T>)target;
            parentTheme = themedComponent.GetComponentInParent<GUITheme>();
        }

        protected virtual T GetPalette()
        {
            if (parentTheme == null)
            {
                EditorGUILayout.HelpBox("This component is not being managed by a GUI Theme. " +
                    "Must have a GUI Theme component on one of the parents of this GameObject.", MessageType.Error);
                return null;
            }

            var currentTheme = parentTheme.GetCurrentTheme();

            if (currentTheme == null)
            {
                EditorGUILayout.HelpBox("No theme assigned to the GUI Theme component managing this element!", MessageType.Error);
                return null;
            }

            var palette = currentTheme.GetPalette<T>();

            if (palette == null)
            {
                EditorGUILayout.HelpBox("Currently selected theme does not have a Palette of type " + typeof(T).Name, MessageType.Error);
                return null;
            }

            if (palette.Definition == null || palette.Definition.Keys == null || palette.Definition.Keys.Count == 0)
            {
                EditorGUILayout.HelpBox("Error retreving a Palette Definition from " + palette.name +
                    ". Make sure a Definition is assigned, with at least one key.", MessageType.Error);
                return null;
            }

            return palette;
        }

        protected virtual void DrawKeyPopup(T palette)
        {
            var options = palette.Definition.Keys;

            if (keyProp.stringValue == string.Empty)
                keyProp.stringValue = options[0];
            else if (!options.Contains(keyProp.stringValue))
                keyProp.stringValue = options[0];

            var selectedIndex = options.IndexOf(keyProp.stringValue);

            selectedIndex = EditorGUILayout.Popup(KeyLabel, selectedIndex, options.ToArray());
            keyProp.stringValue = options[selectedIndex];
        }
    }
}
