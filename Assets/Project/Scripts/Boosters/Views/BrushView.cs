using System.Collections.Generic;
using DG.Tweening;
using NUnit.Framework;
using UnityEngine;

public class BrushView : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private int _inkIndex = 2;
    [SerializeField] private ParticleSystem _inkVFX;

    private List<Material> _materialsCache = new List<Material>(3);
    
    public Tween Appear()
    {
        _meshRenderer.transform.DOScale(0, 0);
        transform.rotation = Quaternion.identity;
        _meshRenderer.transform.localPosition = Vector3.zero;

        return _meshRenderer.transform.DOScale(1, 0.25f).SetLink(gameObject);
    }
    public Tween BeginColoring(Vector3 position, Color color)
    {
        ParticleSystem.MainModule mainModule = _inkVFX.main;
        mainModule.startColor = color;
        
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOMove(position + Vector3.up, 0.4f));
        sequence.Join(_meshRenderer.transform.DOLocalMoveX(1, 0.4f).SetRelative());
        sequence.AppendCallback(_inkVFX.Play);
        
        return sequence.Play().SetLink(gameObject);
    }

    public void SetInkMaterial(Material material)
    {
        _meshRenderer.GetSharedMaterials(_materialsCache);
        _materialsCache[_inkIndex] = material;
        _meshRenderer.SetSharedMaterials(_materialsCache);
    }

    public Tween EndColoring()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DORotate(Vector3.up * 360, 1f, RotateMode.WorldAxisAdd));
        sequence.Append(_meshRenderer.transform.DOScale(0, 0.3f));
        sequence.AppendCallback(_inkVFX.Stop);
        
        return sequence.Play().SetLink(gameObject);
    }
}