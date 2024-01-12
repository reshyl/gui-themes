namespace Reshyl.GUI
{
    public abstract class ThemedComponent<T> : ThemedComponentBase
        where T : PaletteBase
    {
        protected override void OnThemeChanged(Theme previousTheme, Theme newTheme)
        {
            if (newTheme == null)
                return;

            var palette = newTheme.GetPalette<T>();
            
            if (palette != null)
                UpdateElement(palette);
        }

        public abstract void UpdateElement(T palette);
    }
}
