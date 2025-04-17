using SerializeReferenceEditor;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlantsZombiesAR.Plants
{
    public class SkillController : MonoBehaviour
    {
        [SerializeReference]
        [SR]
        [SerializeField] private List<PlantSkill> _skillList;

        public PlantSkill ReadySkill { get; private set; }

        private PlantController _plant;

        public void Init(PlantController plant)
        {
            _plant = plant;
            ReadySkill = null;
            _skillList.ForEach((skill) => skill.Init());
        }

        public int GetSkillIndex(){
            if(ReadySkill == null){
                return -1;
            }

            return _skillList.IndexOf(ReadySkill);
        }

        public bool CheckCanUseSkill()
        {
            if (_skillList.Count == 0)
            {
                return false;
            }

            foreach(var skill in _skillList){
                if(skill.CheckCanUseSkill()){
                    if(ReadySkill != skill){
                        ReadySkill = skill;
                        ReadySkill.SetPlant(_plant);
                    }
                    return true;
                }
            }

            return false;
        }

        public void DoSkill()
        {
            ReadySkill.DoSkill();
            CooldownSkill(ReadySkill);
        }

        public void CooldownSkill(PlantSkill skill)
        {
            if(skill.CooldownTime >= 999){
                return;
            }

            StartCoroutine(Cooldown());

            IEnumerator Cooldown()
            {
                yield return new WaitForSeconds(skill.CooldownTime);
                skill.FinishCD();
            }
        }
    }
}
