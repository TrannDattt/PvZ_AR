using PlantsZombiesAR.Enums;
using PlantsZombiesAR.Gameplays;
using SerializeReferenceEditor;
using System.Collections;
using UnityEngine;

namespace PlantsZombiesAR.Zombies
{
    public class SkillController : MonoBehaviour
    {
        [SerializeReference]
        [SR]
        [SerializeField] private ZombieSkill _skill;

        public void Init()
        {
            _skill.Init(this);
        }

        public bool CheckCanUseSkill()
        {
            if (_skill == null)
            {
                return false;
            }

            switch (_skill)
            {
                case MeleeAttackSkill meleeAttackSkill:
                    return meleeAttackSkill.CheckInRange() && !meleeAttackSkill.IsInCD;

                default:
                    return !_skill.IsInCD;
            }
        }

        public void DoSkill()
        {
            _skill.DoSkill();
            CooldownSkill();
        }

        public void CooldownSkill()
        {
            StartCoroutine(Cooldown());

            IEnumerator Cooldown()
            {
                yield return new WaitForSeconds(_skill.CooldownTime);
                _skill.FinishCD();
            }
        }

        public void ReturnSkillParticle(ParticleSystem particle, EParticle particleType)
        {
            if (particle == null) return;

            StartCoroutine(WaitParticleFinished());

            IEnumerator WaitParticleFinished()
            {
                yield return new WaitForSeconds(particle.main.duration);
                particle.gameObject.SetActive(false);   
                ParticlePooling.Instance.RemoveParticle(particle, particleType);
            }
        }
    }
}
