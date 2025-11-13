using Cysharp.Threading.Tasks;
using StateMachine;
using Services;
using UnityEngine;

namespace Infrastructure
{
    public class Level_InitLevelState : IState
    {
        private IStateChanger _stateChanger;
        private readonly IGameStateChanger _gameStateChanger;
        private WindowService _windowService;
        private LevelProgressService _levelProgress;
        private GameWalletService _wallet;
        private IHexGridService _hexGridService;
        private CameraService _cameraService;
        private CancellationAsyncService _cancellationAsyncService;
        private ResultService _resultService;

        public Level_InitLevelState(IStateChanger stateChanger, IGameStateChanger gameStateChanger, AllServices services)
        {
            _stateChanger = stateChanger;
            this._gameStateChanger = gameStateChanger;
            _windowService = services.Single<WindowService>();
            _levelProgress = services.Single<LevelProgressService>();
            _wallet = services.Single<GameWalletService>();
            _hexGridService = services.Single<IHexGridService>();
            _cameraService = services.Single<CameraService>();
            _cancellationAsyncService = services.Single<CancellationAsyncService>();
            _resultService = services.Single<ResultService>();
        }
        public async void Enter()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;
            
            _levelProgress.LevelStarted();
            _windowService.Open(WindowId.LoadingScreen);
            
            _hexGridService.CreateGrid();
            _cameraService.SetCenterPos();
            _resultService.OnLevelEnter();

            await UniTask.WaitForEndOfFrame(_cancellationAsyncService.Token);
            
            _stateChanger.Enter<Level_StartLevelState>();
        }
        
        public void Exit()
        {
            _windowService.Close(WindowId.LoadingScreen);
        }
    }
}