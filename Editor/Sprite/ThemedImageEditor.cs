using Reshyl.GUI.Themes;
using UnityEditor;

namespace ReshylEditor.GUI.Themes
{
    [CustomEditor(typeof(ThemedImage))]
    public class ThemedImageEditor : ThemedComponentEditorBase<SpritePalette>
    {
        protected override string KeyLabel => "Sprite";
    }
}
