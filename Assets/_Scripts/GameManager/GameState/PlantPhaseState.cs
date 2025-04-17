using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.UIElements;
using UnityEngine;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class PlantPhaseState : BaseGameState
    {
        private SunGenerator _sunGenerator;
        private ProgressSlider _progressSlider = ProgressSlider.Instance;
        private ZombieSpawner _zombieSpawner = ZombieSpawner.Instance;
        private ShopManager _shopManager => ShopManager.Instance;
        private GroundManager _groundManager => GroundManager.Instance;

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

            PlantPooling.Instance.InitPool();
            ZombiePooling.Instance.InitPool();
            ProjectilePooling.Instance.InitPool();

            _shopManager.gameObject.SetActive(true);
            _shopManager.InitShop(LevelManager.Instance.CurLevel);

            _sunGenerator = SunGenerator.Instance;
            _sunGenerator.StartGenerate();

            _zombieSpawner.InitSpawner(LevelManager.Instance.CurLevel);
            _zombieSpawner.StartSpawn();

            ZombieDiedCounter.ResetCounter();

            _progressSlider.InitSlider();
        }

        public override void Exit()
        {
            base.Exit();

            _shopManager.gameObject.SetActive(false);
            _sunGenerator.StopGenerate();
            _zombieSpawner.StopSpawn();
            _progressSlider.DeactivateSlider();
            _groundManager.DeactivePlane();

            Time.timeScale = 0;
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EGameState GetNextState()
        {
            if (ZombieDiedCounter.Count == _zombieSpawner.ZombieToSpawn)
            {
                return EGameState.LevelLosePhase;
            }

            return base.GetNextState();
        }
    }
}
