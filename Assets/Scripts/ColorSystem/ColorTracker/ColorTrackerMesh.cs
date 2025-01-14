using UnityEngine;

namespace ColorSystem.ColorTracker
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ColorTrackerMesh : ColorTracker
    {
        private MeshRenderer _meshRenderer;

        protected override void SetTracker()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            Material material = _meshRenderer.material;
            ColorData.ColorChanged += (color) => SetMaterialColor(material, color);
        }
        
        private void SetMaterialColor(Material material, Color color)
        {
            material.SetColor("_Color", AdjustColor(color));
        }
    }
}