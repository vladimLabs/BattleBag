using UnityEngine;
using Items;

namespace DragItem
{
    public class BagFight : MonoBehaviour
    {
        public GameItem[] items = new GameItem[9]; //Массив слотов рюкзака


        //Метод для установки слота как занятого
        public void SetSlotOccupied(int index, GameItem item)
        {
            items[index] = item;
            ShowItems();
        }

        //Метод для установки слота как занятого
        public void DelSlotOccupied(int index)
        {
            items[index] = null;
            //ShowItems();
        }

        private void ShowItems()
        {
            foreach (GameItem item in items)
            {
                if (item != null)
                {
                    Debug.Log(item.KeyItem + " " + item.itemName);
                }
            }
        }
    }
}