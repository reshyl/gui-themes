using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Theme")]
    public class Theme : ScriptableObject
    {
        [SerializeField]
        private List<PaletteBase> palettes;

        public int GetPaletteCount()
        {
            return palettes.Count;
        }

        public T GetPalette<T>() where T : PaletteBase
        {
            var palette = palettes.SingleOrDefault(p => p != null && p.GetType() == typeof(T));
            return (T)palette;
        }

        public T GetPalette<T>(string id) where T : PaletteBase
        {
            var palettesOfType = palettes.Where(p => p != null && p.GetType() == typeof(T));
            var palette = palettesOfType.SingleOrDefault(p => p.ID == id);

            return (T)palette;
        }

        public bool AddPalette<T>(T palette) where T : PaletteBase
        {
            if (palettes.Contains(palette))
                return false;

            palettes.Add(palette);
            return true;
        }

        public bool RemovePalette<T>() where T : PaletteBase
        {
            var palette = palettes.SingleOrDefault(p => p != null && p.GetType() == typeof(T));
            
            if (palette != null)
                return palettes.Remove(palette);

            return false;
        }

        public bool RemovePalette(string id)
        {
            var palette = palettes.SingleOrDefault(p => p != null && p.ID == id);

            if (palette != null)
                return palettes.Remove(palette);

            return false;
        }
    }
}
