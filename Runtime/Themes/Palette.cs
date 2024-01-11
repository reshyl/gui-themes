using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    public class Palette<T> : PaletteBase
    {
        [SerializeField] protected List<T> elements;

        public virtual bool GetElement(string key, out T element)
        {
            if (!definition.Keys.Contains(key))
            {
                element = default;
                return false;
            }

            var index = definition.Keys.IndexOf(key);
            element = elements[index];
            return true;
        }
    }
}
