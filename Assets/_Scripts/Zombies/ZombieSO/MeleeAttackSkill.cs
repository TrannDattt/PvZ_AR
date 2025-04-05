using PlantsZombiesAR.Plants;
using SerializeReferenceEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace PlantsZombiesAR.Zombies
{
    [SRName("Zombie Skill/Melee Attack")]
    public class MeleeAttackSkill : ZombieSkill
    {
        public float AttackRange;
        public int Damage;
        public Transform AttackPos;

        private PlantController _target;

        public bool CheckInRange()
        {
            var ray = new Ray(AttackPos.position, Vector3.back);
            if (Physics.Raycast(ray, out var hitPlant, AttackRange, LayerMask.GetMask("PlantData")))
            {
                _target = hitPlant.collider.gameObject.GetComponent<PlantController>();

                return true;
            }

            _target = null;
            return false;
        }

        public override void DoSkill()
        {
            base.DoSkill();

            _target.ChangeHealth(Damage);
        }
    }
}
