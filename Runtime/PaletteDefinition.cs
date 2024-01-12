using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI.Themes
{
    [CreateAssetMenu(menuName = "GUI/Palette Definition")]
    public class PaletteDefinition : ScriptableObject
    {
        [SerializeField]
        private List<string> keys;

        public List<string> Keys => keys;
    }
}
