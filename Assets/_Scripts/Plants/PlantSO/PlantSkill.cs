using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Plants
{
    [Serializable]
    public abstract class PlantSkill
    {
        public float CooldownTime;

        public bool IsInCD { get; private set; }

        public void Init()
        {
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
