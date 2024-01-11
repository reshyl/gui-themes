using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Theme")]
    public class Theme : ScriptableObject
    {
        public List<PaletteBase> palettes;

        public T GetPalette<T>() where T : PaletteBase
        {
            var palette = palettes.Find(p => p.GetType() == typeof(T));
            return (T)palette;
        }
    }
}
