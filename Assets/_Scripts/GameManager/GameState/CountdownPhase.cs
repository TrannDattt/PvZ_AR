using PlantsZombiesAR.UIElements;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class CountdownPhase : BaseGameState
    {
        private TimeCounter _timeCounter => TimeCounter.Instance;

        public CountdownPhase(EGameState stateKey) : base(stateKey)
        {
        }

        public override void Do()
        {
            base.Do();
        }

        public override void Enter()
        {
            base.Enter();

            _timeCounter.gameObject.SetActive(true);
            _timeCounter.InitTimer(3);
            _timeCounter.StartTimer();
        }

        public override void Exit()
        {
            base.Exit();

            _timeCounter.gameObject.SetActive(false);
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EGameState GetNextState()
        {
            if (_isFinished)
            {
                return EGameState.PlantPhase;
            }

            return base.GetNextState();
        }
    }
}
