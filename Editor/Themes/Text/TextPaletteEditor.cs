using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(TextPalette))]
    public class TextPaletteEditor : PaletteEditorBase
    {
        protected override string ElementsHeader => "Text Elements";
    }
}
