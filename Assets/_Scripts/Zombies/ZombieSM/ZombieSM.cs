using PlantsZombiesAR.Helpers;
using UnityEngine;
using static PlantsZombiesAR.Zombies.ZombieSM;

namespace PlantsZombiesAR.Zombies
{
    public class ZombieSM : BaseStateMachine<EState>
    {
        public enum EState
        {
            Run,
            Skill,
            Die,
        }

        [SerializeField] private AnimationClip _runClip;
        [SerializeField] private AnimationClip _skillClip;
        [SerializeField] private AnimationClip _dieClip;

        private Animator _animator;

        public void Init(ZombieController zombie)
        {
            _stateDict.Clear();

            _stateDict.Add(EState.Run, new RunState(EState.Run, zombie, _runClip));
            _stateDict.Add(EState.Skill, new SkillState(EState.Skill, zombie, _skillClip));
            _stateDict.Add(EState.Die, new DieState(EState.Die, zombie, _dieClip));

            ChangeState(EState.Run);
        }
    }
}
