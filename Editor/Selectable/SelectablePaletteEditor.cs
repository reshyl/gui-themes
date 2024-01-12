using Reshyl.GUI.Themes;
using UnityEditor;

namespace ReshylEditor.GUI.Themes
{
    [CustomEditor(typeof(SelectablePalette))]
    public class SelectablePaletteEditor : PaletteEditorBase
    {
        protected override string ElementsHeader => "Selectables";
    }
}
