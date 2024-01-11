using UnityEngine;

namespace Reshyl.GUI
{
    public abstract class ThemedComponentBase : MonoBehaviour
    {
        [SerializeField] protected string elementKey;

        protected GUITheme parentTheme;

        protected virtual void OnEnable()
        {
            if (parentTheme == null)
                parentTheme = GetComponentInParent<GUITheme>();

            if (parentTheme != null)
                parentTheme.OnThemeChanged += OnThemeChanged;
        }

        protected virtual void OnDisable()
        {
            if (parentTheme != null)
                parentTheme.OnThemeChanged -= OnThemeChanged;
        }

        protected abstract void OnThemeChanged(Theme previousTheme, Theme newTheme);
    }
}
