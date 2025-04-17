using PlantsZombiesAR.UIElements;
using UnityEngine;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class LevelLosePhaseState : BaseGameState
    {
        private LevelLoseMenu _loseMenu = LevelLoseMenu.Instance;

        public LevelLosePhaseState(EGameState stateKey) : base(stateKey)
        {
        }

        public override void Do()
        {
            base.Do();
        }

        public override void Enter()
        {
            base.Enter();

            _loseMenu.InitMenu();
            _loseMenu.MenuEnter();
        }

        public override void Exit()
        {
            base.Exit();

            Time.timeScale = 1;

            _loseMenu.MenuExit();
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EGameState GetNextState()
        {
            // if(_isFinished){
            //     return _nextState;
            // }

            return base.GetNextState();
        }
    }
}
