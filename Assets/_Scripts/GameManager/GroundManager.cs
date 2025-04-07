using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.UIElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace PlantsZombiesAR.GameManager
{
    public class GroundManager : Singleton<GroundManager>
    {
        [SerializeField] private ARPlaneManager _arPlaneManager;
        [SerializeField] private ARRaycastManager _arRaycastManager;

        [SerializeField] private GameObject _ingameGroundPreb;

        public GameObject Ground { get; private set; }

        private Camera _camera;

        public PlantSlot CurSlot { get; private set; }

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
            Ground.SetActive(false);
        }

        public void ActivePlane()
        {
            Ground.SetActive(true);
        }

        public void DeactivePlane()
        {
            Ground.SetActive(false);
        }

        public void UpdateSelectedSlot(Vector2 touchPos)
        {
            var ray = _camera.ScreenPointToRay(touchPos);
            if(Physics.Raycast(ray, out var hitSlot, Mathf.Infinity, LayerMask.GetMask("Slot")))
            {
                UnselectSlot();
                //Debug.Log(hitSlot.collider.gameObject);
                SelectSlot(hitSlot.collider.GetComponentInChildren<PlantSlot>());
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
