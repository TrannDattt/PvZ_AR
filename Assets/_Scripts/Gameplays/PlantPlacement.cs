//using PlantsZombiesAR.Enums;
//using PlantsZombiesAR.GameManager;
//using PlantsZombiesAR.Helpers;
//using PlantsZombiesAR.Plants;
//using PlantsZombiesAR.UIElements;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.InputSystem;
//using UnityEngine.XR.ARFoundation;
//using UnityEngine.XR.ARSubsystems;

//namespace PlantsZombiesAR.Gameplays
//{
//    public class PlantPlacement : Singleton<PlantPlacement>
//    {
//        [SerializeField] private ARRaycastManager _arRaycastManager;

//        public StatSO CurSelectedPlant => ShopManager.Instance.CurItem.CurPlantInfo.Plant;

//        public void PlacePlant(PlantSlot slot)
//        {
//            if (!slot.HasPlant && CurSelectedPlant != null && CurSelectedPlant.PlantType != EPlant.None)
//            {
//                PlantPooling.Instance.SpawnPlant(CurSelectedPlant.PlantType, slot.transform.position);
//                slot.ChangeToNotEmpty();
//                ShopManager.Instance.BuyPlant();
//                //UnselectedPlant();
//            }
//        }

//        //public void SelectPlant(StatSO plantStat)
//        //{
//        //    CurSelectedPlant = plantStat;
//        //}

//        //private void UnselectedPlant()
//        //{
//        //    CurSelectedPlant = null;
//        //}
//    }
//}
