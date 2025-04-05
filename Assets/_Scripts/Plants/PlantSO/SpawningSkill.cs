using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Projectiles;
using SerializeReferenceEditor;
using UnityEngine;

namespace PlantsZombiesAR.Plants
{
    [SRName("PlantData Skill/Spawning")]
    public class SpawningSkill : PlantSkill
    {
        public ProjectileController ProjectilePreb;
        public Transform SpawnPos;

        private void SpawnProjectile()
        {
            var projectile = ProjectilePooling.Instance.SpawnProjectile(ProjectilePreb.ProjectileType, SpawnPos.position, Vector3.zero);
            projectile.Rigidbody.AddForce(10 * Vector3.up);
        }

        public override void DoSkill()
        {
            base.DoSkill();
            SpawnProjectile();
        }
    }
}
