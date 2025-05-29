using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public enum Rarity
    {
        Common,
        Uncommon,
        Rare
    }

    [System.Serializable]
    public class GameItem
    {
        public Rarity rarity;
        public string ItemName;
        public string KeyItem;
        public float Attack; // Атака
        public float Health; // Здоровье
        public float Speed; // Скорость
        public float Power; // Сила предмета за уровень
        public float Level; // Уровень
        public List<string> evolutionRecipes; // Рецепты эволюции

        public GameItem(Rarity rarity, string itemName, string keyItem, float attack, float health, float speed, float power, List<string> evolutionRecipes)
        {
            this.rarity = rarity;
            this.ItemName = itemName;
            this.KeyItem = keyItem;
            this.Attack = attack;
            this.Health = health;
            this.Speed = speed;
            this.Power = power;
            this.Level = 1;
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
            new GameItem(Rarity.Common, "Меч разрушения", "SwordDestruction", 15, 0, 1.2f, 2, new List<string> { "Меч разрушения + Лук снайпера = Двойной клинок", "Топор войны + Меч разрушения = Убийственный топор" }),
            new GameItem(Rarity.Common, "Пояс снайпера", "SniperBelt", 10, 5,  1.5f, 1, new List<string>()),
            new GameItem(Rarity.Common, "Топор войны", "WarAxe", 20, 2, 0.9f, 2, new List<string>()),
            new GameItem(Rarity.Common, "Шлем стража", "GuardianHelmet", 2, 10, 1.1f, 2, new List<string>()),
            new GameItem(Rarity.Common, "Ожерелье мудрости", "NecklaceWisdom", 3, 15, 0.4f, 2, new List<string>()),
            new GameItem(Rarity.Common, "Броня титана", "TitanArmor", 0, 20, 0.8f, 2, new List<string>()),
            new GameItem(Rarity.Common, "Простое зелье", "SimplePotion", 0, 0, 0, 1, new List<string>()),
            new GameItem(Rarity.Uncommon, "Двойной клинок", "DoubleBlade", 32, 0, 1.1f, 6, new List<string> { "Двойной клинок + Убийственный топор = Клинок разрушения", "Убийственный топор + Меч разрушения = Топор разрушения" }),
            new GameItem(Rarity.Uncommon, "Посох духа", "SpiritStaff", 40, 0, 0.9f, 5, new List<string>()),
            new GameItem(Rarity.Uncommon, "Пояс непобедимого", "BeltInvincible", 10, 30, 0.7f, 6, new List<string>()),
            new GameItem(Rarity.Uncommon, "Шлем теней", "HelmetShadows", 2, 40, 0.8f, 6, new List<string>()),
            new GameItem(Rarity.Uncommon, "Броня теней", "ShadowArmor", 0, 60, 0.7f, 5, new List<string>()),
            new GameItem(Rarity.Uncommon, "Убийственный топор", "KillerAxe", 30, 0, 0.8f, 5, new List<string>()),
            new GameItem(Rarity.Rare, "Клинок разрушения", "BladeDestruction", 40, 0, 1.0f, 15, new List<string>()),
            new GameItem(Rarity.Rare, "Топор разрушения", "AxeDestruction", 45, 0, 0.7f, 15,  new List<string>()),
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
                    // Создаем новый экземпляр GameItem на основе найденного
                    return new GameItem(item.rarity, item.ItemName, item.KeyItem, item.Attack, item.Health, item.Speed, item.Power, new List<string>(item.evolutionRecipes));
                }
            }
            //если элемент не найден, возвращаем null
            return null;
        }
    }


}

