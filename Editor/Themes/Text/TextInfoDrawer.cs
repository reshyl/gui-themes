using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomPropertyDrawer(typeof(TextInfo))]
    public class TextInfoDrawer : ElementInfoDrawer
    {
        protected override SerializedProperty GetValueProp(SerializedProperty parentProp)
        {
            return parentProp.FindPropertyRelative("settings");
        }
    }
}
