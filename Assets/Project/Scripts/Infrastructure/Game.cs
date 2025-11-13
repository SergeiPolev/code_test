using UnityEngine;
using Services;

namespace Infrastructure
{
    public class Game : MonoBehaviour, ICoroutineRunner
    {        
        private GameStateMachine _stateMachine;
        public GameStateMachine StateMachine => _stateMachine;

        private void Awake()
        {
            SetScreenSleep();
            SetStateMachine();
        }

        private void Update()
        {
            _stateMachine.Tick();
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedTick();
        }

        private void SetScreenSleep()
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        private void SetStateMachine()
        {
            _stateMachine = new GameStateMachine(AllServices.Container, this, this);
            _stateMachine.Enter<BootstrapState>();
        }

        private void OnApplicationQuit()
        {
            _stateMachine.Enter<Game_AppQuit_State>();
        }
    }
}