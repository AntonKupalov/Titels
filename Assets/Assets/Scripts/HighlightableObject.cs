using UnityEngine;

/// <summary>
/// Скрипт подсвечиваемого тайла
/// </summary>
public class HighlightableObject : MonoBehaviour
{
    [SerializeField]
    private Color _highlightColor;
    private Material _material;

    private void Awake()
    {
        var meshRenderer = GetComponent<MeshRenderer>();
        _material = meshRenderer.material;
    }

    public void Highlight()
    {
        _material.color = _highlightColor;
    }

    public void ResetColor()
    {
        _material.color = Color.white;
    }
}