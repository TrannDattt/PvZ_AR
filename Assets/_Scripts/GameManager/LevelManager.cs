using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Helpers;
using UnityEngine.Events;

namespace PlantsZombiesAR.GameManager
{
    public class LevelManager : Singleton<LevelManager>
    {
        public LevelDataSO CurLevel { get; private set; }

        public void GetLevelData(LevelDataSO levelData)
        {
            CurLevel = levelData;
        }
    }
}
