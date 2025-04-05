using PlantsZombiesAR.Plants;
using UnityEngine;

namespace PlantsZombiesAR.Gameplays
{
    [CreateAssetMenu(menuName = "ScriptableObject/Shop Item")]
    public class ShopItemSO : ScriptableObject
    {
        public StatSO PlantData;
        public Sprite Image;
        public int Price;
        public float BuyCooldown;
    }
}
