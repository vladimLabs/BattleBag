using Items;
using Shop;
using UnityEngine;

namespace GameProcess {
    public class Game : MonoBehaviour
    {
        [SerializeField] private ShopInBattle shopInBattle;
        void Start()
        {
            //инициализация основных параметров (инфа о предметах и стоимости)
            ShopController.instance.Initialize();
            ItemController.instance.Initialize();
            //выбор предметов в магазин для выбора
            shopInBattle.ChoiceLowestRarityItems(3);

            HUD.instance.ShowInfo(ShopController.instance.GetCoin());
        }
    }
}
