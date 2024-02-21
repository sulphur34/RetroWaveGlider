using Unity.VisualScripting;
using UnityEngine;

public class GliderFabric : MonoBehaviour
{
    [SerializeField] Glider[] _gliderPrefabs;

    ColorHandler _colorHandler;

    public void Initialize(ColorHandler colorHandler)
    {
        _colorHandler = colorHandler;
    }

    public Glider Build()
    {
        Glider newGlider = Instantiate(_gliderPrefabs[0]);
        ColorTracker colorTracker = newGlider.AddComponent<ColorTracker>();
        colorTracker.Initialize(_colorHandler.GetColorData(ColorNames.Glider));
        return newGlider;
    }
}
