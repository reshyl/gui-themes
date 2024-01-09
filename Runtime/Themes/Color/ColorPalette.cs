using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Color Palette")]
    public sealed class ColorPalette : ScriptableObject
    {
        [SerializeField]
        private PaletteDefinition definition;
        [SerializeField]
        private List<ColorInfo> colors;

        /// <summary>
        /// Get the Color with the given key.
        /// </summary>
        /// <param name="color">Color will be assigned to this variable. 
        /// Will be Color.black if the given key doesn't exist.</param>
        /// <returns>Whether the given key exists or not.</returns>
        public bool GetColor(string key, out Color color)
        {
            var info = colors.Find(c => c.key == key);

            if (info != null)
            {
                color = info.color;
                return true;
            }

            color = Color.black;
            return false;
        }
    }
}
