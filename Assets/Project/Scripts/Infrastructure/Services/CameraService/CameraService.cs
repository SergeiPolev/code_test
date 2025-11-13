using System;
using DG.Tweening;
using Infrastructure;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services
{
    public class CameraService : IService
    {
        private Camera _mainCamera;
        private CameraGroup _cameraGroup;
        private IHexGridService _hexGridService;

        public CameraGroup CameraGroup => _cameraGroup;
        public Camera Camera => _mainCamera;
        
        public void Initialize(IHexGridService hexGridService)
        {
            _hexGridService = hexGridService;
            _cameraGroup = Object.FindObjectOfType<CameraGroup>();
            _mainCamera = Camera.main;
            //SetWidth(10f);
        }

        public void SetFollow(GameObject follow)
        {
            _cameraGroup.VirtualCamera.Follow = follow.transform;
            _cameraGroup.VirtualCamera.LookAt = follow.transform;
        }
        
        // For portrait mobile
        public void SetWidth(float width)
        {
            _mainCamera.ResetAspect();
            float _1OverAspect = 1f / _mainCamera.aspect;
            var finalValue = width * .5f * _1OverAspect;
            _cameraGroup.VirtualCamera.Lens.OrthographicSize = finalValue;
        }

        public void NextStage(Action stageMoved)
        {
            _cameraGroup.transform.DOMoveY(-40f,2f).SetRelative().OnComplete(stageMoved.Invoke);
        }

        public void SetCenterPos()
        {
            Vector3 gridCenter = _hexGridService.GetGridCenterPos();
            var delta = gridCenter - _cameraGroup.TargetPoint.position;
            
            _cameraGroup.TargetPoint.position = gridCenter;
            _cameraGroup.VirtualCamera.OnTargetObjectWarped(_cameraGroup.TargetPoint, delta);
        }
    }
}