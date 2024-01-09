using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ColorPalette))]
    public class ColorPaletteEditor : PaletteEditor
    {
        protected override void OnEnable()
        {
            definitionProp = serializedObject.FindProperty("definition");
            listProp = serializedObject.FindProperty("colors");
        }
    }
}
