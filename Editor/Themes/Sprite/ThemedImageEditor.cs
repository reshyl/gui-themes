using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ThemedImage))]
    public class ThemedImageEditor : ThemedComponentEditorBase<SpritePalette>
    {
        protected override string KeyLabel => "Sprite";
    }
}
