using Infrastructure.Services;
using Infrastructure.Services.Core;
using Infrastructure.Services.Gameplay;
using Infrastructure.StateMachine;
using UI;

namespace Infrastructure
{
    public class Level_LevelState : IState, ITick
    {
        private WindowService _windowService;
        private InputService _inputService;
        private HexPilesService _hexPilesService;
        private MergeService _mergeService;
        private BoosterService _boosterService;

        public Level_LevelState(AllServices services)
        {
            _windowService = services.Single<WindowService>();
            _inputService = services.Single<InputService>();
            _hexPilesService = services.Single<HexPilesService>();
            _mergeService = services.Single<MergeService>();
            _boosterService = services.Single<BoosterService>();
        }
        
        public void Enter()
        {
            _windowService.Open(WindowId.HUD);
            _hexPilesService.OnLevelEnter();
            _mergeService.OnLevelEnter();
        }

        public void Tick()
        {
            _inputService.LateTick();
            _boosterService.Tick();
        }

        public void Exit()
        {
            _boosterService.Dispose();
        }
    }
}