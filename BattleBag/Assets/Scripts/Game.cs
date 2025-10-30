using Items;
using Shop;
using DragItem;
using UnityEngine;

namespace GameProcess {
    public class Game : MonoBehaviour
    {
        [SerializeField] private ShopInBattle shopInBattle;

        //[SerializeField] private GameObject[] items; //Слоты рюкзака

        void Start()
        {
            Time.timeScale = 1; //снимаем игру с паузы потому что в конце боя она была поставлена на паузу

            //инициализация основных параметров (инфа о предметах и стоимости)
            ShopController.instance.Initialize();
            ItemController.instance.Initialize();
            //выбор предметов в магазин для выбора
            shopInBattle.ChoiceLowestRarityItems(3);

            HUD.instance.ShowInfo(ShopController.instance.GetCoin());
            ItemController.instance.LoadHeroBag();
        }
        
    }
}
