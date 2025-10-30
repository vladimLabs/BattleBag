using UnityEngine;
using Items;

namespace DragItem
{
    public class BagFight : MonoBehaviour
    {
        private GameItem[] gameSlotsItem = new GameItem[9]; //Массив слотов рюкзака для подгрузки в бой
        private Item[] items = new Item[9]; //Массив для прокачки уровня слота

        [SerializeField] private Slot[] slots = new Slot[9];

        [SerializeField] private GameObject prefabDragItem;
        [SerializeField] private Transform canvas;

        public void LoadStateBag()
        {
            gameSlotsItem = GameBag.GetGameItem();
        }

        //Метод для установки слота как занятого
        public void SetSlotOccupied(int index, GameItem gameItem, Item item)
        {
            gameSlotsItem[index] = gameItem;

            GameBag.SetGameItem(gameSlotsItem);

            items[index] = item;
            //ShowItems();
        }

        //Метод для установки слота как свободно
        public void DelSlotOccupied(int index)
        {
            gameSlotsItem[index] = null;
            GameBag.SetGameItem(gameSlotsItem);
        }

        public string GetItemName(int index)
        {
            return gameSlotsItem[index].KeyItem;
        }

        public void UpgradeItem(int index)
        {
            items[index].UpgradeLevel();   //увеличиваем уровень у предмета в слоте
            slots[index].UpgradeItem();
            GameBag.SetGameItem(gameSlotsItem);
        }

        public void LoadHeroBag()
        {
            LoadStateBag();
            if (GameBag.IsFullBag())
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (GameBag._gameSlotsItem[i] != null)
                    {
                        GameObject clone = Instantiate(prefabDragItem, slots[i].transform.position, Quaternion.identity, canvas);
                        clone.GetComponent<Item>().DisablePhysics();
                        clone.GetComponent<Item>().GetInfoItem(GameBag._gameSlotsItem[i].KeyItem);
                        clone.GetComponent<Item>().LoadInfoItem(GameBag._gameSlotsItem[i].KeyItem, GameBag._gameSlotsItem[i].Level);
                        GameObject.Find("slotShopBag" + i).GetComponent<Slot>().LoadOccupedSlotsInfo();
                        slots[i].ChangeGenerate(true);
                        Debug.Log(GameBag._gameSlotsItem[i].KeyItem + " " + GameBag._gameSlotsItem[i].Level);
                    }
                }
            }
        }
    }
}