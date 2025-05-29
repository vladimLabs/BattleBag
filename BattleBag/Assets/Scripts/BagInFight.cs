using Items;
using UnityEngine;

public class BagInFight : MonoBehaviour
{
    [SerializeField] private FightItem[] fightItems;
    [SerializeField] private EnemyBag enemyBag;

    public void LoadHeroBag()
    {
        for (int i = 0; i < fightItems.Length; i++)
        {
            fightItems[i].GetInfo(GameBag._gameSlotsItem[i], "person");
        }
    }

    public void CalcPowerHero()
    {
        float power = 0;
        int countCommon = 0;
        int countUncommon = 0;
        int countRare = 0;
        foreach (var item in GameBag._gameSlotsItem)
        {
            if (item != null)
            {
                power += item.Power * item.Level;
                switch (item.rarity)
                {
                    case Rarity.Common:
                        countCommon++;
                        break;
                    case Rarity.Uncommon:
                        countUncommon++;
                        break;
                    case Rarity.Rare:
                        countRare++;
                        break;

                }
            }
        }
        enemyBag.GenerateEnemyInFight(power, countCommon, countUncommon, countRare);
    }
    public Hero GetHero()
    {
        return new Hero("person", CalcAttackBonus(), CalcHealthBonus(), CalcPower());
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
