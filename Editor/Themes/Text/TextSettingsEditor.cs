using Reshyl.GUI;
using UnityEditor;
using UnityEngine;

namespace ReshylEditor.GUI
{
    [CustomEditor(typeof(TextSettings))]
    public class TextSettingsEditor : Editor
    {
        private SerializedProperty fontProp;
        private SerializedProperty fontMaterialProp;
        private SerializedProperty styleProp;

        private SerializedProperty fontSizeProp;
        private SerializedProperty autoSizeProp;
        private SerializedProperty minSizeProp;
        private SerializedProperty maxSizeProp;
        private SerializedProperty characterWidthAdjProp;
        private SerializedProperty lineSpacingAdjProp;

        private SerializedProperty vertexColorProp;
        private SerializedProperty colorGradientProp;
        private SerializedProperty gradientPresetProp;

        private SerializedProperty characterSpacingProp;
        private SerializedProperty wordSpacingProp;
        private SerializedProperty lineSpacingProp;
        private SerializedProperty paragraphSpacingProp;

        private SerializedProperty alignmentProp;

        private SerializedProperty wrappingProp;
        private SerializedProperty overflowProp;
        private SerializedProperty horMappingProp;
        private SerializedProperty vertMappingProp;

        private void OnEnable()
        {
            fontProp = serializedObject.FindProperty("font");
            fontMaterialProp = serializedObject.FindProperty("fontMaterial");
            styleProp = serializedObject.FindProperty("style");

            fontSizeProp = serializedObject.FindProperty("fontSize");
            autoSizeProp = serializedObject.FindProperty("autoSize");
            minSizeProp = serializedObject.FindProperty("minFontSize");
            maxSizeProp = serializedObject.FindProperty("maxFontSize");
            characterWidthAdjProp = serializedObject.FindProperty("characterWidthAdjustment");
            lineSpacingAdjProp = serializedObject.FindProperty("lineSpacingAdjustment");

            vertexColorProp = serializedObject.FindProperty("vertexColor");
            colorGradientProp = serializedObject.FindProperty("colorGradient");
            gradientPresetProp = serializedObject.FindProperty("gradientPreset");

            characterSpacingProp = serializedObject.FindProperty("characterSpacing");
            wordSpacingProp = serializedObject.FindProperty("wordSpacing");
            lineSpacingProp = serializedObject.FindProperty("lineSpacing");
            paragraphSpacingProp = serializedObject.FindProperty("paragraphSpacing");

            alignmentProp = serializedObject.FindProperty("alignment");

            wrappingProp = serializedObject.FindProperty("wrapping");
            overflowProp = serializedObject.FindProperty("overflow");
            horMappingProp = serializedObject.FindProperty("horizontalMapping");
            vertMappingProp = serializedObject.FindProperty("verticalMapping");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            DrawFont();
            DrawFontSize();
            DrawColors();
            DrawSpacingOptions();
            DrawAlignment();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawFont()
        {
            EditorGUILayout.PropertyField(fontProp);
            EditorGUILayout.PropertyField(fontMaterialProp);
            EditorGUILayout.PropertyField(styleProp);
        }

        private void DrawFontSize()
        {
            if (autoSizeProp.boolValue)
            {
                UnityEngine.GUI.enabled = false;
                EditorGUILayout.PropertyField(fontSizeProp);
                UnityEngine.GUI.enabled = true;

                EditorGUILayout.PropertyField(autoSizeProp);

                var rect = EditorGUILayout.GetControlRect(true, EditorGUIUtility.singleLineHeight);

                var label = new GUIContent("Auto Size Options");
                EditorGUI.PrefixLabel(rect, label);

                int previousIndent = EditorGUI.indentLevel;

                EditorGUI.indentLevel = 0;
                rect.width = (rect.width - EditorGUIUtility.labelWidth) / 4f;
                rect.x += EditorGUIUtility.labelWidth;

                EditorGUIUtility.labelWidth = 24;
                EditorGUI.PropertyField(rect, minSizeProp, new GUIContent("Min"));

                rect.x += rect.width;

                EditorGUIUtility.labelWidth = 27;
                EditorGUI.PropertyField(rect, maxSizeProp, new GUIContent("Max"));

                rect.x += rect.width;

                EditorGUIUtility.labelWidth = 36;
                EditorGUI.PropertyField(rect, characterWidthAdjProp, new GUIContent("WD%"));
                
                rect.x += rect.width;
                
                EditorGUIUtility.labelWidth = 28;
                EditorGUI.PropertyField(rect, lineSpacingAdjProp, new GUIContent("Line"));

                EditorGUIUtility.labelWidth = 0;

                EditorGUI.indentLevel = previousIndent;
            }
            else
            {
                EditorGUILayout.PropertyField(fontSizeProp);
                EditorGUILayout.PropertyField(autoSizeProp);
            }
        }

        private void DrawColors()
        {
            EditorGUILayout.PropertyField(vertexColorProp);
            EditorGUILayout.PropertyField(colorGradientProp);

            if (colorGradientProp.boolValue)
                EditorGUILayout.PropertyField(gradientPresetProp);
        }

        private void DrawSpacingOptions()
        {
            var rect = EditorGUILayout.GetControlRect(true, EditorGUIUtility.singleLineHeight);

            EditorGUI.PrefixLabel(rect, new GUIContent("Spacing Options (em)"));

            int oldIndent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            float currentLabelWidth = EditorGUIUtility.labelWidth;
            rect.x += currentLabelWidth;
            rect.width = (rect.width - currentLabelWidth - 3f) / 2f;

            EditorGUIUtility.labelWidth = Mathf.Min(rect.width * 0.55f, 80f);

            EditorGUI.PropertyField(rect, characterSpacingProp, new GUIContent("Character"));
            rect.x += rect.width + 3f;
            EditorGUI.PropertyField(rect, wordSpacingProp, new GUIContent("Word"));

            rect = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight);

            rect.x += currentLabelWidth;
            rect.width = (rect.width - currentLabelWidth - 3f) / 2f;
            EditorGUIUtility.labelWidth = Mathf.Min(rect.width * 0.55f, 80f);

            EditorGUI.PropertyField(rect, lineSpacingProp, new GUIContent("Line"));
            rect.x += rect.width + 3f;
            EditorGUI.PropertyField(rect, paragraphSpacingProp, new GUIContent("Paragraph"));

            EditorGUIUtility.labelWidth = currentLabelWidth;
            EditorGUI.indentLevel = oldIndent;
        }

        private void DrawAlignment()
        {
            EditorGUILayout.PropertyField(alignmentProp);

            EditorGUILayout.PropertyField(wrappingProp);
            EditorGUILayout.PropertyField(overflowProp);
            EditorGUILayout.PropertyField(horMappingProp);
            EditorGUILayout.PropertyField(vertMappingProp);
        }
    }
}
