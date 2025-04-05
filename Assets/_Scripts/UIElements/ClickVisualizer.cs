using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace PlantsZombiesAR.UIElements
{
    public class ClickVisualizer : MonoBehaviour
    {
        [SerializeField] private GameObject _clickVisualizer;
        [SerializeField] private Canvas _canvas;

        private RectTransform _clickVisualizerRectTransform;

        private void GetTouchInput()
        {
            if (Touchscreen.current != null)
            {

                if (Touchscreen.current.primaryTouch.press.isPressed)
                {
                    _clickVisualizer.SetActive(true);

                    var touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(
                        _canvas.transform as RectTransform,
                        touchPos,
                        null,
                        out Vector2 localPoint
                    );
                    _clickVisualizerRectTransform.anchoredPosition = localPoint;
                }
                else
                {
                    _clickVisualizer.SetActive(false);
                }
            }
        }

        private void Start()
        {
            _clickVisualizerRectTransform = _clickVisualizer.GetComponent<RectTransform>();
            _clickVisualizer.SetActive(false);
        }

        private void Update()
        {
            GetTouchInput();
        }
    }
}
