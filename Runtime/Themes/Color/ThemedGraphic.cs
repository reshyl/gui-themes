using UnityEngine;
using UnityEngine.UI;

namespace Reshyl.GUI
{
    [RequireComponent(typeof(Graphic))]
    public class ThemedGraphic : ThemedComponent<ColorPalette>
    {
        [SerializeField]
        private bool overrideAlpha;
        [SerializeField, Range(0f, 1f)]
        private float alpha = 1f;

        private Graphic graphic;

        public override void UpdateElement(ColorPalette palette)
        {
            if (graphic == null)
                graphic = GetComponent<Graphic>();

            if (palette.GetElement(elementKey, out var color))
            {
                if (overrideAlpha)
                    color.a = alpha;

                graphic.color = color;
            }
            else
            {
                Debug.LogWarning(palette.name + " does not contain a Color with key " + elementKey);
            }
        }
    }
}
