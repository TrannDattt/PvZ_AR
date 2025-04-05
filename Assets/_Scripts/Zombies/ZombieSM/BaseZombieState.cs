using PlantsZombiesAR.Helpers;
using UnityEngine;
using static PlantsZombiesAR.Zombies.ZombieSM;

namespace PlantsZombiesAR.Zombies
{
    public class BaseZombieState : BaseState<EState>
    {
        protected ZombieController _zombie;

        public BaseZombieState(EState stateKey, ZombieController zombie) : base(stateKey)
        {
            _zombie = zombie;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log(StateKey);
        }
    }
}
