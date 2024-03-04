using UnityEngine;

namespace Assets.Scripts.ColorSystem.ColorTracker
{
    public abstract class ColorTracker : MonoBehaviour
    {
        [SerializeField] private ColorHandler colorHandler;

        protected string ColorName;
        protected IColorData ColorData;

        public virtual void Initialize()
        {
            ColorData = colorHandler.GetColorData(ColorName);
        }

        protected abstract void SetTracker();
    }
}