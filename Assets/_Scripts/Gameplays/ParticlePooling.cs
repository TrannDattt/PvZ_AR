using PlantsZombiesAR.Enums;
using PlantsZombiesAR.Helpers;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Gameplays
{
    public class ParticlePooling : Singleton<ParticlePooling>
    {
        [SerializeField] private ParticleSystem _explodePreb;
        [SerializeField] private ParticleSystem _zomAttackPreb;
        [SerializeField] private ParticleSystem _peaAttackPreb;
        [SerializeField] private Transform _spawnedParticlePos;

        private Queue<ParticleSystem> _explodeQueue = new();
        private Queue<ParticleSystem> _zomAttackQueue = new();
        private Queue<ParticleSystem> _peaAttackQueue = new();

        public void InitPool(){
            _explodeQueue.Clear();
            _zomAttackQueue.Clear();
            _peaAttackQueue.Clear();
        }

        public ParticleSystem SpawnParticle(EParticle particleType, Transform spawnPos){
            switch(particleType){
                case EParticle.Explode:
                    return SpawnParticleInPool(_explodePreb, _explodeQueue, spawnPos);

                case EParticle.ZomAttack:
                    return SpawnParticleInPool(_zomAttackPreb, _zomAttackQueue, spawnPos);

                case EParticle.PeaAttack:
                    return SpawnParticleInPool(_peaAttackPreb, _peaAttackQueue, spawnPos);

                default:
                    return null;
            }
        }

        private ParticleSystem SpawnParticleInPool(ParticleSystem particlePreb, Queue<ParticleSystem> particleQueue, Transform spawnPos){
            if (particleQueue.Count == 0)
            {
                var newParticle = Instantiate(particlePreb, spawnPos);
                newParticle.transform.SetParent(_spawnedParticlePos);
                return newParticle;
            }

            var spawnParticle = particleQueue.Dequeue();
            spawnParticle.transform.position = spawnPos.position;
            spawnParticle.gameObject.SetActive(true);
            return spawnParticle;
        }

        public void RemoveParticle(ParticleSystem particle, EParticle particleType){
            switch(particleType){
                case EParticle.Explode:
                    _explodeQueue.Enqueue(particle);
                    break;

                case EParticle.ZomAttack:
                    _zomAttackQueue.Enqueue(particle);
                    break;

                case EParticle.PeaAttack:
                    _peaAttackQueue.Enqueue(particle);
                    break;
            }
        }
    }
}
