using UnityEngine;

namespace DragItem
{
    public class BagFight : MonoBehaviour
    {
        public Slot[] slots; // ������ ������ �������

        // ����� ��� ��������, ����� �� ����
        public bool IsSlotOccupied(int index)
        {
            return slots[index].IsOccupied();
        }

        // ����� ��� ��������� ����� ��� ��������
        public void SetSlotOccupied(int index, bool occupied)
        {
            slots[index].SetOccupied(occupied);
        }
    }
}