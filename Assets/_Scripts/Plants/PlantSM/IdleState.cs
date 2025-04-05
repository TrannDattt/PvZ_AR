using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlantsZombiesAR.Plants.PlantSM;

namespace PlantsZombiesAR.Plants
{
    public class IdleState : BasePlantState
    {
        public IdleState(EState stateKey, PlantController plant, AnimationClip clip) : base(stateKey, plant, clip)
        {
        }

        public override void Do()
        {
            base.Do();
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EState GetNextState()
        {
            if(_plant.CurHealth <= 0)
            {
                return EState.Die;
            }

            if (_plant.SkillController.CheckCanUseSkill())
            {
                return EState.Skill;
            }

            return base.GetNextState();
        }
    }
}
