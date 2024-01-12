using UnityEngine;

namespace Reshyl.GUI
{
    public abstract class ThemedComponentBase : MonoBehaviour
    {
        [SerializeField] protected string elementKey;

        protected GUITheme themeController;

        protected virtual void OnEnable()
        {
            themeController = GetComponentInParent<GUITheme>();

            if (themeController != null)
            {
                themeController.OnThemeChanged += OnThemeChanged;
                OnThemeChanged(null, themeController.GetCurrentTheme());
            }
        }

        protected virtual void OnDisable()
        {
            if (themeController != null)
                themeController.OnThemeChanged -= OnThemeChanged;
        }

        //We make sure to update the element if it's been moved from one GUI Theme to another
        protected virtual void OnTransformParentChanged()
        {
            var newController = GetComponentInParent<GUITheme>();

            if (newController == themeController)
                return;

            if (themeController != null)
            {
                themeController.OnThemeChanged -= OnThemeChanged;
                OnThemeChanged(themeController.GetCurrentTheme(), null);
            }

            themeController = newController;

            if (themeController != null)
            {
                themeController.OnThemeChanged += OnThemeChanged;
                OnThemeChanged(null, themeController.GetCurrentTheme());
            }
        }

        public string GetElementKey()
        {
            return elementKey;
        }

        protected abstract void OnThemeChanged(Theme previousTheme, Theme newTheme);
    }
}
