using static PlantsZombiesAR.Zombies.ZombieSM;

namespace PlantsZombiesAR.Zombies
{
    public class DieState : BaseZombieState
    {
        private bool _isDied;

        public DieState(EState stateKey, ZombieController zombie) : base(stateKey, zombie)
        {
            _isDied = false;
        }

        public override void Do()
        {
            base.Do();

            if (!_isDied && PlayedTime > 1)
            {
                _isDied = true;
                _zombie.DestroyZombie();
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

        public override EState GetNextState()
        {
            return base.GetNextState();
        }
    }
}
