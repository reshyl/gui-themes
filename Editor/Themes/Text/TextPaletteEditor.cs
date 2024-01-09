using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(TextPalette))]
    public class TextPaletteEditor : PaletteEditor
    {
        protected override void OnEnable()
        {
            definitionProp = serializedObject.FindProperty("definition");
            listProp = serializedObject.FindProperty("texts");
        }
    }
}
