using PlantsZombiesAR.Enums;
using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Projectiles;
using SerializeReferenceEditor;
using UnityEngine;

namespace PlantsZombiesAR.Plants
{
    [SRName("PlantData Skill/Shooting")]
    public class ShootingSkill : PlantSkill
    {
        public Bullet BulletPreb;
        public Transform SpawnPos;
        public float AttackRange;

        public bool CheckInRange()
        {
            var ray = new Ray(SpawnPos.position, Vector3.forward);
            if (Physics.Raycast(ray, out _, AttackRange, LayerMask.GetMask("Zombie")))
            {
                return true;
            }

            return false;
        }

        private void SpawnProjectile()
        {
            ProjectilePooling.Instance.SpawnProjectile(BulletPreb.ProjectileType, SpawnPos.position, BulletPreb.Speed * Vector3.forward);
        }

        public override void DoSkill()
        {
            base.DoSkill();
            SpawnProjectile();
        }
    }
}
