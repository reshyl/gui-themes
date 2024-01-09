using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(SpritePalette))]
    public class SpritePaletteEditor : PaletteEditor
    {
        protected override void OnEnable()
        {
            definitionProp = serializedObject.FindProperty("definition");
            listProp = serializedObject.FindProperty("sprites");
        }
    }
}
