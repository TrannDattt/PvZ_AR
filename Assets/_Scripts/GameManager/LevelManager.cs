using System.Collections.Generic;
using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.Enums;
using UnityEngine;
using System.Linq;

namespace PlantsZombiesAR.GameManager
{
    public class LevelManager : Singleton<LevelManager>
    {
        public LevelDataSO CurLevel { get; private set; }

        private const string PATH_TO_LEVEL_FOLDER = "LevelDataSO";

        private Queue<LevelDataSO> _testLevel = new();
        private Queue<LevelDataSO> _dayTimeLevel = new();

        public void GetLevelData(ELevelType levelType)
        {
            switch(levelType){
                case ELevelType.Test:
                    if (_testLevel.Count == 0) return;
                    CurLevel = _testLevel.Dequeue();
                    break;

                case ELevelType.DayTime:
                    if (_dayTimeLevel.Count == 0) return;
                    CurLevel = _dayTimeLevel.Dequeue();
                    break;

                default:
                    Debug.LogError($"Level type {levelType} not found!");
                    return;
            }
        }

        public void LoadLevel(){
            if (CurLevel == null) return;
        }

        // TODO: Make a function to navigate through levels

        void Start()
        {
            Resources.LoadAll<LevelDataSO>($"{PATH_TO_LEVEL_FOLDER}/Test")
                .Where(level => !level.IsFinished)
                .ToList()
                .ForEach(level => _testLevel.Enqueue(level));

            Resources.LoadAll<LevelDataSO>($"{PATH_TO_LEVEL_FOLDER}/DayTime")
                .Where(level => !level.IsFinished)
                .ToList()
                .ForEach(level => _dayTimeLevel.Enqueue(level));
        }
    }
}
