using UnityEngine;
using UnityEngine.UI;

namespace Reshyl.GUI
{
    public class ThemedImage : MonoBehaviour
    {
        [SerializeField]
        private SpritePalette spritePalette;
        [SerializeField]
        private string spriteKey;

        private Image image;

        public virtual void UpdateElement()
        {
            if (image == null)
                image = GetComponent<Image>();

            if (spritePalette.GetElement(spriteKey, out var sprite))
                image.sprite = sprite;
            else
                Debug.LogWarning(spritePalette.name + " does not contain a Sprite with key " + spriteKey);
        }
    }
}
