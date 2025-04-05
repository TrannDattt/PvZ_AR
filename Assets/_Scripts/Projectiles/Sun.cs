using PlantsZombiesAR.Interfaces;
using PlantsZombiesAR.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlantsZombiesAR.Projectiles
{
    public class Sun : ProjectileController, ICollectable
    {
        [field: SerializeField] public int Value { get; private set; }

        public override void Init()
        {
            base.Init();
        }

        public void GainValue()
        {
            //throw new System.NotImplementedException();
        }

        
    }
}
