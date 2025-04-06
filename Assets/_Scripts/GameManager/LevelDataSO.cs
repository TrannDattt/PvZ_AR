using PlantsZombiesAR.Zombies;
using System;
using System.Collections.Generic;
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

        [Header("Enviroment")]
        //TODO: Add level type for different background
        //public 

        [Header("Shop Info")]
        public int StartSun;

        [Header("Zombie Info")]
        public List<ZombieType> Zombies;
    }
}
