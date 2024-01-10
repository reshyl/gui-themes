using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Selectable/Selectable Palette")]
    public sealed class SelectablePalette : ScriptableObject
    {
        public PaletteDefinition definition;
        public List<SelectableInfo> selectables;

        public bool GetSelectable(string key, out SelectableSettings settings)
        {
            var info = selectables.Find(c => c.key == key);

            if (info != null)
            {
                settings = info.settings;
                return true;
            }

            settings = null;
            return false;
        }
    }
}
