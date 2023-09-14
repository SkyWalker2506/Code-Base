using Attribute;
using UnityEngine;

namespace ColorSystem
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ColorSetter : MonoBehaviour
    {
        private readonly int shPropColor = Shader.PropertyToID("_BaseColor");
        private MaterialPropertyBlock mpb;
        private MaterialPropertyBlock mpbGetter => mpb ??= new MaterialPropertyBlock();
        [ReadOnly] public Color color;
        private MeshRenderer meshRenderer;

        public void SetColor(Color color)
        {
            this.color = color;
            ApplyColor();
        }

        private void OnEnable()
        {
            ApplyColor();
        }

        private void OnValidate()
        {
            ApplyColor();
        }

        private void ApplyColor()
        {
            if (!meshRenderer)
            {
                meshRenderer = GetComponent<MeshRenderer>();
            }
            mpbGetter.SetColor(shPropColor, color);
            meshRenderer.SetPropertyBlock(mpbGetter);
        }
    }
}