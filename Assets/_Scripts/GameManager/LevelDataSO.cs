using PlantsZombiesAR.Zombies;
using System;
using System.Collections.Generic;
using PlantsZombiesAR.Enums;
using UnityEngine;

namespace PlantsZombiesAR.GameManager
{
    [CreateAssetMenu(menuName = "ScriptableObject/Level")]
    public class LevelDataSO : ScriptableObject
    {
        [Serializable]
        public class ZombieType
        {
            public StatSO ZombieData;
            public int Count;
        }

        [Header("Base Info")]
        public string LevelID;
        public bool IsFinished;

        [Header("Enviroment")]
        //TODO: Add level type for different background and make GroundManager change the ground model base on type
        public ELevelType LevelType;

        [Header("Shop Info")]
        public int StartSun;

        [Header("Zombie Info")]
        public List<ZombieType> Zombies;
    }
}
