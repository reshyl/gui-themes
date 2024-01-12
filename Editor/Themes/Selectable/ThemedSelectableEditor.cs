using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedSelectable))]
    public class ThemedSelectableEditor : ThemedComponentEditorBase<SelectablePalette>
    {
        protected override string KeyLabel => "Selectable";
    }
}
