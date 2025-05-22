using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.Enums;
using UnityEngine;

namespace PlantsZombiesAR.GameManager
{
    public class GameManager : Singleton<GameManager>
    {
        [field: SerializeField] public GameflowSM StateMachine { get; private set; }

        private void Start()
        {
            StateMachine.Init();
        }

        private void StartLevel(ELevelType levelType)
        {
            LevelManager.Instance.GetLevelData(levelType);
            StateMachine.ChoseNextState(GameflowSM.EGameState.FindPlanePhase);
        }

        public void StartTestLevel()
        {
            StartLevel(ELevelType.Test);
        }

        public void StartDayTimeLevel()
        {
            StartLevel(ELevelType.DayTime);
        }

        public void BackToMainMenu()
        {
            StateMachine.ChoseNextState(GameflowSM.EGameState.WaitingPhase);
        }

        public void RestartLevel()
        {
            StateMachine.ChoseNextState(GameflowSM.EGameState.FindPlanePhase);
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }
        
        public void ResumeGame()
        {
            Time.timeScale = 1;
        }
    }
}
