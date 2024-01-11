using System.Collections.Generic;
using System.Linq;
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

        public T GetPalette<T>(string id) where T : PaletteBase
        {
            var palettesOfType = palettes.Where(p => p.GetType() == typeof(T));
            var palette = palettesOfType.SingleOrDefault(p => p.ID == id);

            return (T)palette;
        }
    }
}
