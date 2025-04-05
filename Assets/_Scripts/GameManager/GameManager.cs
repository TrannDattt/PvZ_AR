using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.UIElements;
using System;
using UnityEngine;

namespace PlantsZombiesAR.GameManager
{
    public class GameManager : Singleton<GameManager>
    {
        [field: SerializeField] public GameflowSM StateMachine { get; private set; }

        private void Start()
        {
            StateMachine.Init();
        }
    }
}
