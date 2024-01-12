using Reshyl.GUI.Themes;
using UnityEditor;

namespace ReshylEditor.GUI.Themes
{
    [CustomEditor(typeof(TextPalette))]
    public class TextPaletteEditor : PaletteEditorBase
    {
        protected override string ElementsHeader => "Text Elements";
    }
}
