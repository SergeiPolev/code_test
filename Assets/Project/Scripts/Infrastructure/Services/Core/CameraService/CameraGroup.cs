using Unity.Cinemachine;
using UnityEngine;

namespace Infrastructure.Services.Core
{
    public class CameraGroup : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera _virtualCamera;
        [SerializeField] private Transform[] _pilePoints;
        [SerializeField] private Transform _targetPoint;
    
        public Transform[] PilePoints => _pilePoints;
        public Transform TargetPoint => _targetPoint;
        public CinemachineCamera VirtualCamera => _virtualCamera;
    }
}