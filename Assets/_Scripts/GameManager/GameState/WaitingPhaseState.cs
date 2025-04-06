using PlantsZombiesAR.UIElements;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class WaitingPhaseState : BaseGameState
    {
        private StartMenu _startMenu => StartMenu.Instance;

        public WaitingPhaseState(EGameState stateKey) : base(stateKey)
        {
        }

        public override void Do()
        {
            base.Do();
        }

        public override void Enter()
        {
            base.Enter();

            _startMenu.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();

            _startMenu.gameObject.SetActive(false);
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EGameState GetNextState()
        {
            if (_isFinished)
            {
                return EGameState.FindPlanePhase;
            }

            return base.GetNextState();
        }
    }
}
