using Items;
using Shop;
using UnityEngine;

namespace GameProcess {
    public class Game : MonoBehaviour
    {
        [SerializeField] private ShopInBattle shopInBattle;
        void Start()
        {
            //������������� �������� ���������� (���� � ��������� � ���������)
            ShopController.instance.Initialize();
            ItemController.instance.Initialize();
            //����� ��������� � ������� ��� ������
            shopInBattle.ChoiceLowestRarityItems(3);

            HUD.instance.ShowInfo(ShopController.instance.GetCoin());
        }
    }
}
