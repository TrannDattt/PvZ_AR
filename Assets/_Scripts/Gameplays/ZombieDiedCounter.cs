using PlantsZombiesAR.Helpers;
using System;
using UnityEngine.Events;

namespace PlantsZombiesAR.Gameplays
{
    public static class ZombieDiedCounter
    {
        public static int Count { get; private set; }

        public static void ResetCounter()
        {
            Count = 0;
        }

        public static void Increase(int amount = 1)
        {
            Count += amount;
        }
    }
}
