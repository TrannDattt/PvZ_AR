using PlantsZombiesAR.Enums;
using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Projectiles;
using SerializeReferenceEditor;
using UnityEngine;

namespace PlantsZombiesAR.Plants
{
    [SRName("PlantData Skill/Exploding")]
    public class ExplodingSkill : PlantSkill{
        public Transform ExplodePos;
        public EProjectile ExplosionType;
        public Vector3 RangeMult;
        public float TriggerRange;

        public override void Init()
        {
            base.Init();
        }

        public bool CheckInRange()
        {
            var ray = new Ray(ExplodePos.transform.position, Vector3.forward);
            if (Physics.Raycast(ray, out _, TriggerRange, LayerMask.GetMask("Zombie")))
            {
                return true;
            }

            return false;
        }

        public override bool CheckCanUseSkill()
        {
            // Debug.Log($"Check can use: {base.CheckCanUseSkill()}, In range: {CheckInRange()}");
            return base.CheckCanUseSkill() && CheckInRange();
        }

        public void Explode(){
            ProjectilePooling.Instance.SpawnExplosion(ExplosionType, ExplodePos.position, RangeMult);

            _plant.ChangeHealth(_plant.CurHealth);
        }

        public override void DoSkill()
        {
            base.DoSkill();
            // Debug.Log("Explode");
            Explode();
        }
    }
}
