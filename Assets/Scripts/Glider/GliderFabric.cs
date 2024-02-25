using Unity.VisualScripting;
using UnityEngine;

public class GliderFabric : MonoBehaviour
{
    [SerializeField] Glider _glider;

    ColorHandler _colorHandler;

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
