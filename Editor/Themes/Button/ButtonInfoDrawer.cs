using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomPropertyDrawer(typeof(ButtonInfo))]
    public class ButtonInfoDrawer : ElementInfoDrawer
    {
        protected override SerializedProperty GetValueProp(SerializedProperty parentProp)
        {
            return parentProp.FindPropertyRelative("settings");
        }
    }
}
