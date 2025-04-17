using PlantsZombiesAR.Enums;
using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.Plants;
using PlantsZombiesAR.Projectiles;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Gameplays
{
    public class ProjectilePooling : Singleton<ProjectilePooling>
    {
        [SerializeField] private ProjectileController _peaPreb;
        [SerializeField] private ProjectileController _sunPreb;
        [SerializeField] private ProjectileController _explosionPreb;
        [SerializeField] private Transform _spawnedProjectilePos;

        private Queue<ProjectileController> _peaQueue = new();
        private Queue<ProjectileController> _sunQueue = new();
        private Queue<ProjectileController> _explosionQueue = new();

        public void InitPool(){
            _peaQueue.Clear();
            _sunQueue.Clear();
            _explosionQueue.Clear();
        }

        public ProjectileController SpawnProjectile(EProjectile projectile, Vector3 spawnPos, Vector3 velocity)
        {
            switch (projectile)
            {
                case EProjectile.Pea:
                    return GetProjectileFromPool(_peaPreb, _peaQueue, spawnPos, velocity);

                case EProjectile.Sun:
                    return GetProjectileFromPool(_sunPreb, _sunQueue, spawnPos, velocity);

                default:
                    return null;
            }
        }

        public ProjectileController SpawnExplosion(EProjectile projectile, Vector3 spawnPos, Vector3 rangeMult){
            switch(projectile){
                case EProjectile.Explosion:
                    return GetExplosionFromPool(_explosionPreb, _explosionQueue, spawnPos, rangeMult);

                default:
                    return null;
            }
        }

        public void RemoveProjectile(ProjectileController projectile)
        {
            switch (projectile.ProjectileType)
            {
                case EProjectile.Pea:
                    _peaQueue.Enqueue(projectile);
                    break;

                case EProjectile.Sun:
                    _sunQueue.Enqueue(projectile);
                    break;

                default:
                    break;
            }
        }

        private ProjectileController GetProjectileFromPool(ProjectileController projectilePreb, Queue<ProjectileController> projectileQueue, Vector3 spawnPos, Vector3 velocity)
        {
            if (projectileQueue.Count == 0)
            {
                var newProjectile = Instantiate(projectilePreb, spawnPos, Quaternion.identity);
                newProjectile.Init();
                newProjectile.transform.SetParent(_spawnedProjectilePos);
                newProjectile.Rigidbody.velocity = velocity;
                return newProjectile;
            }

            var spawnProjectile = projectileQueue.Dequeue();
            spawnProjectile.Init();
            spawnProjectile.transform.position = spawnPos;
            spawnProjectile.Rigidbody.velocity = velocity;
            return spawnProjectile;
        }

        private ProjectileController GetExplosionFromPool(ProjectileController explosionPreb, Queue<ProjectileController> explosionQueue, Vector3 spawnPos, Vector3 rangeMult){
            if (explosionQueue.Count == 0)
            {
                var newExplosion = Instantiate(explosionPreb, spawnPos, Quaternion.identity);
                newExplosion.Init();
                newExplosion.transform.SetParent(_spawnedProjectilePos);
                newExplosion.transform.localScale = rangeMult;
                return newExplosion;
            }

            var spawnExplosion = explosionQueue.Dequeue();
            spawnExplosion.Init();
            spawnExplosion.transform.position = spawnPos;
            spawnExplosion.transform.localScale = rangeMult;

            return spawnExplosion;
        }
    }
}
