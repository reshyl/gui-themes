using System.Collections.Generic;
using UnityEngine;

namespace Reshyl.GUI
{
    public class Palette<T> : PaletteBase
    {
        [SerializeField] protected List<T> elements;

        public int GetElementCount()
        {
            return definition.Keys.Count;
        }

        public bool GetElement(string key, out T element)
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

        public T GetElementAt(int index)
        {
            if (index >= 0 && index < definition.Keys.Count)
                return elements[index];

            throw new System.IndexOutOfRangeException();
        }

        public bool SetElement(string key, T element)
        {
            if (!definition.Keys.Contains(key))
                return false;

            var index = definition.Keys.IndexOf(key);
            elements[index] = element;
            return true;
        }

        public bool SetElementAt(int index, T element)
        {
            if (index >= 0 && index < definition.Keys.Count)
            {
                elements[index] = element;
                return true;
            }

            throw new System.IndexOutOfRangeException();
        }
    }
}
