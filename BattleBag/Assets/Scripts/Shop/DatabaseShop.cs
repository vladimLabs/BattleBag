using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class DatabaseShop : MonoBehaviour
    {
        private Dictionary<string, float> itemPrices;

        //словарь со стоимостью предметов для покупки 
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
                { "AxeDestruction", 30f },
                { "GuardianHelmet", 5f },
                { "NecklaceWisdom", 7f },
                { "TitanArmor", 18f },
                { "SimplePotion", 2f },
                { "SpiritStaff", 22f },
                { "BeltInvincible", 16f },
                { "HelmetShadows", 14f },
                { "ShadowArmor", 28f }
            };
        }

        public float GetCostItem(string item)
        {
            return itemPrices[item];
        }
    }
}