using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Utils
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private T _prefab;
        private List<T> _objects;
        private Transform _container;

        public void Initialize(T prefab, Transform container, int startSize)
        {
            _container = container;
            _prefab = prefab;
            _objects = new List<T>();

            for (int i = 0; i < startSize; i++)
            {
                Create(out T newInstance);
            }
        }

        public T Get()
        {
            var instance = _objects.FirstOrDefault();

            if (instance != null)
            {
                Create(out T newInstance);
                instance = newInstance;
            }

            instance.gameObject.SetActive(true);
            return instance;
        }

        public void Release(T instance)
        {
            instance.gameObject.SetActive(false);
        }

        private void Create(out T newInstance)
        {
            var instance = Object.Instantiate(_prefab, _container);
            instance.gameObject.SetActive(false);
            _objects.Add(instance);
            newInstance = instance;
        }
    }
}