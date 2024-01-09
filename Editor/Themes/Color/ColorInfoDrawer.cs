using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomPropertyDrawer(typeof(ColorInfo))]
    public class ColorInfoDrawer : ElementInfoDrawer
    {
        protected override SerializedProperty GetValueProp(SerializedProperty parentProp)
        {
            return parentProp.FindPropertyRelative("color");
        }
    }
}
