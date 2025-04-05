using PlantsZombiesAR.Gameplays;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Plants
{
    public class PlantController : MonoBehaviour
    {
        [field: SerializeField] public StatSO Stat { get; private set; }
        [field: SerializeField] public PlantSM StateMachine { get; private set; }
        [field: SerializeField] public SkillController SkillController { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }

        public int CurHealth {  get; private set; }

        public void Init()
        {
            gameObject.SetActive(true);
            CurHealth = Stat.Health;
            StateMachine.Init(this);
            SkillController.Init();
        }

        public void ChangeHealth(int amount)
        {
            CurHealth = Mathf.Clamp(CurHealth - amount, 0, Stat.Health);
        }

        public void DestroyPlant()
        {
            gameObject.SetActive(false);

            PlantPooling.Instance.RemovePlant(this);
        }

        private void Start()
        {
            Init();
        }
    }
}
