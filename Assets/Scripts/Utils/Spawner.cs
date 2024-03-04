using UnityEngine;

namespace Assets.Scripts.Utils
{
    public abstract class Spawner : ObjectPool<MonoBehaviour>, ISpawner
    {
        public abstract void Spawn();
    }
}
