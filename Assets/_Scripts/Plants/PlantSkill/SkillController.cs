using SerializeReferenceEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Plants
{
    public class SkillController : MonoBehaviour
    {
        [SerializeReference]
        [SR]
        [SerializeField] private PlantSkill _skill;

        public void Init()
        {
            _skill.Init();
        }

        public bool CheckCanUseSkill()
        {
            if (_skill == null)
            {
                return false;
            }

            switch (_skill)
            {
                case ShootingSkill shootingSkill:
                    return shootingSkill.CheckInRange() && !shootingSkill.IsInCD;

                case SpawningSkill spawningSkill:
                    return !spawningSkill.IsInCD;

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
