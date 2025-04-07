using PlantsZombiesAR.Gameplays;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class PlantPhaseState : BaseGameState
    {
        private SunGenerator _sunGenerator;
        private ZombieSpawner _zombieSpawner = ZombieSpawner.Instance;

        public PlantPhaseState(EGameState stateKey) : base(stateKey)
        {
        }

        public override void Do()
        {
            base.Do();
        }

        public override void Enter()
        {
            base.Enter();

            _sunGenerator = SunGenerator.Instance;
            _sunGenerator.StartGenerate();

            _zombieSpawner.InitSpawner(LevelManager.Instance.CurLevel);
            _zombieSpawner.StartSpawn();
        }

        public override void Exit()
        {
            base.Exit();

            _sunGenerator.StopGenerate();
            _zombieSpawner.StopSpawn();
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
