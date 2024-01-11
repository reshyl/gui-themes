using UnityEngine;

namespace Reshyl.GUI
{
    public class GUITheme : MonoBehaviour
    {
        [SerializeField]
        protected Theme theme;

        public delegate void ThemeChangedEvent(Theme previousTheme, Theme newTheme);
        public event ThemeChangedEvent OnThemeChanged;

        public Theme GetCurrentTheme() => theme;
        
        public void UpdateTheme(Theme theme)
        {
            var prevTheme = GetCurrentTheme();

            if (prevTheme == theme)
                return;

            this.theme = theme;

            if (OnThemeChanged != null)
                OnThemeChanged(prevTheme, theme);
        }
    }
}
