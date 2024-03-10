using System.Collections;
using UnityEngine;

namespace Glider
{
    [RequireComponent(typeof(GliderMover))]
    public class Controls : MonoBehaviour
    {
        private GliderMover _gliderMover;

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
            _gliderMover = GetComponent<GliderMover>();
        }

        private IEnumerator AwaitInput()
        {
            bool isContinue = true;

            while (isContinue)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _gliderMover.AddVerticalVelocity();
                }

                if (Input.GetKey(KeyCode.LeftControl))
                {
                    _gliderMover.AddHorizontalVelocity();
                }

                yield return null;
            }
        }
    }
}