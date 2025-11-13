using Infrastructure.Services;
using Infrastructure.Services.Gameplay;
using Infrastructure.StateMachine;

namespace Infrastructure.States
{
    internal class Game_InitializeState : IState
    {
        private IGameStateChanger _stateChanger;
        private ColorMaterialsService _colorMaterialsService;

        public Game_InitializeState(IGameStateChanger stateChanger, AllServices services) 
        {
            _stateChanger = stateChanger;
            _colorMaterialsService = services.Single<ColorMaterialsService>();
        }

        public void Enter()
        {
            _colorMaterialsService.UpdateColors();
            
            SetState();
        }
        
        private void SetState()
        {
            _stateChanger.Enter<Game_HubState>();
        }
        
        public void Exit()
        {

        }
    }
}