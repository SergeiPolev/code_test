using StateMachine;
using Services;
using Data;

namespace Infrastructure
{
    internal class Game_InitializeState : IState
    {
        private SaveLoadService _saveLoadService;
        private IGameStateChanger _stateChanger;
        private WindowService _windowService;
        private ColorMaterialsService _colorMaterialsService;

        public Game_InitializeState(IGameStateChanger stateChanger, AllServices services) 
        {
            _stateChanger = stateChanger;
            _saveLoadService = services.Single<SaveLoadService>();
            _windowService = services.Single<WindowService>();
            _colorMaterialsService = services.Single<ColorMaterialsService>();
        }

        public void Enter()
        {
            _saveLoadService.LoadProgressAndInformReaders();
            _colorMaterialsService.UpdateColors();
            
            SetState();

#if DEBUG
            //_windowService.Open(WindowId.DEBUG);
#endif
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