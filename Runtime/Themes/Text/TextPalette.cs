using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Text/Text Palette")]
    public sealed class TextPalette : ScriptableObject
    {
        [SerializeField]
        private PaletteDefinition definition;
        [SerializeField]
        private List<TextInfo> texts;
    }
}
