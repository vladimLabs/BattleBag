using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Items;

namespace Shop
{
    public class ShopInBattle : MonoBehaviour
    {
        [SerializeField] private GameObject[] slotsShop;

        //Выбор какие предметы будут доступны в магазине
        public void ChoiceLowestRarityItems(int count)
        {
            //Получаем список всех доступных предметов
            List<GameItem> allItems = ItemController.instance.GetListGameItem();

            //Получаем предметы по редкости Common
            List<GameItem> commonItems = allItems.Where(item => item.rarity == Rarity.Common).ToList();

            for (int i = 0; i < count; i++)
            {
                slotsShop[i].SetActive(true); //больше для кнопки добавить в процессе, когда можно добавить еще предметы платно
                int index = Random.Range(0, commonItems.Count);
                slotsShop[i].GetComponent<SlotShop>().GetInfo(commonItems[index], ShopController.instance.GetCostItem(commonItems[index].KeyItem));
            }
        }
    }
}