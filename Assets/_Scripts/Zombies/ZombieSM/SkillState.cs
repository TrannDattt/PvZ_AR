using UnityEngine;
using UnityEngine.InputSystem;
using static PlantsZombiesAR.Zombies.ZombieSM;

namespace PlantsZombiesAR.Zombies
{
    public class SkillState : BaseZombieState
    {
        private bool _isFinished;

        public SkillState(EState stateKey, ZombieController zombie, params AnimationClip[] anim) : base(stateKey, zombie, anim)
        {
        }

        public override void Do()
        {
            base.Do();

            if(PlayedTime > _zombie.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.length)
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
            base.Exit();

            _zombie.SkillController.DoSkill();
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EState GetNextState()
        {
            if (_isFinished)
            {
                if (_zombie.SkillController.CheckCanUseSkill())
                {
                    Exit();
                    Enter();
                    return StateKey;
                }

                return EState.Run;
            }

            return base.GetNextState();
        }
    }
}
