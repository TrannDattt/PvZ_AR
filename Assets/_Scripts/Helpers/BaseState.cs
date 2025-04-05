using System;
using UnityEngine;

namespace PlantsZombiesAR.Helpers
{
    public class BaseState<StateEnum> where StateEnum : Enum
    {
        public StateEnum StateKey { get; private set; }

        private float _startTime;
        public float PlayedTime => Time.time - _startTime;

        public BaseState(StateEnum stateKey)
        {
            StateKey = stateKey;
        }

        public virtual void Enter()
        {
            _startTime = Time.time;
        }

        public virtual void Exit() { }

        public virtual void Do() { }

        public virtual void FixedDo() { }

        public virtual StateEnum GetNextState() => StateKey;
    }
}
