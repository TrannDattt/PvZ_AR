using PlantsZombiesAR.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlantsZombiesAR.GameManager.GameflowSM;

namespace PlantsZombiesAR.GameManager
{
    public class BaseGameState : BaseState<EGameState>
    {
        protected bool _isFinished;

        public BaseGameState(EGameState stateKey) : base(stateKey)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _isFinished = false;
        }

        public void FinishState() => _isFinished = true;
    }
}
