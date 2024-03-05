using UnityEngine;

namespace Utils
{
    public abstract class Spawner : ObjectPool<MonoBehaviour>, ISpawner
    {
        public abstract void Spawn();
    }
}
