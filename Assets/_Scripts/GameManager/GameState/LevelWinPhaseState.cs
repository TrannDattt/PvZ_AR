using PlantsZombiesAR.UIElements;
using UnityEngine;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class LevelWinPhaseState : BaseGameState
    {
        private LevelWinMenu _winMenu = LevelWinMenu.Instance;

        public LevelWinPhaseState(EGameState stateKey) : base(stateKey)
        {
        }

        public override void Do()
        {
            base.Do();
        }

        public override void Enter()
        {
            base.Enter();

            _winMenu.InitMenu();
            _winMenu.MenuEnter();
        }

        public override void Exit()
        {
            base.Exit();

            Time.timeScale = 1;

            _winMenu.MenuExit();
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EGameState GetNextState()
        {
            return base.GetNextState();
        }
    }
}
