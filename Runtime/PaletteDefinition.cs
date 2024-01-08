using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Palette Definition")]
    public class PaletteDefinition : ScriptableObject
    {
        public List<string> keys;
    }
}
