using UnityEngine;
using Items;

namespace DragItem
{
    public class BagFight : MonoBehaviour
    {
        private GameItem[] gameSlotsItem = new GameItem[9]; //Массив слотов рюкзака для подгрузки в бой
        private Item[] items = new Item[9]; //Массив для прокачки уровня слота

        [SerializeField] private Slot[] slots = new Slot[9];


        //Метод для установки слота как занятого
        public void SetSlotOccupied(int index, GameItem gameItem, Item item)
        {
            gameSlotsItem[index] = gameItem;

            GameBag.GetGameItem(gameSlotsItem);

            items[index] = item;
            //ShowItems();
        }

        //Метод для установки слота как свободно
        public void DelSlotOccupied(int index)
        {
            gameSlotsItem[index] = null;
            GameBag.GetGameItem(gameSlotsItem);
        }

        public string GetItemName(int index)
        {
            return gameSlotsItem[index].KeyItem;
        }

        public void UpgradeItem(int index)
        {
            items[index].UpgradeLevel();   //увеличиваем уровень у предмета в слоте
            slots[index].UpgradeItem();
            GameBag.GetGameItem(gameSlotsItem);
        }

    }
}