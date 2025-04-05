using UnityEngine;
using UnityEngine.InputSystem;

namespace PlantsZombiesAR.Helpers
{
    public class ClickPositionDetect : Singleton<ClickPositionDetect>
    {
        public Vector3 ClickPos { get; private set; }

        public Vector2 GetMousePosOnCanvas()
        {
            return Camera.main.ScreenToViewportPoint(ClickPos);
        }

        public Vector2 GetMousePosInWorld()
        {
            return Camera.main.ScreenToWorldPoint(ClickPos);
        }

        private void Update()
        {
            if (Application.isMobilePlatform)
            {
                if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
                {
                    ClickPos = Touchscreen.current.primaryTouch.position.ReadValue();
                    //Debug.Log("Touch detected at: " + ClickPos);
                }
            }
            else
            {
                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    ClickPos = Mouse.current.position.ReadValue();
                    //Debug.Log("Mouse click detected at: " + ClickPos);
                }
            }
        }
    }
}
