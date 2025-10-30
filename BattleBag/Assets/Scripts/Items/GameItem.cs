using System.Collections;
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
}