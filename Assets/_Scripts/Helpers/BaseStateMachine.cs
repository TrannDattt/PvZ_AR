using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Helpers
{
    public class BaseStateMachine<StateEnum> : MonoBehaviour where StateEnum : Enum
    {
        protected Dictionary<StateEnum, BaseState<StateEnum>> _stateDict = new();
        protected BaseState<StateEnum> _curState;

        public void ChangeState(StateEnum key)
        {
            _curState?.Exit();
            _curState = _stateDict[key];
            _curState.Enter();
        }

        protected virtual void Update()
        {
            if (_curState != null)
            {
                _curState.Do();

                var nextState = _curState.GetNextState();
                if (!nextState.Equals(_curState.StateKey))
                {
                    ChangeState(nextState);
                }
            }
        }

        private void FixedUpdate()
        {
            _curState?.FixedDo();
        }
    }
}
