using SerializeReferenceEditor;
using UnityEngine;

namespace PlantsZombiesAR.Plants
{
    [SRName("PlantData Skill/Waiting")]
    public class WaitingSkill : PlantSkill{
        public bool IsFinish => Time.time - _initTime >= SkillTime;

        private float _initTime;

        public override void Init()
        {
            base.Init();
            _initTime = Time.time;
        }

        public override bool CheckCanUseSkill()
        {
            return base.CheckCanUseSkill() && !IsFinish;
        }
    }
}
