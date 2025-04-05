using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlantsZombiesAR.Plants.PlantSM;

namespace PlantsZombiesAR.Plants
{
    public class DieState : BasePlantState
    {
        private bool _isDied;

        public DieState(EState stateKey, PlantController plant, AnimationClip clip) : base(stateKey, plant, clip)
        {
            _isDied = false;
        }

        public override void Do()
        {
            base.Do();

            if(!_isDied && PlayedTime > 1)
            {
                _isDied = true;
                _plant.DestroyPlant();
            }
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
    }
}
