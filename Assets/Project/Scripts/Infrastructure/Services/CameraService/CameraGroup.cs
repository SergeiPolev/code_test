using Unity.Cinemachine;
using UnityEngine;

public class CameraGroup : MonoBehaviour
{
    [SerializeField] private CinemachineCamera _virtualCamera;
    [SerializeField] private Transform[] _pilePoints;
    [SerializeField] private Transform _pilePointsRoot;
    [SerializeField] private Transform _targetPoint;
    
    public Transform[] PilePoints => _pilePoints;
    public Transform TargetPoint => _targetPoint;
    public Transform PilePointsRoot => _pilePointsRoot;
    public CinemachineCamera VirtualCamera => _virtualCamera;

    private Camera _camera;
    
    private void OnEnable()
    {
        _camera = Camera.main;
    }
}