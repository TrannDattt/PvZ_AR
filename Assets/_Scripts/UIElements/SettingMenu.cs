using PlantsZombiesAR.GameManager;
using UnityEngine;
using UnityEngine.UI;

namespace PlantsZombiesAR.UIElements
{
    public class SettingMenu : GameMenuSingleton<SettingMenu>
    {
        [SerializeField] private Slider _volumeSlider;

        protected override void Start()
        {
            base.Start();
            SoundManager.Instance.ChangeAllVolume(_volumeSlider.value);
        }
    }
}
