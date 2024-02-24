using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TerrainMesh : MonoBehaviour
{
    private Mesh _mesh;
    private MeshFilter _meshFilter;
    private Vector3[] _verticies;
    private int[] _triangles;
    private Vector2[] _uv;
    [SerializeField] private int _xSize;
    [SerializeField] private int _ySize;
    [SerializeField] private float _xStart;
    [SerializeField] private float _yStart;
    [SerializeField] private float _xDelta;
    [SerializeField] private CameraData _cameraData;

    private List<TextMesh> _textMeshes = new List<TextMesh>();

    private void Awake()
    {
        _meshFilter = GetComponent<MeshFilter>();
        _mesh = new Mesh();
        _xStart = _cameraData.LeftBorder;
        _yStart = _cameraData.LowerBorder;
    }

    private void Start()
    {
        CreateQuads();
        _mesh.vertices = _verticies;
        _mesh.triangles = _triangles;
        _meshFilter.mesh = _mesh;
    }

    private void Update()
    {       
        if (_cameraData.LeftBorder - 1 > _verticies.First().x)
        {
            Vector3 lastVertice = _verticies.Last();
            float yPosition = Mathf.Clamp(lastVertice.y + Random.Range(-0.5f, 0.5f), -3, 0);


            Vector3 verticie1 = new Vector3(lastVertice.x + _xDelta, _yStart);
            Vector3 verticie2 = new Vector3(lastVertice.x + _xDelta, yPosition);
            AddEdge(verticie1,verticie2);
            RemoveEdge();
        }
    }

    private void CreateQuads()
    {
        CreateVerticies();
        CreateTriangles();
    }

    private void CreateVerticies()
    {
        foreach (var text in _textMeshes)
        {
            Destroy(text.gameObject);
        }
        _textMeshes.Clear();

        _verticies = new Vector3[(_xSize + 1) * (_ySize + 1)];
        float y = _yStart;

        for (int i = 0, iy = 0; iy <= _ySize; iy++)
        {
            float x = _xStart;
            for (int ix = 0; ix <= _xSize; i++, ix++, x+=_xDelta)
            {
                _verticies[i] = new Vector2(x, y);
            }

            y += 1.5f;
        }
    }

    private void CreateTriangles()
    {
        _triangles = new int[_xSize * _ySize * 6];

        for (int ti = 0, vi = 0, iy = 0; iy < _ySize; iy++, vi++)
        {
            for (int ix = 0; ix < _xSize; ix++, ti += 6, vi++)
            {
                _triangles[ti] = vi;
                _triangles[ti + 1] = _triangles[ti + 4] = vi + _xSize + 1;
                _triangles[ti + 2] = _triangles[ti + 3] = vi + 1;
                _triangles[ti + 5] = vi + _xSize + 2;
            }
        }

        for (int i = 1; i < _triangles.Length; i++)
        {
            Debug.DrawLine(_verticies[_triangles[i-1]], _verticies[_triangles[i]]);
        }
    }

    private void AddEdge(Vector3 vertice1, Vector3 vertice2)
    {
        List<Vector3> verticies = _verticies.ToList();
        int middleIndex = (verticies.Count / 2) - 1;
        verticies.Insert(middleIndex + 1, vertice1);
        verticies.Add(vertice2);
        _verticies = verticies.ToArray();
        _xSize++;
        CreateTriangles();
        _mesh.Clear();
        _mesh.vertices = _verticies;
        _mesh.triangles = _triangles;
        _meshFilter.mesh = _mesh;
    }

    private void RemoveEdge()
    {
        List<Vector3> verticies = _verticies.ToList();
        int middleIndex = (verticies.Count / 2) - 1;
        verticies.RemoveAt(middleIndex + 1);
        verticies.RemoveAt(0);
        _verticies = verticies.ToArray();
        _xStart += _xDelta;
        _xSize--;
        CreateTriangles();
        _mesh.Clear();
        _mesh.vertices = _verticies;
        _mesh.triangles = _triangles;
    }
}
