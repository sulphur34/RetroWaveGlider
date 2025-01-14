using ColorSystem.ColorTracker;
using Enemies;
using Glider.EnergySystem;
using Glider.ModuleSystem;
using TerrainSystem;
using UnityEngine;

namespace Glider
{
    [RequireComponent(typeof(GliderMover))]
    [RequireComponent(typeof(Controls))]
    [RequireComponent(typeof(ColorTracker))]
    [RequireComponent(typeof(PolygonCollider2D))]
    public class Glider : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _deathParticle;
        
        private Energy _energy;
        private IModule[] _modules;
        private PolygonCollider2D _polygonCollider;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.TryGetComponent(out Enemy enemy) || collision.collider.TryGetComponent(out TerrainMesh terrainMesh))
            {
                Instantiate(_deathParticle, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}