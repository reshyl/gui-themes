using Reshyl.GUI;
using UnityEditor;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(SelectableSettings))]
    public class SelectableSettingsEditor : Editor
    {
        private SerializedProperty spriteProp;
        private SerializedProperty transitionProp;
        private SerializedProperty colorsProp;
        private SerializedProperty spritesProp;
        private SerializedProperty animationsProp;
        private SerializedProperty controllerProp;

        private void OnEnable()
        {
            spriteProp = serializedObject.FindProperty("sprite");
            transitionProp = serializedObject.FindProperty("transition");
            colorsProp = serializedObject.FindProperty("colors");
            spritesProp = serializedObject.FindProperty("sprites");
            animationsProp = serializedObject.FindProperty("animations");
            controllerProp = serializedObject.FindProperty("controller");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(spriteProp);
            EditorGUILayout.PropertyField(transitionProp);

            if (transitionProp.enumValueIndex == 1)
                EditorGUILayout.PropertyField(colorsProp);
            else if (transitionProp.enumValueIndex == 2)
                EditorGUILayout.PropertyField(spritesProp);
            else if (transitionProp.enumValueIndex == 3)
            {
                EditorGUILayout.PropertyField(animationsProp);
                EditorGUILayout.PropertyField(controllerProp);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
