using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragItem;

namespace Items
{
    public class ItemController : DatabaseItem
    {
        public static ItemController instance;
        [SerializeField] private Transform pointSpawn;
        [SerializeField] private Transform canvas;
        [SerializeField] private GameObject prefabItem;
        private BagFight bagFight;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            bagFight = FindObjectOfType<BagFight>();
        }

        public void SummonItem(string nameItem)
        {
            GameObject item = Instantiate(prefabItem, pointSpawn.position, Quaternion.identity, canvas);
            item.GetComponent<Item>().GetInfoItem(nameItem);
        }

        public void SlotOccupied(GameItem item, int index)
        {
            bagFight.SetSlotOccupied(index, item);
        }

        public void SlotUnOccupied(int index)
        {
            bagFight.DelSlotOccupied(index);
        }
    }   
}