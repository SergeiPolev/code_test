using StateMachine;
using Services;

namespace Infrastructure
{
    public class Level_CleanUpState : IState
    {
        private IStateChanger _stateChanger;
        private WindowService _windowService;
        private IHexGridService _gridService;
        private ResultService _resultService;
        private HexPilesService _pilesService;

        public Level_CleanUpState(IStateChanger stateChanger, IGameStateChanger gameStateChanger, AllServices services)
        {
            _stateChanger = stateChanger;
            _windowService = services.Single<WindowService>();
            _gridService = services.Single<IHexGridService>();
            _resultService = services.Single<ResultService>();
            _pilesService = services.Single<HexPilesService>();
        }
        public void Enter()
        {
            _windowService.Close(WindowId.HUD);
            
            _resultService.OnLevelExit();
            _gridService.CleanUpGrid();
            _pilesService.ClearPiles();
        }

        public void Exit()
        {
        }
    }
}