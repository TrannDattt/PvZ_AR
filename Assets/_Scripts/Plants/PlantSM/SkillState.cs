using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlantsZombiesAR.Plants.PlantSM;

namespace PlantsZombiesAR.Plants
{
    public class SkillState : BasePlantState
    {
        private bool _isFinished;

        public SkillState(EState stateKey, PlantController plant, AnimationClip clip) : base(stateKey, plant, clip)
        {
        }

        public override void Do()
        {
            if(PlayedTime > 1)
            {
                _isFinished = true;
            }
        }

        public override void Enter()
        {
            base.Enter();
            _isFinished = false;
        }

        public override void Exit()
        {
            _plant.SkillController.DoSkill();
        }

        public override void FixedDo()
        {
            
        }

        public override EState GetNextState()
        {
            if (_isFinished)
            {
                return EState.Idle;
            }

            return base.GetNextState();
        }
    }
}
