using PlantsZombiesAR.Enums;
using PlantsZombiesAR.GameManager;
using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Helpers;
using PlantsZombiesAR.Plants;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace PlantsZombiesAR.UIElements
{
    public class ShopManager : Singleton<ShopManager>
    {
        [SerializeField] private TextMeshProUGUI _sunCount;
        [SerializeField] private GameObject _shopItemParent;

        public int SunCount { get; private set; }
        public ShopItem CurItem { get; private set; }

        public void InitShop(LevelDataSO levelData)
        {
            SunCount = levelData.StartSun;
            CurItem = null;

            _sunCount.text = SunCount.ToString();

            _shopItemParent.transform.GetComponentsInChildren<ShopItem>().ToList().ForEach(shopItem => Destroy(shopItem.gameObject));
            foreach (var item in SelectPlantMenuManager.Instance.SelectedItems)
            {
                var newItem = Instantiate(item, _shopItemParent.transform);
                newItem.FetchItemInfo(item.ItemData);
            }
        }

        public void SelectItem(ShopItem item)
        {
            CurItem = item;
        }

        public void UnselectedItem()
        {
            CurItem = null;
        }

        public void UpdateSun(int amount)
        {
            SunCount += amount;
            _sunCount.text = SunCount.ToString();
        }

        public StatSO BuyPlant()
        {
            if(CurItem != null && SunCount >= CurItem.ItemData.Price)
            {
                UpdateSun(-1 * CurItem.ItemData.Price);
                CurItem.CooldownItem();
                var plantData = CurItem.ItemData.PlantData;
                UnselectedItem();
                return plantData;
            }

            return null;
        }

        public void PlacePlant(StatSO boughtPlant, PlantSlot slot)
        {
            if (!slot.HasPlant && boughtPlant != null && boughtPlant.PlantType != EPlant.None)
            {
                PlantPooling.Instance.SpawnPlant(boughtPlant.PlantType, slot.transform.position);
                slot.ChangeToNotEmpty();
            }
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
