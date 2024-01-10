using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Sprite Palette")]
    public sealed class SpritePalette : ScriptableObject
    {
        public PaletteDefinition definition;
        public List<SpriteInfo> sprites;

        /// <summary>
        /// Get the Sprite with the given key.
        /// </summary>
        /// <param name="sprite">The sprite will be assigned to this variable. 
        /// Will be null if the given key doesn't exist.</param>
        /// <returns>Whether the given key exists or not.</returns>
        public bool GetSprite(string key, out Sprite sprite)
        {
            var info = sprites.Find(c => c.key == key);

            if (info != null)
            {
                sprite = info.sprite;
                return true;
            }

            sprite = null;
            return false;
        }
    }
}
