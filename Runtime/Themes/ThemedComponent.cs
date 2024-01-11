namespace Reshyl.GUI
{
    public abstract class ThemedComponent<T> : ThemedComponentBase
        where T : PaletteBase
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            OnThemeChanged(null, parentTheme.GetCurrentTheme());
        }

        protected override void OnThemeChanged(Theme previousTheme, Theme newTheme)
        {
            if (newTheme == null)
                return;

            var palette = newTheme.GetPalette<T>();
            UpdateElement(palette);
        }

        public abstract void UpdateElement(T palette);
    }
}
