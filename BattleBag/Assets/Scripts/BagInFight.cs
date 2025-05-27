using UnityEngine;

public class BagInFight : MonoBehaviour
{
    [SerializeField] private FightItem[] fightItems;
    void Start()
    {
        for (int i = 0; i < fightItems.Length; i++)
        {
            fightItems[i].GetInfo(GameBag._gameSlotsItem[i]);
        }
    }
}
