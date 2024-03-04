using Assets.Scripts.ColorSystem;
using UnityEngine;

namespace Assets.Scripts.Glider
{
    public class GliderFabric : MonoBehaviour
    {
        [SerializeField] private Glider _glider;

        private ColorHandler _colorHandler;

        public void Initialize(ColorHandler colorHandler)
        {
            _colorHandler = colorHandler;
        }

        //public Glider Build()
        //{
        //    Glider newGlider = Instantiate(_gliderPrefabs[0]);
        //    newGlider.Initialize();
        //    return newGlider;
        //}
    }
}