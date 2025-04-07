using PlantsZombiesAR.GameManager;
using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.Zombies;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Gameplays
{
    public class ZombieSpawner : Singleton<ZombieSpawner>
    {
        [SerializeField] private float _delayTime;
        [SerializeField] private float _intervalTime;
        [SerializeField] private Vector3 _spawnOffset = Vector3.forward;

        public int ZombieToSpawn { get; private set; }
        public int ZombieSpawned { get; private set; }

        private List<Transform> _spawnPosList = new();
        private List<StatSO> _zombieList = new();

        public void InitSpawner(LevelDataSO levelData)
        {
            _spawnPosList.Clear();
            foreach (Transform transform in GroundManager.Instance.Ground.transform.Find("PlantPos").transform)
            {
                _spawnPosList.Add(transform);
            }

            _zombieList.Clear();
            foreach (var zombieType in levelData.Zombies)
            {
                for (int i = 0; i < zombieType.Count; i++)
                {
                    _zombieList.Add(zombieType.ZombieData);
                }
            }
            ZombieToSpawn = _zombieList.Count;
            ZombieSpawned = 0;
        }

        //public void InitSpawner()
        //{
        //    _spawnPosList.Clear();
        //    foreach (Transform transform in GroundManager.Instance.Ground.transform.Find("PlantPos").transform)
        //    {
        //        _spawnPosList.Add(transform);
        //    }

        //    _zombieList.Clear();
        //    foreach (var zombieType in testLevel.Zombies)
        //    {
        //        for (int i = 0; i < zombieType.Count; i++)
        //        {
        //            _zombieList.Add(zombieType.ZombieData);
        //        }
        //    }

        //    ZombieToSpawn = _zombieList.Count;
        //    ZombieSpawned = 0;
        //}

        private void Spawn()
        {
            if(_zombieList.Count > 0)
            {
                var spawnIndex = Random.Range(0, _spawnPosList.Count);
                var spawnPos = _spawnPosList[spawnIndex].position + _spawnOffset;

                var zombieIndex = Random.Range(0, _zombieList.Count);
                ZombiePooling.Instance.SpawnZombie(_zombieList[zombieIndex].ZombieType, spawnPos);
                ZombieSpawned++;

                _zombieList.RemoveAt(zombieIndex);
            }
        }

        public void StartSpawn()
        {
            InvokeRepeating(nameof(Spawn), _delayTime, _intervalTime);
        }

        public void StopSpawn()
        {
            CancelInvoke(nameof(Spawn));
        }
    }
}
