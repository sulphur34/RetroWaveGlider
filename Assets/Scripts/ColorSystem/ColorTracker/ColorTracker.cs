using UnityEngine;

namespace ColorSystem.ColorTracker
{
    public abstract class ColorTracker : MonoBehaviour
    {
        [SerializeField] private ColorAnimator colorAnimator;

        protected string ColorName;
        protected IColorData ColorData;

        public virtual void Initialize()
        {
            ColorData = colorAnimator.GetColorData(ColorName);
        }

        protected abstract void SetTracker();

        protected virtual Color AdjustColor(Color color) => color;
    }
}