using PlantsZombiesAR.Gameplays;
using PlantsZombiesAR.Helpers;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlantsZombiesAR.UIElements
{
    public class SelectPlantMenuManager : GameMenuSingleton<SelectPlantMenuManager>
    {
        private const int MAX_PLANT = 5;

        [SerializeField] private TextMeshProUGUI _plantCount;
        [SerializeField] private List<Image> _selectIndicators;
        [SerializeField] private GameObject _selectMenuParent;
        [SerializeField] private ShopItem _shopItemPreb;
        [SerializeField] private Button _finishSelectBtn;

        public List<ShopItem> SelectedItems { get; private set; } = new();

        //private List<ShopItem> _itemList = new();
        private Dictionary<GameObject, ShopItem> _indicatorDict = new();

        private const string PATH_TO_SHOP_ITEM_FOLDER = "ShopItemSO";

        public override void InitMenu()
        {
            foreach(Transform item in _selectMenuParent.transform){
                Destroy(item.gameObject);
            }
            
            GetAllItems();
            _indicatorDict.Clear();

            _selectIndicators.ForEach(i => {
                i.gameObject.SetActive(false);
                _indicatorDict.Add(i.gameObject, null);
            });

            SelectedItems.Clear();
        }

        private void GetAllItems()
        {
            ShopItemSO[] itemInfoList = Resources.LoadAll<ShopItemSO>(PATH_TO_SHOP_ITEM_FOLDER);
            if(itemInfoList.Length == 0)
            {
                Debug.Log(null);
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                var index = Mathf.Min(i, itemInfoList.Length - 1);
                ShopItem newItem = Instantiate(_shopItemPreb, _selectMenuParent.transform);
                newItem.FetchItemInfo(itemInfoList[index]);
            }
        }

        public void AddItem(ShopItem item)
        {
            if(SelectedItems.Count <  MAX_PLANT)
            {
                SelectedItems.Add(item);
                ActivateIndicator(item);
                UpdateUI();
            }
        }

        public void RemoveItem(ShopItem item)
        {
            SelectedItems.Remove(item);
            DeactivateIndicator(item);
            UpdateUI();
        }

        private void ActivateIndicator(ShopItem item)
        {
            var indicator = _indicatorDict.Keys.Where(key => _indicatorDict[key] == null).First();
            _indicatorDict[indicator] = item;
            indicator.SetActive(true);
            indicator.GetComponent<RectTransform>().position = item.GetComponent<RectTransform>().position;
        }

        private void DeactivateIndicator(ShopItem item)
        {
            var indicator = _indicatorDict.Keys.Where(key => _indicatorDict[key] == item).First();
            _indicatorDict[indicator] = null;
            indicator.SetActive(false);
        }

        private void UpdateUI()
        {
            _plantCount.text = $"{SelectedItems.Count}/{MAX_PLANT}";
            _finishSelectBtn.interactable = SelectedItems.Count > 0;
        }
    }
}
