using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Items;

namespace Shop
{
    public class SlotShop : MonoBehaviour
    {
        private GameItem _gameItem;
        private Image img;
        [SerializeField] private TextMeshProUGUI costItem;
        private float _cost;

        private void Awake()
        {
            img = GetComponent<Image>();
        }

        public void GetInfo(GameItem gameItem, float cost)
        {
            _gameItem = gameItem;
            _cost = cost;
            img.sprite = Resources.Load<Sprite>(_gameItem.KeyItem+gameItem.Level.ToString());
            costItem.text = _cost.ToString();
        }

        public void BuyItem()
        {
            if (ShopController.instance.CheckCanBuy(_cost))
            {
                ShopController.instance.BuyForCoin(_cost, true);
                ItemController.instance.SummonItem(_gameItem.KeyItem);
                gameObject.SetActive(false);
            }
        }
    }
}