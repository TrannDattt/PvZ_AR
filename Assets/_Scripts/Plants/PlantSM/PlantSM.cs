using PlantsZombiesAR.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlantsZombiesAR.Plants.PlantSM;

namespace PlantsZombiesAR.Plants
{
    public class PlantSM : BaseStateMachine<EState>
    {
        public enum EState
        {
            Idle,
            Skill,
            Die,
        }

        [SerializeField] private AnimationClip _idleClip;
        [SerializeField] private AnimationClip[] _skillClips;
        [SerializeField] private AnimationClip _dieClip;

        public void Init(PlantController plant)
        {
            _stateDict.Clear();

            _stateDict.Add(EState.Idle, new IdleState(EState.Idle, plant, _idleClip));
            _stateDict.Add(EState.Skill, new SkillState(EState.Skill, plant, _skillClips));
            _stateDict.Add(EState.Die, new DieState(EState.Die, plant, _dieClip));

            ChangeState(EState.Idle);
        }

        //protected override void Update()
        //{
        //    base.Update();
        //    Debug.Log(_curState.StateKey);
        //}
    }
}
