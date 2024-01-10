using TMPro;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Text/Text Settings")]
    public class TextSettings : ScriptableObject
    {
        public TMP_FontAsset font;
        public Material fontMaterial;
        public FontStyles style;
        
        public float fontSize;
        public bool autoSize;
        public float minFontSize;
        public float maxFontSize;
        public float characterWidthAdjustment;
        public float lineSpacingAdjustment;

        public Color vertexColor;
        public bool colorGradient;
        public TMP_ColorGradient gradientPreset;

        public float characterSpacing;
        public float wordSpacing;
        public float lineSpacing;
        public float paragraphSpacing;

        public TextAlignmentOptions alignment;

        public bool wrapping;
        public TextOverflowModes overflow;
        public TextureMappingOptions horizontalMapping;
        public TextureMappingOptions verticalMapping;

        private void Reset()
        {
            //Set the default values to be similar to TMP when creating a new object.
            font = Resources.Load<TMP_FontAsset>("Fonts & Materials/LiberationSans SDF");
            fontMaterial = font != null ? font.material : null;

            fontSize = 36f;
            minFontSize = 18f;
            maxFontSize = 72f;

            vertexColor = Color.white;

            alignment = TextAlignmentOptions.TopLeft;

            wrapping = true;
        }

        private void OnValidate()
        {
            minFontSize = Mathf.Clamp(minFontSize, 1f, maxFontSize - 1f);
            maxFontSize = Mathf.Clamp(maxFontSize, minFontSize + 1f, float.MaxValue);
            lineSpacingAdjustment = Mathf.Clamp(lineSpacingAdjustment, float.MinValue, 0f);
        }
    }
}
