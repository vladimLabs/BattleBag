using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shop
{
    public class ShopController : DatabaseShop
    {
        public static ShopController instance;
        private float coin = 500;

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
        }
        public float GetCoin()
        {
            return coin;
        }
        public bool CheckCanBuy(float cost)
        {
            return coin >= cost;
        }

        public void BuyForCoin(float cost)
        {
            coin -= cost;
            HUD.instance.ShowInfo(ShopController.instance.GetCoin());
        }
    }
}