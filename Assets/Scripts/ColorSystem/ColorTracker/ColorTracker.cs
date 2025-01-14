using UnityEngine;

namespace ColorSystem.ColorTracker
{
    public abstract class ColorTracker : MonoBehaviour
    {
        [field : SerializeField] protected ColorNames ColorName { get; private set; }
        protected IColorData ColorData;

        public virtual void Initialize(ColorAnimator colorAnimator)
        {
            ColorData = colorAnimator.GetColorData(ColorName);
            SetTracker();
        }

        protected abstract void SetTracker();

        protected virtual Color AdjustColor(Color color) => color;
    }
}