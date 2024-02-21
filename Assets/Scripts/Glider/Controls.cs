using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Mover))]
public class Controls : MonoBehaviour
{
    private Mover _mover;

    private Coroutine _coroutine;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        _coroutine = StartCoroutine(AwaitInput());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    public void Initialize()
    {
        _mover = GetComponent<Mover>();
    }

    private IEnumerator AwaitInput()
    {
        bool isContinue = true;

        while (isContinue)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mover.AddVerticalVelocity();
            }

            yield return null;
        }
    }
}
