using PlantsZombiesAR.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlantsZombiesAR.Plants.PlantSM;

namespace PlantsZombiesAR.Plants
{
    public abstract class BasePlantState : BaseState<EState>
    {
        protected PlantController _plant;
        protected AnimationClip[] _clips;

        public BasePlantState(EState stateKey, PlantController plant, params AnimationClip[] clips) : base(stateKey)
        {
            _plant = plant;
            _clips = clips;
        }

        public virtual void PlayAnim(){
            if(_clips.Length != 0){
                _plant.Animator.Play(_clips[0].name);
            }

        }

        public override void Enter()
        {
            base.Enter();

            PlayAnim();
            //Debug.Log(StateKey);
        }
    }
}
