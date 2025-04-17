using UnityEngine;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class LevelWinPhaseState : BaseGameState
    {
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
        }

        public override void Exit()
        {
            base.Exit();

            Time.timeScale = 1;
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
