using UnityEngine;
using UnityEngine.UI;

namespace Reshyl.GUI
{
    public class ThemedSelectable : MonoBehaviour
    {
        [SerializeField]
        private SelectablePalette palette;
        [SerializeField]
        private string selectableKey;

        private Selectable selectable;

        public virtual void UpdateElement()
        {
            if (selectable == null)
                selectable = GetComponent<Selectable>();

            if (palette.GetElement(selectableKey, out var settings))
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
                Debug.LogWarning(palette.name + " does not contain a Selectable with key " + selectableKey);
            }
        }
    }
}
