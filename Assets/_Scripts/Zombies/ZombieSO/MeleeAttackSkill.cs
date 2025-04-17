using PlantsZombiesAR.Enums;
using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Plants;
using SerializeReferenceEditor;
using UnityEngine;

namespace PlantsZombiesAR.Zombies
{
    [SRName("Zombie Skill/Melee Attack")]
    public class MeleeAttackSkill : ZombieSkill
    {
        public float AttackRange;
        public int Damage;
        public Transform AttackPos;
        public EParticle ParticleType;

        private PlantController _target;

        public override void Init(SkillController skillController)
        {
            base.Init(skillController);
        }

        public bool CheckInRange()
        {
            var ray = new Ray(AttackPos.position, Vector3.back);
            if (Physics.Raycast(ray, out var hitPlant, AttackRange, LayerMask.GetMask("Plant")))
            {
                _target = hitPlant.collider.GetComponent<PlantController>();

                return true;
            }

            _target = null;
            return false;
        }

        public override void DoSkill()
        {
            base.DoSkill();

            _target.ChangeHealth(Damage);

            var particle = ParticlePooling.Instance.SpawnParticle(ParticleType, AttackPos);
            particle.Play();
            _skillController.ReturnSkillParticle(particle, ParticleType);
        }
    }
}
