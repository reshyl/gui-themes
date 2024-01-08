using System.Collections;
using UnityEngine;

namespace Reshyl.GUI
{
    [CreateAssetMenu(menuName = "GUI/Theme")]
    public class Theme : ScriptableObject
    {
        [SerializeField]
        private ColorPalette colorPalette;
    }
}
