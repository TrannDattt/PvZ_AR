using PlantsZombiesAR.Projectiles;
using PlantsZombiesAR.UIElements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlantsZombiesAR.Gameplays
{
    public class CurrencyCollector : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
            {
                var touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                Ray ray = _camera.ScreenPointToRay(touchPos);

                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Collectable")))
                {
                    var sun = hit.collider.GetComponentInParent<Sun>();
                    ShopManager.Instance.UpdateSun(sun.Value);
                    sun.DestroyProjectile();
                }
            }
        }
    }
}
