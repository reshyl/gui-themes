using UnityEngine;
using UnityEngine.UI;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Button Settings")]
    public class ButtonSettings : ScriptableObject
    {
        public Sprite sprite;
        public Selectable.Transition transition;
        public ColorBlock colors;
        public SpriteState sprites;
        public AnimationTriggers animations;
        public RuntimeAnimatorController controller;

        private void Reset()
        {
            transition = Selectable.Transition.ColorTint;
            colors = new ColorBlock
            {
                normalColor = Color.white,
                highlightedColor = new Color32(245, 245, 245, 255),
                pressedColor = new Color32(200, 200, 200, 255),
                selectedColor = new Color32(245, 245, 245, 255),
                disabledColor = new Color32(200, 200, 200, 128),
                colorMultiplier = 1f,
                fadeDuration = 0.1f
            };
        }
    }
}
