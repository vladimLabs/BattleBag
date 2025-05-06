using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Items;

namespace Shop
{
    public class ShopInBattle : MonoBehaviour
    {
        [SerializeField] private GameObject[] slotsShop;

        public void ChoiceLowestRarityItems(int count)
        {
            List<Items.GameItem> allItems = ItemController.instance.GetListGameItem();

            //Получаем предметы по редкости Common
            List<Items.GameItem> commonItems = allItems.Where(item => item.rarity == Rarity.Common).ToList();

            for (int i = 0; i < count; i++)
            {
                Items.GameItem item = commonItems[i];
                slotsShop[i].GetComponent<SlotShop>().GetInfo(commonItems[i], ShopController.instance.GetCostItem(commonItems[i].KeyItem));
                
            }
        }
    }
}