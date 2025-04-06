using PlantsZombiesAR.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace PlantsZombiesAR.UIElements
{
    public class StartMenu : GameMenuSingleton<StartMenu>
    {
        protected override void Start()
        {
            base.Start();
            gameObject.SetActive(true);
        }
    }
}
