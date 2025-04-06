using PlantsZombiesAR.Helpers;
using UnityEngine;

namespace PlantsZombiesAR.UIElements
{
    public abstract class GameMenu : MonoBehaviour
    {
        public virtual void InitMenu()
        {

        }

        public virtual void MenuEnter()
        {
            gameObject.SetActive(true);
        }

        public virtual void MenuExit()
        {
            gameObject.SetActive(false);
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
