using UnityEngine;
using UnityEngine.UI;

namespace Reshyl.GUI
{
    [RequireComponent(typeof(Graphic))]
    public class ThemedGraphic : MonoBehaviour
    {
        [SerializeField]
        private ColorPalette colorPalette;
        [SerializeField]
        private string colorKey;
        [SerializeField]
        private bool overrideAlpha;
        [SerializeField, Range(0f, 1f)]
        private float alpha = 1f;

        private Graphic graphic;

        public virtual void UpdateElement()
        {
            if (graphic == null)
                graphic = GetComponent<Graphic>();

            if (colorPalette.GetElement(colorKey, out var color))
            {
                if (overrideAlpha)
                    color.a = alpha;

                graphic.color = color;
            }
            else
            {
                Debug.LogWarning(colorPalette.name + " does not contain a Color with key " + colorKey);
            }
        }
    }
}
