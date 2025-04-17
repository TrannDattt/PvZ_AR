using PlantsZombiesAR.Gameplays;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Zombies
{
    public class ZombieController : MonoBehaviour
    {
        [field: SerializeField] public StatSO Stat { get; private set; }
        [field: SerializeField] public ZombieSM StateMachine { get; private set; }
        [field: SerializeField] public SkillController SkillController { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

        public int CurHealth {  get; private set; }
        public float CurSpeed {  get; private set; }

        public void Init()
        {
            gameObject.SetActive(true);
            CurHealth = Stat.Health;
            CurSpeed = Stat.Speed;
            StateMachine.Init(this);
            SkillController.Init();
        }

        public void ChangeHealth(int amount)
        {
            CurHealth = Mathf.Clamp(CurHealth - amount, 0, Stat.Health);
        }

        public void DestroyZombie()
        {
            gameObject.SetActive(false);
            ZombieDiedCounter.Increase();

            ZombiePooling.Instance.RemoveZombie(this);
        }

        //private void Start()
        //{
        //    Init();
        //}
    }
}
