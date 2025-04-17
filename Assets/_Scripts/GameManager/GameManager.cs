using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.UIElements;
using System;
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

        public void StartLevel(LevelDataSO levelData){
            LevelManager.Instance.GetLevelData(levelData);
            StateMachine.ChoseNextState(GameflowSM.EGameState.FindPlanePhase);
        }

        public void BackToMainMenu(){
            StateMachine.ChoseNextState(GameflowSM.EGameState.WaitingPhase);
        }

        public void RestartLevel(){
            StateMachine.ChoseNextState(GameflowSM.EGameState.FindPlanePhase);
        }
    }
}
