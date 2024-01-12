using Reshyl.GUI.Themes;
using UnityEditor;

namespace ReshylEditor.GUI.Themes
{
    [CustomEditor(typeof(ThemedSelectable))]
    public class ThemedSelectableEditor : ThemedComponentEditorBase<SelectablePalette>
    {
        protected override string KeyLabel => "Selectable";
    }
}
