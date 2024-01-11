using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(SelectablePalette))]
    public class SelectablePaletteEditor : PaletteEditorBase
    {
        protected override string ElementsHeader => "Selectables";
    }
}
