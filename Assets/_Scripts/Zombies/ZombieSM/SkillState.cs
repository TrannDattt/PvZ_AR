using static PlantsZombiesAR.Zombies.ZombieSM;

namespace PlantsZombiesAR.Zombies
{
    public class SkillState : BaseZombieState
    {
        private bool _isFinished;

        public SkillState(EState stateKey, ZombieController zombie) : base(stateKey, zombie)
        {
        }

        public override void Do()
        {
            base.Do();

            if(PlayedTime > 1)
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
                return EState.Run;
            }

            return base.GetNextState();
        }
    }
}
