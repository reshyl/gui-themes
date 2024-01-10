using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Text/Text Palette")]
    public sealed class TextPalette : ScriptableObject
    {
        public PaletteDefinition definition;
        public List<TextInfo> texts;

        public bool GetText(string key, out TextSettings settings)
        {
            var info = texts.Find(t => t.key == key);

            if (info != null)
            {
                settings = info.settings;
                return true;
            }

            settings = null;
            return false;
        }
    }
}
