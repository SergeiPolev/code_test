using StateMachine;
using Services;

namespace Infrastructure
{
    internal class Game_LoadLevelState : IState
    {
        private IGameStateChanger _stateChanger;
        private LevelProgressService _levelProgress;
        private GameWalletService _wallet;
        private GoogleSheetService _googleSheetService;

        public Game_LoadLevelState(IGameStateChanger stateChanger, AllServices services) 
        {
            _stateChanger = stateChanger;
            _levelProgress = services.Single<LevelProgressService>();
            _wallet = services.Single<GameWalletService>();
            _googleSheetService = services.Single<GoogleSheetService>();
        }

        public void Enter()
        {
            _wallet.LoadLevel();
            _stateChanger.Enter<Game_LevelState>();
        }

        public void Exit()
        {

        }

    }
}