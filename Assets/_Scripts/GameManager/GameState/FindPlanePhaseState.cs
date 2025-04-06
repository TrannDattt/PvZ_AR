using PlantsZombiesAR.UIElements;
using UnityEngine;

namespace PlantsZombiesAR.GameManager
{
    public class FindPlanePhaseState : BaseGameState
    {
        private FindPlanePanel _findPlanePanel = FindPlanePanel.Instance;
        private GroundManager _groundManager = GroundManager.Instance;

        private bool _foundPlane;

        public FindPlanePhaseState(GameflowSM.EGameState stateKey) : base(stateKey)
        {
        }

        public override void Do()
        {
            base.Do();

            if (_groundManager.Ground != null && !_foundPlane)
            {
                _foundPlane = true;
                _findPlanePanel.FinishFindPlane();
                _groundManager.ActivePlane();
            }
        }

        public override void Enter()
        {
            base.Enter();

            _foundPlane = false;
            _findPlanePanel.gameObject.SetActive(true);
            _findPlanePanel.StartFindPlane();
        }

        public override void Exit()
        {
            base.Exit();

            _findPlanePanel.gameObject.SetActive(false);
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override GameflowSM.EGameState GetNextState()
        {
            if (_isFinished)
            {
                return GameflowSM.EGameState.SelectPhase;
            }

            return base.GetNextState();
        }
    }
}
