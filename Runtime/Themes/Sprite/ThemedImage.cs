using UnityEngine;
using UnityEngine.UI;

namespace Reshyl.GUI
{
    [RequireComponent(typeof(Image))]
    public class ThemedImage : ThemedComponent<SpritePalette>
    {
        private Image image;

        public override void UpdateElement(SpritePalette palette)
        {
            if (image == null)
                image = GetComponent<Image>();

            if (palette.GetElement(elementKey, out var sprite))
                image.sprite = sprite;
            else
                Debug.LogWarning(palette.name + " does not contain a Sprite with key " + elementKey);
        }
    }
}
