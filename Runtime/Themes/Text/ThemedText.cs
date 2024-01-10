﻿using TMPro;
using UnityEngine;

namespace Reshyl.GUI
{
    public class ThemedText : MonoBehaviour
    {
        [SerializeField]
        private TextPalette palette;
        [SerializeField]
        private string textKey;
        [SerializeField]
        private bool ignoreColor;

        private TMP_Text textMesh;

        public virtual void UpdateElement()
        {
            if (textMesh == null)
                textMesh = GetComponent<TMP_Text>();

            if (palette.GetText(textKey, out var settings))
            {
                textMesh.font = settings.font;
                textMesh.fontSharedMaterial = settings.fontMaterial;
                textMesh.fontStyle = settings.style;

                textMesh.fontSize = settings.fontSize;
                textMesh.enableAutoSizing = settings.autoSize;
                textMesh.fontSizeMin = settings.minFontSize;
                textMesh.fontSizeMax = settings.maxFontSize;
                textMesh.characterWidthAdjustment = settings.characterWidthAdjustment;
                textMesh.lineSpacingAdjustment = settings.lineSpacingAdjustment;

                if (!ignoreColor)
                    textMesh.color = settings.vertexColor;
                
                textMesh.enableVertexGradient = settings.colorGradient;
                textMesh.colorGradientPreset = settings.gradientPreset;

                textMesh.characterSpacing = settings.characterSpacing;
                textMesh.wordSpacing = settings.wordSpacing;
                textMesh.lineSpacing = settings.lineSpacing;
                textMesh.paragraphSpacing = settings.paragraphSpacing;

                textMesh.alignment = settings.alignment;

                textMesh.enableWordWrapping = settings.wrapping;
                textMesh.overflowMode = settings.overflow;
                textMesh.horizontalMapping = settings.horizontalMapping;
                textMesh.verticalMapping = settings.verticalMapping;
            }
            else
            {
                Debug.LogWarning(palette.name + " does not contain a Text with key " + textKey);
            }
        }
    }
}
