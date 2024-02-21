using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] Brick[] _bricks;

    public float Width { get; private set; }

    private void Awake()
    {
        Width = _bricks[0].Width;
    }

    private void OnEnable()
    {
        DisableRandomBricksAmount();
    }

    private void OnDisable()
    {
        ResetBricks();
    }

    private void DisableRandomBricksAmount()
    {
        int minValue = 0;
        int maxValue = _bricks.Length;
        int disableFactorStart = Random.Range(10, 17);
        int disableFactorEnd = Random.Range(10, 17);
        int startDisableIndex = Random.Range(minValue, maxValue / 2 - disableFactorStart);
        int endDisableIndex = Random.Range(maxValue / 2 + disableFactorEnd, maxValue);

        for (int i = startDisableIndex; i < endDisableIndex; i++)
        {
            _bricks[i].gameObject.SetActive(false);
        }
    }

    private void ResetBricks()
    {
        foreach (var brick in _bricks)
        {
            brick.gameObject.SetActive(true);
        }
    }
}
