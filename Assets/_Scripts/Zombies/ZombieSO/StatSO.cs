using PlantsZombiesAR.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Zombies
{
    [CreateAssetMenu(menuName = "ScriptableObject/Zombie/Stat")]
    public class StatSO : ScriptableObject
    {
        public int Health;
        public float Speed;
        public EZombie ZombieType;
    }
}
