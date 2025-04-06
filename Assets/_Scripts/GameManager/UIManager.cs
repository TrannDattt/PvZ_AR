using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.UIElements;
using System.Collections.Generic;

namespace PlantsZombiesAR.GameManager
{
    public class UIManager : Singleton<UIManager>
    {
        private Stack<GameMenu> _menuStack = new();

        public void PushMenu(GameMenu menu)
        {
            if(_menuStack.Count > 0)
            { 
                var curMenu = _menuStack.Peek();
                curMenu.MenuExit();
            }

            menu.MenuEnter();
            _menuStack.Push(menu);
        }

        public void PopMenu()
        {
            if (_menuStack.Count > 1)
            {
                var poppedMenu = _menuStack.Pop();
                poppedMenu.MenuExit();

                var curMenu = _menuStack.Peek();
                curMenu.MenuEnter();
            }
        }

        private void Start()
        {
            _menuStack.Push(StartMenu.Instance);
        }
    }
}
