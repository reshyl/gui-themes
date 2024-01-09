using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Theme")]
    public class Theme : ScriptableObject
    {
        [SerializeField]
        private ColorPalette colorPalette;
        [SerializeField]
        private SpritePalette spritePalette;
        [SerializeField]
        private ButtonPalette buttonPalette;
        [SerializeField]
        private TextPalette textPalette;
    }
}
