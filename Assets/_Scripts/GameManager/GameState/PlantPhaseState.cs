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

            GameManager.Instance.ResumeGame();
        }

        public override void Exit()
        {
            base.Exit();

            _shopManager.gameObject.SetActive(false);
            _sunGenerator.StopGenerate();
            _zombieSpawner.StopSpawn();
            _progressSlider.DeactivateSlider();
            _groundManager.DeactivePlane();

            GameManager.Instance.PauseGame();
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EGameState GetNextState()
        {
            // TODO: Change to win if all zombies are dead, change to lose if zombie reached the end
            if(_groundManager.EndPosChecker.IsReached){
                return EGameState.LevelLosePhase;
            }

            if (ZombieDiedCounter.Count == _zombieSpawner.ZombieToSpawn)
            {
                return EGameState.LevelWinPhase;
            }

            return base.GetNextState();
        }
    }
}
