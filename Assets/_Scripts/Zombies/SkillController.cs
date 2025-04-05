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

        public GameObject Target {  get; private set; }

        public void Init()
        {
            _skill.Init();
            Target = null;
        }

        public bool CheckCanUseSkill()
        {
            if (_skill != null)
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
    }
}
