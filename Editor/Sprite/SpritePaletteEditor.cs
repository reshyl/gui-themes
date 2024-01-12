using Reshyl.GUI.Themes;
using UnityEditor;

namespace ReshylEditor.GUI.Themes
{
    [CustomEditor(typeof(SpritePalette))]
    public class SpritePaletteEditor : PaletteEditorBase
    {
        protected override string ElementsHeader => "Sprites";
    }
}
