using Items;
using Shop;
using DragItem;
using UnityEngine;

namespace GameProcess {
    public class Game : MonoBehaviour
    {
        [SerializeField] private ShopInBattle shopInBattle;

        [SerializeField] private GameObject[] items;
        [SerializeField] private GameObject prefabDragItem;
        [SerializeField] private Transform canvas;

        public void LoadHeroBag()
        {
            Debug.Log(GameBag._gameSlotsItem.Length);
            for (int i = 0; i < items.Length; i++)
            {
                    Debug.Log("123");
                    GameObject clone = Instantiate(prefabDragItem, items[i].transform.position, Quaternion.identity, canvas);
                    clone.GetComponent<Item>().DisablePhysics();
                    clone.GetComponent<Item>().GetInfoItem(GameBag._gameSlotsItem[i].ItemName);
                
            }
        }
        void Start()
        {
            Time.timeScale = 1;
            //инициализация основных параметров (инфа о предметах и стоимости)
            ShopController.instance.Initialize();
            ItemController.instance.Initialize();
            //выбор предметов в магазин для выбора
            shopInBattle.ChoiceLowestRarityItems(3);

            HUD.instance.ShowInfo(ShopController.instance.GetCoin());
            //LoadHeroBag();
        }
    }
}
