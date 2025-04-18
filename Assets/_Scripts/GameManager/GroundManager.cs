using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.UIElements;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

namespace PlantsZombiesAR.GameManager
{
    public class GroundManager : Singleton<GroundManager>
    {
        [SerializeField] private ARPlaneManager _arPlaneManager;
        [SerializeField] private ARRaycastManager _arRaycastManager;
        [SerializeField] private GameObject _ingameGroundPreb;
        [SerializeField] private Transform _plantSpawnPos;
        [SerializeField] private Transform _zombieSpawnPos;
        [SerializeField] private Transform _projectileSpawnPos;

        public GameObject Ground { get; private set; }
        public EndPosReachChecker EndPosChecker { get; private set; }

        private Camera _camera;

        public PlantSlot CurSlot { get; private set; }

        private List<PlantSlot> _slotList = new();

        public void SelectSlot(PlantSlot slot)
        {
            CurSlot = slot;
            CurSlot.OnHovering();
        }

        public void UnselectSlot()
        {
            CurSlot?.OnQuitHovering();
            CurSlot = null;
        }

        private void PlaceGroundOnPlane(ARPlane plane)
        {
            Ground = Instantiate(_ingameGroundPreb, plane.transform.position, Quaternion.identity);
            // EndPos = Ground.transform.Find("EndPos").transform;
            EndPosChecker = Ground.GetComponentInChildren<EndPosReachChecker>();
            if(EndPosChecker == null){
                Debug.LogError("EndPos not found!");
                return;
            }
            Ground.SetActive(false);
        }

        private void FindAllPlantSlots(){
            _slotList.Clear();

            _slotList = Ground.GetComponentsInChildren<PlantSlot>().ToList();
        }

        public void InitPlane()
        {
            Ground.SetActive(true);
            EndPosChecker.InitChecker();
            CurSlot = null;

            FindAllPlantSlots();
            _slotList.ForEach((slot) => {
                slot.ChangeToEmpty();
            });
        }

        public void DeactivePlane()
        {
            if(Ground){
                ClearGround();
                Ground.SetActive(false);
            }
        }

        public void ClearGround(){
            foreach(Transform plant in _plantSpawnPos){
                Destroy(plant.gameObject);
            }

            foreach(Transform zombie in _zombieSpawnPos){
                Destroy(zombie.gameObject);
            }

            foreach(Transform projectile in _projectileSpawnPos){
                Destroy(projectile.gameObject);
            }
        }

        public void UpdateSelectedSlot(Vector2 touchPos)
        {
            var ray = _camera.ScreenPointToRay(touchPos);
            if(Physics.Raycast(ray, out var hitSlot, Mathf.Infinity, LayerMask.GetMask("Slot")))
            {
                UnselectSlot();
                var slot = hitSlot.collider.GetComponentInChildren<PlantSlot>();
                if(!slot.HasPlant){
                    SelectSlot(slot);
                }
                return;
            }

            UnselectSlot();
        }

        private void OnPlaneChanged(ARPlanesChangedEventArgs args)
        {
            foreach (ARPlane plane in args.added)
            {
                if (!Ground)
                {
                    PlaceGroundOnPlane(plane);
                }
            }
        }

        private void Start()
        {
            _camera = Camera.main;

            _arPlaneManager.planesChanged += OnPlaneChanged;
        }

        private void Update()
        {
            if (Touchscreen.current != null)
            {
                if (Touchscreen.current.primaryTouch.press.isPressed)
                {
                    if(ShopManager.Instance.CurItem != null)
                    {
                        var touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                        UpdateSelectedSlot(touchPos);
                    }
                }
                else if(CurSlot != null)
                {
                    var boughtPlant = ShopManager.Instance.BuyPlant();
                    if(boughtPlant != null)
                    { 
                        ShopManager.Instance.PlacePlant(boughtPlant, CurSlot); 
                    }
                    UnselectSlot();
                }
                else
                {
                    ShopManager.Instance.UnselectedItem();
                }
            }
        }
    }
}
