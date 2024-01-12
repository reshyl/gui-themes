using UnityEngine;

namespace Reshyl.GUI.Themes
{
    public class PaletteBase : ScriptableObject
    {
        [SerializeField] protected string id = "palette_id";
        [SerializeField] protected PaletteDefinition definition;

        public string ID => id;
        public PaletteDefinition Definition => definition;
    }
}
