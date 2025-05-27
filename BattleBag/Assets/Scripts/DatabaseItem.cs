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
        public float attack; // Атака
        public float speed; // Скорость
        public List<string> evolutionRecipes; // Рецепты эволюции

        public GameItem(Rarity rarity, string itemName, string keyItem, float attack, float speed, List<string> evolutionRecipes)
        {
            this.rarity = rarity;
            this.itemName = itemName;
            this.KeyItem = keyItem;
            this.attack = attack;
            this.speed = speed;
            this.evolutionRecipes = evolutionRecipes;
        }

        public void Evolve(GameItem itemToCombine)
        {
            // Логика эволюции предмета
        }
    }

    public class DatabaseItem : MonoBehaviour
    {
        private List<GameItem> gameItems;

        public void Initialize()
        {
            gameItems = new List<GameItem>
        {
            new GameItem(Rarity.Common, "Меч разрушения", "SwordDestruction", 15, 1.2f, new List<string> { "Меч разрушения + Лук снайпера = Двойной клинок", "Топор войны + Меч разрушения = Убийственный топор" }),
            new GameItem(Rarity.Common, "Пояс снайпера", "SniperBelt", 10, 1.5f, new List<string>()),
            new GameItem(Rarity.Common, "Топор войны", "WarAxe", 20, 0.9f, new List<string>()),
            new GameItem(Rarity.Uncommon, "Двойной клинок", "DoubleBlade", 25, 1.1f, new List<string> { "Двойной клинок + Убийственный топор = Клинок разрушения", "Убийственный топор + Меч разрушения = Топор разрушения" }),
            new GameItem(Rarity.Uncommon, "Убийственный топор", "KillerAxe", 30, 0.8f, new List<string>()),
            new GameItem(Rarity.Rare, "Клинок разрушения", "BladeDestruction", 40, 1.0f, new List<string>()),
            new GameItem(Rarity.Rare, "Топор разрушения", "AxeDestruction", 45, 0.7f, new List<string>()),
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
            //если элемент не найден, возвращаем null
            return null; 
        }
    }
}

