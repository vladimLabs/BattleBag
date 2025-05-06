using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare,
        Epic
    }

    [System.Serializable]
    public class GameItem
    {
        public Rarity rarity;
        public string itemName;
        public string KeyItem;
        public Dictionary<string, float> attributes; //��������������
        public List<string> evolutionRecipes; //������� ��������

        public GameItem(Rarity rarity, string itemName, string keyItem, Dictionary<string, float> attributes, List<string> evolutionRecipes)
        {
            this.rarity = rarity;
            this.itemName = itemName;
            this.KeyItem = keyItem;
            this.attributes = attributes;
            this.evolutionRecipes = evolutionRecipes;
        }

        public void Evolve(GameItem itemToCombine)
        {
            //������ �������� ��������

        }
    }

    public class DatabaseItem : MonoBehaviour
    {
        private List<GameItem> gameItems;

        public void Initialize()
        {
            gameItems = new List<GameItem>
            {
                new GameItem(Rarity.Common, "��� ����������", "SwordDestruction", new Dictionary<string, float> { { "����", 15 }, { "��������", 1.2f } }, new List<string> { "��� ���������� + ��� �������� = ������� ������", "����� ����� + ��� ���������� = ������������ �����" }),
                new GameItem(Rarity.Common, "���� ��������", "SniperBelt", new Dictionary<string, float> { { "����", 10 }, { "��������", 1.5f } }, new List<string>()),
                new GameItem(Rarity.Common, "����� �����", "WarAxe", new Dictionary<string, float> { { "����", 20 }, { "��������", 0.9f } }, new List<string>()),
                new GameItem(Rarity.Uncommon, "������� ������", "DoubleBlade", new Dictionary<string, float> { { "����", 25 }, { "��������", 1.1f } }, new List<string> { "������� ������ + ������������ ����� = ������ ����������", "������������ ����� + ��� ���������� = ����� ����������" }),
                new GameItem(Rarity.Uncommon, "������������ �����", "KillerAxe", new Dictionary<string, float> { { "����", 30 }, { "��������", 0.8f } }, new List<string>()),
                new GameItem(Rarity.Rare, "������ ����������", "BladeDestruction", new Dictionary<string, float> { { "����", 40 }, { "��������", 1.0f } }, new List<string>()),
                new GameItem(Rarity.Rare, "����� ����������", "AxeDestruction", new Dictionary<string, float> { { "����", 45 }, { "��������", 0.7f } }, new List<string>()),
            };
        }

        public List<GameItem> GetListGameItem()
        {
            return gameItems;
        }

        public GameItem GetGameItem(string key)
        {
            foreach (var item in gameItems)
            {
                if (item.KeyItem == key)
                {
                    return item;
                }
            }
            //���� ������� �� ������, ���������� null
            return null; 
        }
    }
}

