using ColorSystem;
using UnityEngine;

namespace Glider
{
    public class GliderFactory : MonoBehaviour
    {
        [SerializeField] private Glider _glider;

        private ColorHandler _colorHandler;

        public void Initialize(ColorHandler colorHandler)
        {
            _colorHandler = colorHandler;
        }
    }
}