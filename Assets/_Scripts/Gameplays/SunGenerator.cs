using PlantsZombiesAR.Helpers;
using UnityEngine;

namespace PlantsZombiesAR.Gameplays
{
    public class SunGenerator : Singleton<SunGenerator>
    {
        [SerializeField] private Collider _spawnRange;
        [SerializeField] private float _delayTime;
        [SerializeField] private float _intervalTime;

        private void Generate()
        {
            var spawnPosY = _spawnRange.bounds.max.y;
            var spawnPosX = Random.Range(_spawnRange.bounds.min.x, _spawnRange.bounds.max.x);
            var spawnPosZ = Random.Range(_spawnRange.bounds.min.z, _spawnRange.bounds.max.z);

            ProjectilePooling.Instance.SpawnProjectile(Enums.EProjectile.Sun, new(spawnPosX, spawnPosY, spawnPosZ), Vector3.zero);
        }

        public void StartGenerate()
        {
            InvokeRepeating(nameof(Generate), _delayTime, _intervalTime);
        }

        public void StopGenerate()
        {
            CancelInvoke(nameof(Generate));
        }
    }
}
