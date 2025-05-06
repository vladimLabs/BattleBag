using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class DatabaseShop : MonoBehaviour
    {
        private Dictionary<string, float> itemPrices;

        public void Initialize()
        {
            itemPrices = new Dictionary<string, float>
        {
            { "SwordDestruction", 10f },
            { "SniperBelt", 8f },
            { "WarAxe", 12f },
            { "DoubleBlade", 15f },
            { "KillerAxe", 20f },
            { "BladeDestruction", 25f },
            { "AxeDestruction", 30f }
        };
        }

        public float GetCostItem(string item)
        {
            return itemPrices[item];
        }
    }
}