using PlantsZombiesAR.Enums;
using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.Zombies;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Gameplays
{
    public class ZombiePooling : Singleton<ZombiePooling>
    {
        [SerializeField] private ZombieController _norZomPreb;
        [SerializeField] private Transform _spawnedZombiePos;

        private Queue<ZombieController> _norZomQueue = new();

        public void InitPool(){
            _norZomQueue.Clear();
        }

        public ZombieController SpawnZombie(EZombie zombie, Vector3 spawnPos)
        {
            switch (zombie)
            {
                case EZombie.NorZomb:
                    return GetZombieFromPool(_norZomPreb, _norZomQueue, spawnPos);

                default:
                    return null;
            }
        }

        public void RemoveZombie(ZombieController zommbie)
        {
            switch (zommbie.Stat.ZombieType)
            {
                case EZombie.NorZomb:
                    _norZomQueue.Enqueue(zommbie);
                    break;

                default:
                    break;
            }
        }

        private ZombieController GetZombieFromPool(ZombieController zombiePreb, Queue<ZombieController> zombieQueue, Vector3 spawnPos)
        {
            if (zombieQueue.Count == 0)
            {
                var newZombie = Instantiate(zombiePreb, spawnPos, Quaternion.identity);
                newZombie.Init();
                newZombie.transform.SetParent(_spawnedZombiePos);
                return newZombie;
            }

            var spawnedZombie = zombieQueue.Dequeue();
            spawnedZombie.Init();
            spawnedZombie.transform.position = spawnPos;
            return spawnedZombie;
        }
    }
}
