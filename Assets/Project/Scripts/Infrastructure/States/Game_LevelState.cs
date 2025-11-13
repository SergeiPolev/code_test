using Infrastructure.Services;
using Infrastructure.Services.Gameplay;
using Infrastructure.StateMachine;
using StateMachine_IState = Infrastructure.StateMachine.IState;

namespace Infrastructure.States
{
    internal class Game_LevelState : StateMachine_IState, ITick, IFixedTick, ILateTick
    {
        private LevelStateMachine _lvlStageMachine;

        public Game_LevelState(IGameStateChanger stateChanger, AllServices services)
        {
            _lvlStageMachine = new LevelStateMachine(stateChanger, services);
            services.Single<ResultService>().SetLevelStateChanger(_lvlStageMachine);
        }

        public void Enter()
        {
            _lvlStageMachine.Enter<Level_InitLevelState>();
        }
        public void Exit()
        {
            _lvlStageMachine.Enter<Level_CleanUpState>();            
        }
        
        public void Tick()
        {
            _lvlStageMachine.Tick();
        }

        public void FixedTick()
        {
            _lvlStageMachine.FixedTick();
        }

        public void LateTick()
        {
            _lvlStageMachine.LateTick();
        }
    }
}