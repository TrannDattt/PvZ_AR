using PlantsZombiesAR.Helpers;
using UnityEngine;
using static PlantsZombiesAR.Zombies.ZombieSM;

namespace PlantsZombiesAR.Zombies
{
    public class BaseZombieState : BaseState<EState>
    {
        protected ZombieController _zombie;
        protected AnimationClip[] _anim;

        public BaseZombieState(EState stateKey, ZombieController zombie, params AnimationClip[] anim) : base(stateKey)
        {
            _zombie = zombie;
            _anim = anim;
        }

        public override void Enter()
        {
            base.Enter();

            PlayAnim();
        }

        protected virtual void PlayAnim(){
            if(_anim != null && _anim.Length > 0) 
            {
                _zombie.Animator.Play(_anim[0].name);
            }
        }
    }
}
