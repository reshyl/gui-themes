using Reshyl.GUI.Themes;
using UnityEditor;

namespace ReshylEditor.GUI.Themes
{
    [CustomEditor(typeof(ColorPalette))]
    public class ColorPaletteEditor : PaletteEditorBase
    {
        protected override string ElementsHeader => "Colors";
    }
}
