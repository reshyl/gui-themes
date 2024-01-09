using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(ButtonPalette))]
    public class ButtonPaletteEditor : PaletteEditor
    {
        protected override void OnEnable()
        {
            definitionProp = serializedObject.FindProperty("definition");
            listProp = serializedObject.FindProperty("buttons");
        }
    }
}
