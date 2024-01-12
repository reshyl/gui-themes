using UnityEngine;
using UnityEngine.UI;

namespace Reshyl.GUI
{
    [RequireComponent(typeof(Selectable))]
    public class ThemedSelectable : ThemedComponent<SelectablePalette>
    {
        private Selectable selectable;

        public override void UpdateElement(SelectablePalette palette)
        {
            if (selectable == null)
                selectable = GetComponent<Selectable>();

            if (palette.GetElement(elementKey, out var settings))
            {
                selectable.image.sprite = settings.sprite;
                selectable.transition = settings.transition;
                selectable.colors = settings.colors;
                selectable.spriteState = settings.sprites;
                selectable.animationTriggers = settings.animations;

                if (settings.transition == Selectable.Transition.Animation)
                {
                    var animator = GetComponent<Animator>();

                    if (animator == null)
                        animator = gameObject.AddComponent<Animator>();

                    animator.runtimeAnimatorController = settings.controller;
                }
            }
            else
            {
                Debug.LogWarning(palette.name + " does not contain a Selectable with key " + elementKey);
            }
        }
    }
}
