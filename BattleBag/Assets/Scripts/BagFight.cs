using UnityEngine;

namespace DragItem
{
    public class BagFight : MonoBehaviour
    {
        public Slot[] slots; // Массив слотов рюкзака

        // Метод для проверки, занят ли слот
        public bool IsSlotOccupied(int index)
        {
            return slots[index].IsOccupied();
        }

        // Метод для установки слота как занятого
        public void SetSlotOccupied(int index, bool occupied)
        {
            slots[index].SetOccupied(occupied);
        }
    }
}