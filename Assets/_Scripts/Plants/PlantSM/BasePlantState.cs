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
        protected AnimationClip _clip;

        public BasePlantState(EState stateKey, PlantController plant, AnimationClip clip) : base(stateKey)
        {
            _plant = plant;
            _clip = clip;
        }

        public override void Enter()
        {
            base.Enter();

            if (_clip != null)
            {
                _plant.Animator.Play(_clip.name);
            }
            //Debug.Log(StateKey);
        }
    }
}
