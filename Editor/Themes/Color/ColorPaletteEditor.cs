using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ColorPalette))]
    public class ColorPaletteEditor : PaletteEditorBase
    {
        protected override string ElementsHeader => "Colors";
    }
}
