using Items;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBag : MonoBehaviour
{
    List<GameItem> allItems;
    [SerializeField] private FightItem[] fightItems;
    private GameItem[] _enemySlotsItem = new GameItem[9];
    private int CommonIndex = 2;  //Количество силы за уровень предмета обычной редкости

    public void GenerateEnemyInFight(float power, int countCommon, int countUncommon, int countRare)
    {
        allItems = ItemController.instance.GetListGameItem();

        //Индексы слотов, куда поместим предметы врага
        List<int> ints = new List<int>();
        ints = GenerateItems(ints, countCommon + countUncommon + countRare);
        //Debug.Log(ints.Count);

        //Выбираем какие будут предметы определенной редкости (по количеству видов редкости)
        List<GameItem> commonItems = AddItemsLevel(countCommon, GetLevelsItem(countCommon, CommonIndex), Rarity.Common);
        for(int i = 0; i < countCommon; i++)
        {
            _enemySlotsItem[ints[i]] = commonItems[i];
        }
        ints.RemoveRange(0, countCommon);

        LoadEnemyBag();
    }

    private List<int> GenerateItems(List<int> ints, int countItem)
    {
        for (int i = 0; i < countItem; i++)
        {
            int rand = Random.Range(0, _enemySlotsItem.Length);
            while (ints.Contains(rand))
            {
                rand = Random.Range(0, _enemySlotsItem.Length);
            }
            ints.Add(rand);
        }
        return ints;
    }

    private int GetLevelsItem(int count, int index)
    {
        //Подсчет количества уровней для предметов определенной редкости
        return (count * index) - Random.Range(-1, 2) - count;
    }

    private List<GameItem> AddItemsLevel(int countItems, int countLevels, Rarity rarityItem)
    {
        List<GameItem> items = new List<GameItem>();

        //Получаем предметы по редкости Common
        List<GameItem> rarityItems = allItems.Where(item => item.rarity == rarityItem).ToList();
        GameItem gameItem;
        for(int i = 0; i < countItems; i++)
        {
            gameItem = rarityItems[Random.Range(0, rarityItems.Count)];
            while (items.Contains(gameItem))
            {
                gameItem = rarityItems[Random.Range(0, rarityItems.Count)];
            }
            items.Add(gameItem);
        }
        for(int i = 0; i < countLevels; i++)
        {
            items[Random.Range(0, items.Count)].Level++;
        }
        return items;
    }

    public void LoadEnemyBag()
    {
        for (int i = 0; i < fightItems.Length; i++)
        {
            fightItems[i].GetInfo(_enemySlotsItem[i], "enemy");
        }
    }

    public Hero GetHero()
    {
        return new Hero("enemy", CalcAttackBonus(),CalcHealthBonus(), CalcPower());
    }

    private float CalcHealthBonus()
    {
        float healthBonus = 0;
        foreach (var item in fightItems)
        {
            if (item.GetNotNullGameItem())
            {
                healthBonus += item.GetHealthBonus();
            }
        }
        return healthBonus;
    }
    private float CalcAttackBonus()
    {
        float attackBonus = 0;
        foreach (var item in fightItems)
        {
            if (item.GetNotNullGameItem())
            {
                attackBonus += item.GetAttackBonus();
            }
        }
        return attackBonus;
    }
    private float CalcPower()
    {
        float power = 0;
        foreach (var item in fightItems)
        {
            if (item.GetNotNullGameItem())
            {
                power += item.GetPowerItem();
            }
        }
        return power;
    }
}
