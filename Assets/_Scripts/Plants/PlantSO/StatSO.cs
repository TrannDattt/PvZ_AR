using PlantsZombiesAR.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlantsZombiesAR.Plants
{
    [CreateAssetMenu(menuName = "ScriptableObject/PlantData/Stat")]
    public class StatSO : ScriptableObject
    {
        public int Health;
        public EPlant PlantType;
    }
}
