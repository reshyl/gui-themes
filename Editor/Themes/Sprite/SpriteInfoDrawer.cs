using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomPropertyDrawer(typeof(SpriteInfo))]
    public class SpriteInfoDrawer : ElementInfoDrawer
    {
        protected override SerializedProperty GetValueProp(SerializedProperty parentProp)
        {
            return parentProp.FindPropertyRelative("sprite");
        }
    }
}
