using PlantsZombiesAR.UIElements;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class SelectPhaseState : BaseGameState
    {
        private SelectPlantMenuManager _selectPlantMenu => SelectPlantMenuManager.Instance;

        public SelectPhaseState(EGameState stateKey) : base(stateKey)
        {
        }

        public override void Do()
        {
            base.Do();
        }

        public override void Enter()
        {
            base.Enter();

            _selectPlantMenu.gameObject.SetActive(true);
            _selectPlantMenu.InitMenu();
        }

        public override void Exit()
        {
            base.Exit();

            _selectPlantMenu.gameObject.SetActive(false);
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EGameState GetNextState()
        {
            if (_isFinished)
            {
                return EGameState.CountdownPhase;
            }

            return base.GetNextState();
        }
    }
}
