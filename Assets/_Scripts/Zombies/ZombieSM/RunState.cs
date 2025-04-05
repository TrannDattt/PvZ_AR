using UnityEngine;
using static PlantsZombiesAR.Zombies.ZombieSM;

namespace PlantsZombiesAR.Zombies
{
    public class RunState : BaseZombieState
    {
        public RunState(EState stateKey, ZombieController zombie) : base(stateKey, zombie)
        {
        }

        public override void Do()
        {
            base.Do();
        }

        public override void Enter()
        {
            base.Enter();

            _zombie.Rigidbody.velocity = _zombie.CurSpeed * Vector3.back;
        }

        public override void Exit()
        {
            base.Exit();

            _zombie.Rigidbody.velocity = Vector3.zero;
        }

        public override void FixedDo()
        {
            base.FixedDo();
        }

        public override EState GetNextState()
        {
            if (_zombie.CurHealth <= 0)
            {
                return EState.Die;
            }

            if (_zombie.SkillController.CheckCanUseSkill())
            {
                return EState.Skill;
            }

            return base.GetNextState();
        }
    }
}
