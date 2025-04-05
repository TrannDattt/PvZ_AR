using PlantsZombiesAR.Plants;
using PlantsZombiesAR.UIElements;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PlantsZombiesAR.Gameplays
{
    public class ShopItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private Image _itemImage;
        [SerializeField] private Image _deactivePanel;

        public ShopItemSO ItemData { get; private set; }

        private bool _finishedCooldown;

        public void FetchItemInfo(ShopItemSO itemData)
        {
            _finishedCooldown = true;
            ItemData = itemData;

            _priceText.text = itemData.Price.ToString();
            _itemImage.sprite = itemData.Image;
        }

        public void ClearItemInfo()
        {
            _priceText.text = string.Empty;
            _itemImage = null;
        }

        public void CooldownItem()
        {
            _finishedCooldown = false;
            StartCoroutine(CooldownItem());

            IEnumerator CooldownItem()
            {
                float elapsedTime = 0;
                while (elapsedTime < ItemData.BuyCooldown)
                {
                    _deactivePanel.fillAmount = 1 - (float)(elapsedTime / ItemData.BuyCooldown);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                _deactivePanel.fillAmount = 0;
                _finishedCooldown = true;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            //throw new System.NotImplementedException();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(GameManager.GameManager.Instance.StateMachine.CurGameState == GameManager.GameflowSM.EGameState.PlantPhase)
            {
                if (_finishedCooldown)
                {
                    ShopManager.Instance.SelectItem(this);
                }
            }
            else if(GameManager.GameManager.Instance.StateMachine.CurGameState == GameManager.GameflowSM.EGameState.SelectPhase)
            {
                if (SelectPlantMenuManager.Instance.SelectedItems.Contains(this))
                {
                    SelectPlantMenuManager.Instance.RemoveItem(this);
                }
                else
                {
                    SelectPlantMenuManager.Instance.AddItem(this);
                }
            }
        }
    }
}
