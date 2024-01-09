using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Selectable/Selectable Palette")]
    public sealed class SelectablePalette : ScriptableObject
    {
        [SerializeField]
        private PaletteDefinition definition;
        [SerializeField]
        private List<SelectableInfo> selectables;
    }
}
