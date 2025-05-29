using UnityEngine;

namespace Shop
{
    public class ShopController : DatabaseShop
    {
        [SerializeField] private GameObject buttonAddItems;
        [SerializeField] private ShopInBattle shopInBattle;
        public static ShopController instance;
        //private float coin = 100;
        private float costAddItem = 2;
        private int countItem = 3;
        private int nowItem;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            nowItem = countItem;
            buttonAddItems.SetActive(false);
        }
        public float GetCoin()
        {
            return PlayerPrefs.GetFloat("coin");
        }
        public bool CheckCanBuy(float cost)
        {
            return PlayerPrefs.GetFloat("coin") >= cost;
        }

        public void BuyForCoin(float cost, bool isBuyItem)
        {
            PlayerPrefs.SetFloat("coin", PlayerPrefs.GetFloat("coin") - cost);
            //coin -= cost;
            HUD.instance.ShowInfo(ShopController.instance.GetCoin());
            if (isBuyItem)
            {
                DelBuyItem();
            }
        }

        private void DelBuyItem()
        {
            nowItem--;
            if (nowItem == 0)
            {
                buttonAddItems.SetActive(true);
                nowItem = countItem;
            }
        }

        public void AddItem()
        {
            if (CheckCanBuy(costAddItem))
            {
                shopInBattle.ChoiceLowestRarityItems(countItem);
                buttonAddItems.SetActive(false);
                BuyForCoin(costAddItem, false);
            }
        }
    }
}