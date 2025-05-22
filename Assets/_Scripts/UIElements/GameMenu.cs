using PlantsZombiesAR.Helpers;
using UnityEngine;

namespace PlantsZombiesAR.UIElements
{
    public class GameMenu : MonoBehaviour
    {
        private bool _isMenuActive;

        public virtual void InitMenu()
        {

        }

        public virtual void MenuEnter()
        {
            _isMenuActive = true;
            gameObject.SetActive(true);
        }

        public virtual void MenuExit()
        {
            _isMenuActive = false;
            gameObject.SetActive(false);
        }

        public void ChangeDisplayMode()
        {
            if (_isMenuActive)
            {
                MenuExit();
            }
            else
            {
                MenuEnter();
            }
        }

        protected virtual void Start()
        {
            gameObject.SetActive(false);
        }
    }

    public abstract class GameMenuSingleton<T> : GameMenu where T : GameMenuSingleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
