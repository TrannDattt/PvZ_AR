using PlantsZombiesAR.Enums;
using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.Plants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Gameplays
{
    public class PlantPooling : Singleton<PlantPooling>
    {
        [SerializeField] private PlantController _peashooterPreb;
        [SerializeField] private PlantController _sunflowerPreb;

        private Queue<PlantController> _peashooterQueue = new();
        private Queue<PlantController> _sunflowerQueue = new();

        public PlantController SpawnPlant(EPlant plant, Vector3 spawnPos)
        {
            switch (plant)
            {
                case EPlant.Peashooter:
                    return GetPlantFromPool(_peashooterPreb, _peashooterQueue, spawnPos);

                case EPlant.Sunflower:
                    return GetPlantFromPool(_sunflowerPreb, _sunflowerQueue, spawnPos);

                default:
                    return null;
            }
        }

        public void RemovePlant(PlantController plant)
        {
            switch (plant.Stat.PlantType)
            {
                case EPlant.Peashooter:
                    _peashooterQueue.Enqueue(plant);
                    break;

                case EPlant.Sunflower:
                    _sunflowerQueue.Enqueue(plant);
                    break;

                default:
                    break;
            }
        }

        private PlantController GetPlantFromPool(PlantController plantPreb, Queue<PlantController> plantQueue, Vector3 spawnPos)
        {
            if(plantQueue.Count == 0)
            {
                var newPlant = Instantiate(plantPreb, spawnPos, Quaternion.identity);
                newPlant.Init();
                return newPlant;
            }

            var spawnPlant = plantQueue.Dequeue();
            spawnPlant.Init();
            spawnPlant.transform.position = spawnPos;
            return spawnPlant;
        }
    }
}
