using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Button Palette")]
    public sealed class ButtonPalette : ScriptableObject
    {
        [SerializeField]
        private PaletteDefinition definition;
        [SerializeField]
        private List<ButtonInfo> buttons;
    }
}
