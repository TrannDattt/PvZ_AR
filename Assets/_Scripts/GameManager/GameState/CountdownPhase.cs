using PlantsZombiesAR.UIElements;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class CountdownPhase : BaseGameState
    {
        private ShopManager _shopManager => ShopManager.Instance;
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

            _shopManager.gameObject.SetActive(true);
            _shopManager.InitShop(LevelManager.Instance.CurLevel);

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
