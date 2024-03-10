using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Timer
    {
        private readonly float _step = 0.1f;
        
        private float _duration;
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds;
        private MonoBehaviour _context;

        public event Action Started;
        public event Action<float> Changed;
        public event Action Ended;

        public Timer(MonoBehaviour context)
        {
            _context = context;
            _waitForSeconds = new WaitForSeconds(_step);
        }

        private void Initialize(float duration)
        {
            _waitForSeconds = new WaitForSeconds(_step);
        }

        private void Begin(float duration)
        {
            _duration = duration;
            _coroutine = _context.StartCoroutine(Counting());
        }

        private void Stop()
        {
            if (_coroutine != null)
                _context.StopCoroutine(_coroutine);
        }

        private IEnumerator Counting()
        {
            Started?.Invoke();
            float remainTime = _duration;

            while (remainTime > 0)
            {
                remainTime -= _step;
                Changed?.Invoke(remainTime);
                yield return _waitForSeconds;
            }
            Ended?.Invoke();
        }
    }
}