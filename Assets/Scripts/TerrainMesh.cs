using UnityEngine;

[RequireComponent (typeof(MeshFilter))]
public class TerrainMesh : MonoBehaviour
{
    private Mesh _mesh;
    private MeshFilter _meshFilter;

    private void Start()
    {
        _mesh = new Mesh();
        Vector3[] verticies = new Vector3[3];
        Vector2[] uv = new Vector2[3];
        int[] triangles = new int[3];

        _mesh.vertices = verticies;
        _mesh.uv = uv;
        _mesh.triangles = triangles;

    }
    
}
