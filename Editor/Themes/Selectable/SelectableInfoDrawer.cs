using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomPropertyDrawer(typeof(SelectableInfo))]
    public class SelectableInfoDrawer : ElementInfoDrawer
    {
        protected override SerializedProperty GetValueProp(SerializedProperty parentProp)
        {
            return parentProp.FindPropertyRelative("settings");
        }
    }
}
