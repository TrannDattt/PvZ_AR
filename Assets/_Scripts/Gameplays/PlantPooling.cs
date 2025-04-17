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
        [SerializeField] private PlantController _wallnutPreb;
        [SerializeField] private PlantController _potatominePreb;

        [SerializeField] private Transform _spawnedPlantPos;

        private Queue<PlantController> _peashooterQueue = new();
        private Queue<PlantController> _sunflowerQueue = new();
        private Queue<PlantController> _wallnutQueue = new();
        private Queue<PlantController> _potatomineQueue = new();

        public void InitPool(){
            _peashooterQueue.Clear();
            _sunflowerQueue.Clear();
            _wallnutQueue.Clear();
        }

        public PlantController SpawnPlant(EPlant plant, Vector3 spawnPos)
        {
            switch (plant)
            {
                case EPlant.Peashooter:
                    return GetPlantFromPool(_peashooterPreb, _peashooterQueue, spawnPos);

                case EPlant.Sunflower:
                    return GetPlantFromPool(_sunflowerPreb, _sunflowerQueue, spawnPos);

                case EPlant.Wallnut:
                    return GetPlantFromPool(_wallnutPreb, _wallnutQueue, spawnPos);

                case EPlant.Potatomine:
                    return GetPlantFromPool(_potatominePreb, _potatomineQueue, spawnPos);

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

                case EPlant.Wallnut:
                    _wallnutQueue.Enqueue(plant);
                    break;

                case EPlant.Potatomine:
                    _potatomineQueue.Enqueue(plant);
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
                newPlant.transform.SetParent(_spawnedPlantPos);
                return newPlant;
            }

            var spawnPlant = plantQueue.Dequeue();
            spawnPlant.Init();
            spawnPlant.transform.position = spawnPos;
            return spawnPlant;
        }
    }
}
