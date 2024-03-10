using ColorSystem;
using UnityEngine;

namespace Glider
{
    public class GliderFactory : MonoBehaviour
    {
        private ColorAnimator _colorAnimator;

        public void Initialize(ColorAnimator colorAnimator)
        {
            _colorAnimator = colorAnimator;
        }
    }
}