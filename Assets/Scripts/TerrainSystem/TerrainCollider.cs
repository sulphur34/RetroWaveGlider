using UnityEngine;

namespace Assets.Scripts.TerrainSystem
{
    [RequireComponent(typeof(EdgeCollider2D))]
    [RequireComponent(typeof(TerrainMesh))]
    public class TerrainCollider : MonoBehaviour
    {
        private TerrainMesh _terrainMesh;
        private EdgeCollider2D _edgeCollider;

        private void Awake()
        {
            _terrainMesh = GetComponent<TerrainMesh>();
            _edgeCollider = GetComponent<EdgeCollider2D>();
            _terrainMesh.TerrainChanged += BuildCollider;
        }

        private void BuildCollider(Vector2[] surface)
        {
            _edgeCollider.points = surface;
        }
    }
}
