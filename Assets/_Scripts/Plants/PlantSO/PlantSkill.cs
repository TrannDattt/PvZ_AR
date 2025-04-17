using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Plants
{
    [Serializable]
    public abstract class PlantSkill
    {
        public float SkillTime = 1;
        public float CooldownTime;

        public bool IsInCD { get; private set; }

        protected PlantController _plant;

        public virtual void Init()
        {
            IsInCD = false;
        }

        public void SetPlant(PlantController plant){
            _plant = plant;
        }

        public virtual bool CheckCanUseSkill(){
            return !IsInCD;
        }

        public virtual void DoSkill()
        {
            IsInCD = true;
        }

        public void FinishCD()
        {
            IsInCD = false;
        }
    }
}
