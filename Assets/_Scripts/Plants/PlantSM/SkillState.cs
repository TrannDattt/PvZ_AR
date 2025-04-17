using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlantsZombiesAR.Plants.PlantSM;

namespace PlantsZombiesAR.Plants
{
    public class SkillState : BasePlantState
    {
        private bool _isFinished;

        public SkillState(EState stateKey, PlantController plant, params AnimationClip[] clips) : base(stateKey, plant, clips)
        {
        }

        public override void Do()
        {
            if(PlayedTime > _plant.SkillController.ReadySkill.SkillTime)
            {
                // Debug.Log(_plant.SkillController.ReadySkill.SkillTime);
                _isFinished = true;
            }
        }

        public override void Enter()
        {
            base.Enter();

            _isFinished = false;
        }

        public override void PlayAnim()
        {
            if(_clips.Length == 0){
                return;
            }

            var clipIndex = _plant.SkillController.GetSkillIndex();
            if(clipIndex >= 0){
                _plant.Animator.Play(_clips[clipIndex].name);
                // Debug.Log(_clips[clipIndex].name);
            }
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
