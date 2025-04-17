using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Zombies
{
    [Serializable]
    public abstract class ZombieSkill
    {
        public float CooldownTime;

        public bool IsInCD { get; private set; }

        protected SkillController _skillController;

        public virtual void Init(SkillController skillController)
        {
            _skillController = skillController;
            IsInCD = false;
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
