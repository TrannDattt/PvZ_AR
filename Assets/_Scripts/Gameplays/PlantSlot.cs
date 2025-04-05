using PlantsZombiesAR.Plants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlantsZombiesAR.Gameplays
{
    public class PlantSlot : MonoBehaviour
    {
        [SerializeField] private Sprite _defaultSprite;

        public bool HasPlant {  get; private set; }

        private SpriteRenderer _renderer;

        public void ChangeToEmpty()
        {
            HasPlant = false;
        }

        public void ChangeToNotEmpty()
        {
            HasPlant = true;
        }

        //public void OnHovering(StatSO plant)
        //{
        //    _renderer.sprite = plant.Image;
        //    _renderer.color = Color.white;
        //}

        public void OnHovering()
        {
            _renderer.color = new Color(1, 1, 1, .2f);
        }

        public void OnQuitHovering()
        {
            _renderer.color = Color.clear;
        }

        //public void OnQuitHovering()
        //{
        //    _renderer.sprite = _defaultSprite;
        //    _renderer.color = Color.clear;
        //}

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.sprite = _defaultSprite;
        }
    }
}
