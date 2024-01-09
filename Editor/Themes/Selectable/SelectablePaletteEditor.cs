using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(SelectablePalette))]
    public class SelectablePaletteEditor : PaletteEditor
    {
        protected override void OnEnable()
        {
            definitionProp = serializedObject.FindProperty("definition");
            listProp = serializedObject.FindProperty("selectables");
        }
    }
}
