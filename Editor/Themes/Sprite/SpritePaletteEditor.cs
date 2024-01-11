using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(SpritePalette))]
    public class SpritePaletteEditor : PaletteEditorBase
    {
        protected override string ElementsHeader => "Sprites";
    }
}
